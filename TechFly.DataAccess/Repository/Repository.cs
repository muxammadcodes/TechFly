using Newtonsoft.Json;
using TachFly.Domain.Commons;
using TachFly.Domain.Entities;
using TachFly.Domain.Entities.Orders;
using TachFly.Domain.Entities.Products;
using TechFly.DataAccess.Configurations;
using TechFly.DataAccess.IRepository;

namespace TechFly.DataAccess.Repository;

public class Repository<TResult> : IRepository<TResult> where TResult : Auditable
{
    private string path;
    private long lastId;

    public Repository()
    {
        if (typeof(TResult) == typeof(Admin))
        {
            path = DbPath.Admin;
        }
        else if (typeof(TResult) == typeof(Product))
        {
            path = DbPath.Products;
        }
        else if (typeof(TResult) == typeof(Order))
        {
            path = DbPath.Order;
        }
        else if (typeof(TResult) == typeof(OrderComment))
        {
            path = DbPath.OrderComments;
        }
        else if (typeof(TResult) == typeof(OrderDetails))
        {
            path = DbPath.OrderDetails;
        }
        else if(typeof(TResult) == typeof(ProductCategory))
        {
            path = DbPath.ProductCatigories;
        }
        else if (typeof(TResult) == typeof(Client))
        {
            path = DbPath.Clients;
        }
    }


    public async Task<TResult> InsertAsync(TResult value)
    {
        var values = await SelectAllAsync();
        if (values.Count == 0)
        {
            lastId = 1;
        }
        else
        {
            lastId = values[values.Count - 1].Id;
        }
        value.Id = ++lastId;
        value.CreatedAt = DateTime.UtcNow;
        values.Add(value);
        var json = JsonConvert.SerializeObject(values,Formatting.Indented);
        await File.WriteAllTextAsync(path, json);

        return value;
    }
    public async Task<TResult> DeleteAsync(long id)
    {
        var contents = await SelectAllAsync();
        var unpublish = contents.FirstOrDefault(p => p.Id == id);
        if (unpublish is not null)
        {
            contents.Remove(unpublish);
            var json = JsonConvert.SerializeObject(contents, Formatting.Indented);
            await File.WriteAllTextAsync(path,json);
        }
        return unpublish;
    }

    public async Task<List<TResult>> SelectAllAsync(Func<TResult, bool> predicate = null)
    {
        string content = await File.ReadAllTextAsync(path);
        if (string.IsNullOrEmpty(content))
        {
            content = "[]";
        }
        List<TResult> contents = JsonConvert.DeserializeObject<List<TResult>>(content);
        return contents;
    }

    public async Task<TResult> SelectAsync(long Id)
    {
        var values = await SelectAllAsync();
        return values.FirstOrDefault((v) => v.Id == Id);
    }

    public async Task<TResult> UpdateAsync(long id, TResult value)
    {
        var models = await SelectAllAsync();
        var modernize = models.FirstOrDefault(m => m.Id == id);
        if (modernize is not null)
        {
            var index = models.IndexOf(modernize);
            models.RemoveAt(index);

            value.Id = modernize.Id;
            value.CreatedAt = modernize.CreatedAt;
            value.UpdatedAt = DateTime.UtcNow;

            models.Insert(index, value);
            var json = JsonConvert.SerializeObject(models, Formatting.Indented);
            await File.WriteAllTextAsync(path, json);
            return modernize;
        }
        return modernize;
    }
}
