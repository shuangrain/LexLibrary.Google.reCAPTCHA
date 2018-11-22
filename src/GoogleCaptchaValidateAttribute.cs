using LexLibrary.Google.reCAPTCHA.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LexLibrary.Google.reCAPTCHA
{
    public class GoogleCaptchaValidateAttribute : ActionFilterAttribute
    {
        public GoogleCaptchaVersion Version { get; set; }

        public string ErrorMessage { get; set; }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var services = context.HttpContext.RequestServices;
            var setting = services.GetRequiredService<GoogleCaptchaSetting>();

            var request = context.HttpContext.Request;
            if (request == null || request.Form == null || !request.Form.Keys.Contains(GoogleCaptchaSetting.FormKey))
            {
                addModelError(context, "Google reCAPTCHA Token Not Found");
            }
            else
            {
                string token = request.Form[GoogleCaptchaSetting.FormKey];

                bool isValid = await validCaptcha(services, token, setting);
                if (!isValid)
                {
                    addModelError(context, "Invalid Google reCAPTCHA");
                }
            }

            await base.OnActionExecutionAsync(context, next);
        }

        /// <summary>
        /// 新增 Error 訊息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="error"></param>
        private void addModelError(ActionExecutingContext context, string error)
        {
            if (!string.IsNullOrWhiteSpace(ErrorMessage))
            {
                error = ErrorMessage;
            }

            context.ModelState.AddModelError(string.Empty, error);
        }

        private async Task<bool> validCaptcha(IServiceProvider services, string token, GoogleCaptchaSetting setting)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return false;
            }

            var httpClientFactory = services.GetService<IHttpClientFactory>();
            var hc = httpClientFactory.CreateClient(nameof(GoogleCaptchaValidateAttribute));

            var query = new Dictionary<string, string>();

            query.Add("secret", setting.Secretkey);
            query.Add("response", token);

            string stringResult = null;
            using (var content = new FormUrlEncodedContent(query))
            {
                var postResult = await hc.PostAsync(setting.ApiVerificationEndpoint, content);
                stringResult = await postResult.Content.ReadAsStringAsync();
            }

            var model = JsonConvert.DeserializeObject<ResponseDTO>(stringResult);

            switch (Version)
            {
                case GoogleCaptchaVersion.v2:
                    {
                        return (model != null && model.Success);
                    }
                case GoogleCaptchaVersion.v3:
                    {
                        return (model != null && model.Success && model.Score > 0.5);
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }
        }

    }
}
