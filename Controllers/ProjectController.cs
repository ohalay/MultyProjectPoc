using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MultyProjectPoc.Controllers
{
    public abstract class ProjectController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAncestor;

        public ProjectController(IHttpContextAccessor httpContextAncestor)
        {
            _httpContextAncestor = httpContextAncestor;
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ViewData["project"] = _httpContextAncestor.HttpContext.Items.TryGetValue(Const.ProjectKey, out var value) 
                ? ViewData["project"] = $"/{value}"
                : ViewData["project"] = "";

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
