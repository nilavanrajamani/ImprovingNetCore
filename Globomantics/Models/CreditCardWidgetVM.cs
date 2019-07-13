using Globomantics.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class CreditCardWidgetVM
    {
        public List<Rate> Rates { get; set; }
        public string WidgetTitle { get; set; }
        public string WidgetSubTitle { get; set; }
    }
}
