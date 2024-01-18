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
            mageName  = splittedNames[2];
            druidName = splittedNames[3];
        }

        return true;
    }

    // Agafa el valors donats i els assigna a la variable pertinent per referència
    public static void AssignAttributes(ref double characterHP, ref double characterMaxHP, ref double characterDMG, ref double characterReduct, int assignedHP, int assignedDMG, int assignedReduct)
    {
        characterHP = assignedHP;
        characterMaxHP = assignedHP;
        characterDMG = assignedDMG; 
        characterReduct = assignedReduct; 
    }

    // Sobrecàrrega - Fa el mateix que el primer AssignAttributes però la versió del monstre ja que no té maxHP
    public static void AssignAttributes(ref double characterHP, ref double characterDMG, ref double characterReduct, int assignedHP, int assignedDMG, int assignedReduct)
    {
        characterHP = assignedHP;
        characterDMG = assignedDMG;
        characterReduct = assignedReduct;
    }

    // Comprova que els atributs estiguin dins del rang
    public static bool CheckValidAttributes(double attributeValue, int minAttributeValue, int maxAttributeValue)
    {
        return attributeValue >= minAttributeValue && attributeValue <= maxAttributeValue;
    }
}