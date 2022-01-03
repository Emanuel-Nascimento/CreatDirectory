using System;
using System.IO;

namespace CreatDirectory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var folderName = "pasta";
            var subFolderName = "subpasta";
            var subFolderNameStatic = "subpasta_usingstatic";

            var directoryInfoSubfolder = new DirectoryInfo(subFolderName);
            if(!Directory.Exists(folderName) || !directoryInfoSubfolder.Exists)
            {
                Directory.CreateDirectory(folderName);
                Directory.CreateDirectory(subFolderNameStatic);
                directoryInfoSubfolder.Create();

                directoryInfoSubfolder.MoveTo($"{folderName}//{subFolderName}");
                Directory.Move(subFolderNameStatic, @$"{folderName}\{subFolderNameStatic}");
            }

            var name = directoryInfoSubfolder.Name;
            var parent = directoryInfoSubfolder.Parent;
            var root = directoryInfoSubfolder.Root;
            var exists = directoryInfoSubfolder.Exists;

            foreach (var directory in Directory.GetDirectories(folderName))
            {
                Console.WriteLine(directory);
            }
            Directory.Delete($@"{folderName}\{subFolderName}");
        }
    }
}
