using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4 {
  class Program {
    static void Main(string[] args) {

      List<string> ListFiles;

      ListFiles = SearchFiles.FilesKeyWordSearch(@"C:\Users\vyati\source\repos\Lab_4\", "alone");

      foreach (var ListElement in ListFiles) {
        Console.WriteLine(ListElement);
      }

      //MyFile.BinarySerialize(FileF);
      //FileStream fs = new
      //FileStream(@"C:\Users\vyati\source\repos\Lab4\FullNameSerialize.bin",
      //FileMode.OpenOrCreate, FileAccess.Write);
      //FullNameClass fnc = new FullNameClass("Ivan", "Ivanov", "Ivanovich");
      //fnc.Print();
      //fnc.Serialize(fs);
      //fnc = new FullNameClass("Petr", "Petrov", "Petrovich");
      //fnc.Print();
      //fs = new
      //FileStream(@"C:\Users\vyati\source\repos\Lab4\FullNameSerialize.bin",
      //FileMode.OpenOrCreate, FileAccess.Read);
      //fnc.Deserialize(fs);
      //fnc.Print();
    }
  }
}
