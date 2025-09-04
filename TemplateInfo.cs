using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyiFFmpegUI
{
    internal class TemplateInfo
    {
        public TemplateInfo()
        {
        }

        public string Name { get; set; } = "";
        public string Format { get; set; } = "";
        public string Params { get; set; } = "";

        public override string ToString()
        {
            return this.Name;
        }

    }
}
