namespace CustomersSite.Controller
{
    public interface IGen<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
    }
}
