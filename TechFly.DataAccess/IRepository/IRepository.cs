namespace TechFly.DataAccess.IRepository;

public interface IRepository<TResult>
{
    public Task<TResult> InsertAsync(TResult value);
    public Task<TResult> UpdateAsync(long id, TResult value);
    public Task<TResult> DeleteAsync(long id);
    public Task<List<TResult>> SelectAllAsync(Func<TResult,bool> predicate = null);
    public Task<TResult> SelectAsync(long Id);

}
