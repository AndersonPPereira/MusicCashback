using MusicCashback.Domain.Interfaces.Json;
using Newtonsoft.Json;
using System;

namespace MusicCashback.Infra.Json.Services
{
    public class JsonService : IJsonService
    {
        public T DeserializeObject<T>(string stringJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(stringJson);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
