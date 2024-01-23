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
