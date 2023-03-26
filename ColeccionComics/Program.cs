namespace ColeccionComics {
    internal class Program {
        static void Main (string [] args) {

            IMenu consola = new MenuConsole("CRUD Comics Console");

            CRUDComicsController control = new CRUDComicsController(consola);
        }
    }
} 