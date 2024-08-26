using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal  // bellek üzerinde ürünle iligili veri erişim kodlarının yazılacağı yer
    {
        List<Product> _products;// alttan tre söz dizimidir classın içinde ama metotların dışında
        public InMemoryProductDal()
        {
            // bu yapı sanki bize veri tabanından oracleden sql den geliyormul gibi arka planda simüle ettiğimşz için çalılır
            _products = new List<Product> {
              new Product {ProductId = 1, CategoryId = 1, ProductName = "bardak", UnitInStock = 15, UnitPrice = 15},
              new Product {ProductId = 2, CategoryId = 1, ProductName = "kamera", UnitInStock = 500, UnitPrice = 1},
              new Product {ProductId = 3, CategoryId = 5, ProductName = "telefon", UnitInStock = 15150, UnitPrice = 5},
              new Product {ProductId = 4, CategoryId = 5, ProductName = "klavye", UnitInStock = 150, UnitPrice = 3},
              new Product {ProductId = 5, CategoryId = 3, ProductName = "fare", UnitInStock = 156, UnitPrice = 56}
            };
        }
        public void Add(Product product)
        {
            _products .Add (product);
        }

        public void Delete(Product product)  // delete metodu içindeki bu yapı LINQ yapısı olmasaydı yapılabilirdi çünkü remove metodu buradaki verileri direk silemez referans numrası lazım bize
                                             // aynı isimde farklı veriler olabilir burada referans numarası çok önemli LINQ yapısını kullanacağımız için bu yapıyı commentliyoruz temel bir yapıdır
        {

            //foreach (var p in _products)
            //{
            //    if (product .ProductId == p.ProductId )
            //    {
            //        productToDelete = p;
            //    }
            //}
            // LINQ yapısı aşağıdaki gibi hata verirse ampulden linq ekle (remove kodu lınqe dahil değil)
            Product productToDelete = _products .SingleOrDefault(p=>p.ProductId ==product .ProductId  ); // => lambda denir bu işarete ve p=> kısmı ise foreachin yukarıdaki yaptığı döngüyle aynı anlama gelir tek tek ünğrnleri dolanır
           // her p için benim gönderdiğim pnin ıdsine eşitmi demek= singleordefault (firstordefault da olur first de olur ) singleordefault sadece bir kere döner bütün ürünleri  genellikle ıd ler için kullanırlır
            // 42. satır eşittir 33-40 dakine denktir LINQ yapısı bu yüzden kolaylık sağlar tek kodla ürünleri döndürür
            _products .Remove (productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
           return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
             return _products .Where(p=> p.CategoryId== categoryId ) .ToList (); // where koşulu içindeki şarta uyan bütün elemanları yeni liste haline getirir ve döndürür
        }

        public void Update(Product product) // güncelemede de yapı aynıdır 
        {
            // gönderdiğim ürün ıd'sine sahip listedeki ürün idisini bul demek
            Product productToUpdate =  _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate .ProductName = product.ProductName;
            productToUpdate .UnitPrice = product.UnitPrice; 
            productToUpdate .CategoryId = product.CategoryId;   
            productToUpdate .UnitInStock = product.UnitInStock;
        }

    }
}
