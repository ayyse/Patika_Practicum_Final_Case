# Patika_Practicum_Final_Case

# Patika - Param Practicum Final Projesi  Alışveriş Uygulaması

Projenin amacı kullanıcıların belli kategorilere göre alışveriş listesi oluşturup rahatlıkla takip edebilmeleridir. Bu projede admin ve kullanıcı olarak iki farklı rol tanımı bulunuyor.

### Admin 
- Sistemde kullanıcı olarak kayıt oluşturma, güncelleme ve silme işlemlerini yapabilir. Tüm kullanıcıları listeleyebilir ve id'lerine göre getirme işlemi yapabilir.
- Tüm kullanıcıların alışveriş listelerine, tüm kategorilere ve tüm ürünlere erişim sağlayabilir.

### Kullanıcı
- Kategori oluşturabilir. 
- Kategorilerin altına istediği kadar alışveriş listesi oluşturabilir.
- Alışveriş listelerinin altına eklemek istedikleri ürünleri miktar belirterek ekleyebilir.

## Kullandığım Teknolojiler
<p align="center">
  <img width="50" height="50" src="https://codeopinion.com/wp-content/uploads/2017/10/Bitmap-MEDIUM_Entity-Framework-Core-Logo_2colors_Square_Boxed_RGB.png">
  <img width="100" height="50" src="https://tech.playgokids.com/static/5080497fdeb321559343c59f795a5dcf/f3583/automapper-logo.png">
  <img width="50" height="50" src="https://upload.wikimedia.org/wikipedia/commons/a/ab/Swagger-logo.png">
  <img width="85" height="50" src="https://miro.medium.com/max/1061/1*qEmLubkC3Agiaap5wnBu9g.png">
</p>

## Projenin Kurulumu
Projemi Visual Studio 2022 .Net 7 ile geliştirdim. Veritabanı için PostgreSQL kullandım. Projeyi kurabilmek için bilgisayarınızda <b>Visual Studio 2022, .Net 7 SDK ve PostgreSql</b> kurulumunun tamamlanmış olması gerekiyor. Github aracılığıyla projeyi indirdikten sonra Visual Studio üzerinden açıp Package Manager Console'a tıklayıp Default project olarak `ShoppingApi.Data` seçtikten sonra konsola `Update-Database` yazıp enter'a tıklıyoruz. Burada almış olduğum Migration sizin veritabanınıza kurulmuş olacaktır. Daha sonrasında projeyi swagger üzerinden kullanabilirsiniz. Token bazlı bir proje olduğu için veritabanına yeni bir kullanıcı kaydettikten sonra username ve password bilgileri ile alacağınız access token sayesinde diğer metotlara erişim sağlayabilirsiniz. 
