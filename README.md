# LexLibrary.Google.reCAPTCHA
使用 HtmlHelper + ValidateAttribute 快速將 Google reCAPTCHA 驗證加入你的網站

Blog：[https://blog.exfast.me/2018/11/c-sharp-asp-net-core-quickly-add-google-recaptcha-verification-to-your-website/](https://blog.exfast.me/2018/11/c-sharp-asp-net-core-quickly-add-google-recaptcha-verification-to-your-website/)

NuGet：[https://www.nuget.org/packages/LexLibrary.Google.reCAPTCHA/](https://www.nuget.org/packages/LexLibrary.Google.reCAPTCHA/)

GitHub：[https://github.com/shuangrain/LexLibrary.Google.reCAPTCHA](https://github.com/shuangrain/LexLibrary.Google.reCAPTCHA)

# Support
- [ ] Google reCAPTCHA v1
- [x] Google reCAPTCHA v2
- [x] Google reCAPTCHA v3

# Example
新增設定檔到 `Startup.cs`
````
services.AddGoogleCaptcha(new GoogleCaptchaSetting { })
````

View
````
@Html.GooglereCaptchaV2()
@Html.GooglereCaptchaV3("/login")
````

Controller
````
[GoogleCaptchaValidate(Version = GoogleCaptchaVersion.v2, ErrorMessage = "驗證失敗，請重新再試。")]
[GoogleCaptchaValidate(Version = GoogleCaptchaVersion.v3, ErrorMessage = "驗證失敗，請重新再試。")]
````
