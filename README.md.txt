# LexLibrary.Google.reCAPTCHA
�ϥ� HtmlHelper + ValidateAttribute �ֳt�N Google reCAPTCHA ���ҥ[�J�A������

NuGet�G[https://www.nuget.org/packages/LexLibrary.Google.reCAPTCHA/]()

Blog�G[https://blog.exfast.me]()

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
[GoogleCaptchaValidate(Version = GoogleCaptchaVersion.v2, ErrorMessage = "���ҥ��ѡA�Э��s�A�աC")]
[GoogleCaptchaValidate(Version = GoogleCaptchaVersion.v3, ErrorMessage = "���ҥ��ѡA�Э��s�A�աC")]
````