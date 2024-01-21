using System;
using System.Threading;
using GameModules;

namespace GameProject
{

    class AntonucciSandroCode
    {

        static void Main()
        {

            const int Zero = 0, One = 1, Two = 2, Three = 3, Four = 4, Percent = 100, Five = 5;

            const string MsgAction = " · Introdueix la teva acció: ";
            const string MsgCharacterActions = "\n  1.- Atacar\n  2.- Protegir-se\n  3.- Habilitat especial\n\n";
            const string MsgInputNotValid = "\n - Aquesta entrada no és vàlida.\n\n";
            const string MsgOutOfTries = "S'han acabat els intents.";
            const string MsgProtect = " es protegeix del monstre i duplica la seva reducció de dany pel pròxim atac.";
            const string MsgCooldown = "L'habilitat especial encara té temps d'espera. Falten ";
            const string MsgLost = "El monstre ha matat a tot el grup. Has perdut :/";
            const string MsgWon = "Felicitats, has matat al monstre!";
            const string MsgStart = " Benvingut a Herois vs Monstre!\n Que vols fer?";
            const string MsgPlay = "\n 1. Iniciar una nova batalla";
            const string MsgQuit = " 0. Sortir\n";
            const string MsgCharNames = "Introdueix els noms dels personatges (arquera, bàrbar, mag i druida en aquest ordre) separats per comes i un espai (et queden {0} intents): \n\n - ";
            const string MsgCharStats = "\nOK! Començem amb la creació de personatges. ";
            const string MsgGameDifficulty = "\nOK! Començem amb el selector de dificultat";
            const string MsgDifficultySelector = " · Selecciona una dificultat: \n\n  1.- Fàcil: Agafa el valor més alt del rang d’atributs dels personatges, i el més baix del monstre automàticament.\n  2.- Difícil:  Agafa el valor més baix del rang d’atributs dels personatges, i el més alt del monstre automàticament\n  3.- Personalitzat: Introduiràs els atributs dels personatges manualment\n  4.- Random: S'assignaràn els valors aleatoriament\n\n";

            const string MsgFinalStats = "\n\n --- Estadístiques Finals --- \n\n";
            const string MsgDecoration = "\n\n-----------------------------------------\n\n";
            const string MsgDecorationArcher = "\n\n--- Estadístiques d'arquera ---\n\n";
            const string MsgDecorationBarbarian = "\n\n--- Estadístiques de bàrbar ---\n\n";
            const string MsgDecorationMage = "\n\n--- Estadístiques de maga ---\n\n";
            const string MsgDecorationDruid = "\n\n--- Estadístiques de druida ---\n\n";
            const string MsgDecorationMonster = "\n\n--- Estadístiques de monstre ---\n\n";

            const string MsgOutOfTriesStats = "\nT'has equivocat 3 vegades, torna a introduïr els atributs.";
            const string MsgOutOfTriesCharacters = "\nT'has equivocat 3 vegades donant atributs als personatges, tornes al menú principal.";
            const string MsgOutOfTriesNames = "\nT'has equivocat 3 vegades donant noms als personatges, tornes al menú principal.";
            const string MsgOutOfTriesDifficulty = "\nT'has equivocat 3 vegades escollint la dificultat, tornes al menú principal.";

            const string MsgArcherName = "Arquera";
            const string MsgArcherDied = "\nL'arquera ha mort :(";

            const string MsgBarbarianName = "Bàrbar";
            const string MsgBarbarianSpecial = "\n - El bàrbar activa la seva habilitat especial i augmenta la seva defensa al 100% durant 3 torns.";
            const string MsgBarbarianMaxReduct = "\nLa reducció de dany del bàrbar ja està al 100%";
            const string MsgBarbarianDied = "El bàrbar ha mort :(";

            const string MsgMageName = "Maga";
            const string MsgMageSpecial = "\n - La maga activa la seva habilitat especial i dispara una bola de foc que fa 3 cops el seu atac.";
            const string MsgMageDied = "El mag ha mort :(";
            
            const string MsgDruidName = "Druida";
            const string MsgDruidSpecial = "\n - El druida activa la seva habilitat especial i cura a tothom 500 de vida.";
            const string MsgDruidDied = "El druida ha mort :(";

            const string MsgMonsterName = "Monstre";
            const string MsgMonsterAttack = "\nEl monstre ataca a tots els herois: ";
            const string MsgMonsterCantAttack = "\nEl monstre està atordit i no pot atacar.";

            const string MsgBattle = "Comença la batalla!";
            const string MsgTurn = "Torn ";

            int statIndexer = 0, startGame, menuTries, difficulty, difficultyTries = 3, statsTries = 3, namesTries = 3, characterTries = 3, turnTries = 3, actionChosen = 0, turn = 1;

            // Aquesta part la podría fer constant amb el readonly però no sé si es pot utilitzar, al readme hi ha més informació sobre la organització de les matrius
            double[,] minStats = { { 1500, 200, 25 }, { 3000, 150, 35 }, { 1100, 300, 20 }, { 2000, 70, 25 }, {7000, 300, 20} };
            double[,] maxStats = { { 2000, 300, 35 }, { 3750, 250, 45 }, { 1500, 400, 35 }, { 2500, 120, 40 }, {10000, 400, 30} };

            // Les estadístiques les divideixo en un array per a cada personatge i el monstre
            double[] archerStats = new double[4];
            double[] barbarianStats = new double[4];
            double[] mageStats = new double[4];
            double[] druidStats = new double[4];
            double[] monsterStats = new double[4];

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

            // Cooldown de les habilitats especials
            double archerSpecialCooldown = 0;
            double barbarianSpecialCooldown = 0, barbarianReductSpecialTurns = 0;
            double mageSpecialCooldown = 0;
            double druidSpecialCooldown = 0;

            double monsterStun = 0;

            string archerName, barbarianName, mageName, druidName;

            bool exitGame = false, characterStatsCompleted = false, archerStatsCompleted = false, barbarianStatsCompleted = false, mageStatsCompleted = false, druidStatsCompleted = false, monsterStatsCompleted = false, turnEnded = false;

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

                                Modules.ResetStatsCheckers(ref characterStatsCompleted, ref statIndexer, ref statsTries, ref archerStatsCompleted, ref barbarianStatsCompleted, ref mageStatsCompleted, ref druidStatsCompleted, ref characterTries);

                                while (!characterStatsCompleted && characterTries > Zero)
                                {

                                    if (!archerStatsCompleted)
                                    {
                                        Console.Write(MsgDecorationArcher);

                                        // Estadístiques d'arquera
                                        while (statIndexer < Three && statsTries > Zero)
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
                                            }
                                            // Si l'estadística està dins del rang, es comprova que sigui vida per a fer maxHP i que sigui l'última característica per a donar per completat el personatge
                                            else
                                            {
                                                if (statIndexer == Zero) archerStats[Zero] = archerStats[One];
                                                if (statIndexer == Two) archerStatsCompleted = true;
                                                statIndexer++;
                                            }
                                        }
                                    }

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    if (!barbarianStatsCompleted && archerStatsCompleted)
                                    {

                                        Modules.ResetStatsCheckers(ref characterStatsCompleted, ref statIndexer, ref statsTries);
                                        Console.Write(MsgDecorationBarbarian);


                                        // Estadístiques de bàrbar
                                        while (statIndexer < Three && statsTries > Zero)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;

                                            Console.Write(msgBarbarianStats[statIndexer]);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            barbarianStats[statIndexer + One] = Convert.ToDouble(Console.ReadLine());

                                            if (!Modules.CheckValidAttributes(barbarianStats[statIndexer + One], minStats[One, statIndexer], maxStats[One, statIndexer]))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine(MsgInputNotValid);
                                                statsTries--;
                                            }
                                            else
                                            {
                                                if (statIndexer == Zero) barbarianStats[Zero] = barbarianStats[One];
                                                if (statIndexer == Two) barbarianStatsCompleted = true;
                                                statIndexer++;
                                            }
                                        }
                                    }

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    // Només es comencen les estadístiques del mag si s'ha completat el bàrbar
                                    if (!mageStatsCompleted && barbarianStatsCompleted)
                                    {

                                        Modules.ResetStatsCheckers(ref characterStatsCompleted, ref statIndexer, ref statsTries);
                                        Console.Write(MsgDecorationMage);

                                        // Estadístiques del mag
                                        while (statIndexer < Three && statsTries > Zero)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            
                                            Console.Write(msgMageStats[statIndexer]);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            mageStats[statIndexer + One] = Convert.ToDouble(Console.ReadLine());

                                            if (!Modules.CheckValidAttributes(mageStats[statIndexer + One], minStats[Two, statIndexer], maxStats[Two, statIndexer]))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine(MsgInputNotValid);
                                                statsTries--;
                                            }
                                            else
                                            {
                                                if (statIndexer == Zero) mageStats[Zero] = mageStats[One];
                                                if (statIndexer == Two) mageStatsCompleted = true;
                                                statIndexer++;
                                            }
                                        }
                                    }

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    if (!druidStatsCompleted && mageStatsCompleted)
                                    {

                                        Modules.ResetStatsCheckers(ref characterStatsCompleted, ref statIndexer, ref statsTries);
                                        Console.Write(MsgDecorationDruid);

                                        // Estadístiques del druida
                                        while (statIndexer < Three && statsTries > Zero)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write(msgDruidStats[statIndexer]);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            druidStats[statIndexer + One] = Convert.ToDouble(Console.ReadLine());

                                            if (!Modules.CheckValidAttributes(druidStats[statIndexer + One], minStats[Three, statIndexer], maxStats[Three, statIndexer]))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine(MsgInputNotValid);
                                                statsTries--;
                                            }
                                            else
                                            {
                                                if (statIndexer == Zero) druidStats[Zero] = druidStats[One];
                                                if (statIndexer == Two) druidStatsCompleted = true;
                                                statIndexer++;
                                            }
                                        }
                                    }

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    if (!monsterStatsCompleted && druidStatsCompleted)
                                    {

                                        Modules.ResetStatsCheckers(ref characterStatsCompleted, ref statIndexer, ref statsTries);
                                        Console.Write(MsgDecorationMonster);

                                        // Estadístiques del monstre
                                        while (statIndexer < Three && statsTries > Zero)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write(msgMonsterStats[statIndexer]);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            monsterStats[statIndexer + One] = Convert.ToDouble(Console.ReadLine());

                                            if (!Modules.CheckValidAttributes(monsterStats[statIndexer + One], minStats[Four, statIndexer], maxStats[Four, statIndexer]))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine(MsgInputNotValid);
                                                statsTries--;
                                            }
                                            else
                                            {
                                                if (statIndexer == Zero) monsterStats[Zero] = monsterStats[One];
                                                if (statIndexer == Two) characterStatsCompleted = true;
                                                statIndexer++;
                                            }
                                        }
                                    }

                                    // Es resta un intent a les estadístiques de tots els personatges i es torna a executar el while
                                    else
                                    {
                                        Modules.ResetStatsCheckers(ref characterStatsCompleted, ref statIndexer, ref statsTries);
                                        characterTries--;
                                    }

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
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

                        // Si no es completen les estadístiques correctament el joc torna al menú principal
                        if (!characterStatsCompleted) break;

                        // Es retornen les estadístiques
                        Modules.PrintStats(archerName, MsgArcherName, archerStats);
                        Modules.PrintStats(barbarianName, MsgBarbarianName,barbarianStats);
                        Modules.PrintStats(mageName, MsgMageName,mageStats);
                        Modules.PrintStats(druidName, MsgDruidName,druidStats);
                        Modules.PrintStats(MsgMonsterName, MsgMonsterName, monsterStats);

                        Console.Clear();


                        break;


                        /*
                        // Joc

                        Console.WriteLine("\n - " + MsgBattle);
                        Console.ReadKey();

                        turn = 1;
                        turnTries = Three;

                        // Aquest while s'executa mentre hi quedi un personatge viu, el monstre no hagi mort i hi quedin intents
                        while ((archerHP > Zero || barbarianHP > Zero || mageHP > Zero || druidHP > Zero) && monsterHP > Zero && turnTries > Zero)
                        {

                            Console.ForegroundColor = ConsoleColor.Yellow;

                            //Cada torn resta un al cooldown de les habilitats si està actiu

                            if (archerSpecialCooldown > Zero) archerSpecialCooldown--;

                            if (barbarianSpecialCooldown > Zero) barbarianSpecialCooldown--;
                            if (barbarianReductSpecialTurns > Zero) barbarianReductSpecialTurns--;

                            if (mageSpecialCooldown > Zero) mageSpecialCooldown--;

                            if (druidSpecialCooldown > Zero) druidSpecialCooldown--;

                            turnTries = Three;

                            // Torn Arquera
                            while (turnTries > Zero && turnEnded == false && archerHP > Zero && monsterHP > Zero)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("--- " + MsgTurn + turn + " ---\n\n");

                                Console.Write(" - " + MsgArcherName + " - \n" + MsgCharacterActions + MsgAction);
                                actionChosen = Convert.ToInt32(Console.ReadLine());

                                // Si la entrada no es vàlida, es treu un intent i es torna a executar el while
                                if (actionChosen < 1 || actionChosen > Three)
                                {
                                    turnTries--;
                                    Console.WriteLine(MsgInputNotValid);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    // Switch per a executar l'acció escollida pel jugador
                                    switch (actionChosen)
                                    {

                                        // Acció d'atacar
                                        case One:
                                            monsterHP -= archerDMG * ((Percent - monsterReduct) / Percent);
                                            Console.WriteLine("\n - " + MsgArcherName + " ataca a " + MsgMonsterName + " amb " + archerDMG + " de dany. El monstre es defensa i rep només " + (archerDMG * ((Percent - monsterReduct) / Percent)) + " de dany.");
                                            Console.ReadKey();
                                            Console.WriteLine("\n - Monstre: " + monsterHP + " HP");
                                            currentArcherReduct = archerReduct;
                                            turnEnded = true;
                                            break;

                                        // Acció de protegir-se
                                        case Two:
                                            Console.WriteLine("\n - La " + MsgArcherName + MsgProtect);
                                            Console.ReadKey();
                                            currentArcherReduct = archerReduct * Two;
                                            turnEnded = true;
                                            break;

                                        // Acció d'habilitat especial. Si te cooldown, torna a demanar una acció.
                                        case Three:

                                            // Comprova si la pot utilitzar
                                            if (archerSpecialCooldown > Zero)
                                            {
                                                Console.WriteLine("\n - " + MsgCooldown + archerSpecialCooldown + " torns per poder utilitzar-la.");
                                                turnEnded = true;
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(MsgArcherSpecial);
                                                currentArcherReduct = archerReduct;
                                                archerSpecialCooldown = Five;
                                                monsterStun = Two;
                                                turnEnded = true;
                                                break;
                                            }
                                    }
                                }
                            }

                            // Comprovem si s'han gastat tots els intents
                            if (turnTries > Zero)
                            {
                                turnTries = Three;
                                Console.ReadKey();
                            }
                            turnEnded = false;

                            // Torn Bàrbar
                            while (turnTries > Zero && turnEnded == false && barbarianHP > Zero && monsterHP > Zero)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("--- " + MsgTurn + turn + " ---\n\n");

                                Console.Write(" - " + MsgBarbarianName + " - \n" + MsgCharacterActions + MsgAction);
                                actionChosen = Convert.ToInt32(Console.ReadLine());

                                // Si la entrada no es vàlida, es treu un intent i es torna a executar el while
                                if (actionChosen < One || actionChosen > Three)
                                {
                                    turnTries--;
                                    Console.WriteLine(MsgInputNotValid);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    // Switch per a executar l'acció escollida pel jugador
                                    switch (actionChosen)
                                    {
                                        // Acció d'atacar
                                        case One:
                                            monsterHP -= barbarianDMG * ((Percent - monsterReduct) / Percent);
                                            Console.WriteLine("\n - " + MsgBarbarianName + " ataca a " + MsgMonsterName + " amb " + barbarianDMG + " de dany. El monstre es defensa i rep només " + (barbarianDMG * ((Percent - monsterReduct) / Percent)) + " de dany.");
                                            Console.ReadKey();
                                            Console.WriteLine("\n - Monstre: " + monsterHP + " HP");

                                            if (barbarianReductSpecialTurns <= Zero)
                                            {
                                                currentBarbarianReduct = barbarianReduct;
                                            }

                                            turnEnded = true;
                                            break;

                                        // Acció de protegir-se
                                        case Two:

                                            if (barbarianSpecialCooldown > Zero)
                                            {
                                                Console.WriteLine("\n - " + MsgBarbarianMaxReduct);
                                                Console.ReadKey();
                                                turnEnded = true;

                                            }
                                            else
                                            {

                                                Console.WriteLine("\n - El " + MsgBarbarianName + MsgProtect);
                                                Console.ReadKey();
                                                currentBarbarianReduct = barbarianReduct * Two;
                                                turnEnded = true;
                                            }

                                            break;

                                        // Acció d'habilitat especial. Si te cooldown, torna a demanar una acció.
                                        case Three:

                                            // Comprova si la pot utilitzar
                                            if (barbarianSpecialCooldown > Zero)
                                            {
                                                Console.WriteLine("\n - " + MsgCooldown + barbarianSpecialCooldown + " torns per poder utilitzar-la.");
                                                turnEnded = true;
                                                break;
                                            }
                                            // Defensa al Percent% si no té cooldown
                                            else
                                            {
                                                Console.WriteLine(MsgBarbarianSpecial);
                                                currentBarbarianReduct = Percent;
                                                barbarianSpecialCooldown = Five;
                                                barbarianReductSpecialTurns = Three;
                                                turnEnded = true;
                                                break;
                                            }
                                    }
                                }
                            }

                            if (turnTries > Zero)
                            {
                                turnTries = Three;
                                Console.ReadKey();
                            }
                            turnEnded = false;

                            // Torn Maga
                            while (turnTries > Zero && turnEnded == false && mageHP > Zero && monsterHP > Zero)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("--- " + MsgTurn + turn + " ---\n\n");

                                Console.Write(" - " + MsgMageName + " - \n" + MsgCharacterActions + MsgAction);
                                actionChosen = Convert.ToInt32(Console.ReadLine());

                                // Si la entrada no es vàlida, es treu un intent i es torna a executar el while
                                if (actionChosen < One || actionChosen > Three)
                                {
                                    turnTries--;
                                    Console.WriteLine(MsgInputNotValid);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    // Switch per a executar l'acció escollida pel jugador
                                    switch (actionChosen)
                                    {

                                        // Acció d'atacar
                                        case One:
                                            monsterHP -= mageDMG * ((Percent - monsterReduct) / Percent);
                                            Console.WriteLine("\n - " + MsgMageName + " ataca a " + MsgMonsterName + " amb " + mageDMG + " de dany. El monstre es defensa i rep només " + (mageDMG * ((Percent - monsterReduct) / Percent)) + " de dany.");
                                            Console.ReadKey();
                                            Console.WriteLine("\n - Monstre: " + monsterHP + " HP");

                                            currentMageReduct = mageReduct;
                                            turnEnded = true;
                                            break;

                                        // Acció de protegir-se
                                        case Two:

                                            Console.WriteLine("\n - La " + MsgMageName + MsgProtect);
                                            Console.ReadKey();
                                            currentMageReduct = mageReduct * Two;
                                            turnEnded = true;
                                            break;


                                        // Acció d'habilitat especial. Si te cooldown, torna a demanar una acció.
                                        case Three:

                                            // Comprova si la pot utilitzar
                                            if (mageSpecialCooldown > Zero)
                                            {
                                                Console.WriteLine(MsgCooldown + mageSpecialCooldown + " torns per poder utilitzar-la.");
                                                turnEnded = true;
                                                break;
                                            }
                                            // Fa el dany del seu atac per Three
                                            else
                                            {
                                                currentMageReduct = mageReduct;

                                                Console.WriteLine(MsgMageSpecial);

                                                monsterHP -= mageDMG * Three * ((Percent - monsterReduct) / Percent);
                                                Console.WriteLine("\n - " + MsgMageName + " ataca a " + MsgMonsterName + " amb " + (mageDMG * 3) + " de dany. El monstre es defensa i rep només " + (mageDMG * Three * ((Percent - monsterReduct) / Percent)) + " de dany.");
                                                Console.ReadKey();
                                                Console.WriteLine("\n - Monstre: " + monsterHP + " HP");


                                                mageSpecialCooldown = Five;
                                                turnEnded = true;
                                                break;
                                            }
                                    }
                                }
                            }

                            if (turnTries > Zero)
                            {
                                turnTries = Three;
                                Console.ReadKey();
                            }
                            turnEnded = false;

                            // Torn Druida
                            while (turnTries > Zero && turnEnded == false && druidHP > Zero && monsterHP > Zero)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("--- " + MsgTurn + turn + " ---\n\n");

                                Console.Write(" - " + MsgDruidName + " - \n" + MsgCharacterActions + MsgAction);
                                actionChosen = Convert.ToInt32(Console.ReadLine());

                                // Si la entrada no es vàlida, es treu un intent i es torna a executar el while
                                if (actionChosen < One || actionChosen > Three)
                                {
                                    turnTries--;
                                    Console.WriteLine(MsgInputNotValid);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    // Switch per a executar l'acció escollida pel jugador
                                    switch (actionChosen)
                                    {

                                        // Acció d'atacar
                                        case One:
                                            monsterHP -= druidDMG * ((Percent - monsterReduct) / Percent);
                                            Console.WriteLine("\n - " + MsgDruidName + " ataca a " + MsgMonsterName + " amb " + druidDMG + " de dany. El monstre es defensa i rep només " + (druidDMG * ((Percent - monsterReduct) / Percent)) + " de dany.");
                                            Console.ReadKey();
                                            Console.WriteLine("\n - Monstre: " + monsterHP + " HP");
                                            currentDruidReduct = druidReduct;
                                            turnEnded = true;
                                            break;

                                        // Acció de protegir-se
                                        case Two:

                                            Console.WriteLine("\n - El " + MsgDruidName + MsgProtect);
                                            Console.ReadKey();
                                            currentDruidReduct = druidReduct * Two;
                                            turnEnded = true;
                                            break;


                                        // Acció d'habilitat especial. Si te cooldown, torna a demanar una acció.
                                        case Three:

                                            // Comprova si la pot utilitzar
                                            if (druidSpecialCooldown > Zero)
                                            {
                                                Console.WriteLine("\n - " + MsgCooldown + druidSpecialCooldown + " torns per poder utilitzar-la.");
                                                turnEnded = true;
                                                break;
                                            }
                                            // Cura a tothom 500 de vida si están vius
                                            else
                                            {
                                                currentDruidReduct = druidReduct;

                                                Console.WriteLine("\n - " + MsgDruidSpecial);

                                                // Comprovem que el personatge estigui viu
                                                if (archerHP > Zero)
                                                {
                                                    // Operador ternari per que la cura no sobrepassi la vida màxima
                                                    archerHP = archerHP + DruidHeal > archerMaxHP ? archerHP = archerMaxHP : archerHP += DruidHeal;
                                                }

                                                // Comprovem que el personatge estigui viu
                                                if (barbarianHP > Zero)
                                                {
                                                    // Operador ternari per que la cura no sobrepassi la vida màxima
                                                    barbarianHP = barbarianHP + DruidHeal > barbarianMaxHP ? barbarianHP = barbarianMaxHP : barbarianHP += DruidHeal;
                                                }

                                                // Comprovem que el personatge estigui viu
                                                if (mageHP > Zero)
                                                {
                                                    // Operador ternari per que la cura no sobrepassi la vida màxima
                                                    mageHP = mageHP + DruidHeal > mageMaxHP ? mageHP = mageMaxHP : mageHP += DruidHeal;
                                                }

                                                // En el cas del Druida no comprovem si està viu ja que si no ho estigués no podria fer l'habilitat especial
                                                druidHP = druidHP + DruidHeal > druidMaxHP ? druidHP = druidMaxHP : druidHP += DruidHeal;

                                                druidSpecialCooldown = 5;
                                                turnEnded = true;
                                                break;
                                            }
                                    }
                                }
                            }

                            if (turnTries > Zero)
                            {
                                turnTries = Three;
                                Console.ReadKey();
                            }
                            turnEnded = false;


                            // Torn monstre

                            if (monsterHP > Zero && turnTries > Zero)
                            {

                                Console.Clear();
                                Console.WriteLine("--- " + MsgTurn + turn + " ---");
                                Console.ForegroundColor = ConsoleColor.Red;

                                // Comprovem si pot atacar o no depenent de si s'ha activat l'habilitat de l'arquera
                                if (monsterStun > Zero)
                                {
                                    Console.WriteLine(MsgMonsterCantAttack);
                                    Console.ReadKey();
                                    monsterStun--;
                                }
                                else
                                {
                                    Console.WriteLine(MsgMonsterAttack + "\n");

                                    // Ataca a l'arquera si està viva

                                    if (archerHP > Zero)
                                    {
                                        archerHP -= monsterDMG * ((Percent - currentArcherReduct) / Percent);
                                        Console.WriteLine(MsgMonsterName + " ataca a " + MsgArcherName + " amb " + monsterDMG + " de dany. L'arquera es defensa i rep només " + (monsterDMG * ((Percent - currentArcherReduct) / Percent)) + " de dany. Vida restant de l'Arquera: " + archerHP + " HP");

                                        // Comprovem si ha mort per comunicar-ho al jugador
                                        if (archerHP <= Zero) Console.WriteLine(MsgArcherDied);
                                        Console.ReadKey();
                                    }

                                    // Ataca al bàrbar si està viu

                                    if (barbarianHP > Zero)
                                    {
                                        barbarianHP -= monsterDMG * ((Percent - currentBarbarianReduct) / Percent);
                                        Console.WriteLine(MsgMonsterName + " ataca a " + MsgBarbarianName + " amb " + monsterDMG + " de dany. El bàrbar es defensa i rep només " + (monsterDMG * ((Percent - currentBarbarianReduct) / Percent)) + " de dany. Vida restant del bàrbar: " + barbarianHP + " HP");

                                        // Comprovem si ha mort per comunicar-ho al jugador
                                        if (barbarianHP <= Zero) Console.WriteLine(MsgBarbarianDied);
                                        Console.ReadKey();
                                    }

                                    // Ataca a la maga si esta viva
                                    if (mageHP > Zero)
                                    {
                                        mageHP -= monsterDMG * ((Percent - currentMageReduct) / Percent);
                                        Console.WriteLine(MsgMonsterName + " ataca a " + MsgMageName + " amb " + monsterDMG + " de dany. La maga es defensa i rep només " + (monsterDMG * ((Percent - currentMageReduct) / Percent)) + " de dany. Vida restant de la maga: " + mageHP + " HP");

                                        // Comprovem si ha mort per comunicar-ho al jugador
                                        if (mageHP <= Zero) Console.WriteLine(MsgMageDied);
                                        Console.ReadKey();
                                    }

                                    // Ataca al druida si està viu
                                    if (druidHP > Zero)
                                    {
                                        druidHP -= monsterDMG * ((Percent - currentDruidReduct) / Percent);
                                        Console.WriteLine(MsgMonsterName + " ataca a " + MsgDruidName + " amb " + monsterDMG + " de dany. El druida es defensa i rep només " + (monsterDMG * ((Percent - currentDruidReduct) / Percent)) + " de dany. Vida restant del druida: " + druidHP + " HP");

                                        // Comprovem si ha mort per comunicar-ho al jugador
                                        if (druidHP <= Zero) Console.WriteLine(MsgDruidDied);
                                        Console.ReadKey();
                                    }

                                }

                            }

                            turn++;
                        }

                        // Quan s'acaba la partida comprovem qui ha perdut

                        if (turnTries == Zero)// Tanca el joc si t'has quedat sense intents
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(MsgOutOfTries + " Adéu!");
                            Console.ReadKey();
                            Console.Clear();
                            exitGame = true;
                        }
                        else if (monsterHP > Zero) // Tanca el joc si t'has quedat sense intents
                        {
                            Console.WriteLine(MsgDecoration);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(MsgLost);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine(MsgDecoration);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(MsgWon);
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
*/
                }    
            }
        }               
    }                   
}