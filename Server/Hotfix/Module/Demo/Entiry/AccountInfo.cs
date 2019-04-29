using ETModel;
using MongoDB.Bson.Serialization.Attributes;
namespace ETHotfix
{
    [BsonIgnoreExtraElements]
    public class AccountInfo : Entity
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
}