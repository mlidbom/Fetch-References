#region usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

#endregion

namespace FetchReferences
{
    public static class Configured
    {
        static Configured()
        {
            if (!File.Exists("references.xml"))
            {
                throw new Exception("no references.xml file found. Should be in the same directory as this executable");
            }
        }


        public static DirectoryInfo Repository
        {
            get { return new DirectoryInfo(ReferencesXmlFile.ValueOf("repositoryPath")); }
        }

        public static DirectoryInfo LocalStorage
        {
            get { return new DirectoryInfo(ReferencesXmlFile.ValueOf("localPath")); }
        }

        public static IEnumerable<Reference> References
        {
            get
            {

                return ReferencesXmlFile
                    .Elements("reference")
                    .Select(reference =>
                            new Reference(name: reference.ValueOf("name"),
                                          version: reference.ValueOf("version"))
                    );
            }
        }

        private static XElement ReferencesXmlFile
        {
            get { return XElement.Load("references.xml"); }
        }
    }
}