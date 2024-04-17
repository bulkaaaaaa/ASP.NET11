using Microsoft.AspNetCore.Mvc.Filters;

namespace LR11.Filters
{
    public class UniqueUserFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // отримання IP-адреси користувача
            var userId = context.HttpContext.Connection.RemoteIpAddress.ToString(); 

            string filePath = @"D:\Logs\UsersUnique.txt";
            bool isNewUser = !File.Exists(filePath) || !File.ReadAllLines(filePath).Contains(userId);

            if (isNewUser)
            {
                // запис ідентифікатора у файл
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(userId);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // потрібно щось виконати після виконання дії
        }
    }
}
