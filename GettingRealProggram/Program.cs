using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SourceCodeGettingReal;

namespace GettingRealUI {
    class Program {
        static void Main(string[] args) {
            Program myProgram = new Program();
            myProgram.Run();
        }

        public void Run() {
            Menu menu = new Menu();
            menu.Init();
            menu.MainMenu();
        }
    }
}
