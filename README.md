# YMH 219 - TCP/IP İstemci-Sunucu Chat Uygulaması

* **Öğrenci Adı Soyadı:** Hayrunnisa Ekinci
* **Öğrenci Numarası:** 240541043
* **Ders:** YMH 219 - Görsel Programlama / Nesne Yönelimli Programlama

## Proje Hakkında

Bu proje, C# Windows Forms (.NET 10.0) kullanılarak geliştirilmiş; `TcpListener` ve `TcpClient` sınıfları ile yerel ağ veya `localhost` (`127.0.0.1`) üzerinden çoklu istemcilerin eş zamanlı mesajlaşmasını sağlayan nesne yönelimli bir **İstemci-Sunucu Sohbet Uygulamasıdır**.

## Temel Özellikler & OOP Mimarisi

* **Sunucu İstemci Modeli (`ClientInfo` Sınıfı):** Bağlanan her istemcinin TCP soketi, `StreamWriter` akışı, kullanıcı adı, IP:Port adresi ve bağlantı zamanı kapsüllenmiştir.
* **İstemci Ağ Yönetimi (`ChatClientConnection` Sınıfı):** Sunucuya asenkron TCP bağlantısı (`ConnectAsync`), arka planda sürekli veri dinleme döngüsü, özel protokol ayrıştırma (`JOIN|`, `MSG|`, `SYS|`) ve güvenli bağlantı sonlandırma davranışları ayrı bir sınıfta toplanmıştır.
* **Asenkron Mimari (`async/await`):** Arayüz donmalarını önlemek için istemci kabulü, mesaj yayını (`BroadcastAsync`) ve okuma işlemleri tamamen asenkron yürütülür.
* **Çoklu İstemci & Zaman Damgası:** Birden fazla kullanıcı aynı anda ortak odaya katılabilir; tüm mesajlar saat bilgisiyle (`[HH:mm:ss]`) hem sunucu günlüğünde hem de bağlı istemcilerde anlık listelenir.

## Kurulum ve Çalıştırma

1. Depoyu bilgisayarınıza klonlayın:
   ```bash
   git clone [https://github.com/eknchayru403-afk/YMH219-ChatApp.git](https://github.com/eknchayru403-afk/YMH219-ChatApp.git)
