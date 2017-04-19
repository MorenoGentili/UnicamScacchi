# Scacchiera
La scacchiera è la superficie di gioco ed è composta di 64 case disposte su 8 traverse ed 8 colonne.

## Specifica funzionale
1. La scacchiera è composta di 64 case su cui si posizionano i pezzi;
2. All'inizio della partita, sulla scacchiera saranno disposti i seguenti pezzi (da disporre in ordine dalla Colonna A alla colonna H):
  * Prima traversa: i pezzi bianchi Torre, Cavallo, Alfiere, Donna, Re, Alfiere, Cavallo, Torre;
  * Seconda traversa: 8 pedoni bianchi;
  * Settima traversa: 8 pedoni neri;
  * Ottava traversa: i pezzi neri Torre, Cavallo, Alfiere, Donna, Re, Alfiere, Cavallo, Torre.

## Specifica tecnica
1. Non deve essere possibile alterare il numero di case;
2. La scacchiera deve supportare sia l'accesso randomico con due coordinate (traversa e colonna) che la lettura sequenziale;
3. Le istanze delle case non devono poter essere riassegnate.

![Scacchiera](../Immagini/scacchiera.jpg)
