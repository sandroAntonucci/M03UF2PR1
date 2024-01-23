# M03UF2PR1
Pràctica d'herois vs monstre fent servir el disseny modular

## ESQUEMA ESTADÍSTIQUES

MATRIU:

Primera posició (Arquera) -> Array amb vida màxima, vida actual, dany i reducció en aquest ordre
Segona posició (Bàrbar) -> Array amb vida màxima, vida actual, dany i reducció en aquest ordre
Tercera posició (Maga) -> Array amb vida màxima, vida actual, dany i reducció en aquest ordre
Cuarta posició (Druida) -> Array amb vida màxima, vida actual, dany i reducció en aquest ordre

Les estadístiques del monstre es guarden en una array apart.

## Proves de caixa negra. Classes d'equivalència

### CheckAndAssignValidNames

Es volen definir les proves de caixa negra per a una funció que retorna si una cadena conté 4 paraules separades per una coma i un espai i assigna les paraules com a nom de cada personatge si són vàlides.

DOMINI: STRING

// Retorn True
* Valors vàlids: "Sandro, Alex, Marcos, Carla" - Cadena amb 4 paraules separades per coma i espai sense caràcters especials.
* Valors vàlids: "$andro, Al&x, Marc$s, Carl%" - Cadena amb 4 paraules separades per comes i espai amb caràcters especials. (també els considero caràcters vàlids ja que a molts videojocs et deixa)

// Retorn False
* Valors invàlids: "Sandro, Alex, Marcos, Carla, Juan" - Cadena amb més de 4 paraules
* Valors invàlids: "Sandro, Alex" - Cadena amb menys de 4 paraules
* Valors invàlids: "" - Cadena buida

No hi ha valors límit ja que rep una cadena i strings globals.

### Save Names 

Aquest módul retorna un conjunt de strings com a string[]. No fa cap tipus de validació (tots els valors són vàlids mentre es rebin 4 strings diferents).

### Assign Stats (double[,] matrix, int arrayPosition)

Retorna la copia d'un array dins d'una matriu. S'utilitza per assignar estadístiques a la dificultat fàcil i difícil. Rep una matriu i una posició i retorna l'array que està a la posició de la matriu com a copia. No es fa cap tipus de validació (els valors són vàlids mentre la posició rebuda no sobrepassi la longitud de la matriu).

### Assign Stats (double[,] minStats, double[,] maxStats, int arrayPosition)

Sobrecàrrega del primer assign stats. S'encarrega d'assignar les estadístiques aleatoriament, rep les estadístiques mínimes i màximes i la posició (depén del personatge). Fa servir una funció externa per a generar el valor aleatori. No es fa cap tipus de validació (els valors són vàlids mentre la posició rebuda no sobrepassi la longitud de les matrius).

### CheckValidAttributes

Comprova que els atributs estiguin dins del rang (rep un mínim, un màxim i el valor de l'atribut).

DOMINI: INT

// Retorn True
* Valors vàlids - Nombre positiu entre el rang - Límit superior: MAX otorgat / Límit inferior: MÍN otorgat
* Valors vàlids - Nombre negatiu entre el rang - Límit superior: MAX otorgat / Límit inferior: MÍN otorgat
* Valors vàlids - Nombre igual a 0 si el màxim i el mínim és 0 - Limit superior: 0 / Límit inferior: 0

// Retorn False
* Valor invàlid - Nombre major que el màxim - Limit inferior: MAX + 1 / Límit superior: Valor màxim int
* Valor invàlid - Nombre negatiu menor que el mínim - Límit inferior: Valor màxim int / Limit superior: Min - 1

### ResetStatsCheckers

Rep els tries i el indexer de les estadístiques i les retorna al valor inicial per referència, no hi ha classes d'equivalència.

### GenerateRandom 

Rep un mínim i un màxim i genera un valor aleatori entre aquests nombres. No hi ha valors vàlids o invàlids ja que el valor el genera un métode extern (random).

### PrintStats

Rep les característiques i el nom del personatge i printa per pantalla els valors rebuts. No hi ha classes d'equivalència.

### SortArrayRandomly

Reorganitza una array de longitud 4 aleatoriament (s'utilitza per als torns aleatoris dels herois). No hi ha classes d'equivalència.

### HandleAttack

Rep el dany del personatge, les característiques del monstre i el nom de l'atacant per als missatges cap a l'usuari. Comprova si s'ha fallat l'atac amb una funció externa (MissedAttack) o si és crític (IsCrit). Retorna diferents missatges depenent dels retorns d'aquestes funcions externes i resta el dany a la vida del monstre comprovant també la seva reducció de dany. No hi ha classes d'equivalència (retorna una string que es el missatge per a l'usuari).

### IsCrit

Genera un número aleatori entre 1 i 101 i si aquest és menor que 10 significa que és un atac crític. Retorna true o false depén del random (no es pot comprovar mitjançant unitTesting).

DOMINI: INT

// Retorna True
* Valors vàlids: Nombre entre el rang - Valor mínim: 1 \ Valor màxim: 10

// Retorna False
* Valors invàlids: Nombre fora del rang - Valor mínim: 11 \ Valor màxim: 100

### MissedAttack

Genera un número aleatori entre 1 i 101 i si aquest és menor o igual que 5 significa que s'ha fallat l'atac. Retorna true o false depén del random (no es pot comprovar mitjançant unitTesting).

DOMINI: INT
// Retorna True
* Valors vàlids: Nombre entre el rang - Valor mínim: 1 \ Valor màxim: 5

// Retorna False
* Valors invàlids: Nombre fora del rang - Valor mínim: 6 \ Valor màxim: 100

### NotValidAction

Es passa l'acció com a paràmetre i comprova si no és vàlida (no està entre 1 i 3).  

DOMINI: INT
// Retorna True
* Valors vàlids: Nombre menor que el mínim - Valor mínim: -Valor màxim int / Valor màxim: 0
* Valors vàlids: Nombre major que el mínim - Valor mínim: 3 / Valor màxim: Valor màxim int

// Retorna False
* Valors invàlids: Nombre entre el rang - Valor mínim: 1 \ Valor màxim: 3

### ArcherSpecial
Rep la variable monsterStun per referència per indicar que està parat, el para durant dos torns i mostra per consola que el monstre no pot atacar. No retorna res i no té classes d'equivalència.

### BarbarianSpecial
Rep la variable per referència de la reducció total del bàrbar i l'assigna per durar 2 torns, també informa a l'usuari. No retorna res i no té classes d'equivalència.

### MageSpecial
Rep la variable per referència de la vida del monstre i el dany de la maga i l'aplica multiplicat per tres, també informa a l'usuari. No retorna res i no té classes d'equivalència.

### DruidSpecal
Rep les característiques de la vida de tots els personatges i comprova si sobrepassen la vida màxima o no amb la cura i si estàn morts. Els personatges vius que no sobrepassen el màxim obtenen 500 de curació, els que els sobrepassen directament s'assigna el màxim. No té classes d'equivalència i no retorna res.

### CheckHealth
Rep la vida i la vida màxima i comprova si aquesta més 500 dona més.

No té valors vàlids ni invàlids ni valors límit.

// Retorna 0 
* HP menor o igual que 0

// Retorna 1 
* HP més 500 major que maxHP

// Retorna 2
* HP més 500 menor que maxHP

### CheckMonsterAlive
Rep la vida actual del monstre i retorna true si es major a 0, si no retorna false.

// True
* Valor vàlid: Nombre positiu - Límit inferior: 1 // Límit superior: Max INT

// False
* Valor invàlid: Nombre igual a 0 o negatiu - Limit inferior: -Max INT // Límit superior: 0;

### ReduceCooldowns
Rep totes les variables de cooldown per referència i resta 1 si son major que 0. No retorna res ni té classes d'equivalència.

### ResetCooldowns
S'utilitza al començament de la batalla per posar a 0 els contadors de tots els cooldowns. No retorna res ni té classes d'equivalència.

### MonsterAttack (per a tots els herois menys al bàrbar)
Rep el dany del monstre, la vida del personatge i si esta protegit. Si no està protegit, es resta el dany a la vida menys el percentatge de la reducció, si ho està, fa el mateix pero multiplica la reducció per dos. Retorna un missatge per a l'usuari. No té classes d'equivalència.

### MonsterAttack (per al bàrbar)
Rep el dany del monstre, la vida del personatge i si esta protegit. Si no està protegit, es resta el dany a la vida menys el percentatge de la reducció, si ho està, fa el mateix pero multiplica la reducció per dos. També comprova si té l'habilitat especial activada, si la té, no pot atacar. Retorna un missatge per a l'usuari. No té classes d'equivalència.

### CheckDeadCharacter
Rep la vida actual del personatge i retorna true si es menor que 0, si no retorna false.

// True
* Valor vàlid: Nombre igual a 0 o negatiu - Limit inferior: -Max INT // Límit superior: 0

// False
* Valor invàlid: Nombre negatiu - Límit inferior: 1 // Límit superior: Max INT

### CheckGameLost 
Rep una matriu amb totes les característiques del personatge i comprova amb el módul chekcDeadCharacter qui no està mort. Si hi ha algún personatge que no està mort, retorna true, si no, retorna false.

### OrderDesc
Fent servir el bubbleSort rep una array desordenada i retorna una array ordenada de manera descendent. No té classes d'equivalència.

### PrintHP 
Rep l'array ordenada i printa un missatge cap a l'usuari si el valor és major que 0 i coincideix amb el personatge. No té classes d'equivalència.
