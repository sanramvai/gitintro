using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace FinalSportStore.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session,string key,object value)
        {
            session.SetString(key,JsonConvert.SerializeObject(value));
            //session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T GetJson<T>(this ISession session,string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default: JsonConvert.DeserializeObject<T>(sessionData);
            //return sessionData == null? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
