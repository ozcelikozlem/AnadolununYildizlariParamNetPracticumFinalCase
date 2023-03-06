# Anadolu'nun Yıldızları Param .Net Practicum Final Case
## Restful Api
## #Online Store
- .Net 5.0
- Online Alışveriş Listesi
- İki tip rol vardır. [User & Administrator]
- Kullanıcılar kayıt olmadan veya giriş yapmadan işlem yapamazlar.

* Proje Başlatma

![ProjeGörseli1](/images/Final4.jpg)

* Swagger API Test Arayüzü 1

![ProjeGörseli1](/images/Final1.jpg)

### Category & Measure : 
* Product varlığının özellikleridir.
Administrator tarfından kontrol edilirler.(Görüntüleme işlemleri, Ekleme, Silme, Güncelleme)

* Swagger API Test Arayüzü 2

![ProjeGörseli2](/images/Final2.jpg)

### Product & ProductShoppingList & Shopping List :
* Product ekleme ,güncelleme , silem işlemleri yalnızca Administrator tarafından kontrol edilir. Görüntüleme işlemleri her iki kullanıcı içinde geçerlidir.
* Shooping List ekleme , güncelleme ,silme işlemleri User tarafından kontrol edilir. Görüntüleme işlemleri her iki kullanıcı içinde geçerlidir.
* Her iki kullanıcıda iki varlık arasında ilişkilendirme yapabilir.

* Swagger API Test Arayüzü 3

![ProjeGörseli3](/images/Final3.jpg)

### User :
* Kullanıcı görüntüleme, oluşturma , silme , güncelleme ,rol verme, JWT, kullanıcının doğrulanması, web servis güvenliği sağlama işlemleri yapılır.

* Unit Test & Integrasyon Testi (TDD)

![ProjeGörseli4](/images/Final6.jpg)

! Entegrasyon testi Jwt Authentication olmadan çalışmakta.



