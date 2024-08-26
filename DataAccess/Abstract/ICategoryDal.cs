using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public  interface ICategoryDal: IEntityRepository <Category >
    {
        //List<Category> GetAll(); // product ilk yazıldığında hata verdi dataaccess sağ tık add >> project referance >> çıkan sekmeden entities i seç sadece verilerini oradan alacağı için sadece o seçilir daha sonra ampulden using çıkacak zaten
        //void Add(Category category);
        //void Update(Category category);
        //void Delete(Category category );
        //List<Product> GetAllByCategory(int categoryId);


    }
}
