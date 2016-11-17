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
