# Tavolo
Il tavolo è l'oggetto che regge tutti gli altri componenti del gioco ed è il posto in cui si svolge la partita.

## Specifica

1. Il tavolo deve accettare come input la mossa del giocatore corrente. Il formato atteso è il seguente: B2 B3, dove B2 è la casa di partenza e B3 quella di arrivo.
2. La casa di partenza deve contenere un pezzo del colore del giocatore corrente.
3. Nonappena è stata indicata la mossa, il tavolo deve invocare il metodo PuòMuovere del pezzo nella casa di partenza per verificare se la mossa è consentita;
4. Se la mossa non è consentita, deve essere visualizzato un errore;
5. Se la mossa è consentita, il pezzo verrà spostato dalla casa di partenza a quella di arrivo, eventualmente catturando un pezzo avversario;
6. Dopo ogni mossa (consentita o no) deve essere visualizzata la scacchiera e il suo stato attuale. 

![Blocco note](../Immagini/tavolo.jpg)
