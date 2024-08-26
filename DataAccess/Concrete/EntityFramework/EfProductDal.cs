using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // IDisposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext ())
            {
                // bu yapı using bittiğinde bellekten atılır direk siler demek
                var addedEntity =context .Entry (entity); // referansı yakala
                addedEntity .State = EntityState.Added;// eklenecek nesne
                context .SaveChanges (); // şimdi ekle

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                // bu yapı using bittiğinde bellekten atılır direk siler demek
                var deletedEntity = context.Entry(entity); // referansı yakala
                deletedEntity.State = EntityState.Deleted ;// silinecek nesne
                context.SaveChanges(); // şimdi ekle

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext ())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext ())
            {
                return filter == null ? context.Set<Product>().ToList(): context .Set<Product>().Where (filter ).ToList();
                    // select* product anlamına gelir bir nevi-- filtre vermişse filtreler yoksa bütün ürünleri getirir
            } // filtre null ise iki noktaya kadar olanı çalıştırır değilse devamını çalıştırır çalışan kısmı listeler
        }    // tolist : listeye çevir

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                // bu yapı using bittiğinde bellekten atılır direk siler demek
                var updatedEntity = context.Entry(entity); // referansı yakala
                updatedEntity.State = EntityState.Modified ;// eklenecek nesne
                context.SaveChanges(); // şimdi ekle

            }
        }
    }
}
