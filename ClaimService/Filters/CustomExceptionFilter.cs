using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClaimServices.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Step 1: Create Logs folder if not exists
            var logFolder = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }

            // Step 2: File path
            var filePath = Path.Combine(logFolder, "ErrorLog.txt");

            // Step 3: Write error details
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("-------------");
                writer.WriteLine("Date: " + DateTime.Now);

                writer.WriteLine("Controller: " + context.RouteData.Values["controller"]);
                writer.WriteLine("Action: " + context.RouteData.Values["action"]);

                writer.WriteLine("Error Message: " + context.Exception.Message);
                writer.WriteLine("StackTrace: " + context.Exception.StackTrace);
            }

            // Step 4: Handle exception (VERY IMPORTANT)
            context.ExceptionHandled = true;

            // Step 5: Return proper response
            context.Result = new ObjectResult(new
            {
                Message = "Something went wrong. Please try again later."
            })
            {
                StatusCode = 500
            };
        }
    }
}