﻿// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;

Console.WriteLine("Hello, World!");

// VİSUAL STUDIO' A  GİRİYORUZ  NEW CREATE PROJECT DİYORUZ BLANK SOLUTIONU SEÇİYORUZ SAĞ TARAFTAN 
// MYFİNALPROJECT İ OLUŞTURUYORUZ SIRASIYLA BUSINESS DATAACCESS VE ENTİTİES KATMANLARINI NEW PROJECT >> CLASS LİBRARY SEÇİYORUZ VE ÜÇÜNÜDE YENİ PROJE OLARAK OLUŞTURUYORUZ
//BU ÜÇ KATMANIN ORTAK KATMANI OLARAK CONSOLEUI I OLUŞTURUYORUZ (TEST ORTAMI- YARDIMCI KATMAN NESNELERİ BURAYA ALIRIZ) CONCOLE APPDEN OLUŞTURURUZ
// ARDINDAN BU ÜÇ KATMANA ADD>> NEW FOLDER ADIMLARIYLA YENİ KLASÖR EKLERİZ VE İSİMLERİ ABSTRACT VE CONCRETEDİR.
// ABSTRACT-- SOYUT NESNELERİ, İNTERFACELERİ, ABSTRACT NESNELERİ VE BASE CLASSLARI BU KLASÖRÜN İÇİNE KOYARIZ , REFERANS TUTUCULARI KOYARIZ
// CONCRETE-- SOMUT , GERÇEK İŞİ YAPAN CLASSLAR BURAYA YAZILIR
//ENTİTİES KATMANINDA GEREKLİ NESNELERİ EKLERİZ İNTERFACE VE CLASSLAR GİBİ İNTERFACE İLE CLASSLARI İMPLEMENTE EDERİZ --PRODUCT:IENTİTY, CATEGORY:IENTİTY
// DATAACCESS KATMANINDA ABSTARCT KLASÖRÜNE IPRODUCTDAL İNTERFACESİ OLUŞTURURUZ** HER ENSNENİN İNTERFACESİ KESİNLİKLE OLMALIDIR YANİ BENİM PRODUCLA İLGİLİ OPERASYOM YAPACSĞIM İNTERFACEDİR
// HER OLUŞTURDUĞUMUZ İNTERFACE VE CLASSLARI DA PUBLİC YAPMAYI UNUTMA DİĞER KATMANLARIN ULAŞMASI İÇİN GEREKLİ
// IPRODUCTDALIN OPERASYONLSRINI YAZDIKTAN SONRA İLK OPERASYONDA HATA VERDİ ÇÖZĞMĞ BAHSEDİLEN SAYFADA 
// DATAACCESS << CONCRETE<< NEW FOLDER << INMEMORY EKLENDİ BU KLASÖRDE IPRODUCTDALIN SOMUTUNU YAPACAĞIZ 
// DATACCESS << CONCRETE<< ADD <<CLASS<< INMEMORYPRODUCTDAL EKLENDİ ıproductdal ile iplemente edildi
// simüle ettiğimiz için ınmemory yani bellekte verilerimşz var onlarla çalışcağız gibi
// bellekte çalışacağımız için inmemory olulturduk




// ICATEGORYDAL VE IPRODUCTDAL İNTERFACELEİN ŞABLONU AŞAĞI YUKARI AYNIDIR SADECE CATEGORY VE PRODUCT DİYE DEĞİŞİYOR 
// DAHA KULLANIŞLI OLMASI İÇİN BİZ BUNU ORTAK BİR İNTERFACE ŞABLONUNDA TOPLUYORUZ YANİ
// IENTITIYREPOSITORY İNTERFACESİ ADI ALTINDA ŞABLONU BİRİNDEN KOPYALIYORUZ ICATEGORDAL VE IPRODUCTDAL DAN KODLARINI SİLİYORUZ
// VE ICATEGORYDAL:I IENTITIYREPOSİTORY  VE IPRODUCTDAL :I IENTITIYREPOSİTORY İLE İPLEMENTE EDİYORUZ
// IENTITIY İÇİ ŞÖYLE OLACAK:
// List<T> GetAll(Expression <Func <T, bool>> filter = null);  
// T Get(Expression<Func<T, bool>> filter);
//void Add(T entity);
//void Update(T entity);
//void Delete(T entity);

// LİST İLE BAŞLAYAN İLK İKİ KOD İÇİN: FİLTER: NULL FİLTRE VERME TÜM ELEMANLARI GETİR DEMEKTİR
// İKİNCİ SATIR İSE : FİLTRELEME YAPIYOR (P.P=> P ...) BU YAPI İÇİN YAPTIK NAMEYE GÖRE ID YE GÖRE FİLTRELE SEÇENEKLERİ ARTIRILABİLİR

// DAHA SONRA CUSTOMER CLASSINI EKLEDİK VE IENTİTY İLE İPLEMENTE EDİLDİ(CUSTOMER ),
// VERİ ERİŞİM KATMANINDA İNTERFACESİ OLUŞTURULDU(ICUSTOMERDAL:IENTITIYREPOSİTORY),
// IENTITIYREPOSİTORY İLE İMPLEMENTE EDİLDİ YAPILANDIRILDI

// VERİ ERİŞİM KATMANINDA ENTİTY FRAMEWORK İÇİN : EFCATEGORYDAL VE EFPRODUCTDAL CLASSLARI OLUŞTURULDU VE IPRODUCTDAL VE ICATEGORYDAL İLE İMPLEMENTE EDİLDİ


// IENTİTYREPOSITORY DE <T> YAZAN KISMI SINIRLANDIRACAĞIZ ÇÜNKÜ ICATEGORYDAL A GİDİP T YERİNE İNT TE YAZSAK KABUL EDER T YERİNE YAZMAK İSTEDİĞİMİZ
// GELMESİ GEREKENLER CUSTOMER PRODUCT VE CATEGORY OLMALIDIR  YAPI AŞAĞIDAKİ GİBİ OLMALIDIR

// public  interface IEntityRepository<T>  where T:class ,IEntity, NEW ()

// YANİ BURADA HER CLASS DEĞİLDE IENTİTY İLE İNHERİTE- İMPLEMENTE EDİLEMİŞ NESNELER GELSİN SADECE DEMEK İSTİYORUZ
// BUNA GENERİC CONSTRAİNT DENİR
// CLASS : REFERANS TİP ***
// IENTITY: IIENTITY OLABİLİR VEYA IENTITY İLE İMPLEMENTE EDEN BİR NESNE OLABİLİR
// NEW(): NEW'LENEBİLİR OLMALI
// NEWLİ YAPI İSE SADECE NESNELERİ ALMAK İSTEDİĞİMİZDEN VE NEWSİZ HALİ İLE IENTITY YİDE GETİRİR IENTITY BİZİM İŞİMİZİ
// GÖRMÜYOR VE IENTITY BİR İNTERFACE OLDUĞUZ İÇİN VE NEW LENEMEDİĞİ İÇİN BU YAPIYI YAZARSAK IENTITY DE ALMAZ
                // NuGet
// dataaccess>> manage nuget packages>> browse entityframework.sql >> alttan seç üçüncü yandaki pencereden versiyon seç 3.1.11 gibi yükle kabul et
// bu şu anlama geliriyo artık dataaccessin içinde entityframework core kod yazbiliriz