# \# YMH 219 - TCP/IP İstemci-Sunucu Chat Uygulaması (`YMH219-ChatApp`)

# 

# Bu proje, \*\*YMH 219 Görsel Programlama\*\* dersi kapsamında C# ve Windows Forms kullanılarak geliştirilmiş, çoklu istemci destekli bir TCP/IP istemci-sunucu sohbet uygulamasıdır.

# 

# \## Projenin Amacı ve Özellikleri

# 

# \- \*\*TCP/IP Ağ İletişimi:\*\* `TcpListener` ve `TcpClient` sınıfları ile yerel ağ veya `localhost` (`127.0.0.1`) üzerinden çift yönlü veri alışverişi.

# \- \*\*Asenkron Mimari (`async/await`):\*\* Arayüz donmalarını önlemek için istemci kabulü ve mesaj dinleme döngülerinin tamamen asenkron yürütülmesi.

# \- \*\*Çoklu İstemci Desteği:\*\* Birden fazla kullanıcının aynı anda sunucuya bağlanarak ortak sohbet odasında mesajlaşabilmesi.

# \- \*\*Özel Uygulama Protokolü:\*\* `JOIN|KullaniciAdi`, `MSG|Mesaj` ve `SYS|Bilgi` biçiminde yapılandırılmış satır tabanlı iletişim protokolü.

# \- \*\*Canlı İstemci Takibi ve Zaman Damgası:\*\* Sunucu tarafında bağlı istemcilerin kullanıcı adı, IP:Port ve bağlantı zamanının listelenmesi; tüm mesajların saat bilgisiyle gösterilmesi.

# \- \*\*Hata Yönetimi:\*\* Bağlantı kopmaları ve geçersiz girişlerin uygulamayı çökertmeden kullanıcıya bildirilmesi.

# 

# \## Kullanılan Teknolojiler

# 

# \- \*\*Dil:\*\* C# (.NET 10.0)

# \- \*\*Arayüz:\*\* Windows Forms (WinForms)

# \- \*\*Ağ \& G/Ç Kütüphaneleri:\*\* `System.Net`, `System.Net.Sockets`, `System.IO`, `System.Threading.Tasks`

# \- \*\*IDE:\*\* Visual Studio Community 2026

# 

# \## Sınıf Yapısı

# 

# \### Sunucu Projesi (`YMH219-ChatApp`)

# \- \*\*`ClientInfo`:\*\* Bağlanan her istemcinin TCP soketini, `StreamWriter` akışını, kullanıcı adını, IP adresini ve bağlantı zamanını kapsüller.

# \- \*\*`Form1`:\*\* `TcpListener` yaşam döngüsünü, asenkron istemci kabulünü, mesaj yayınını (`BroadcastAsync`) ve sunucu günlüğünü yönetir.

# 

# \### İstemci Projesi (`ChatClient`)

# \- \*\*`ChatClientConnection`:\*\* Sunucuya TCP bağlantısı kurma, arka planda asenkron mesaj dinleme, protokol ayrıştırma ve bağlantıyı güvenli sonlandırma işlemlerini yönetir.

# \- \*\*`Form1`:\*\* Kullanıcı adı, IP, Port girişleri, bağlantı durumu göstergesi ve mesajlaşma arayüzünü yönetir.

# 

# \## Çalıştırma Adımları

# 

# 1\. Çözümü (`YMH219-ChatApp`) Visual Studio 2026 ile açın ve derleyin (`Ctrl + Shift + B`).

# 2\. Önce \*\*`YMH219-ChatApp` (Sunucu)\*\* projesini başlatın, port numarasını (`5000`) onaylayıp \*\*Başlat\*\* butonuna tıklayın.

# 3\. Ardından \*\*`ChatClient` (İstemci)\*\* projesinden bir veya birden fazla örnek başlatın.

# 4\. Kullanıcı adınızı girin (`127.0.0.1` ve `5000` varsayılan değerleriyle) ve \*\*Bağlan\*\* butonuna tıklayarak sohbete katılın.

# 

# \## Ekran Görüntüleri

# 

# \### 1. Sunucu ve İstemci Bağlantısı

# !\[Sunucu ve İstemci Bağlantısı](ekran1.png)

# 

# \### 2. Çoklu İstemci Mesajlaşma Görünümü

# !\[Çoklu İstemci Mesajlaşma](ekran2.png)

