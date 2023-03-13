﻿using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4 {

  [Serializable]
  public class ClassFile : IOriginator {
    public string FileUserContent { get; set; }

    public ClassFile() {
      FileUserContent = default;
    }

    public ClassFile(FileStream FileUser) {
      StreamReader SR = new StreamReader(FileUser);

      while (SR.EndOfStream != true) {
        FileUserContent += SR.ReadLine() + "\n";
      }

      SR.Close();
    }

    public ClassFile(string Path) {
      FileStream FileUser = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
      StreamReader SR = new StreamReader(FileUser);

      while (SR.EndOfStream != true) {
        FileUserContent += SR.ReadLine() + "\n";
      }

      SR.Close();
      FileUser.Close();
    }

    class PatternMemento {
      public string FileUserContent { get; set; }
    }

    public class Caretaker {
      private object Memento;
      public void SaveState(IOriginator Originator) {
        Originator.SetMemento(Memento);
      }

      public void RestoreState(IOriginator Originator) {
        Memento = Originator.GetMemento();
      }
    }

    object IOriginator.GetMemento() {
      Console.WriteLine($"Текст файла {this.FileUserContent}");
      return new PatternMemento { FileUserContent = this.FileUserContent };
    }

    void IOriginator.SetMemento(object memento) {
      if (memento is PatternMemento) {
        var mem = memento as PatternMemento;

        FileUserContent = mem.FileUserContent;
      }
    }

    public void FileEnterData(string FilePath) {
      StreamWriter SW = new StreamWriter(FilePath);

      SW.WriteLine(FileUserContent);

      SW.Close();
    }
    public void BinarySerialize(FileStream FileBinary) {
      BinaryFormatter Binary = new BinaryFormatter();

      Binary.Serialize(FileBinary, this);
      FileBinary.Flush();
      FileBinary.Close();
    }

    public void BinaryDeserialize(FileStream FileBinary) {
      BinaryFormatter BinaryFile = new BinaryFormatter();
      ClassFile DeserializedFile = (ClassFile)BinaryFile.Deserialize(FileBinary);

      FileUserContent = DeserializedFile.FileUserContent;
      FileBinary.Close();
    }

    public void XMLSerialize(FileStream FileXml) {
      XmlSerializer Xml = new XmlSerializer(this.GetType());

      Xml.Serialize(FileXml, this);
      FileXml.Flush();
      FileXml.Close();
    }

    public void XMLDeserialize(FileStream FileXml) {
      XmlSerializer Xml = new XmlSerializer(typeof(ClassFile));
      ClassFile DeserializedFile = (ClassFile)Xml.Deserialize(FileXml);

      FileUserContent = DeserializedFile.FileUserContent;
      FileXml.Close();
    }
  }
}

