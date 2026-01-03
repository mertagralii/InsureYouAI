# 🛡️ InsureYouAI - AI-Powered Insurance Management Platform

<div align="center">

![. NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=dotnet)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet)
![SignalR](https://img.shields.io/badge/SignalR-512BD4?style=for-the-badge&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server)

</div>

## 📋 İçindekiler

- [Proje Hakkında](#-proje-hakkında)
- [Özellikler](#-özellikler)
- [Teknoloji Stack](#-teknoloji-stack)
- [Yapay Zeka Entegrasyonları](#-yapay-zeka-entegrasyonları)
- [Proje Yapısı](#-proje-yapısı)
- [Kurulum](#-kurulum)
- [Öğrenilen Teknolojiler](#-öğrenilen-teknolojiler)

---

## 🎯 Proje Hakkında

**InsureYouAI**, yapay zeka destekli modern bir sigorta yönetim platformudur. Proje, sigorta şirketlerinin müşteri ilişkileri yönetimini (CRM), poliçe takibini ve müşteri iletişimini otomatikleştirmek için geliştirilmiştir.  Birden fazla AI servisini entegre ederek, akıllı içerik üretimi, otomatik kategorizasyon, duygu analizi, tahminleme ve sesli asistan özellikleri sunar.

### 💡 Projenin Amacı

- **Müşteri İletişimini Otomatikleştirme**: AI destekli otomatik yanıt sistemleri
- **Akıllı Kategorizasyon**: Gelen mesajları ve talepleri otomatik kategorize etme
- **Tahmine Dayalı Analiz**: ML.NET ile satış tahminleme
- **İçerik Üretimi**: Yapay zeka ile blog, hizmet ve hakkımızda içerikleri oluşturma
- **Çok Dilli AI Entegrasyonu**: OpenAI, Google Gemini, Anthropic Claude, HuggingFace ve ElevenLabs entegrasyonu
- **Real-Time İletişim**: SignalR ile anlık sohbet sistemi

---

## ✨ Özellikler

### 🤖 Yapay Zeka Özellikleri

#### 1. **Intelligent Chat System (SignalR + OpenAI GPT-4)**
- Real-time AI destekli müşteri sohbet sistemi
- GPT-4o-mini modeli ile streaming yanıtlar
- Conversation history management
- WebSocket tabanlı anlık mesajlaşma

#### 2. **Smart Message Categorization (Google Gemini)**
- Gelen müşteri mesajlarını otomatik kategorize etme
- Kategoriler: Kasko, Trafik Sigortası, Sağlık, Konut, Hasar Bildirimi, Fiyat Teklifi, Poliçe Yenileme
- Gemini 2.5 Flash modeli kullanımı

#### 3. **Priority Detection System (Google Gemini)**
- Mesaj öncelik seviyesi belirleme (High, Medium, Low)
- Acil durumları otomatik tespit etme
- Intelligent routing için AI bazlı karar verme

#### 4. **Auto-Response with Claude AI**
- Anthropic Claude ile otomatik müşteri yanıtları
- Kurumsal ve samimi ton dengelemesi
- E-posta entegrasyonu ile otomatik yanıt gönderimi
- MailKit kullanarak SMTP entegrasyonu

#### 5. **Content Generation (Multiple AI Models)**
- **Google Gemini**: Blog ve hakkımızda içeriği üretimi
- **Anthropic Claude**: Hizmet açıklamaları oluşturma
- Otomatik SEO-friendly içerik üretimi

#### 6. **Toxicity Detection (HuggingFace)**
- Kullanıcı yorumlarını toxic içerik için analiz etme
- Helsinki-NLP/opus-mt-tr-en:  Türkçe-İngilizce çeviri
- unitary/toxic-bert:  Toxicity detection
- Otomatik içerik moderasyonu

#### 7. **User Behavior Analysis (Google Gemini)**
- Kullanıcı yorumlarını analiz etme
- Duygu durumu tespiti (Pozitif, Negatif, Nötr)
- İlgi alanları ve konu başlıkları çıkarma
- Profil bazlı AI raporları

#### 8. **Insurance Recommendation System (AI)**
- Kullanıcı profiline göre sigorta paketi önerisi
- Yaş, meslek, şehir, medeni durum, bütçe analizi
- Kronik hastalık ve seyahat sıklığı değerlendirmesi
- İkincil seçenek önerisi ve detaylı açıklama

#### 9. **Voice Assistant (ElevenLabs AI)**
- Text-to-Speech (TTS) entegrasyonu
- Sigorta sorularına sesli yanıt
- MP3 format ses dosyası üretimi
- Özelleştirilebilir ses ayarları (stability, similarity_boost)

#### 10. **Sales Forecasting (ML.NET)**
- Time Series tahminleme
- Poliçe satış tahminleri
- SSA (Singular Spectrum Analysis) algoritması
- Minimum 8 veri noktası ile çalışma

### 🔐 Kimlik Doğrulama ve Yetkilendirme
- ASP.NET Core Identity
- Role-based authorization
- Secure authentication

### 📊 Admin Panel
- Dinamik içerik yönetimi
- Kullanıcı yönetimi
- Mesaj ve yorum moderasyonu
- Blog ve hizmet yönetimi
- AI destekli içerik oluşturma araçları

### 🎨 Modern UI/UX
- Responsive tasarım
- Bootstrap 5 entegrasyonu
- Bootstrap Icons
- Modern card-based layout
- Smooth animations

---

## 🛠️ Teknoloji Stack

### Backend Technologies
```
- .NET 9.0
- ASP.NET Core MVC
- C# 12
- Entity Framework Core 9.0
- ASP.NET Core Identity
- SignalR (Real-time communication)
```

### Frontend Technologies
```
- HTML5
- CSS3
- JavaScript
- Bootstrap 5
- Razor View Engine
- SignalR Client
```

### Database
```
- Microsoft SQL Server
- Entity Framework Core (Code-First)
```

### AI/ML Services
```
- OpenAI GPT-4o-mini (Chat completion, streaming)
- Google Gemini 2.5 Flash (Categorization, priority detection, content generation)
- Anthropic Claude 2 & Claude Sonnet 4. 5 (Auto-response, service generation)
- HuggingFace Inference API: 
  - Helsinki-NLP/opus-mt-tr-en (Turkish to English translation)
  - unitary/toxic-bert (Toxicity detection)
- ElevenLabs API (Text-to-Speech)
- ML.NET 5.0 (Time series forecasting)
```

### Other Libraries & Tools
```
- MailKit 4.14.1 (Email sending)
- MimeKit (Email construction)
- PdfPig 0.1.11 (PDF processing)
- System.Text.Json (JSON serialization)
```

---

## 🤖 Yapay Zeka Entegrasyonları

### 1. OpenAI GPT-4
**Kullanım Alanı**: Real-time chat sistemi  
**Model**: `gpt-4o-mini`  
**Özellikler**:
- Streaming responses
- Conversation history
- Temperature:  0.2 (tutarlı yanıtlar)
- System prompt:  "You are a helpful assistant"

```csharp
// Program.cs
builder.Services.AddHttpClient("openai", client =>
{
    client.BaseAddress = new Uri("https://api.openai.com");
});
```

### 2. Google Gemini
**Kullanım Alanı**: Kategorizasyon, öncelik tespiti, içerik üretimi  
**Model**: `gemini-2.5-flash`  
**Özellikler**: 
- Sigorta kategori tespiti
- Öncelik seviyesi belirleme (High/Medium/Low)
- Blog ve about içerik üretimi
- Kullanıcı davranış analizi

```csharp
// AIService.cs
private readonly string _model = "gemini-2.5-flash";
```

### 3. Anthropic Claude
**Kullanım Alanı**: Otomatik müşteri yanıtları, hizmet açıklamaları  
**Modeller**: `claude-2`, `claude-sonnet-4-5`  
**Özellikler**:
- Kurumsal ton ile yanıt üretimi
- E-posta entegrasyonu
- 5 farklı hizmet açıklaması üretimi
- Max tokens: 512-1000

```csharp
// DefaultController.cs
var requestBody = new
{
    model = "claude-2",
    max_tokens_to_sample = 1000,
    temperature = 0.5
};
```

### 4. HuggingFace Models
**Kullanım Alanı**: Yorum analizi ve moderasyon  
**Modeller**:
- `Helsinki-NLP/opus-mt-tr-en`: Türkçe → İngilizce çeviri
- `unitary/toxic-bert`: Toxicity detection

**Workflow**:
1. Türkçe yorum alınır
2. HuggingFace ile İngilizceye çevrilir
3. Toxic-BERT ile analiz edilir
4. Toxic ise yorum reddedilir

```csharp
// BlogController.cs - AddComment
var translateResponse = await client.PostAsync(
    "https://api-inference.huggingface.co/models/Helsinki-NLP/opus-mt-tr-en", 
    translateContent
);
```

### 5. ElevenLabs TTS
**Kullanım Alanı**: Sesli yanıt sistemi  
**Özellikler**:
- Text-to-Speech dönüşümü
- MP3 format
- Voice settings:  stability (0.5), similarity_boost (0.8)
- Multilingual v2 model desteği

```csharp
// ElevenLabsAIController.cs
voice_settings = new
{
    stability = 0.5,
    similarity_boost = 0.8
}
```

### 6. ML.NET Time Series
**Kullanım Alanı**: Satış tahminleme  
**Algoritma**:  Singular Spectrum Analysis (SSA)  
**Özellikler**:
- Poliçe satış tahminleri
- Minimum 8 veri noktası
- 3 aylık tahmin horizon
- Window size: veri sayısının 1/4'ü

```csharp
// ForecastService.cs
var forecastPipeline = _mlContext. Forecasting.ForecastBySsa(
    outputColumnName: nameof(PolicySalesForecast.SalesForecast),
    inputColumnName: nameof(PolicySalesData.SalesCount),
    windowSize: windowSize,
    seriesLength: seriesLength,
    trainSize: salesData.Count,
    horizon: horizon
);
```

---

## 📁 Proje Yapısı

```
InsureYouAI/
│
├── 📂 Controllers/             # MVC Controllers
│   ├── DefaultController.cs    # Ana sayfa ve mesajlar
│   ├── BlogController.cs       # Blog ve yorum yönetimi
│   ├── ServiceController.cs    # Hizmet yönetimi + AI
│   ├── AppUserController.cs    # Kullanıcı yönetimi + AI analiz
│   ├── MessageController.cs    # Mesaj kategorizasyon + AI
│   └── ElevenLabsAIController. cs # TTS entegrasyonu
│
├── 📂 Services/                # Business Logic
│   ├── AIService.cs            # Gemini entegrasyonu
│   └── ForecastService.cs      # ML.NET tahminleme
│
├── 📂 Models/                  # ViewModels & SignalR Hubs
│   ├── ChatHub.cs              # SignalR + OpenAI chat
│   └── AIInsuranceRecommendationViewModel. cs
│
├── 📂 Entities/                # Domain Models
│   ├── AppUser.cs              # Identity User
│   ├── Policy.cs               # Poliçe modeli
│   ├── Message.cs              # Mesaj modeli
│   ├── Comment.cs              # Yorum modeli
│   ├── Blog.cs                 # Blog modeli
│   ├── Service.cs              # Hizmet modeli
│   ├── AboutItem.cs            # Hakkımızda modeli
│   └── Testimonial.cs          # Referans modeli
│
├── 📂 Context/                 # Database Context
│   └── InsureContext.cs        # EF Core DbContext
│
├── 📂 Views/                   # Razor Views
│   ├── Default/                # Ana sayfa views
│   ├── Blog/                   # Blog views
│   ├── Service/                # Hizmet views
│   ├── Message/                # Mesaj views
│   ├── AdminLayout/            # Admin panel layout
│   └── Shared/                 # Shared components
│
├── 📂 ViewComponents/          # View Components
│   └── DefaultViewComponents/  # Ana sayfa componentleri
│
├── 📂 wwwroot/                 # Static files
│   ├── css/                    # Stylesheets
│   ├── js/                     # JavaScript files
│   ├── voices/                 # ElevenLabs generated audio
│   └── images/                 # Image assets
│
├── 📄 Program.cs               # Application startup
├── 📄 appsettings.json         # Configuration
└── 📄 InsureYouAI.csproj       # Project file
```

---

## 🚀 Kurulum

### Gereksinimler

- .NET 9.0 SDK
- SQL Server (LocalDB veya Express)
- Visual Studio 2022 / VS Code / Rider

### API Keys (Gerekli)

Projeyi çalıştırmak için aşağıdaki API anahtarlarına ihtiyacınız var:

```
- OpenAI API Key      → ChatHub.cs
- Google Gemini Key   → AIService.cs
- Anthropic Claude    → DefaultController.cs, ServiceController.cs
- HuggingFace Token   → BlogController.cs
- ElevenLabs API Key  → ElevenLabsAIController.cs
```

### Adım Adım Kurulum

1. **Repoyu Klonlayın**
```bash
git clone https://github.com/mertagralii/InsureYouAI. git
cd InsureYouAI
```

2. **API Anahtarlarını Ekleyin**

Aşağıdaki dosyalarda `YOUR_API_KEY_HERE` yazan yerleri kendi API anahtarlarınızla değiştirin: 
- `Models/ChatHub.cs` (Line 10:  OpenAI)
- `Services/AIService.cs` (Line 10: Google Gemini)
- `Controllers/DefaultController.cs` (Line 40: Claude)
- `Controllers/BlogController.cs` (Line 59: HuggingFace)
- `Controllers/ElevenLabsAIController. cs` (ElevenLabs)

3. **Database Migration**
```bash
dotnet ef database update
```

4. **Projeyi Çalıştırın**
```bash
dotnet run
```

5. **Tarayıcıda Açın**
```
https://localhost:5001
```

---

## 🎓 Öğrenilen Teknolojiler

Bu proje kapsamında öğrenilen ve uygulanan teknolojiler: 

### Backend Development
✅ **ASP.NET Core MVC** - Modern web uygulaması geliştirme  
✅ **Entity Framework Core** - Code-First approach, migrations  
✅ **ASP.NET Core Identity** - Authentication & Authorization  
✅ **SignalR** - Real-time communication  
✅ **Dependency Injection** - IoC Container kullanımı

### AI & Machine Learning
✅ **OpenAI GPT-4 API** - Chat completion, streaming  
✅ **Google Gemini API** - Text generation, classification  
✅ **Anthropic Claude API** - Advanced text generation  
✅ **HuggingFace Inference API** - Translation, toxicity detection  
✅ **ElevenLabs API** - Text-to-Speech  
✅ **ML.NET** - Time series forecasting

### API Integration
✅ **RESTful API consumption** - HttpClient usage  
✅ **JSON serialization** - System.Text.Json  
✅ **HTTP streaming** - Server-sent events  
✅ **API authentication** - Bearer tokens, API keys

### Email & Communication
✅ **MailKit & MimeKit** - SMTP email sending  
✅ **Automated email responses** - AI-generated content

### Design Patterns & Architecture
✅ **Repository Pattern** - Data access layer  
✅ **Service Layer Pattern** - Business logic separation  
✅ **ViewComponent Pattern** - Reusable UI components  
✅ **Async/Await** - Asynchronous programming

### Frontend
✅ **Razor View Engine** - Dynamic HTML generation  
✅ **Bootstrap 5** - Responsive design  
✅ **SignalR Client** - JavaScript integration  
✅ **AJAX** - Asynchronous requests

---
