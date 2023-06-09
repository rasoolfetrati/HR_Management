namespace HR_Management.MVC.Contracts
{
    public interface ILocalStorageService
    {
        void ClearStorage(List<string> keys);
        void SetStorageValue<T>(string key, string value);
        bool Exists(string key);
        T GetStorageValue<T>(string key);
    }
}
