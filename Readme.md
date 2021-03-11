## 11.03.2021 Ödev 1
RentACar projeniz için:

Angular projesi oluşturunuz

Bootstrap entegrasyonu yapınız

Markaları listeleyiniz

Renkleri listeleyiniz

Müşterileri listeleyiniz

Arabaları listeleyiniz. (Arabaları listelerken BrandId yerine BrandName, ColorId yerine ColorName şeklinde gösteriniz)

Kiralamaları listeleyiniz (Rentals) CarId yerine BrandName, CustomerId yerine FirstName + LastName şeklinde gösteriniz.

Kodlarınızı githuba aktarıp paylaşınız.

## 03.03.2021 Ödev 1
RentACar projenize;

Cache, Transaction ve Performance aspectlerini ekleyiniz.

Github adresinizi paylaşınız.

[ReCapProject-Frontend ](https://github.com/enginyenice/ReCapProject-Frontend)


## 27.02.2021 Ödev

RentACar projenize JWT entegrasyonu yapınız.

GitHub adresinizi paylaşınız.

## 24.02.2021 Ödev 1
Artık araştırma yapıp, yeni işlemleri projeye ekleyebilmemiz gerekiyor.

RentACar projenizde;

CarImages (Araba Resimleri) tablosu oluşturunuz. (Id,CarId,ImagePath,Date) Bir arabanın birden fazla resmi olabilir.

Api üzerinden arabaya resim ekleyecek sistemi yazınız.

Resimler projeniz içerisinde bir klasörde tutulacaktır. Resimler yüklendiği isimle değil, kendi vereceğiniz GUID ile dosyalanacaktır.

Resim silme, güncelleme yetenekleri ekleyiniz.

Bir arabanın en fazla 5 resmi olabilir.

Resmin eklendiği tarih sistem tarafından atanacaktır.

Bir arabaya ait resimleri listeleme imkanı oluşturunuz. (Liste)

Eğer bir arabaya ait resim yoksa, default bir resim gösteriniz. Bu resim şirket logonuz olabilir. (Tek elemanlı liste)

Github linkinizi paylaşınız.

## 17.02.2021 3. Ödev

Car Rental Projenize AOP desteği ekleyiniz.

ValidationAspect ekleyiniz.

Yazdığınız kodların Github linkini paylaşınız.


## 17.02.2021 2. Ödev

Car Rental Projenize FluentValidation desteği ekleyiniz.

Yazdığınız kodların Github linkini paylaşınız.

## 17.02.2021 1. Ödev

Car Rental Projenize Autofac desteği ekleyiniz.

Yazdığınız kodların Github linkini paylaşınız.

## 13.02.2021

CarRental projenizde;

WebAPI katmanını kurunuz.

Business katmanındaki tüm servislerin Api karşılığını yazınız.

Postman'de test ediniz.

Kodlarınızı paylaşınız.


## 10.02.2021 - 4. Ödev

CarRental projenizde;

Kullanıcılar tablosu oluşturunuz. Users-->Id,FirstName,LastName,Email,Password

Müşteriler tablosu oluşturunuz. Customers-->UserId,CompanyName

Kullanıcılar ve müşteriler ilişkilidir.

Arabanın kiralanma bilgisini tutan tablo oluşturunuz. Rentals-->Id, CarId, CustomerId, RentDate(Kiralama Tarihi), ReturnDate(Teslim Tarihi). Araba teslim edilmemişse ReturnDate null'dır.

Projenizde bu entity'leri oluşturunuz.

CRUD operasyonlarını yazınız.

Yeni müşteriler ekleyiniz.

Arabayı kiralama imkanını kodlayınız. Rental-->Add

Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.

## 10.02.2021 - 1. Ödev

Car Rental Projenizde;

Core katmanında Results yapılandırması yapınız.

Daha önce geliştirdiğiniz tüm Business sınıflarını bu yapıya göre refactor (kodu iyileştirme) ediniz.

## 06.02.2021

Not : İsteyenler Northwind projesindeki Core katmanını da ekleyebilir ama pekiştirmek için yeniden yazmanızı öneririm. Bu şekilde yapmak isteyenler CarRental/Solution Explorer Sağ Tık / Add /Existing Project/ Northwind içindeki Core klasöründe Core.csproj dosyasını ekleyebilirler. Bu şekilde yapanlar aşağıdaki 3. adımdan devam edebilirler.

Önerim aşağıdaki gibi yeniden yapmanızdır.

CarRental Projenizde Core katmanı oluşturunuz.
IEntity, IDto, IEntityRepository, EfEntityRepositoryBase dosyalarınızı 9. gün dersindeki gibi oluşturup ekleyiniz.
Car, Brand, Color sınıflarınız için tüm CRUD operasyonlarını hazır hale getiriniz.
Console'da Tüm CRUD operasyonlarınızı Car, Brand, Model nesneleriniz için test ediniz. GetAll, GetById, Insert, Update, Delete.
Arabaları şu bilgiler olacak şekilde listeleyiniz. CarName, BrandName, ColorName, DailyPrice. (İpucu : IDto oluşturup 3 tabloya join yazınız)
Kodlarınızı Github hesabınızda paylaşıp link veriniz.
Başkalarının kodlarını inceleyiniz. Beğenirseniz yıldız veriniz.


## 03.02.2021
Araba Kiralama projemiz üzerinde çalışmaya devam edeceğiz.

Car nesnesine ek olarak;

1) Brand ve Color nesneleri ekleyiniz(Entity)

Brand-->Id,Name

Color-->Id,Name

2) Sql Server tarafında yeni bir veritabanı kurunuz. Cars,Brands,Colors tablolarını oluşturunuz. (Araştırma)

3) Sisteme Generic IEntityRepository altyapısı yazınız.

4) Car, Brand ve Color nesneleri için Entity Framework altyapısını yazınız.

5) GetCarsByBrandId , GetCarsByColorId servislerini yazınız.

6) Sisteme yeni araba eklendiğinde aşağıdaki kuralları çalıştırınız.

Araba ismi minimum 2 karakter olmalıdır

Araba günlük fiyatı 0'dan büyük olmalıdır.

Ödevinize ait github linkini paylaşınız.

## 30.01.2021
Kampımızla beraber paralelde geliştireceğimiz bir projemiz daha olacak. Araba kiralama sistemi yazıyoruz.

Yepyeni bir proje oluşturunuz. Adı ReCapProject olacak. (Tekrar ve geliştirme projesi)

Entities, DataAccess, Business ve Console katmanlarını oluşturunuz.

Bir araba nesnesi oluşturunuz. "Car"

Özellik olarak : Id, BrandId, ColorId, ModelYear, DailyPrice, Description alanlarını ekleyiniz. (Brand = Marka)

InMemory formatta GetById, GetAll, Add, Update, Delete oprasyonlarını yazınız.

Consolda test ediniz.

Önemli: Copy-Paste yasak fakat kamp projesinden destek almak serbest.

Kodlarınızı Github'a aktarıp paylaşınız. İncelediğiniz arkadaşlarınıza yıldız vermeyi unutmayınız.
