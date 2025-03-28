
namespace ProductsBLL
{
    public interface IProductsService
    {
        void Add(ProductDTO product);
        IEnumerable<ProductDTO> Get();
        ProductDTO Get(int id);
    }
}