using System;
using System.Threading;
using GameModules;

namespace GameProject
{

    class AntonucciSandroCode
    {

        static void Main()
        {

            const int Zero = 0, One = 1, Two = 2, Three = 3, Four = 4, Five = 5;

            const string MsgAction = " · Introdueix la teva acció: ";
            const string MsgCharacterActions = "\n  1.- Atacar\n  2.- Protegir-se\n  3.- Habilitat especial\n\n";
            const string MsgInputNotValid = "\n - Aquesta entrada no és vàlida.\n\n";
            const string MsgOutOfTries = "S'han acabat els intents.";
            const string MsgProtect = "\n - {0} es protegeix del monstre i duplica la seva reducció de dany pel pròxim atac.";
            const string MsgCooldown = "\n - L'habilitat especial encara té temps d'espera. Falten {0} torns";
            const string MsgLost = "El monstre ha matat a tot el grup. Has perdut :/";
            const string MsgWon = "Felicitats, has matat al monstre!";
            const string MsgStart = " Benvingut a Herois vs Monstre!\n Que vols fer?";
            const string MsgPlay = "\n 1. Iniciar una nova batalla";
            const string MsgQuit = " 0. Sortir\n";
            const string MsgCharacterDead = "{0} ({1}) ha mort :(";
            const string MsgCharNames = "Introdueix els noms dels personatges (arquera, bàrbar, mag i druida en aquest ordre) separats per comes i un espai (et queden {0} intents): \n\n - ";
            const string MsgGameDifficulty = "\nOK! Començem amb el selector de dificultat";
            const string MsgDifficultySelector = " · Selecciona una dificultat: \n\n  1.- Fàcil: Agafa el valor més alt del rang d’atributs dels personatges, i el més baix del monstre automàticament.\n  2.- Difícil:  Agafa el valor més baix del rang d’atributs dels personatges, i el més alt del monstre automàticament\n  3.- Personalitzat: Introduiràs els atributs dels personatges manualment\n  4.- Random: S'assignaràn els valors aleatoriament\n\n";
            const string MsgOutOfTriesStats = "Has assignat l'estadística malament tres vegades, s'assigna el valor mínim";

            const string MsgTurn = "\n\n --- Torn de {0} ({1}) --- \n\n";

            const string MsgDecoration = "\n\n-----------------------------------------\n\n";
            const string MsgDecorationArcher = "\n\n--- Estadístiques d'arquera ---\n\n";
            const string MsgDecorationBarbarian = "\n\n--- Estadístiques de bàrbar ---\n\n";
            const string MsgDecorationMage = "\n\n--- Estadístiques de maga ---\n\n";
            const string MsgDecorationDruid = "\n\n--- Estadístiques de druida ---\n\n";
            const string MsgDecorationMonster = "\n\n--- Estadístiques de monstre ---\n\n";

            const string MsgOutOfTriesTurn = "\n T'has equivocat 3 vegades escollint una opció. Es passa el torn.";
            const string MsgOutOfTriesNames = "\nT'has equivocat 3 vegades donant noms als personatges, tornes al menú principal.";
            const string MsgOutOfTriesDifficulty = "\nT'has equivocat 3 vegades escollint la dificultat, tornes al menú principal.";

            const string MsgArcherName = "Arquera";

            const string MsgBarbarianName = "Bàrbar";

            const string MsgMageName = "Maga";

            const string MsgDruidName = "Druida";

            const string MsgMonsterTurn = "--- Torn de Monstre ---";
            const string MsgMonsterName = "Monstre";
            const string MsgMonsterAttack = "\nEl monstre ataca a tots els herois: ";
            const string MsgMonsterCantAttack = "\nEl monstre està atordit i no pot atacar.";

            int statIndexer = 0, startGame, menuTries, difficulty, difficultyTries = 3, statsTries = 3, namesTries = 3, turnTries = 3, actionChosen = 0;

            // Aquesta part la podría fer constant amb el readonly però no sé si es pot utilitzar, al readme hi ha més informació sobre la organització de les matrius
            double[,] minStats = { { 1500, 200, 25 }, { 3000, 150, 35 }, { 1100, 300, 20 }, { 2000, 70, 25 }, { 7000, 300, 20 } };
            double[,] maxStats = { { 2000, 300, 35 }, { 3750, 250, 45 }, { 1500, 400, 35 }, { 2500, 120, 40 }, { 10000, 400, 30 } };

            // Guarda si el personatge està protegit o no
            bool[] characterProtected = { false, false, false, false };

            // Les estadístiques les divideixo en un array per a cada personatge i el monstre
            double[] archerStats = new double[4];
            double[] barbarianStats = new double[4];
            double[] mageStats = new double[4];
            double[] druidStats = new double[4];
            double[] monsterStats = new double[4];

            int[] basePositions = { 0, 1, 2, 3 };

            // Missatges a l'usuari de les estadístiques (no son constants ja que son arrays)
            string[] msgArcherStats = { "\n - Introdueix la vida de l'arquera (entre 1500 i 2000): ",
                                        "\n - Introdueix l'atac de l'arquera (entre 200 i 300): ",
                                        "\n - Introdueix la reducció de dany de l'arquera (entre 25% i 35%): "};

            string[] msgBarbarianStats = {  "\n - Introdueix la vida del bàrbar (entre 3000 i 3750): ",
                                            "\n - Introdueix l'atac del bàrbar (entre 150 i 250): ",
                                            "\n - Introdueix la reducció de dany del bàrbar (entre 35% i 45%): "};

            string[] msgMageStats = {   "\n - Introdueix la vida del mag (entre 1100 i 1500): ",
                                        "\n - Introdueix l'atac del mag (entre 300 i 350): ",
                                        "\n - Introdueix la reducció de dany del mag (entre 20% i 35%): "};

            string[] msgDruidStats = {  "\n - Introdueix la vida del druida (entre 2000 i 2500): ",
                                        "\n - Introdueix l'atac del druida (entre 70 i 120): ",
                                        "\n - Introdueix la reducció de dany del druida (entre 25% i 40%): "};

            string[] msgMonsterStats = {    "\n - Introdueix la vida del monstre (entre 7000 i 10000): ",
                                            "\n - Introdueix l'atac del monstre (entre 300 i 400): ",
                                            "\n - Introdueix la reducció de dany del monstre (entre 20% i 30%): "};

            string[] msgCharacterType = {"Arquera", "Bàrbar", "Maga", "Druida"};

            // Cooldown de les habilitats especials
            int archerSpecialCooldown = 0, barbarianSpecialCooldown = 0, barbarianReductSpecialTurns = 0, mageSpecialCooldown = 0, druidSpecialCooldown = 0, monsterStun = 0;

            string archerName, barbarianName, mageName, druidName;

            // CharacterStatsCompleted marca que no s'utilitza però si que s'utilitza per a la creació de personatges
            bool exitGame = false, gameEnded = false;

            while (!(exitGame))         //Joc interminable mentre el jugador no vulgui sortir.
            {

                menuTries = Three;


                //Recull l'acció de l'usuari mentre tingui intents.
                do
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(MsgDecoration);
                    Console.WriteLine(MsgStart);
                    Console.WriteLine(MsgPlay);
                    Console.WriteLine(MsgQuit);

                    if (menuTries < Three)
                    {
                        Console.Write(MsgInputNotValid);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(MsgAction);

                    startGame = Convert.ToInt32(Console.ReadLine());

                    menuTries--;

                    Console.Clear();

                } while (startGame != One && startGame != Zero && menuTries > Zero);


                if (menuTries == Zero)
                {
                    Console.WriteLine(MsgOutOfTries + " Es tanca el joc.");
                    Console.ReadKey();
                    startGame = Zero;
                }

                //Menu principal - 0 és sortir i 1 és jugar -
                switch (startGame)
                {
                    case Zero:         // Sortida

                        Console.WriteLine("Adéu!");
                        exitGame = true;
                        break;

                    case One:         // Joc


                        // Introducció de noms
                        // Es buiden els noms anteriors per a fer la comprovació de que s'han introduit correctament després

                        archerName = "";
                        barbarianName = "";
                        mageName = "";
                        druidName = "";

                        // Es resetejen els cooldowns
                        Modules.ResetCooldowns(ref archerSpecialCooldown, ref barbarianSpecialCooldown, ref mageSpecialCooldown, ref druidSpecialCooldown, ref barbarianReductSpecialTurns, ref monsterStun);

                        gameEnded = false;

                        // Es comprova que els noms s'han introduït correctament i s'assignen als personatges, si no, es resta un intent (3) i es tornen a demanar
                        do
                        {
                            if (namesTries < Three)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(MsgInputNotValid);
                            }

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(MsgCharNames, namesTries);

                            namesTries--;

                            Console.ForegroundColor = ConsoleColor.Green;

                        } while (!Modules.CheckAndAssignValidNames(Console.ReadLine(), ref archerName, ref barbarianName, ref mageName, ref druidName) && namesTries > Zero);

                        // Si l'usuari s'ha quedat sense intents i el nom d'algun personatge esta buit(en aquest cas l'arquera) significa que no ha introduit els noms correctament i torna al menú principal
                        if (archerName == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(MsgOutOfTriesNames);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                        namesTries = Three;

                        // Es guarden els noms a un array
                        string[] characterNames = Modules.SaveNames(archerName, barbarianName, mageName, druidName);

                        // Selector de dificultat
                        Console.WriteLine(MsgGameDifficulty);
                        Console.ReadKey();
                        Console.Clear();

                        // Es comprova que la dificultat s'ha introduït correctament, es resta un intent (3) i es tornen a demanar si no
                        do
                        {
                            if (difficultyTries < Three)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(MsgInputNotValid);
                            }

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(MsgDifficultySelector);
                            Console.Write(MsgAction);

                            Console.ForegroundColor = ConsoleColor.Green;
                            difficulty = Convert.ToInt32(Console.ReadLine());

                            difficultyTries--;

                        } while (!(difficulty > Zero && difficulty <= Four || difficultyTries == Zero));

                        // Si l'usuari s'ha quedat sense intents i no ha introduït la dificultat correctament li informa i torna al menú principal
                        if (!(difficulty > Zero && difficulty <= Four))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(MsgOutOfTriesDifficulty);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                        difficultyTries = Three;

                        Console.Clear();

                        // Assigna les característiques a cada personatge depenent de la dificultat
                        switch (difficulty)
                        {

                            // Dificultat fàcil - Agafa el valor més alt del rang d’atributs dels personatges, i el més baix del monstre automàticament.
                            case One:
                                archerStats = Modules.AssignStats(maxStats, Zero);
                                barbarianStats = Modules.AssignStats(maxStats, One);
                                mageStats = Modules.AssignStats(maxStats, Two);
                                druidStats = Modules.AssignStats(maxStats, Three);
                                monsterStats = Modules.AssignStats(minStats, Four);
                                break;

                            // Dificultad difícil - Agafa el valor més baix del rang d'atributs dels personatges, i el més alt del monstre automàticament.
                            case Two:
                                archerStats = Modules.AssignStats(minStats, Zero);
                                barbarianStats = Modules.AssignStats(minStats, One);
                                mageStats = Modules.AssignStats(minStats, Two);
                                druidStats = Modules.AssignStats(minStats, Three);
                                monsterStats = Modules.AssignStats(maxStats, Four);
                                break;



                            // Dificultat personalitzada - L'usuari introdueix els valors manualment
                            case Three:

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Modules.ResetStatsCheckers(ref statIndexer, ref statsTries);

                                Console.Write(MsgDecorationArcher);

                                // Estadístiques d'arquera
                                while (statIndexer < Three)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    // Llegeix l'estadística que indica statIndexer
                                    Console.Write(msgArcherStats[statIndexer]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    archerStats[statIndexer + One] = Convert.ToDouble(Console.ReadLine());

                                    // Si l'estadística no està dins del rang, retorna error i es resta un intent
                                    if (!Modules.CheckValidAttributes(archerStats[statIndexer + One], minStats[Zero, statIndexer], maxStats[Zero, statIndexer]))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(MsgInputNotValid);
                                        statsTries--;

                                        // Si l'usuari s'ha equivocat tres vegades assignant un atribut, s'assigna el valor mínim
                                        if (statsTries == Zero)
                                        {
                                            Console.WriteLine(MsgOutOfTriesStats);
                                            archerStats[statIndexer + One] = minStats[Zero, statIndexer];

                                            if (statIndexer == Zero) archerStats[Zero] = archerStats[One];

                                            statIndexer++;
                                            statsTries = Three;
                                        }
                                    }
                                    // Si l'estadística està dins del rang, es comprova que sigui vida per a fer maxHP i que sigui l'última característica per a donar per completat el personatge
                                    else
                                    {
                                        if (statIndexer == Zero) archerStats[Zero] = archerStats[One];
                                        statIndexer++;
                                    }
                                }

                                Console.ReadKey();
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Modules.ResetStatsCheckers(ref statIndexer, ref statsTries);
                                Console.Write(MsgDecorationBarbarian);

                                // Estadístiques de bàrbar
                                while (statIndexer < Three)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    // Llegeix l'estadística que indica statIndexer
                                    Console.Write(msgBarbarianStats[statIndexer]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    barbarianStats[statIndexer + One] = Convert.ToDouble(Console.ReadLine());

                                    // Si l'estadística no està dins del rang, retorna error i es resta un intent
                                    if (!Modules.CheckValidAttributes(barbarianStats[statIndexer + One], minStats[One, statIndexer], maxStats[One, statIndexer]))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(MsgInputNotValid);
                                        statsTries--;

                                        // Si l'usuari s'ha equivocat tres vegades assignant un atribut, s'assigna el valor mínim
                                        if (statsTries == Zero)
                                        {
                                            Console.WriteLine(MsgOutOfTriesStats);
                                            barbarianStats[statIndexer + One] = minStats[One, statIndexer];

                                            if (statIndexer == Zero) barbarianStats[Zero] = barbarianStats[One];

                                            statIndexer++;
                                            statsTries = Three;
                                        }
                                    }
                                    // Si l'estadística està dins del rang, es comprova que sigui vida per a fer maxHP i que sigui l'última característica per a donar per completat el personatge
                                    else
                                    {
                                        if (statIndexer == Zero) barbarianStats[Zero] = barbarianStats[One];
                                        statIndexer++;
                                    }
                                }

                                Console.ReadKey();
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Modules.ResetStatsCheckers(ref statIndexer, ref statsTries);
                                Console.Write(MsgDecorationMage);

                                // Estadístiques de la maga
                                while (statIndexer < Three)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    // Llegeix l'estadística que indica statIndexer
                                    Console.Write(msgMageStats[statIndexer]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    mageStats[statIndexer + One] = Convert.ToDouble(Console.ReadLine());

                                    // Si l'estadística no està dins del rang, retorna error i es resta un intent
                                    if (!Modules.CheckValidAttributes(mageStats[statIndexer + One], minStats[Two, statIndexer], maxStats[Two, statIndexer]))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(MsgInputNotValid);
                                        statsTries--;

                                        // Si l'usuari s'ha equivocat tres vegades assignant un atribut, s'assigna el valor mínim
                                        if (statsTries == Zero)
                                        {
                                            Console.WriteLine(MsgOutOfTriesStats);
                                            mageStats[statIndexer + One] = minStats[Two, statIndexer];

                                            if (statIndexer == Zero) mageStats[Zero] = mageStats[One];

                                            statIndexer++;
                                            statsTries = Three;
                                        }
                                    }
                                    // Si l'estadística està dins del rang, es comprova que sigui vida per a fer maxHP i que sigui l'última característica per a donar per completat el personatge
                                    else
                                    {
                                        if (statIndexer == Zero) mageStats[Zero] = mageStats[One];
                                        statIndexer++;
                                    }
                                }

                                Console.ReadKey();
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Modules.ResetStatsCheckers(ref statIndexer, ref statsTries);
                                Console.Write(MsgDecorationDruid);

                                // Estadístiques del druida
                                while (statIndexer < Three)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    // Llegeix l'estadística que indica statIndexer
                                    Console.Write(msgDruidStats[statIndexer]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    druidStats[statIndexer + One] = Convert.ToDouble(Console.ReadLine());

                                    // Si l'estadística no està dins del rang, retorna error i es resta un intent
                                    if (!Modules.CheckValidAttributes(druidStats[statIndexer + One], minStats[Three, statIndexer], maxStats[Three, statIndexer]))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(MsgInputNotValid);
                                        statsTries--;

                                        // Si l'usuari s'ha equivocat tres vegades assignant un atribut, s'assigna el valor mínim
                                        if (statsTries == Zero)
                                        {
                                            Console.WriteLine(MsgOutOfTriesStats);
                                            druidStats[statIndexer + One] = minStats[Three, statIndexer];

                                            if (statIndexer == Zero) druidStats[Zero] = druidStats[One];

                                            statIndexer++;
                                            statsTries = Three;
                                        }
                                    }
                                    // Si l'estadística està dins del rang, es comprova que sigui vida per a fer maxHP i que sigui l'última característica per a donar per completat el personatge
                                    else
                                    {
                                        if (statIndexer == Zero) druidStats[Zero] = druidStats[One];
                                        statIndexer++;
                                    }
                                }

                                Console.ReadKey();
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Modules.ResetStatsCheckers(ref statIndexer, ref statsTries);
                                Console.Write(MsgDecorationMonster);

                                // Estadístiques del monstre
                                while (statIndexer < Three)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    // Llegeix l'estadística que indica statIndexer
                                    Console.Write(msgDruidStats[statIndexer]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    monsterStats[statIndexer + One] = Convert.ToDouble(Console.ReadLine());

                                    // Si l'estadística no està dins del rang, retorna error i es resta un intent
                                    if (!Modules.CheckValidAttributes(monsterStats[statIndexer + One], minStats[Four, statIndexer], maxStats[Four, statIndexer]))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(MsgInputNotValid);
                                        statsTries--;

                                        // Si l'usuari s'ha equivocat tres vegades assignant un atribut, s'assigna el valor mínim
                                        if (statsTries == Zero)
                                        {
                                            Console.WriteLine(MsgOutOfTriesStats);
                                            monsterStats[statIndexer + One] = minStats[Four, statIndexer];

                                            if (statIndexer == Zero) monsterStats[Zero] = monsterStats[One];

                                            statIndexer++;
                                            statsTries = Three;
                                        }
                                    }
                                    // Si l'estadística està dins del rang, es comprova que sigui vida per a fer maxHP i que sigui l'última característica per a donar per completat el personatge
                                    else
                                    {
                                        if (statIndexer == Zero) monsterStats[Zero] = monsterStats[One];
                                        statIndexer++;
                                    }
                                }

                                break;




                            // Dificultat Randomitzada
                            case Four:

                                archerStats = Modules.AssignStats(minStats, maxStats, Zero);
                                barbarianStats = Modules.AssignStats(minStats, maxStats, One);
                                mageStats = Modules.AssignStats(minStats, maxStats, Two);
                                druidStats = Modules.AssignStats(minStats, maxStats, Three);
                                monsterStats = Modules.AssignStats(minStats, maxStats, Four);
                                break;

                        }



                        Modules.PrintStats(archerName, MsgArcherName, archerStats);
                        Modules.PrintStats(barbarianName, MsgBarbarianName, barbarianStats);
                        Modules.PrintStats(mageName, MsgMageName, mageStats);
                        Modules.PrintStats(druidName, MsgDruidName, druidStats);
                        Modules.PrintStats(MsgMonsterName, MsgMonsterName, monsterStats);

                        Console.Clear();

                        // S'emmagatzemen les característiques en una jagged array per a que siguin utilitzables als torns
                        double[][] characterStats = {archerStats, barbarianStats, mageStats, druidStats};

                        // Joc

                        while (!gameEnded)
                        {
                            // Es tornen a randomitzar els torns
                            int[] characterTurn = Modules.SortArrayRandomly(basePositions);

                       

                            // Torn d'herois 
                            for (int i = Zero; i < characterTurn.Length; i++)
                            {

                                if (Modules.CheckMonsterAlive(monsterStats[One]))
                                {
                                    if (characterStats[characterTurn[i]][1] > Zero)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(MsgTurn, characterNames[characterTurn[i]], msgCharacterType[characterTurn[i]]);

                                        do
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write(MsgCharacterActions + MsgAction);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            actionChosen = Convert.ToInt32(Console.ReadLine());

                                            if (Modules.ValidAction(actionChosen))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine(MsgInputNotValid);
                                                Console.ReadKey();
                                                turnTries--;
                                            }

                                        } while (turnTries > Zero && Modules.ValidAction(actionChosen));


                                        if (turnTries == Zero)
                                        {
                                            Console.WriteLine(MsgOutOfTriesTurn);
                                            Console.ReadKey();
                                            turnTries = Three;
                                        }
                                        else
                                        {
                                            //Depén de la opció escollida per l'usuari es faran 3 coses diferents
                                            switch (actionChosen)
                                            {
                                                // Atac
                                                case One:
                                                    // Es fa l'acció d'atacar i es resta la vida al monstre
                                                    Console.WriteLine(Modules.HandleAttack(characterStats[characterTurn[i]], ref monsterStats, characterNames[characterTurn[i]]));
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;

                                                // Defensa
                                                case Two:
                                                    characterProtected[characterTurn[i]] = true;
                                                    Console.WriteLine(MsgProtect, characterNames[characterTurn[i]]);
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;

                                                // Habilitat especial
                                                case Three:

                                                    switch (characterTurn[i])
                                                    {
                                                        // Habilitat especial arquera
                                                        case Zero:

                                                            if (archerSpecialCooldown == Zero)
                                                            {
                                                                Modules.ArcherSpecial(ref monsterStun);
                                                                archerSpecialCooldown = Five;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine(MsgCooldown, archerSpecialCooldown);
                                                            }

                                                            Console.ReadKey();
                                                            Console.Clear();



                                                            break;

                                                        // Habilitat especial bàrbar
                                                        case One:

                                                            if (barbarianSpecialCooldown == Zero)
                                                            {
                                                                Modules.BarbarianSpecial(ref barbarianReductSpecialTurns);
                                                                barbarianSpecialCooldown = Five;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine(MsgCooldown, barbarianSpecialCooldown);
                                                            }

                                                            Console.ReadKey();
                                                            Console.Clear();



                                                            break;

                                                        // Habilitat especial maga
                                                        case Two:

                                                            if (mageSpecialCooldown == Zero)
                                                            {
                                                                Modules.MageSpecial(ref monsterStats, mageStats[Two]);
                                                                mageSpecialCooldown = Five;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine(MsgCooldown, mageSpecialCooldown);
                                                            }

                                                            Console.ReadKey();
                                                            Console.Clear();



                                                            break;

                                                        // Habilitat especial druida
                                                        case Three:

                                                            if (druidSpecialCooldown == Zero)
                                                            {
                                                                Modules.DruidSpecial(ref characterStats, ref characterNames);
                                                                druidSpecialCooldown = Five;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine(MsgCooldown, druidSpecialCooldown);
                                                            }

                                                            Console.ReadKey();
                                                            Console.Clear();



                                                            break;

                                                    }

                                                    break;
                                            }
                                        }
                                    }

                                }
                                else{
                                    gameEnded = true;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(MsgWon);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }

                            // Es comprova que el monstre estigui viu
                            if (Modules.CheckMonsterAlive(monsterStats[One]))
                            {
                                // Torn de monstre

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(MsgMonsterTurn);

                                // Si el monstre està stunnejat no pot atacar
                                if (monsterStun > Zero)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(MsgMonsterCantAttack);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {

                                    for(int i = Zero; i < Four; i++)
                                    {

                                        // El monstre ataca (s'executa un módul diferent si es el bàrbar)
                                        if (i == One)
                                        {
                                            // Comprova si el personatge està viu
                                            if (characterStats[i][One] > Zero)
                                            {
                                                Console.WriteLine(MsgMonsterAttack);
                                                Console.WriteLine(Modules.MonsterAttack(monsterStats[Two], ref characterStats[i], characterNames[i], characterProtected[i], barbarianReductSpecialTurns));
                                                if (Modules.CheckDeadCharacter(characterStats[i][One])) Console.WriteLine(MsgCharacterDead, characterNames[i], msgCharacterType[i]);
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            
                                        }
                                        else 
                                        {
                                            if (characterStats[i][One] > Zero)
                                            {
                                                Console.WriteLine(MsgMonsterAttack);
                                                Console.WriteLine(Modules.MonsterAttack(monsterStats[Two], ref characterStats[i], characterNames[i], characterProtected[i]));
                                                if (Modules.CheckDeadCharacter(characterStats[i][One])) Console.WriteLine(MsgCharacterDead, characterNames[i], msgCharacterType[i]);
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                        }
                                    }
                                }

                                // Es comprova si algún personatge segueix viu
                                if (Modules.CheckGameLost(characterStats))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(MsgLost);
                                    gameEnded = true;
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                // Si si, es printa la vida de cada personatge i del monstre de forma descendent
                                else
                                {
                                    double[] currentHP = {characterStats[Zero][One], characterStats[One][One], characterStats[Two][One], characterStats[Three][One]};
                                    double[] orderedHP = Modules.OrderDesc(currentHP);
                                    Modules.PrintHP(orderedHP, characterStats[Zero][One], characterStats[One][One], characterStats[Two][One], characterStats[Three][One]);
                                }

                            }

                            // Si no, s'acaba el joc i es torna al menú principal
                            else
                            {
                                gameEnded = true;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(MsgWon);
                                Console.ReadKey();
                                Console.Clear();
                            }

                            // Es resta un als cooldowns si hi ha
                            Modules.ReduceCooldowns(ref archerSpecialCooldown, ref barbarianSpecialCooldown, ref mageSpecialCooldown, ref druidSpecialCooldown, ref barbarianReductSpecialTurns, ref monsterStun);

                            // Es reseteja la protecció
                            for (int i = 0; i < characterProtected.Length; i++) characterProtected[i] = false;
                        }

                        break;
                }
            }
        }
    }
}