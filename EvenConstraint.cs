namespace RazorPages;

public class EvenConstraint : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        int id;

        if (Int32.TryParse((values["id"] ?? 1).ToString(), out id))
        {
            if (id % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}