using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppRazorPageDemo.Model;

namespace AppRazorPageDemo.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly MyBlogContext _context;

        public IndexModel(MyBlogContext context)
        {
            _context = context;
        }
        public IList<Article> Article { get;set; } 

        public async Task OnGetAsync(string searchString)
        {
            var qr = from a in _context.Articles
                    orderby a.Created descending
                    select a;
                
                if (!String.IsNullOrEmpty(searchString))
                {
                    Article = qr.Where(a => a.Title.Contains(searchString)).ToList();
                }
                else
                {
                    Article = await qr.ToListAsync();
                }
            
        }
    }
}
