using HR_Management.MVC.Contracts;
using Hanssens.Net;

namespace HR_Management.MVC.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        LocalStorage _localStorage;
        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "HR.Management"
            };
            _localStorage = new LocalStorage(config);
        }
        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                _localStorage.Remove(key);
            }
        }

        public bool Exists(string key)
        {
            return _localStorage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return _localStorage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, string value)
        {
            _localStorage.Store(key, value);
            _localStorage.Persist();
        }
    }
}
