![image](https://github.com/user-attachments/assets/bcb45199-b21a-4f40-9b56-96b9d65d7bee)

## 🧠 Fuzzy Washing Machine

**Fuzzy Washing Machine**, bulanık mantık (fuzzy logic) tabanlı, çamaşır yıkama süresi tahmini yapan bir masaüstü uygulamasıdır. Proje, yapay zekanın alt dallarından biri olan bulanık mantığın, ev tipi cihazlar üzerindeki uygulamasını göstermek amacıyla geliştirilmiştir.

### 📌 Özellikler

* Kullanıcıdan 3 temel girdi alır:

  * **Kirlilik düzeyi (Dirtiness Level)**
  * **Çamaşır yükü (Load Size)**
  * **Yıkama tipi (Washing Type)**
* Bu verilere göre fuzzy mantık ile yıkama süresi hesaplanır.
* Kullanıcı arayüzü üzerinden kolay giriş ve sonuç görselleştirme imkanı sağlar.
* Basit ve anlaşılır .NET Forms arayüzü.

---

### 🛠️ Kullanılan Teknolojiler

* **.NET Framework / Windows Forms**
* **C# (Backend & UI logic)**
* **HTML (Tanıtım sayfası)**
* **Bulanık Mantık Algoritması** (Fuzzy Inference System)

---

### 📂 Proje Yapısı

```
Fuzzy Washing Machine/
│
├── project/
│   ├── MainForm.cs              # Ana uygulama formu (UI + mantık)
│   ├── MainForm.Designer.cs     # Form tasarımı
│   ├── FuzzyWashingMachine.csproj
│   ├── FuzzyWashingMachine.sln  # Çözüm dosyası
│   ├── index.html               # Tanıtım HTML sayfası
│   └── *.js / *.json            # Geliştirme konfigürasyonları
│
└── README.md                    # Bu dosya
```

---




### 🧪 Nasıl Çalışır?

1. Kullanıcı 3 değeri girer:

   * Kirlilik düzeyi (0-10)
   * Yük miktarı (0-10 kg)
   * Yıkama tipi (Hassas / Normal / Yoğun)
2. Bu değerler, bulanık kümeleme kurallarına göre değerlendirilir.
3. Bulanık çıkarım motoru, uygun kuralları uygular.
4. En son bulanık sonuç "de-fuzzify" edilerek net yıkama süresi dakika cinsinden kullanıcıya gösterilir.

---

### 📖 Teorik Arka Plan

Proje, **Mamdani** tipi bulanık çıkarım sistemine dayanır. Girişler “Low”, “Medium”, “High” gibi dilsel değişkenlere dönüştürülür ve kurallar şu şekilde tanımlanır:

**Örnek Kural:**

> Eğer Yük = High ve Kirlilik = High ve Yıkama = Yoğun ise, Süre = Uzun

---


