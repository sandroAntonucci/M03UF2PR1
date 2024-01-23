using System.Data;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

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

            // Aquest if es per si quan i val 0 es genera el 4 (index out of bonds)
            if (randomPosition == 4) randomPosition = 3;

            temp = sortedArray[i];
            sortedArray[i] = sortedArray[randomPosition];
            sortedArray[randomPosition] = temp;
        }

        return sortedArray;
    }

    // Fa l'acció d'atacar
    public static string HandleAttack(double[] characterStats, ref double[] monsterStats, string attackerName)
    {

        double damage = characterStats[2];
        string msgAttack;

        // Comprova si s'ha fallat l'atac
        if (MissedAttack())
        {
            msgAttack = "\n - " + attackerName + " ha fallat l'atac, es passa el torn :(";
            return msgAttack;
        }
        // Comprova si és un atac crític
        else if (IsCrit())
        {
            // Es duplica el dany
            damage *= 2;

            // Es resta el dany a la vida del monstre i retorna el missatge per a l'usuari
            monsterStats[1] -= damage * (100 - monsterStats[3]) / 100;
            msgAttack = "\n - És un atac crític! Es duplica el dany i el monstre rep " + damage + ", peró es defensa i només rep " + (damage * (100 - monsterStats[3]) / 100) + " // Vida restant del monstre: " + monsterStats[1];
            return msgAttack;
        }

        // Es resta el dany a la vida del monstre i retorna el missatge per a l'usuari si no es ni atac crític ni s'ha fallat l'atac
        monsterStats[1] -= damage * (100 - monsterStats[3]) / 100;
        msgAttack = "\n - El monstre rep " + damage + " de dany, peró es defensa i només rep " + (damage * (100 - monsterStats[3]) / 100) + " // Vida restant del monstre: " + monsterStats[1];
        return msgAttack;
    }

    // Retorna si es un atac crític o no
    public static bool IsCrit()
    {
        Random random = new Random();

        int critChance = random.Next(1, 101);

        // Si critChance es menor o igual a 10 significa que és un atac crític
        return critChance <= 10;
    }

    // Retorna si s'ha fallat l'atac
    public static bool MissedAttack()
    {
        Random random = new Random();

        int critChance = random.Next(1, 101);

        // Si critChance es menor o igual a 5 significa que s'ha fallat l'atac
        return critChance <= 5;
    }

    // Retorna si l'acció és vàlida
    public static bool ValidAction(int actionChosen)
    {
        return actionChosen < 1 || actionChosen > 3;
    }

    // Realitza la habilitat especial de l'arquera (stunnea al monstre durant 2 torns)
    public static void ArcherSpecial(ref int monsterStun)
    {
        monsterStun = 2;
        Console.WriteLine("\n - El monstre no pot atacar durant 2 torns");
    }

    // Activa el 100% de defensa en el bàrbar
    public static void BarbarianSpecial(ref int barbarianReductSpecialTurns) 
    {
        barbarianReductSpecialTurns = 2;
        Console.WriteLine("\n - El bàrbar es defensa al 100% durant 2 torns");
    }

    // Habilitat especial del mag (fa 3 cops el seu atac)
    public static void MageSpecial(ref double[] monsterStats, double mageDMG)
    {
        monsterStats[1] -= mageDMG * 3;
        Console.WriteLine("\n - La maga fa el seu atac tres vegades i aplica " + (mageDMG * 3) + " de dany. - Vida restant del monstre: " + monsterStats[1]);
    }

    // Aplica la curació del druida
    public static void DruidSpecial(ref double[][] characterStats, ref string[] characterNames)
    {
        for(int i = 0; i < characterStats.GetLength(0); i++) 
        {
            // Si retorna 1 significa que s'ha d'assignar la vida màxima
            if (CheckHealth(characterStats[i][1], characterStats[i][0]) == 1)
            {
                characterStats[i][1] = characterStats[i][0];
                Console.WriteLine("\n - " + characterNames[i] + " es cura fins al màxim -> " + characterStats[i][1] + " HP");
            }else if(CheckHealth(characterStats[i][1], characterStats[i][0]) == 2)
            {
                characterStats[i][1] += 500;
                Console.WriteLine("\n - "  + characterNames[i] + " es cura 500 de vida -> " + characterStats[i][1] + " HP");
            }
        }

        
    }

    // Comprova si es pot aplicar la curació del druida
    public static int CheckHealth(double HP, double maxHP)
    {
        if(HP <= 0)
        {
            return 0;
        }
        else if (HP + 500 >= maxHP)
        {
            return 1;
        }

        return 2;
    }

    // Comprova si el monstre esta viu
    public static bool CheckMonsterAlive(double monsterHP)
    {
        return monsterHP > 0;
    }

    // Redueix els cooldowns
    public static void ReduceCooldowns(ref int archerSpecialCooldown, ref int barbarianSpecialCooldown, ref int mageSpecialCooldown, ref int druidSpecialCooldown, ref int barbarianReductSpecialTurns, ref int monsterStun)
    {
        if (archerSpecialCooldown > 0) archerSpecialCooldown--;
        if (barbarianSpecialCooldown > 0) barbarianSpecialCooldown--;
        if (mageSpecialCooldown > 0) mageSpecialCooldown--;
        if (druidSpecialCooldown > 0) druidSpecialCooldown--;
        if (barbarianReductSpecialTurns > 0) barbarianReductSpecialTurns--;
        if (monsterStun > 0) monsterStun--;
    }

    // Es resetejen els cooldowns
    public static void ResetCooldowns(ref int archerSpecialCooldown, ref int barbarianSpecialCooldown, ref int mageSpecialCooldown, ref int druidSpecialCooldown, ref int barbarianReductSpecialTurns, ref int monsterStun)
    {
        archerSpecialCooldown = 0;
        barbarianSpecialCooldown = 0;
        mageSpecialCooldown = 0;   
        druidSpecialCooldown = 0;
        barbarianReductSpecialTurns = 0;
        monsterStun = 0;
    }

    // Atac del monstre cap als herois
    public static string MonsterAttack(double monsterDMG, ref double[] characterStats, string characterNames, bool protection)
    {
        double damage;

        if(protection){
            damage = monsterDMG * (100 - characterStats[3] * 2) / 100;
            characterStats[1] -= damage;
            return "El monstre resta " + monsterDMG + " de vida a " + characterNames + " però es protegeix i rep només " + damage;
        }
        else
        {
            damage = monsterDMG * (100 - characterStats[3]) / 100;
            characterStats[1] -= damage;
            return "El monstre resta " + monsterDMG + " de vida a " + characterNames + " però es protegeix i rep només " + damage;
        }


    }

    // Atac del monstre cap al bàrbar (també comprova habilitat especial)
    public static string MonsterAttack(double monsterDMG, ref double[] characterStats, string characterNames, bool protection, int barbarianReductSpecialTurns)
    {
        double damage;

        if (barbarianReductSpecialTurns > 0)
        {
            return "El monstre no resta res a " + characterNames + " ja que ha utilitzat la seva habilitat especial.";
        }else if (protection)
        {
            damage = monsterDMG * (100 - characterStats[3] * 2) / 100;
            characterStats[1] -= damage;
            return "El monstre resta " + monsterDMG + " de vida a " + characterNames + " però es protegeix i rep només " + damage;
        }
        else
        {
            damage = monsterDMG * (100 - characterStats[3]) / 100;
            characterStats[1] -= damage;
            return "El monstre resta " + monsterDMG + " de vida a " + characterNames + " però es protegeix i rep només " + damage;
        }
    }

    // Comprova els personatges morts
    public static bool CheckDeadCharacter(double characterStats)
    {
        return characterStats <= 0;
    }

    // Comprova si tots els personatges han mort
    public static bool CheckGameLost(double[][] characterStats)
    {
        for(int i = 0; i < characterStats.GetLength(0); i++)
        {
            if (!CheckDeadCharacter(characterStats[i][1])) return false;
        }
        return true;
    }

    // Ordena de manera descendent una array
    public static double[] OrderDesc(double[] characterHP)
    {
        for (int i = 0; i < characterHP.Length - 1; i++)
        {
            for (int j = 0; j < characterHP.Length - i - 1; j++)
            {
                // Si el elemento actual es menor que el siguiente, intercambiarlos
                if (characterHP[j] < characterHP[j + 1])
                {
                    double temp = characterHP[j];
                    characterHP[j] = characterHP[j + 1];
                    characterHP[j + 1] = temp;
                }
            }
        }

        return characterHP;
    }

    // Printa per pantalla la vida dels herois de forma descendent
    public static void PrintHP(double[] orderedHP, double archerHP, double barbarianHP, double mageHP, double druidHP)
    {
        for (int i = 0; i < orderedHP.Length; i++)
        {
            // Es comprova que el personatge estigui viu
            if (orderedHP[i] > 0)
            {
                if ((orderedHP[i] == archerHP))Console.WriteLine("L'arquera té " + orderedHP[i] + " de vida.");
                else if ((orderedHP[i] == barbarianHP)) Console.WriteLine("El bàrbar té " + orderedHP[i] + " de vida.");
                else if ((orderedHP[i] == mageHP)) Console.WriteLine("La maga té " + orderedHP[i] + " de vida.");
                else if ((orderedHP[i] == druidHP)) Console.WriteLine("El druida té " + orderedHP[i] + " de vida.");
            }
            
        }

        Console.ReadKey();
        Console.Clear();
    }
}
