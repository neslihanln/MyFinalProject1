using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{    // ÇOK ÖNEMLİ***
    // NE ANLAMA GELİR NASIL İHİTYAÇTAN DOĞMUŞTUR
    // IENTITYREPOSİTORY-- IPRODUCTDAL VE ICATEGORYDALIN İHTİYACINDAN DOĞMUŞTUR YANİ İÇLERİNDEKİ İŞ KODLARI NEREDEYSE TAMAMEN AYNI
    // AMA SADECE PARAMETRELER BULUNDUĞU DALA GÖRE DEĞİŞİYOR O ZAMAN NEDEN GENERİCLERLE TEK BİR ALT YAPIDA TOPLAMAYALIM BUNLARI
    // CATEGORY VE PRODUCT KISIMLARINI İSE T DEĞİŞKENİYLE HANGİSİNİ VERİRSEK O KULLANILACAK 
   public  interface IEntityRepository<T>  where T:class ,IEntity  // **T** bana hangi nesneyi verirse ona göre çalışır 
    {
        List<T> GetAll(Expression <Func <T, bool>> filter = null);  
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}
