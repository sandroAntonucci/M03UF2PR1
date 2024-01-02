# M03UF2PR1
Pràctica d'herois vs monstre fent servir el disseny modular

## Proves de caixa negra. Classes d'equivalència

### CheckValidNames

Es volen definir les proves de caixa negra per a una funció que retorna si una cadena conté 4 paraules separades per una coma i un espai i assigna les paraules com a nom de cada personatge si són vàlides.

* Valors vàlids: "Sandro, Alex, Marcos, Carla" - Cadena amb 4 paraules separades per coma i espai sense caràcters especials.
* Valors vàlids: "$andro, Al&x, Marc$s, Carl%" - Cadena amb 4 paraules separades per comes i espai amb caràcters especials.
* Valors invàlids: "Sandro, Alex, Marcos, Carla, Juan" - Cadena amb més de 4 paraules
* Valors invàlids: "Sandro, Alex" - Cadena amb menys de 4 paraules
* Valors invàlids: "" - Cadena buida

No hi ha valors límit ja que rep una cadena i strings globals.