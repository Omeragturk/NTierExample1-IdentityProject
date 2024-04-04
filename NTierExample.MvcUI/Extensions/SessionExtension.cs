using System.Text.Json;

namespace NTierExample.MvcUI.Extensions
{
    public static class SessionExtension
    {
        public static void JsonParse<TModel>(this ISession session, string key, TModel model)
        {
            string jsonData = JsonSerializer.Serialize(model);
            session.SetString(key, jsonData);
        }

        public static TModel ModelParse<TModel>(this ISession session, string key)
        {
            string jsonModel = session.GetString(key);
            TModel model = JsonSerializer.Deserialize<TModel>(jsonModel);
            return model;
        }
    }
}
