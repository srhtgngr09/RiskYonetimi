Projeyi tasarlarken katman yapısını Asp.Net boilerplate frameworkü referans aldım. Projeyi 6 katman halinde tasarladım.Sigorta sektöründe çalıştığım için ana firma ve bağlı acenteler şekinde planladım.Entityleri Migration ile Ms Sql de tutuyorum.Html css ile önyüz gösterimini sağladım.
Case de verilen adımları acente de basit haliyle süreç nasıl işleyebilir diye düşünerek koda dökmeye çalıştım. 
cs dosyaları içesinde yazdığım kodlarla ilgili  kısa biligler verdim.
 - RiskYonetim.Domain katmanında entity sınıflarını tanımladım.
 - RiskYonetimi.Application  katmanında Dto ve servis interfacelerini tanımladım.
 - RiskYonetimi.Domain.Interfaces  Tenant ın interface kodlarını yazmak için kullandım. Tenant id için interface i oluşturuldu. 
Application katmanından alamamanın sebebi WebAPI ve EF katmanlarına bağımlı olamadığı için bu katmanda oluşturdum.
 - RiskYonetimi.EF DbContext ve Migration bu katmanda oluşturuldu.
 - RiskYonetimi.WebApi FirmaBilgileri Controller ve RiskAlController ile api katmanı yazıldı swagger da gösterilmesi sağlandı.
 - RiskYonetimi.WebUI katmanında WebApi ile iş ortağından gelen dataları veritabanına eklenmiştir. Burada Index.html sayfası ile veritabanından gelen datalar önyüzde  belli alanları doldurulması için çağrılmıştır.
