
namespace ProductsDAL
{
    public interface IProductsRepository
    {
        void Add(ProductModel product);
        IEnumerable<ProductModel> Get();
        ProductModel Get(int id);
    }
}