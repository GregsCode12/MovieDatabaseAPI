using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.ResponseCaching;
using MovieDatabaseAPI.Data;

namespace MovieDatabaseAPI
{
    public class CounterActionFilter : IActionFilter
    {
        private readonly AppDbContext _context;

       public CounterActionFilter(AppDbContext context)
        {
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            var RequestCount = _context.RequestCount.Where(p => p.Id == 1).FirstOrDefault();
           if (RequestCount==null)
            {
                RequestCount = new Data.Models.RequestCount(){ Count = 1 };
                _context.RequestCount.Add(RequestCount);
            } else {
                RequestCount.Count++;
            }
            _context.SaveChanges();
        }
    }
}
