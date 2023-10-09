namespace Project12.Repositories.Base.Models
{
    public interface IDataModel<TKey>
    {
        TKey Id { get; set; }
    }
}
