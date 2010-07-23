using System;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace FetchReferences
{
    public static class XElementExtensions
    {
        public static string ValueOf(this XElement me, string element)
        {
            var result = me.Attribute(element);
            if (result != null)
            {
                return result.Value;
            }

            throw new Exception(string.Format("Could not resolve attribute: {1} from element {0}", me.ToString(), element));
        }

    }
}