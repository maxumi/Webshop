namespace OOP_Dag_6_Webshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu= new Menu();//Creates Instance of Menu.
            menu.LoginScreen();//Login Screen.
            menu.MainMenu();//If login is succesfull, open the main menu.

        }
    }
}