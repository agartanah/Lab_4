using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Lab_4 {
  class SearchFiles {
    public static List<string> FilesKeyWordSearch(string DirectoryPath, string KeyWords) {
      List<string> ListResult = new List<string>();
      var FilesInDirectoryTXT = Directory.EnumerateFiles(DirectoryPath, "*.txt", SearchOption.AllDirectories);

      foreach (var FileTXT in FilesInDirectoryTXT) {
        string FileTXTTitle = FileTXT.Substring(DirectoryPath.Length);

        if (File.ReadLines(DirectoryPath + FileTXTTitle).Any(line => line.Contains(KeyWords)) 
          || FileTXTTitle.Contains(KeyWords)) {
          ListResult.Add(FileTXTTitle);
        }
      }

      return ListResult;
    }
  }
}
