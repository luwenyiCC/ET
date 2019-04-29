namespace ETModel
{
	[Config((int)(AppType.ClientH |  AppType.ClientM | AppType.Gate | AppType.Map))]
	public partial class OutSpaceConfigCategory : ACategory<OutSpaceConfig>
	{
	}

	public class OutSpaceConfig: IConfig
	{
		public long Id { get; set; }
		public string Name;
		public string Desc;
		public int Hp;
		public int ATK;
		public int DEF;
		public int Money;
	}
}
