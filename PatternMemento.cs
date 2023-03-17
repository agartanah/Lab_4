using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4 {
  public interface IOriginator {
    object GetMemento();
    void SetMemento(object memento);
  }

  class PatternMemento {
    public string FileUserContent { get; set; }
  }

  public class Caretaker {
    private object Memento;
    public void SaveState(IOriginator Originator) {
      Memento = Originator.GetMemento();
    }

    public void RestoreState(IOriginator Originator) {
      Originator.SetMemento(Memento);
    }
  }
}
