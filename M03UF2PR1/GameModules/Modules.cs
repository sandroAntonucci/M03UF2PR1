using System.Data;

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

    // Retorna la copia d'un array dins d'una matriu
    public static double[] CopyStatsFromBase(double[,] matrix, int arrayPosition)
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

    // Comprova que els atributs estiguin dins del rang
    public static bool CheckValidAttributes(double attributeValue, double minAttributeValue, double maxAttributeValue)
    {
        return attributeValue >= minAttributeValue && attributeValue <= maxAttributeValue;
    }
}