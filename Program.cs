﻿using System;
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
      string Path = @"C:\Users\vyati\source\repos\Lab4\temp.txt";

      FileStream FileUser = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);

      ClassFile Filek = new ClassFile(FileUser);

      Console.WriteLine(Filek.FileUserContent);

      FileStream BinaryFile = new FileStream(@"C:\Users\vyati\source\repos\Lab4\tempb.bin",
        FileMode.OpenOrCreate, FileAccess.ReadWrite);

      Filek.BinarySerialize(BinaryFile);

      BinaryFile.Close();

      Filek = new ClassFile(@"C:\Users\vyati\source\repos\Lab4\temp2.txt");

      BinaryFile = new FileStream(@"C:\Users\vyati\source\repos\Lab4\tempb.bin",
        FileMode.OpenOrCreate, FileAccess.ReadWrite);

      Console.WriteLine(Filek.FileUserContent);

      Filek.BinaryDeserialize(BinaryFile);

      Console.WriteLine(Filek.FileUserContent);

      FileStream XmlFile = new FileStream(@"C:\Users\vyati\source\repos\Lab4\tempb.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);

      Filek.XMLSerialization(XmlFile);


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
