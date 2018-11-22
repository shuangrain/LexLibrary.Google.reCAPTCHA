# LexLibrary.Google.reCAPTCHA
使用 HtmlHelper + ValidateAttribute 快速將 Google reCAPTCHA 驗證加入你的網站

NuGet：[https://www.nuget.org/packages/LexLibrary.Google.reCAPTCHA/]()

Blog：[https://blog.exfast.me]()

# Support
- [ ] Google reCAPTCHA v1
- [x] Google reCAPTCHA v2
- [x] Google reCAPTCHA v3

# Example
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