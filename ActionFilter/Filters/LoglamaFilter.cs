namespace ActionFilter.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;

    public class LoglamaFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Eylem (action) çalışmadan önce yapılacak işlemler
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();
            string logMesaji = $"[{DateTime.Now}] - Kullanıcı {controller}/{action} eylemini gerçekleştirdi.";
            // LogMesaji'yi bir log dosyasına yazabilir veya başka bir loglama servisi kullanabilirsiniz.
            Console.WriteLine(logMesaji);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Eylem (action) çalıştıktan sonra yapılacak işlemler

            Console.WriteLine("ACTİON TAMAMLANDI" + DateTime.Now.ToLongTimeString());
        }
        //public void OnActionExecuted(ActionExecutedContext context)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
