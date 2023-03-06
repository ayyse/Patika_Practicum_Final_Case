# Patika-Param Practicum Final Projesi  Alışveriş Uygulaması

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
  <img width="60" height="50" src="https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Postgresql_elephant.svg/993px-Postgresql_elephant.svg.png">
  <img width="60" height="50" src="https://1000logos.net/wp-content/uploads/2020/08/Visual-Studio-Logo.png">
  <img width="50" height="50" src="https://cdn-icons-png.flaticon.com/512/25/25231.png">
  <img width="50" height="50" src="https://avatars.githubusercontent.com/u/890883?s=280&v=4">
  <img width="50" height="50" src="https://upload.wikimedia.org/wikipedia/commons/a/ab/Swagger-logo.png">
  <img width="50" height="50" src="https://codeopinion.com/wp-content/uploads/2017/10/Bitmap-MEDIUM_Entity-Framework-Core-Logo_2colors_Square_Boxed_RGB.png">
  <img width="85" height="50" src="https://miro.medium.com/max/1061/1*qEmLubkC3Agiaap5wnBu9g.png">
  <img width="85" height="50" src="http://jwt.io/img/logo-asset.svg">
  <img width="50" height="50" src="https://pbs.twimg.com/profile_images/1583173589733605376/6A7esDyo_400x400.jpg">
</p>

## Projenin Kurulumu
Projemi Visual Studio 2022 .Net 7 ile geliştirdim. Veritabanı için PostgreSQL kullandım. Projeyi kurabilmek için bilgisayarınızda <b>Visual Studio 2022, .Net 7 SDK ve PostgreSql</b> kurulumunun tamamlanmış olması gerekiyor. Github aracılığıyla projeyi indirdikten sonra Visual Studio üzerinden açıp Package Manager Console'a tıklayıp Default project olarak `ShoppingApi.Data` seçtikten sonra konsola `Update-Database` yazıp enter'a tıklıyoruz. Burada almış olduğum Migration sizin veritabanınıza kurulmuş olacaktır. Daha sonrasında projeyi swagger üzerinden kullanabilirsiniz. Token bazlı bir proje olduğu için veritabanına yeni bir kullanıcı kaydettikten sonra username ve password bilgileri ile alacağınız access token sayesinde diğer metotlara erişim sağlayabilirsiniz. 

<p align="center">
  <img src="https://github.com/ayyse/Patika_Practicum_Final_Case/blob/main/ScreenShots/Token-Response.jpeg">
</p>

Burada gelen access token bilgisini kopyalayıp aşağıdaki authorization alanına kopyalarsanız rolünüze göre metotlara erişim sağlayabilirsiniz.

<p align="center">
  <img src="https://github.com/ayyse/Patika_Practicum_Final_Case/blob/main/ScreenShots/Authorization.jpeg">
</p>


## Endpoints
<p align="center">
  <img src="https://github.com/ayyse/Patika_Practicum_Final_Case/blob/main/ScreenShots/Category.jpeg">
  <img src="https://github.com/ayyse/Patika_Practicum_Final_Case/blob/main/ScreenShots/Product.jpeg">
  <img src="https://github.com/ayyse/Patika_Practicum_Final_Case/blob/main/ScreenShots/ShoppingList.jpeg">
  <img src="https://github.com/ayyse/Patika_Practicum_Final_Case/blob/main/ScreenShots/User.jpeg">
</p>
