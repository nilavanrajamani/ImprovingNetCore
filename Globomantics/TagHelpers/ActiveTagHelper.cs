using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "active-url")]
    public class ActiveTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public string ActiveUrl { get; set; }

        public ActiveTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (httpContextAccessor.HttpContext.Request.Path.ToString().Contains(ActiveUrl))
            {
                var existingAttrs = output.Attributes["class"]?.Value;
                output.Attributes.SetAttribute("class", "active " + existingAttrs.ToString());
            }
        }
    }
}
