using Edura.WebUI.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .GetRequiredService<EduraContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                var products = new[]
               {
                new Product() { ProductName = "Pantene Güç ve Parlaklık Bakım Şampuanı",IsFeatured=true, Description = "Doğal Sentez Güç ve Parlaklık serisi ile doğanın gücünü keşfedin. Zayıf saçlarda güç ve görünür parlaklık için Sinameki ile zenginleştirilmiştir.", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Price = 18.90, IsApproved = true,  IsHome=true, Image="PanteneGucParlaklik.jpg"},
                new Product() { ProductName = "Pantene Kepeğe Karşı Etkili Şampuan", Description = "Kepekle mücadele eder, saçınıza bakım yapar.Kepeğe karşı etkili* VE 10 günde sağlıklı görünüme sahip saçlar.Düzenli kullanımda kepekte gözle görülür azalma.", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Price = 15.00, IsApproved = true,  IsHome=true,Image="PanteneKepek.jpg"},
              new Product() { ProductName = "Pantene Aqualight Şampuan", Description = "Aqualight Serisi silikon içermeyen ve ağırlaştırmadan bakım yapan Pantene Pro-V formülüne sahiptir. Saçlarınız güzel bir görünüme kavuşurken geride ağırlık kalmaz.", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Price = 20.00, IsApproved = true, IsHome=true, Image="PanteneAqualight.jpg"},
                 new Product() { ProductName = "Baybit Bit Temizleyici Şampuan", Description ="Bebekler için özel paraben içermeyen formülüyle Babybit Bit öldürücü şampuan.",  HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Price = 18.35,  IsApproved = true,  IsHome=true, Image="BabyBit.jpeg"},
               new Product() { ProductName = "Babe Extra Mild Şampuan", Description = "Bal ekstresi sayesinde saça yumuşaklık, parlaklık, hacim ve dolgunluk vermeyi hedefler.Yıpranmış saçları rahatlatmaya yardımcı olur.", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Price = 45.35, IsApproved = true, IsHome=true, Image="BabeSampuan.jpg"},

                 new Product() { ProductName = "Vichy Mineralizing Water",IsFeatured=true, Description = "Vichy Mineral 89% Mineralizing Water + Hyaluronic Acid 50ml.Doğal hyalüronik asit içerir", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10),Price = 89.50, IsApproved = true,  IsHome=true, Image="vichyTermal.jpg"},
                 new Product() { ProductName = "Bioderma Sebium Gel", Description = "İntensive Gel Moussant 200ml",Price = 69.50, IsApproved = true,  IsHome=true, Image="BiodermaSebium.jpg", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10)},
                 new Product() { ProductName = "Bioderma Atoderm Gel", Description = "İntensive Atoderm Gel Moussant 200ml", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10),Price = 95.50, IsApproved = true,  IsHome=true, Image="BiodermaAtoderm.png"},
                 new Product() { ProductName = "Clinique Repair Serum",IsFeatured=true, Description = "Clinique Smart Custom Repair Serum 30ml.Tüm yaşlar ve farklı cilt tiplerinin kullanımı için uygundur.",Price = 429.00,  IsApproved = true,  IsHome=true, HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10) ,Image="CliniqueSmart.jpg"},


                new Product() { ProductName = "Milupa Papatya Çayı",  HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10),Description = "Mide Düzenleyici Papatya Çayı 200 gr", Price = 14.50,  IsApproved = true,  IsHome=true, Image="MilupaPapatya.jpg"},
                new Product() { ProductName = "Betamega Takviye Edici Şurup", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Description = "Çocuklar İçin Betamega Takviye Edici Gıda Şurup 150ml",Price = 45.50,  IsApproved = true, IsHome=true, Image="BetamegaTakviye.jpg"},


                new Product() { ProductName = "Tena Slip Plus", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Description = "Large 30lu Hasta Bezi",Price = 55.00, IsApproved = true,  IsHome=true,Image="TenaBez30lu.jpg"},
                new Product() { ProductName = "Vivocare Ateş Ölçer", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Description = "Kalem Tipi Dijital Derece", Price = 05.90,  IsApproved = true,  IsHome=true, Image="VivocareÖlçer.png"},
                new Product() { ProductName = "Moos Kulak Tıkacı", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Description = "Doğal yolla daha iyi uyumayı sağlayan ve suyun kulağa girmesini önleyen yumuşak bir silikonlu kulak koruyucudur",Price = 17.50,  IsApproved = true,  IsHome=true, Image="moosTikac.jpg"},


                new Product() { ProductName = "Paradontax Diş Macunu",IsFeatured=true, HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Description = "Plakları fiziksel olarak uzaklaştırarak parodontax diş macunu diş eti bakımınıza yardımcı olur.", Price = 10.00, IsApproved = true, IsHome=true,Image="ParadontaxMacun.jpg"},
                new Product() { ProductName = "Signal White Now", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Description = "Diş minesine zarar vermeyen formülüyle anında beyazlık sağlar. ", Price = 19.00,  IsApproved = true, IsHome=true,Image="SignalWhite.jpg"},

                new Product() { ProductName = "La Roche Posay 50+ Güneş Koruyucu",IsFeatured=true, HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10), Description = "Doğal yollarla elde edilen Shea yağı ile zenginleştirilmiş formülü cildi nemlendirir.Yumuşak ve kadifemsi dokuya sahiptir.", Price = 85.00,  IsApproved = true, IsHome=true,Image="LaRoche50.jpg"},
                 new Product() { ProductName = "Avene 50+ Güneş Koruyucu", HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10),Description = "Yüksek koruma faktörü ile renkli güneş koruyucu bakım ürünüdür.Güneşe karşı koruma sağlar", Price = 67.00,  IsApproved = true, IsHome=true,Image="Avene50.jpg"},
                 new Product() { ProductName = "Sebamed 45+ Güneş Koruyucu",IsFeatured=true, HtmlContent="Lorem ipsum dolor m. Seu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10),Description = "Hassas cilt korumasında yıllardır öncülük eden Sebamed, oluşturduğu yeni 'Güneş Koruma Serisi' ile hassas ciltlere yoğun bir koruma ve bakım kombinasyonu sağlamaktadır.", Price = 58.00,  IsApproved = true,  IsHome=true,Image="sebamed45.jpg"},


                };

                context.Products.AddRange(products);

                var categories = new[]
                {
                     new Category(){CategoryName="Saç Bakımı"},
                new Category(){CategoryName="Cilt Bakım Ürünleri"},
                new Category(){CategoryName="Gıda Takviyeleri"},
                new Category(){CategoryName="Sağlık Gereçleri"},
                new Category(){CategoryName="Ağız ve Diş Sağlığı"},
                 new Category(){CategoryName="Güneş Bakım Ürünleri"},

                };

                context.Categories.AddRange(categories);

                var productcategories = new[]
                {
                    new ProductCategory(){ Product=products[0],Category=categories[0]},
                    new ProductCategory(){ Product=products[1],Category=categories[0]},
                    new ProductCategory(){ Product=products[2],Category=categories[0]},
                    new ProductCategory(){ Product=products[3],Category=categories[0]},
                    new ProductCategory(){ Product=products[4],Category=categories[0]},

                    new ProductCategory(){ Product=products[5],Category=categories[1]},
                    new ProductCategory(){ Product=products[6],Category=categories[1]},
                    new ProductCategory(){ Product=products[7],Category=categories[1]},
                    new ProductCategory(){ Product=products[8],Category=categories[1]},

                    new ProductCategory(){ Product=products[9],Category=categories[2]},
                    new ProductCategory(){ Product=products[10],Category=categories[2]},

                    new ProductCategory(){ Product=products[11],Category=categories[3]},
                    new ProductCategory(){ Product=products[12],Category=categories[3]},
                    new ProductCategory(){ Product=products[13],Category=categories[3]},

                    new ProductCategory(){ Product=products[14],Category=categories[4]},
                    new ProductCategory(){ Product=products[15],Category=categories[4]},

                    new ProductCategory(){ Product=products[16],Category=categories[5]},
                    new ProductCategory(){ Product=products[17],Category=categories[5]},
                    new ProductCategory(){ Product=products[18],Category=categories[5]},

                     new ProductCategory(){ Product=products[16],Category=categories[1]},
                    new ProductCategory(){ Product=products[17],Category=categories[1]},
                    new ProductCategory(){ Product=products[18],Category=categories[1]}


                };

                context.AddRange(productcategories);


                var images = new[]
                {
                    new Image(){ ImageName="product1.jpg", Product=products[0]},
                    new Image(){ ImageName="product2.jpg", Product=products[0]},
                    new Image(){ ImageName="product3.jpg", Product=products[0]},
                    new Image(){ ImageName="product4.jpg", Product=products[0]},

                    new Image(){ ImageName="product1.jpg", Product=products[1]},
                    new Image(){ ImageName="product2.jpg", Product=products[1]},
                    new Image(){ ImageName="product3.jpg", Product=products[1]},
                    new Image(){ ImageName="product4.jpg", Product=products[1]},

                    new Image(){ ImageName="product1.jpg", Product=products[2]},
                    new Image(){ ImageName="product2.jpg", Product=products[2]},
                    new Image(){ ImageName="product3.jpg", Product=products[2]},
                    new Image(){ ImageName="product4.jpg", Product=products[2]},

                    new Image(){ ImageName="product1.jpg", Product=products[3]},
                    new Image(){ ImageName="product2.jpg", Product=products[3]},
                    new Image(){ ImageName="product3.jpg", Product=products[3]},
                    new Image(){ ImageName="product4.jpg", Product=products[3]},

                    new Image(){ ImageName="product1.jpg", Product=products[4]},
                    new Image(){ ImageName="product2.jpg", Product=products[4]},
                    new Image(){ ImageName="product3.jpg", Product=products[4]},
                    new Image(){ ImageName="product4.jpg", Product=products[4]},
                };

                context.Images.AddRange(images);

                var attributes = new[]
                {
                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Pantene Güç ve Parlaklık Bakım Şampuanı", Product=products[0]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="PANTENE", Product=products[0]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="100ml", Product=products[0]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Islak saça masaj yaparak köpürtün, durulayın.", Product=products[0]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Zayıf saçlarda güç ve görünür parlaklık için Sinameki ile zenginleştirilmiştir.", Product=products[0]},

                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Pantene Kepeğe Karşı Etkili Şampuan", Product=products[1]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="PANTENE", Product=products[1]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="200ml", Product=products[1]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Islak saça masaj yaparak köpürtün, durulayın.", Product=products[1]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Kepekle mücadele eder, saçınıza bakım yapar.", Product=products[1]},

                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Pantene Aqualight Şampuan", Product=products[2]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="PANTENE", Product=products[2]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="200ml", Product=products[2]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Islak saça masaj yaparak köpürtün, durulayın.", Product=products[2]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Mikro-güçlendiriciler içeren bu formül, ince telli saçları hedefleyerek ağırlaştırmadan güçlendirmeye* yardımcı olur.", Product=products[2]},


                   new ProductAttribute(){ Attribute="Ürün Adı:",Value="Bit Temizleyici Şampuan", Product=products[3]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="BAYBIT", Product=products[3]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="100ml", Product=products[3]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Islak saça masaj yaparak köpürtün, 1 saat bekledikten sonra durulayın.", Product=products[3]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Bit ve yumurtalarını öldürür, kaşıntıyı giderir.", Product=products[3]},

                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Babe Extra Mild Şampuan", Product=products[4]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="BABE", Product=products[4]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="200ml", Product=products[4]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Islak saça masaj yaparak köpürtün, durulayın.", Product=products[4]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Saçların günlük hijyeni,bakımı ve korunması içindir. Babe Ekstra Yumuşak Şampuan saçların ihtiyaç duyduğu temizliği ve bakımı sağlama konusunda yardımcı bir üründür.", Product=products[4]},


                    //------Yüz
                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Vichy Mineral 89% Mineralizing Water + Hyaluronic Acid", Product=products[5]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="VICHY", Product=products[5]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="50ml", Product=products[5]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="%89 Vichy Termal Suyu ve doğal hyalüronik asit içeren serum,Parfüm ve boya içermez.", Product=products[5]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Günlük oluşan olumsuz etkenlerin giderilmesinde yardımcı olur", Product=products[5]},
                    
                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Bioderma Sebium Foaming", Product=products[6]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="BIODERMA", Product=products[6]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="500ml", Product=products[6]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Karma ve yağlı ciltler için sabun içermeyen temizleme jeli", Product=products[6]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Cildi temizlemeye, kir ve makyajdan arındırmaya yardımcı olur.Sebum salgısını kontrol altına alarak aşırı yağlanmanın önüne geçmeyi hedefler.", Product=products[6]},

                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Bioderma Atoderm Gel", Product=products[7]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="BIODERMA", Product=products[7]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="200ml", Product=products[7]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Çok kuru ve atopik ciltler için ultra zengin yatıştırıcı ve temizleyici jel.", Product=products[7]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Aktif arındırıcılar içeren Atoderm Intensive Foaming Gel cilt kuruluğunun ilerlemesine karşı bakım sağlar.", Product=products[7]},

                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Clinique Smart Custom Repair Serum", Product=products[8]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="CLINIQUE", Product=products[8]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="30ml", Product=products[8]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Tüm cilt tiplerine uygundur.", Product=products[8]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Cilt tonu eşitsizliği, koyu lekeler, çizgi ve kırışıklık görünümü, sıkılık kaybına karşı bakım sağlayan tek bir akıllı serum.", Product=products[8]},

                    //EK BESİN
                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Milupa Papatya Çayı", Product=products[9]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="MİLUPA", Product=products[9]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="200gr", Product=products[9]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Kaynamakta olan 100ml suya tepeleme 1 tatlı kaşığı 5g milupa papatya çayı ilave ederek karıştırınız.", Product=products[9]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Sindirim sistemini düzenler, hazımsızlığı giderir.", Product=products[8]},

                     new ProductAttribute(){ Attribute="Ürün Adı:",Value="Betamega Takviye Edici Şurup", Product=products[10]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="MİLUPA", Product=products[10]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="200gr", Product=products[10]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Kaynamakta olan 100ml suya tepeleme 1 tatlı kaşığı 5g milupa papatya çayı ilave ederek karıştırınız.", Product=products[10]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Sindirim sistemini düzenler, hazımsızlığı giderir.", Product=products[10]},

                    //MEDİKAL
                     new ProductAttribute(){ Attribute="Ürün Adı:",Value="Tena Slip Plus", Product=products[11]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="TENA", Product=products[11]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="30 Adet", Product=products[11]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Large boy yetişkin bezi.", Product=products[11]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Sıvıyı hapseder, kuruluk hissi verir.", Product=products[11]},

                     new ProductAttribute(){ Attribute="Ürün Adı:",Value="Vivocare Ateş Ölçer", Product=products[12]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="VIVOCARE", Product=products[12]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="10cm", Product=products[12]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="%100 su geçirmez.Ölçüm başlama/bitiş uyarısı.", Product=products[12]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="%90'a kadar doğru sonuç verir.", Product=products[12]},

                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Moos Kulak Tıkacı", Product=products[13]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="MOOS", Product=products[13]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="4 adet", Product=products[13]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Yüksek hararetli ortamlarda tavsiye edilmez.", Product=products[13]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Uykuda,yüzerken,sörfte,duşta,seyahat ederken,çalışırken ve dinlenme anlarında gürültüyü engellemeye yardımcı olur.", Product=products[13]},
                    //DİŞ MACUNLARI
                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Parodontax Beyazlatıcı Diş Macunu", Product=products[14]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="PARADONTAX", Product=products[14]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="75ml", Product=products[14]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Diş eti kanaması, sağlıksız diş etinin ilk belirtilerinden biridir. Önlem alınmazsa, diş kaybına sebep olabilir.", Product=products[14]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Diş ve diş etini plaklara ve çürüklere karşı koruyor, diş taşı oluşumunu geciktiriyor. ", Product=products[14]},

                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Signal White Now", Product=products[15]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="SIGNAL", Product=products[15]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="75ml", Product=products[15]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Sigara kaynaklı leke görünümlerini azaltmaya yardımcı olur.", Product=products[15]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Özel geliştirilen yeni White Now Man içeriğindeki mavi ışık partikülleri sayesinde beyazlık sağlar ve sigara kaynaklı lekeleri giderir.", Product=products[15]},

                    //GÜNEŞ
                     new ProductAttribute(){ Attribute="Ürün Adı:",Value="La Roche Posay 50+ Güneş Koruyucu", Product=products[16]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="La Roche Posay", Product=products[16]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="50ml", Product=products[16]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Diş eti kanaması, sağlıksız diş etinin ilk belirtilerinden biridir. Önlem alınmazsa, diş kaybına sebep olabilir.", Product=products[16]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Diş ve diş etini plaklara ve çürüklere karşı koruyor, diş taşı oluşumunu geciktiriyor. ", Product=products[16]},

                    new ProductAttribute(){ Attribute="Ürün Adı:",Value="Avene 50+ Güneş Koruyucu", Product=products[17]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="AVENE", Product=products[17]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="50ml", Product=products[17]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Etkili bir güneş koruması sağlayan renkli krem.", Product=products[17]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Yüksek koruma faktörü ile renkli güneş koruyucu bakım ürünüdür.Renkli yapısı ile cilt kusurlarını kapamada yardımcı olur", Product=products[17]},

                      new ProductAttribute(){ Attribute="Ürün Adı:",Value="Sebamed 45+ Güneş Koruyucu", Product=products[18]},
                    new ProductAttribute(){ Attribute="Ürün Markası:",Value="SEBAMED", Product=products[18]},
                    new ProductAttribute(){ Attribute="Ürün Boyutu:",Value="150ml", Product=products[18]},
                    new ProductAttribute(){ Attribute="Özet Bilgi:",Value="Yağ, alkol ve renklendirici madde içermez.", Product=products[18]},
                    new ProductAttribute(){ Attribute="Ürün Faydaları:",Value="Yüksek etkili 98 UVA ve 30, 45, 50 UVB filtreleri sayesinde güneşin zararlı ışınlarını süzer.", Product=products[18]},

                  
                };

                context.Attributes.AddRange(attributes);


                context.SaveChanges();

            }
        }
    }
}
