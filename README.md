# M03UF2PR1
Pràctica d'herois vs monstre fent servir el disseny modular

## Proves de caixa negra. Classes d'equivalència

### CheckValidNames

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

### AssignAttributes

La funció AssignAttributes rep la vida, el dany i la reducció de dany d'un personatge com a variables globals i els valors a assignar i els assigna (s'utilitza a la dificultat fàcil i difícil).

DOMINI: STRING 

* Valors vàlids: actualHP(20) actualDMG(40) actualReduct(60) HP(100) DMG(40) Reduct(30) - Atributs a assignar positius.

* Valors vàlids: actualHP(0) actualDMG(0) actualReduct(0) HP(-100) DMG(-40) Reduct(-30) - Atributs a assignar negatius.

* Valors vàlids: actualHP(20) actualDMG(40) actualReduct(60) HP(0) DMG(0) Reduct(0) - Atributs a assignar iguals a 0.

No hi ha valors límit ni retorn.

A comentar que es comproven valors negatius i igual a 0 però en el programa no s'introdueixen, només és per testejar la unitat.