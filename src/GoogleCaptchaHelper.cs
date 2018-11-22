using LexLibrary.Google.reCAPTCHA.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace LexLibrary.Google.reCAPTCHA
{
    public static class GoogleCaptchaHelper
    {
        public static HtmlString GooglereCaptchaV2(this IHtmlHelper helper)
        {
            var setting = helper.ViewContext.HttpContext.RequestServices.GetRequiredService<GoogleCaptchaSetting>();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<!-- LexLibrary.Google.reCAPTCHA.v2 by lex.xu(https://blog.exfast.me) -->");
            sb.AppendLine("<script src='https://www.google.com/recaptcha/api.js'></script>");
            sb.AppendLine("<div class='g-recaptcha' data-sitekey='{0}'></div>");
            sb.AppendLine("<!-- LexLibrary.Google.reCAPTCHA.v2 by lex.xu(https://blog.exfast.me) -->");
            sb.Replace("{0}", setting.Sitekey);

            return new HtmlString(sb.ToString());
        }

        public static HtmlString GooglereCaptchaV3(this IHtmlHelper helper, string action)
        {
            var setting = helper.ViewContext.HttpContext.RequestServices.GetRequiredService<GoogleCaptchaSetting>();

            if (string.IsNullOrWhiteSpace(action))
            {
                throw new ArgumentNullException(nameof(action));
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<!-- LexLibrary.Google.reCAPTCHA.v3 by lex.xu(https://blog.exfast.me) -->");
            sb.AppendLine("<input type='hidden' name='g-recaptcha-response' id='g-recaptcha-response'>");
            sb.AppendLine(@"
<script>
    if(!window.grecaptcha) {
        var scriptGooglereCaptchaV3 = document.createElement('script');
        scriptGooglereCaptchaV3.type = 'text/javascript';
        scriptGooglereCaptchaV3.src = 'https://www.google.com/recaptcha/api.js?render={0}';
        scriptGooglereCaptchaV3.onload = callbackGooglereCaptchaV3;
        document.body.appendChild(scriptGooglereCaptchaV3);
    }
    function callbackGooglereCaptchaV3() {
        grecaptcha.ready(function() {
            grecaptcha.execute('{0}', {action: '{1}'}).then(function(token) {
                document.getElementById('g-recaptcha-response').value = token;
            });
        });
    }
</script>");
            sb.AppendLine("<!-- LexLibrary.Google.reCAPTCHA.v3 by lex.xu(https://blog.exfast.me) -->");
            sb.Replace("{0}", setting.Sitekey);
            sb.Replace("{1}", action);
            return new HtmlString(sb.ToString());
        }
    }
}
