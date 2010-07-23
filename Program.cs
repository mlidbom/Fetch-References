namespace FetchReferences
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (Configured.LocalStorage.Exists)
            {
                Configured.LocalStorage.Delete(true);
            }

            foreach (var reference in Configured.References)
            {
                reference.CopyLocal();
            }
        }
    }
}