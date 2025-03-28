using SQLite;

namespace ProductsDAL
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ISQLiteConnection _sqLiteConnection;
        public ProductsRepository(ISQLiteConnection sqLiteConnection)
        {
            _sqLiteConnection = sqLiteConnection;
            _sqLiteConnection.CreateTable<ProductModel>();
        }

        public void Add(ProductModel product)
        {
            _sqLiteConnection.Insert(product);
        }

        public ProductModel Get(int id)
        {
            TableQuery<ProductModel> result =
                _sqLiteConnection.Table<ProductModel>().Where(q => q.Id.Equals(id));
            return result.FirstOrDefault();
        }

        public IEnumerable<ProductModel> Get()
        {
            return _sqLiteConnection.Table<ProductModel>();
        }
    }
}
