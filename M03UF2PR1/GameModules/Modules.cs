using System.Data;

namespace GameModules
{
    public class Modules
    {

        //Comprueba que una cadena tenga 4 palabras separadas por una coma y un espacio (se utiliza en la asignación de nombres)
        public static bool CheckValidNames(string names)
        {
            names = names.Trim(',');

            if (names.Split(' ').Length != 4) return false;

            return true;
        }

    }
}