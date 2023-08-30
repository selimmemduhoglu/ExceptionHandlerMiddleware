using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MiddleWares
{
    public class ExceptionHandlerMiddleware
    {
        public RequestDelegate _requestDelegate { get; }
        public ILogger<ExceptionHandlerMiddleware> _logger { get; } //bunu program.cs içine yazdık loglama mekanizmasını kurduk.

        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        //burada ki try-catch bloğu uygulama içerisindeki bütün try-catch leri yakalayacak demektir.
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);


                //Hata Yönetimi
            }

            //bu middleware class ı içerisinde ki Invoke methodu sayesinde içerisine yazdığımız
            //try-catch methodu application içerisinde nerede hata alıyorsak buraya hat aldıktan
            //sonra düşüyor elde ettiğimiz datalarla da mesaj olsun hatanın imi olun hata yönetimi
            //yapabileceğiz. bunun bize artısı ise sadece tek try-catch ile tüm uygulama içerisindeki
            //exceptionları yönetebiliyoruz.
        }

    }
}
