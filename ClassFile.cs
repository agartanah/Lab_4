﻿using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab_4 {

  [Serializable]
  public class ClassFile : IOriginator {
    public string FileUserContent { get; set; }

    public ClassFile() {
      FileUserContent = "";
    }

    public ClassFile(string Text) {
      FileUserContent = Text;

      if (FileUserContent == null) {
        FileUserContent = "";
      }
    }

    object IOriginator.GetMemento() {
      return new PatternMemento { FileUserContent = this.FileUserContent };
    }

    void IOriginator.SetMemento(object memento) {
      var mem = memento as PatternMemento;
      FileUserContent = mem.FileUserContent;
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

