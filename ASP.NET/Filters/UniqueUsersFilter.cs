using Microsoft.AspNetCore.Mvc.Filters;
public class UniqueUsersFilter : ActionFilterAttribute
{
    private readonly string _filePath ="users.txt";

    override public void OnActionExecuting(ActionExecutingContext context)
    {
        var userIdentifier = context.HttpContext.Connection.RemoteIpAddress.ToString();
        try { 
            using (var reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim() == userIdentifier)
                    {
                        return;
                    }
                }
            }
        }
        catch (FileNotFoundException ex) {
            Console.WriteLine(ex.Message);
        }
        using (var writer = new StreamWriter(_filePath, append: true))
        {
            writer.WriteLine(userIdentifier);
        }
        
    }
}