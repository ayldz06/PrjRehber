# PrjRehber
Blan Solution içerisine 2 adet .Net Core api projesi ve 1 adet .Net Core Mvc projesi eklendi.
Proje isimleri => KisiApi, RaporApi ve RehberMVC
RehberMvc projesinde Front Ent tarafında Bootstrap kütüphanesini kullanarak Kayıt tasarımları yapıldı.
Yapıan kayıt tasarımları (Kişi Ekle, Kişi Bilgileri ekle) ile KisiApi ile entegrasyon işlemi yapılarak kayıt ekleme ve silme işlemleri yapıldı.
KisiApi ve RaporApi projesinde postgresql bağlantıları yapıldı.
RehberMVC projesinde Rapor oluştur butonu ile RaporApi entegrasyonu yapıldı ve MSMQ ile istek kuyruğa aktarıldı.
RaporApi projesinde msqm classı BackgroundService'i oluşturuldu ve 1 snyde bir MSMQ ya gidip veri okumaya başlandı. 
Rapor talebi olduğunda, KisiApi projesine giderek Konum Bilgisi,Kayıtlı Kişi sayısı ve Telefon numara sayısı alındı.
