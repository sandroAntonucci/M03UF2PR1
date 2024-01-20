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

            // Es guarden els missatges de les estadístiques de l'arquera
            string[] msgArcherStats = { "\n - Introdueix la vida de l'arquera (entre 1500 i 2000): ",
                                        "\n - Introdueix l'atac de l'arquera (entre 180 i 300): ",
                                        "\n - Introdueix la reducció de dany de l'arquera (entre 25% i 40%): "};

            const string MsgBarbarianName = "Bàrbar";
            const string MsgBarbarianHP = "\n - Introdueix la vida del bàrbar (entre 3000 i 3750): ";
            const string MsgBarbarianDMG = "\n - Introdueix l'atac del bàrbar (entre 150 i 250): ";
            const string MsgBarbarianReduct = "\n - Introdueix la reducció de dany del bàrbar (entre 35% i 45%): ";
            const string MsgBarbarianSpecial = "\n - El bàrbar activa la seva habilitat especial i augmenta la seva defensa al 100% durant 3 torns.";
            const string MsgBarbarianMaxReduct = "\nLa reducció de dany del bàrbar ja està al 100%";
            const string MsgBarbarianDied = "El bàrbar ha mort :(";


            const string MsgMageName = "Maga";
            const string MsgMageHP = "\n - Introdueix la vida del mag (entre 1000 i 1500): ";
            const string MsgMageDMG = "\n - Introdueix l'atac del mag (entre 300 i 350): ";
            const string MsgMageReduct = "\n - Introdueix la reducció de dany del mag (entre 20% i 35%): ";
            const string MsgMageSpecial = "\n - La maga activa la seva habilitat especial i dispara una bola de foc que fa 3 cops el seu atac.";
            const string MsgMageDied = "El mag ha mort :(";

            const string MsgDruidName = "Druida";
            const string MsgDruidHP = "\n - Introdueix la vida del druida (entre 2000 i 2500): ";
            const string MsgDruidDMG = "\n - Introdueix l'atac del druida (entre 70 i 120): ";
            const string MsgDruidReduct = "\n - Introdueix la reducció de dany del druida (entre 25% i 40%): ";
            const string MsgDruidSpecial = "\n - El druida activa la seva habilitat especial i cura a tothom 500 de vida.";
            const string MsgDruidDied = "El druida ha mort :(";

            const string MsgMonsterName = "Monstre";
            const string MsgMonsterHP = "\n - Introdueix la vida del monstre (entre 9000 i 12000): ";
            const string MsgMonsterDMG = "\n - Introdueix l'atac del monstre (entre 250 i 400): ";
            const string MsgMonsterReduct = "\n - Introdueix la reducció de dany del monstre (entre 20% i 30%): ";
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

            // Cooldown de les habilitats especials
            double archerSpecialCooldown = 0;
            double barbarianSpecialCooldown = 0, barbarianReductSpecialTurns = 0;
            double mageSpecialCooldown = 0;
            double druidSpecialCooldown = 0;

            double monsterStun = 0;

            string archerName, barbarianName, mageName, druidName;

            bool exitGame = false, characterStatsCompleted = true, turnEnded = false;

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

                        // Assigna les característiques a cada personatge depenent de la dificultat
                        switch (difficulty)
                        {

                            // Dificultat fàcil - Agafa el valor més alt del rang d’atributs dels personatges, i el més baix del monstre automàticament.
                            case One:
                                archerStats = Modules.CopyStatsFromBase(maxStats, Zero);
                                barbarianStats = Modules.CopyStatsFromBase(maxStats, One);
                                mageStats = Modules.CopyStatsFromBase(maxStats, Two);
                                druidStats = Modules.CopyStatsFromBase(maxStats, Three);
                                monsterStats = Modules.CopyStatsFromBase(minStats, Four);
                                break;

                            // Dificultad difícil - Agafa el valor més baix del rang d'atributs dels personatges, i el més alt del monstre automàticament.
                            case Two:
                                archerStats = Modules.CopyStatsFromBase(minStats, Zero);
                                barbarianStats = Modules.CopyStatsFromBase(minStats, One);
                                mageStats = Modules.CopyStatsFromBase(minStats, Two);
                                druidStats = Modules.CopyStatsFromBase(minStats, Three);
                                monsterStats = Modules.CopyStatsFromBase(maxStats, Four);
                                break;



                            // Dificultat personalitzada - L'usuari introdueix els valors manualment
                            case Three:

                                while(!characterStatsCompleted && characterTries > Zero)
                                {
                                    // Estadístiques d'arquera
                                    while (statIndexer < 3 && statsTries > Zero)
                                    {
                                        Console.Write(msgArcherStats[statIndexer]);
                                        archerStats[statIndexer + One] = Convert.ToDouble(Console.ReadLine());

                                        if (!Modules.CheckValidAttributes(archerStats[statIndexer + One], minStats[Zero, statIndexer], maxStats[Zero, statIndexer]))
                                        {
                                            Console.WriteLine(MsgInputNotValid);
                                            statsTries--;
                                        }
                                        else
                                        {
                                            if (statIndexer == Zero) archerStats[Zero] = archerStats[One];
                                            if (statIndexer == Two) characterStatsCompleted = true;
                                            statIndexer++;
                                        }
                                    }

                                    // Estadístiques de bàrbar
                                    while (statIndexer < 3 && statsTries > Zero)
                                    {
                                        Console.Write(msgArcherStats[statIndexer]);
                                        archerStats[statIndexer + One] = Convert.ToDouble(Console.ReadLine());

                                        if (!Modules.CheckValidAttributes(archerStats[statIndexer + One], minStats[Zero, statIndexer], maxStats[Zero, statIndexer]))
                                        {
                                            Console.WriteLine(MsgInputNotValid);
                                            statsTries--;
                                        }
                                        else
                                        {
                                            if (statIndexer == Zero) archerStats[Zero] = archerStats[One];
                                            statIndexer++;
                                        }
                                    }
                                }
                                

                                break;


                            case Four:

                                break;

                        }

                        foreach (double s in archerStats) Console.WriteLine(s);

                        break;


                        /*
                        // Introducció de característiques
                        // Estadístiques Arquera

                        Console.WriteLine(MsgCharStats);
                        Console.ReadKey();
                        Console.Clear();

                        characterTries = Three;
                        archerCompleted = false;

                        while (characterTries > Zero && !(archerCompleted))
                        {

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(MsgDecorationArcher);

                            statsTries = Three;
                            archerHP = Zero;
                            archerDMG = Zero;
                            archerReduct = Zero;

                            // Cada while comprova si el stat està dins del rang i si tens intents, si no, et resta un intent i torna a demanar stat

                            // Vida Arquera
                            while ((archerHP < ArcherMinRangeHP || archerHP > ArcherMaxRangeHP) && statsTries > Zero)
                            {
                                Console.Write(MsgArcherHP);
                                archerHP = Convert.ToDouble(Console.ReadLine());
                                archerMaxHP = archerHP;

                                if (archerHP < ArcherMinRangeHP || archerHP > ArcherMaxRangeHP)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Dany arquera
                            while ((archerDMG < ArcherMinRangeDMG || archerDMG > ArcherMaxRangeDMG) && statsTries > Zero)
                            {
                                Console.Write(MsgArcherDMG);
                                archerDMG = Convert.ToDouble(Console.ReadLine());

                                if (archerDMG < ArcherMinRangeDMG || archerDMG > ArcherMaxRangeDMG)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Reducció de dany arquera
                            while ((archerReduct < ArcherMinRangeReduct || archerReduct > ArcherMaxRangeReduct) && statsTries > Zero)
                            {
                                Console.Write(MsgArcherReduct);
                                archerReduct = Convert.ToDouble(Console.ReadLine());

                                if (archerReduct < ArcherMinRangeReduct || archerReduct > ArcherMaxRangeReduct)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Comprova si tots els stats de l'arquera son correctes per a poder continuar cap al següent personatge
                            if (!(archerHP < ArcherMinRangeHP || archerHP > ArcherMaxRangeHP) && !(archerDMG < ArcherMinRangeDMG || archerDMG > ArcherMaxRangeDMG) && !(archerReduct < ArcherMinRangeReduct || archerReduct > ArcherMaxRangeReduct))
                            {

                                archerCompleted = true;

                            }
                            else
                            {
                                Console.WriteLine(MsgOutOfTriesStats);
                                Console.ReadKey();
                                characterTries--;
                            }
                        }

                        // Estadístiques Bàrbar
                        barbarianCompleted = false;

                        while (characterTries > Zero && !(barbarianCompleted))
                        {

                            Console.Clear();
                            Console.Write(MsgDecorationBarbarian);

                            statsTries = Three;
                            barbarianHP = Zero;
                            barbarianDMG = Zero;
                            barbarianReduct = Zero;

                            // Vida Bàrbar
                            while ((barbarianHP < BarbarianMinRangeHP || barbarianHP > BarbarianMaxRangeHP) && statsTries > Zero)
                            {
                                Console.Write(MsgBarbarianHP);
                                barbarianHP = Convert.ToDouble(Console.ReadLine());
                                barbarianMaxHP = barbarianHP;

                                if (barbarianHP < BarbarianMinRangeHP || barbarianHP > BarbarianMaxRangeHP)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Dany Bàrbar
                            while ((barbarianDMG < BarbarianMinRangeDMG || barbarianDMG > BarbarianMaxRangeDMG) && statsTries > Zero)
                            {
                                Console.Write(MsgBarbarianDMG);
                                barbarianDMG = Convert.ToDouble(Console.ReadLine());

                                if (barbarianDMG < BarbarianMinRangeDMG || barbarianDMG > BarbarianMaxRangeDMG)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Reducció de dany Bàrbar
                            while ((barbarianReduct < BarbarianMinRangeReduct || barbarianReduct > BarbarianMaxRangeReduct) && statsTries > Zero)
                            {
                                Console.Write(MsgBarbarianReduct);
                                barbarianReduct = Convert.ToDouble(Console.ReadLine());

                                if (barbarianReduct < BarbarianMinRangeReduct || barbarianReduct > BarbarianMaxRangeReduct)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Comprova si tots els stats de l'arquera son correctes per a poder continuar cap al següent personatge
                            if (!(barbarianHP < BarbarianMinRangeHP || barbarianHP > BarbarianMaxRangeHP) && !(barbarianDMG < BarbarianMinRangeDMG || barbarianDMG > BarbarianMaxRangeDMG) && !(barbarianReduct < BarbarianMinRangeReduct || barbarianReduct > BarbarianMaxRangeReduct))
                            {

                                barbarianCompleted = true;

                            }
                            else
                            {
                                Console.WriteLine(MsgOutOfTriesStats);
                                Console.ReadKey();
                                characterTries--;
                            }
                        }

                        // Estadístiques Maga
                        mageCompleted = false;

                        while (characterTries > Zero && !(mageCompleted))
                        {

                            Console.Clear();
                            Console.Write(MsgDecorationMage);

                            statsTries = Three;
                            mageHP = Zero;
                            mageDMG = Zero;
                            mageReduct = Zero;

                            // Vida Maga
                            while ((mageHP < MageMinRangeHP || mageHP > MageMaxRangeHP) && statsTries > Zero)
                            {
                                Console.Write(MsgMageHP);
                                mageHP = Convert.ToDouble(Console.ReadLine());
                                mageMaxHP = mageHP;

                                if (mageHP < MageMinRangeHP || mageHP > MageMaxRangeHP)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Dany Maga
                            while ((mageDMG < MageMinRangeDMG || mageDMG > MageMaxRangeDMG) && statsTries > Zero)
                            {
                                Console.Write(MsgMageDMG);
                                mageDMG = Convert.ToDouble(Console.ReadLine());

                                if (mageDMG < MageMinRangeDMG || mageDMG > MageMaxRangeDMG)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Reducció de dany Maga
                            while ((mageReduct < MageMinRangeReduct || mageReduct > MageMaxRangeReduct) && statsTries > Zero)
                            {
                                Console.Write(MsgMageReduct);
                                mageReduct = Convert.ToDouble(Console.ReadLine());

                                if (mageReduct < MageMinRangeReduct || mageReduct > MageMaxRangeReduct)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Comprova si tots els stats del mag son correctes per a poder continuar cap al següent personatge
                            if (!(mageHP < MageMinRangeHP || mageHP > MageMaxRangeHP) && !(mageDMG < MageMinRangeDMG || mageDMG > MageMaxRangeDMG) && !(mageReduct < MageMinRangeReduct || mageReduct > MageMaxRangeReduct))
                            {

                                mageCompleted = true;

                            }
                            else
                            {
                                Console.WriteLine(MsgOutOfTriesStats);
                                Console.ReadKey();
                                characterTries--;
                            }
                        }

                        // Estadístiques Druida
                        druidCompleted = false;

                        while (characterTries > Zero && !(druidCompleted))
                        {

                            Console.Clear();
                            Console.Write(MsgDecorationDruid);

                            statsTries = Three;
                            druidHP = Zero;
                            druidDMG = Zero;
                            druidReduct = Zero;

                            // Vida Druida
                            while ((druidHP < DruidMinRangeHP || druidHP > DruidMaxRangeHP) && statsTries > Zero)
                            {
                                Console.Write(MsgDruidHP);
                                druidHP = Convert.ToDouble(Console.ReadLine());
                                druidMaxHP = druidHP;

                                if (druidHP < DruidMinRangeHP || druidHP > DruidMaxRangeHP)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Dany Druida
                            while ((druidDMG < DruidMinRangeDMG || druidDMG > DruidMaxRangeDMG) && statsTries > Zero)
                            {
                                Console.Write(MsgDruidDMG);
                                druidDMG = Convert.ToDouble(Console.ReadLine());

                                if (druidDMG < DruidMinRangeDMG || druidDMG > DruidMaxRangeDMG)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Reducció de dany Druida
                            while ((druidReduct < DruidMinRangeReduct || druidReduct > DruidMaxRangeReduct) && statsTries > Zero)
                            {
                                Console.Write(MsgDruidReduct);
                                druidReduct = Convert.ToDouble(Console.ReadLine());

                                if (druidReduct < DruidMinRangeReduct || druidReduct > DruidMaxRangeReduct)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Comprova si tots els stats del druida son correctes per a poder continuar cap al següent personatge
                            if (!(druidHP < DruidMinRangeHP || druidHP > DruidMaxRangeHP) && !(druidDMG < DruidMinRangeDMG || druidDMG > DruidMaxRangeDMG) && !(druidReduct < DruidMinRangeReduct || druidReduct > DruidMaxRangeReduct))
                            {

                                druidCompleted = true;

                            }
                            else
                            {
                                Console.WriteLine(MsgOutOfTriesStats);
                                Console.ReadKey();
                                characterTries--;
                            }
                        }

                        // Estadístiques Monstre
                        monsterCompleted = false;

                        while (characterTries > Zero && !(monsterCompleted))
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(MsgDecorationMonster);

                            statsTries = Three;
                            monsterHP = Zero;
                            monsterDMG = Zero;
                            monsterReduct = Zero;

                            // Vida Monstre
                            while ((monsterHP < MonsterMinRangeHP || monsterHP > MonsterMaxRangeHP) && statsTries > Zero)
                            {
                                Console.Write(MsgMonsterHP);
                                monsterHP = Convert.ToDouble(Console.ReadLine());

                                if (monsterHP < MonsterMinRangeHP || monsterHP > MonsterMaxRangeHP)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Dany Monstre
                            while ((monsterDMG < MonsterMinRangeDMG || monsterDMG > MonsterMaxRangeDMG) && statsTries > Zero)
                            {
                                Console.Write(MsgMonsterDMG);
                                monsterDMG = Convert.ToDouble(Console.ReadLine());

                                if (monsterDMG < MonsterMinRangeDMG || monsterDMG > MonsterMaxRangeDMG)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Reducció de dany Monstre
                            while ((monsterReduct < MonsterMinRangeReduct || monsterReduct > MonsterMaxRangeReduct) && statsTries > Zero)
                            {
                                Console.Write(MsgMonsterReduct);
                                monsterReduct = Convert.ToDouble(Console.ReadLine());

                                if (monsterReduct < MonsterMinRangeReduct || monsterReduct > MonsterMaxRangeReduct)
                                {
                                    Console.WriteLine(MsgInputNotValid);
                                    statsTries--;
                                }
                            }

                            // Comprova si tots els stats del druida son correctes per a poder continuar cap al següent personatge
                            if (!(monsterHP < MonsterMinRangeHP || monsterHP > MonsterMaxRangeHP) && !(monsterDMG < MonsterMinRangeDMG || monsterDMG > MonsterMaxRangeDMG) && !(monsterReduct < MonsterMinRangeReduct || monsterReduct > MonsterMaxRangeReduct))
                            {

                                monsterCompleted = true;

                            }
                            else
                            {
                                Console.WriteLine(MsgOutOfTriesStats);
                                Console.ReadKey();
                                characterTries--;
                            }
                        }

                        // Comprova si l'usuari s'ha quedat sense intents
                        if (characterTries == Zero)
                        {
                            Console.WriteLine(MsgOutOfTriesCharacters);
                            break;
                        }




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