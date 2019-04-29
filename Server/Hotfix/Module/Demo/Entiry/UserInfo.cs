using ETModel;
using MongoDB.Bson.Serialization.Attributes;
namespace ETHotfix
{
    [BsonIgnoreExtraElements]
    public class UserInfo : Entity
    {
        public string Nickname { get; set; }
        public int Gold { get; set; }
    }
}