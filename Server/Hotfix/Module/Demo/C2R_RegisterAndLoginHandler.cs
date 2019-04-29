using System;
using System.Collections.Generic;
using System.Net;
using ETModel;
 
namespace ETHotfix
{
    [MessageHandler(AppType.Realm)]
    public class C2R_RegisterAndLoginHandler : AMRpcHandler<C2R_RegisterAndLogin, R2C_RegisterAndLogin>
    {
        protected override void Run(Session session, C2R_RegisterAndLogin message, Action<R2C_RegisterAndLogin> reply)
        {
            RunAsync(session, message, reply).Coroutine();
        }
 
        private async ETVoid RunAsync(Session session, C2R_RegisterAndLogin message, Action<R2C_RegisterAndLogin> reply)
        {
            Console.WriteLine(" --> C2R_RegisterAndLoginHandler");
 
            R2C_RegisterAndLogin response = new R2C_RegisterAndLogin();
            try
            {
                Console.WriteLine("account : "+ message.Account+" password : "+ message.Password);
 
                //数据库操作对象
                {
                    DBProxyComponent dbProxy = Game.Scene.GetComponent<DBProxyComponent>();
                    Console.WriteLine("dbProxy : " + dbProxy);
 
                    //查询账号是否存在  使用LINQ和Lambda表达式根据特定条件来查询
                    List<ComponentWithId> result = await dbProxy.Query<AccountInfo>(_account => _account.Account == message.Account);
                    Console.WriteLine("result : " + result);
 
                    if (result.Count > 0)
                    {
                        Console.WriteLine("result.Count : " + result.Count);
 
                        response.Error = ErrorCode.ERR_AccountAlreadyRegister;
                        reply(response);
                        return;
                    }
                    Console.WriteLine("新建账号 : ");
 
                    //新建账号
                    AccountInfo newAccount = ComponentFactory.CreateWithId<AccountInfo>(IdGenerater.GenerateId());
                    newAccount.Account = message.Account;
                    newAccount.Password = message.Password;
 
                    Log.Info($"注册新账号：{MongoHelper.ToJson(newAccount)}");
 
                    //新建用户信息
                    UserInfo newUser = ComponentFactory.CreateWithId<UserInfo>(newAccount.Id);
                    newUser.Nickname = $"用户{message.Account}";
                    newUser.Gold = 10000;
 
                    //保存到数据库
                    await dbProxy.Save(newAccount);
                    await dbProxy.Save(newUser);
                    //释放数据库连接
                    dbProxy.Dispose();
                }
 
                // 随机分配一个Gate
                StartConfig config = Game.Scene.GetComponent<RealmGateAddressComponent>().GetAddress();
                //Log.Debug($"gate address: {MongoHelper.ToJson(config)}");
                IPEndPoint innerAddress = config.GetComponent<InnerConfig>().IPEndPoint;
                Session gateSession = Game.Scene.GetComponent<NetInnerComponent>().Get(innerAddress);
 
                // 向gate请求一个key,客户端可以拿着这个key连接gate
                G2R_GetLoginKey g2RGetLoginKey = (G2R_GetLoginKey)await gateSession.Call(new R2G_GetLoginKey() {Account = message.Account});
 
                string outerAddress = config.GetComponent<OuterConfig>().Address2;
 
                response.Address = outerAddress;
                response.Key = g2RGetLoginKey.Key;
                reply(response);
            }
            catch (Exception e)
            {
                ReplyError(response, e, reply);
            }
        }
    }
}