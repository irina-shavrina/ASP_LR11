using Microsoft.AspNetCore.Mvc.Filters;
public class LogActionFilter : ActionFilterAttribute
{
    override public void OnActionExecuting(ActionExecutingContext context)
    {
        var methodName = context.ActionDescriptor.DisplayName;
        var currentTime = DateTime.Now;
        File.AppendAllText("log.txt", methodName+" "+ currentTime + Environment.NewLine);
    }
}

