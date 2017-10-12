using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Html;

namespace RazorPagesLocalization.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHtmlLocalizer _loc;

        public IndexModel(IHtmlLocalizerFactory htmlLocalizerFactory)
        {
            _loc = htmlLocalizerFactory.Create("RazorPagesLocalization.Pages.Index", "RazorPagesLocalization");
        }

        public IHtmlContent Message { get; set; }

        public void OnGet()
        {
            Message = _loc["Hello"];
        }
    }
}
