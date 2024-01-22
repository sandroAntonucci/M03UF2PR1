using System.Data;
using System.Net.NetworkInformation;

namespace GameModules;

public class Modules
{

    // Comprova si els noms s'han introduit correctament (retorna true o false), i si s'han introduit correctament els assigna per referència a variables globals
    public static bool CheckAndAssignValidNames(string names, ref string archerName, ref string barbarianName, ref string mageName, ref string druidName)
    {

        names = names.Replace(",", "");

        string[] splittedNames = names.Split(' ');

        // Comprova si el format és invàlid (retorna false si ho es)
        if (splittedNames.Length != 4)
        {
            return false;
        }
        // Assigna els noms per referència a variables globals si el format és vàlid
        else
        {
            archerName = splittedNames[0];
            barbarianName = splittedNames[1];
            mageName = splittedNames[2];
            druidName = splittedNames[3];
        }

        return true;
    }

    // Guarda els noms a un array
    public static string[] SaveNames(string archerName, string barbarianName, string mageName, string druidName)
    {
        string[] names = {archerName, barbarianName, mageName, druidName};
        return names;
    }

    // Retorna la copia d'un array dins d'una matriu (s'utilitza per assignar estadístiques)
    public static double[] AssignStats(double[,] matrix, int arrayPosition)
    {
        double[] copiedArray = new double[matrix.GetLength(1) + 1];

        // Aixó és per guardar maxHP i actualHP a dos posicions distintes amb el mateix valor
        copiedArray[0] = matrix[arrayPosition, 0];

        for(int i = 0; i < matrix.GetLength(1); i++)
        {
            copiedArray[i+1] = matrix[arrayPosition, i];

            
        }

        return copiedArray;
    }

    // Retorna un array de valors entre un mínim i un máxim (s'utilitza per assignar estadístiques a la dificultat random)
    public static double[] AssignStats(double[,] minStats, double[,] maxStats, int arrayPosition)
    {

        double[] stats = new double[4];

        // Genera valors aleatoris entre els estats mínims i máxims a partir de la segona posició de l'array
        for(int i = 0; i < minStats.GetLength(1); i++)
        {
            stats[i + 1] = GenerateRandom(Convert.ToInt32(minStats[arrayPosition, i]), Convert.ToInt32(maxStats[arrayPosition, i]));
        }

        // Copia la segona posició de l'array a la primera per a maxHP
        stats[0] = stats[1];

        return stats;
    }
    

    // Comprova que els atributs estiguin dins del rang
    public static bool CheckValidAttributes(double attributeValue, double minAttributeValue, double maxAttributeValue)
    {
        return attributeValue >= minAttributeValue && attributeValue <= maxAttributeValue;
    }

    // Fa reset de les variables utilitzades per a completar les estadístiques
    public static void ResetStatsCheckers(ref int statIndexer, ref int statsTries)
    {
        statIndexer = 0;
        statsTries = 3;
    }


    // Genera un valor aleatori entre mínim i màxim
    public static double GenerateRandom(int minValue, int maxValue)
    {
        Random rand = new Random();

        return Convert.ToDouble(rand.Next(minValue, maxValue + 1));
    }

    // Mostra per consola les estadístiques d'un personatge
    public static void PrintStats(string characterName, string character, double[] characterStats)
    {
        const string MsgStats = "\n\n--- Estadístiques {0} ({1}) ---\n\n Vida: {2} // Dany: {3} // Reducció de dany: {4}";
        const string MsgContinue = "\nPrem una tecla per continuar...";

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(MsgStats, characterName, character, characterStats[1], characterStats[2], characterStats[3]);
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine(MsgContinue);
        Console.ReadKey();

    }

    // Reordena un array aleatoriament
    public static int[] SortArrayRandomly(int[] sortedArray)
    {
        int randomPosition, temp;

        for(int i = 0; i < 4; i++)
        {
            // Agafa una posició aleatoria i la intercambia per la posició i (que es guardada temporalment per a fer l'intercanvi)
            randomPosition = Convert.ToInt32(GenerateRandom(0, 4 - i));
            temp = sortedArray[i];
            sortedArray[i] = sortedArray[randomPosition];
            sortedArray[randomPosition] = temp;
        }

        return sortedArray;
    }

}