         /********************************
          *   Автор: Вяткин Владислав    *
          * Тема: Стандартный ввод/вывод *
          *      Дата: 17.03.2023        *
          ********************************/ 

using System;

namespace Lab_4 {
  class Program {
    static void Main(string[] args) {
      Console.Write("Введите полный путь к текстовому файлу: ");
      string FileTXTPath = Console.ReadLine();

      TextFileEditor.EditorMenu(FileTXTPath);
    }
  }
}
