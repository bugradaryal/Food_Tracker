# Yemek takip uygulaması

Asp.net Core, web tabanlı katmanlı mimari uygulamasıdır.

## Veri Tabanı Oluşturma
Veritabanı, dotnet tools ile oluşturulur. "DataAccess --> DataDbContext.cs" ve "Web.API --> appsettings.json" dosyalarındaki connection string'lerin düzenlenmesi gerekmektedir. Düzenleme yapılması durumunda, konsola "dotnet ef database update" komutunun yazılması ile veritabanı oluşturulacaktır. Arka plan işlemleri için veri tabanı "appsettins.json" dosyasında bulunan connection string ile oluşturulmaktadır.

![version](https://img.shields.io/badge/dotnet_version-6.0.4-blue)
