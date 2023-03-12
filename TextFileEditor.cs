using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4 {
  class TextFileEditor : ClassFile, IOriginator {

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
      return new PatternMemento { FileUserContent = this.FileUserContent };
    }

    void IOriginator.SetMemento(object memento) {
      if (memento is PatternMemento) {
        var mem = memento as PatternMemento;
        FileUserContent = mem.FileUserContent;
      }
    }

    static Caretaker CT = new Caretaker();
    static ClassFile CF = new ClassFile();

    public static void EditorMenu(string FilePath) {
      Console.WriteLine("Что сделать с файлом:\n1. Сериализовать/Десериализовать\n2. Вписать текст\n" +
        "3. Поиск файлов в директории по ключевым словам\n4. Сохранить изменения файла\n" +
        "5. Откатить изменения в файле\nВыберите нужный пункт: ");
      int UserChoice = int.Parse(Console.ReadLine());

      ClassFile FileTXT = new ClassFile(FilePath);

      switch (UserChoice) {
        case 1:
          Console.WriteLine("Введите куда сериализовать/десериализовать");
          string DeserSerPath = Console.ReadLine();
          FileStream FileDeserSer = new FileStream(DeserSerPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

          Console.WriteLine("1. Сериализовать бинарно\n2. XML-сериализация\n3. Десериализовать бинарно\n" +
            "4. XML-десериализация\nВыберите нужный пункт.");
          int UserChoice2 = int.Parse(Console.ReadLine());

          switch (UserChoice2) {
            case 1:
              FileTXT.BinarySerialize(FileDeserSer);

              EditorMenu(FilePath);
              break;
            case 2:
              FileTXT.BinaryDeserialize(FileDeserSer);

              EditorMenu(FilePath);
              break;
            case 3:
              FileTXT.XMLSerialize(FileDeserSer);
              break;
            case 4:
              FileTXT.XMLDeserialize(FileDeserSer);

              EditorMenu(FilePath);
              break;
            default:
              Console.WriteLine("Нет такого пункта! Попробуйте ещё раз!");
              break;
            }

          EditorMenu(FilePath);
          break;
        case 2:
          StreamWriter SW = new StreamWriter(FilePath);

          Console.WriteLine("Ваш текст, который нужно вписать:");
          string UserText = Console.ReadLine();

          SW.WriteLine(UserText);
          SW.Close();

          EditorMenu(FilePath);
          break;
        case 3:
          Console.Write("Введите ключевое слово (фразу): ");
          string KeyWords = Console.ReadLine();

          Console.WriteLine("Введите полный путь директории: ");
          string DirectoryPath = Console.ReadLine();

          List<string> ListFiles = SearchFiles.FilesKeyWordSearch(DirectoryPath, KeyWords);

          foreach (var ListElement in ListFiles) {
            Console.WriteLine(ListElement);
          }

          EditorMenu(FilePath);
          break;
        case 4:
          CT.SaveState(CF);

          break;
        case 5:
          break;
        default:
          Console.WriteLine("Такого пункта не существует! Попробуйте снова!");
          EditorMenu(FilePath);
          break;
      }

    }
  }
}
