# UnicamScacchi
Applicazione che consentirà all'eterna sfida Bob VS Ross di avere luogo.

## Situazione attuale
Dopo una breve pianificazione iniziale, abbiamo iniziato a modellare gli oggetti di una partita di scacchi usando delle `interface`. Dopo questa prima prototipazione, siamo passati ad implementare il comportamento della classe `Orologio`, che implementa `IOrologio`.

## Obiettivo
Aprire il file `Modello\Orologio.cs` e continuare con l'implementazione, provando a realizzare la specifica di un orologio per scacchi:
1. Quando l'utente accende l'orologio, entrambi i tempi residui devono essere impostati su 5 minuti;
2. Quando avvia l'orologio, il tempo inizierà a decrescere per il Giocatore1;
3. Quando mette in pausa l'orologio, il tempo non deve decrescere;
4. Quando avvia l'orologio mentre era in pausa, il tempo deve ricominciare a decrescere per il giocatore che era di turno;
5. Quando si cambia giocatore, il tempo deve arrestarsi per il giocatore precedente ed iniziare a decrescere per il giocatore attualmente di turno;
6. Quando resetta l'orologio, il tempo deve essere reimpostato a 5 minuti per entrambi i giocatori. Il tempo residuo resterà fermo per entrambi i giocatori finché l'utente non lo avvia;
6. *Nice-to-have*: Se si prova ad avviare l'orologio senza averlo prima acceso, deve essere sollevata un'eccezione (es.  `throw new InvalidOperationException("Prima devi accenderlo");`). L'eccezione impedirà la normale esecuzione del programma e questo sarà utile ad informare altri sviluppatori che usano la vostra classe `Orologio` sul corretto uso della classe. Possiamo intenderla come un'estrema forma di documentazione;
7. *Nice-to-have*: Sollevare l'evento `TempoScaduto` quando il tempo residuo del giocatore di turno arriva a zero. Questo non vi ho ancora spiegato come realizzarlo, quindi lo vedremo durante la prossima lezione, oltre ad una revisione delle vostre implementazioni. Nel frattempo, potete usarlo come esercizio di ricerca su StackOverflow :P

## Esempio di orologio per scacchi da tenere alla mano durante la modellazione
Questo particolare orologio ha:
* Due tasti per cambiare il tono o il volume dell'allarme (che è irrilevante per noi e che perciò non modelleremo);
* Un unico tasto per avviare e mettere in pausa;
* Un tasto per resettare il timer;
* Un tasto posteriore (qui non visibile) per accedere l'orologio. L'orologio si spegne automaticamente dopo alcuni minuti di inattività;
* Un tastone basculante superiore che serve a passare il turno all'altro giocatore. In questa immagine, è di turno il giocatore che ha i pezzi neri (perciò sta decrescendo il suo tempo residuo).
![Immagine di un orologio per scacchi](Immagini/orologio.jpg)

## Specifica del blocco note
Il blocco note è l'oggetto che usiamo per trascrivere le mosse in [notazione algebrica standard](https://it.wikipedia.org/wiki/Notazione_algebrica).

1. Tranne il pedone, ogni pezzo è rappresentato da una iniziale: R=Re, D=Donna, T=Torre, A=Alfiere, C=Cavallo;
2. Le case si rappresentano indicando prima la colonna (minuscola) e poi la traversa, ad esempio: a1, f5, h8;
3. Per indicare una mossa, va indicata l'iniziale del pezzo (tranne nel caso dei pedoni) e la casa di arrivo. Ad esempio, Ac4 indica un alfiere che muove nella casa c4, mentre e4 indica che un pedone muove in e4;
4. La promozione di un pedone viene indicata apponendo l'iniziale del pezzo scelto dopo la mossa: ad esempio a8D indica che un pedone raggiunge la casa a8 e viene promosso a donna;
5. Quando un pezzo effettua una cattura, si inserisce una x tra l'iniziale del nome e la casa di destinazione: ad esempio Axe5 indica che un alfiere ha catturato in e5
6. Le mosse vanno presentate in questo modo: <numero del turno>. <mossa bianco> <mossa nero>
7. L'arrocco corto viene indicato con 0-0 e l'arrocco lungo con 0-0-0;
8. Se due pezzi dello stesso tipo possono raggiungere la stessa casa, si inserisce prima della casa di arrivo la traversa o la colonna di partenza del pezzo, in modo da evitare ambiguità: ad esempio, se due cavalli sono in e2 e in g2, e la mossa prevede che uno dei due si sposti in f4, si scriverà Cef4 oppure Cgf4, mentre, se i cavalli sono in a8 e in a6 e uno dei due muove in c7, si scriverà C8c7 oppure C6c7;
9. Se due pezzi dello stesso tipo possono catturare lo stesso pezzo, si inserisce prima della casa di arrivo la traversa o la colonna di partenza del pezzo, ad esempio Cexf3 indica che il cavallo della colonna e cattura in f3. Nel caso dei pedoni si indica la colonna di partenza al posto dell'iniziale del nome del pezzo: dxe5 indica che il pedone della colonna d cattura in e5;
10. In caso di presa en passant si indica la casa di arrivo del pedone che cattura, non quella del pedone catturato; inoltre si può far seguire la dicitura e.p.: quindi cxb6 e.p.
11. Lo scacco viene indicato con un + (ad esempio Axf7+)
12. Lo scacco matto con # (ad esempio Axf7#)
13. La notazione 1-0 si usa a fine partita per indicare la vittoria del bianco, 0-1 per indicare la vittoria del nero, ½-½ o 0,5-0,5 o anche ,5-,5per indicare una patta. Le parole "Il bianco abbandona" o "Il nero abbandona" possono essere usate in caso di abbandono
