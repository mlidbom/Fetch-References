#region usings

using System;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using SearchOption = System.IO.SearchOption;

#endregion

namespace FetchReferences
{
    public class Reference
    {
        public Reference(string name, string version)
        {
            Name = name;
            Version = version;
        }

        public string Name { get; private set; }
        public string Version { get; private set; }

        private DirectoryInfo TargetDirectory
        {
            get { return new DirectoryInfo(Configured.LocalStorage.FullName + @"\" + Name); }
        }


        private DirectoryInfo SourceDirectory
        {
            get
            {
                DirectoryInfo referenceRootDirectory;
                try
                {
                    referenceRootDirectory = Configured.Repository.
                        GetDirectories(Name, SearchOption.AllDirectories)
                        .Single();
                }
                catch (Exception e)
                {
                    throw new Exception(
                        String.Format(
                            "Could not locate folder: {0} anywhere below path:{1}",
                            Name, Configured.Repository),
                        e);
                }

                try
                {
                    return referenceRootDirectory.GetDirectories(Version).Single();
                }
                catch (Exception exception)
                {
                    throw new Exception(
                        String.Format("Failed to find directory {0} under {1}",
                                      Version, referenceRootDirectory),
                        exception);
                }
            }
        }

        public void CopyLocal()
        {
            Console.WriteLine("Fetching: {0} Version: {1} \n\tSource: {2}\n\tTarget: {3}",
                Name, Version, SourceDirectory.FullName, TargetDirectory.FullName);
            
            if (TargetDirectory.Exists)
            {
                Console.WriteLine("\tDeleting Target");
                TargetDirectory.Delete(true);
            }            

            Console.WriteLine("\tCopying");
            FileSystem.CopyDirectory(SourceDirectory.FullName, TargetDirectory.FullName);
        }
    }
}