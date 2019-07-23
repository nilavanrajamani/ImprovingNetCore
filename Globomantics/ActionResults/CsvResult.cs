using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.ActionResults
{
    public class CsvResult : IActionResult
    {
        private IEnumerable sourceData;
        private string fileName;

        public CsvResult(IEnumerable data, string fileName)
        {
            this.sourceData = data;
            this.fileName = fileName;
        }
        public Task ExecuteResultAsync(ActionContext context)
        {
            var builder = new StringBuilder();
            var stringWriter = new StringWriter(builder);

            foreach (var rate in sourceData)
            {
                var properties = rate.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    stringWriter.Write(GetValue(rate, prop.Name));
                    stringWriter.Write(", ");
                }
                stringWriter.WriteLine();
            }

            var csvBytes = Encoding.ASCII.GetBytes(stringWriter.ToString());

            context.HttpContext.Response.Headers["content-disposition"] = "attachment; filename=" + fileName + ".csv";
            return context.HttpContext.Response.Body.WriteAsync(csvBytes, 0, csvBytes.Length);
        }

        private static string GetValue(object item, string propName)
        {
            return item.GetType().GetProperty(propName).GetValue(item, null).ToString() ?? "";
        }
    }
}
