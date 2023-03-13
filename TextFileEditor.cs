using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4 {
  class TextFileEditor : ClassFile {

    public static void EditorMenu(string FilePath) {
      Console.WriteLine("Что сделать с файлом:\n1. Сериализовать/Десериализовать\n2. Вписать текст\n" +
        "3. Поиск файлов в директории по ключевым словам\n4. Откатить изменения в файле\nВыберите нужный пункт: ");
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

              break;
            case 2:
              FileTXT.BinaryDeserialize(FileDeserSer);

              break;
            case 3:
              FileTXT.XMLSerialize(FileDeserSer);

              break;
            case 4:
              FileTXT.XMLDeserialize(FileDeserSer);

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

          Caretaker CT = new Caretaker();
          CT.SaveState(FileTXT);

          SW.WriteLine(UserText);
          SW.Close();

          Console.WriteLine("Изменения сохранены!");

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
          Console.WriteLine("Вы уверены что хотите откатить изменения? Ответье ДА или НЕТ");
          string UserAnswer = Console.ReadLine();
          CT = new Caretaker();

          if (UserAnswer.ToLower() == "да") {
            CT.RestoreState(FileTXT);
            FileTXT.FileEnterData(FilePath);
            Console.WriteLine("Изменения откатились!");
          }

          EditorMenu(FilePath);
          break;
        default:
          Console.WriteLine("Такого пункта не существует! Попробуйте снова!");

          EditorMenu(FilePath);
          break;
      }

    }
  }
}
