namespace MusicCashback.Domain.Interfaces.Json
{
    public interface IJsonService
    {
        T DeserializeObject<T>(string stringJson);
        string SerializeObject(object obj);
    }
}
