# UnicamScacchi
Applicazione che consentirà all'eterna sfida Bob VS Ross di avere luogo.

## Situazione attuale
Abbiamo implementato la [classe Orologio](Modello/Orologio.cs)) e abbiamo verificato che il suo funzionamento fosse aderente alla [specifica](Documenti/SpecificaOrologio.md) usando degli [unit test](Tests/OrologioTest.cs).

Ora proviamo ad implementare il comportamento dei vari pezzi degli scacchi. Nella cartella Modello/Pezzi si trova l'[interfaccia IPezzo](Modello/Pezzi/IPezzo.cs) che espone due membri:
 * Il metodo booleano PuòMuovere, che ci indica se il pezzo può compiere una certa mossa, data una posizione di partenza, una posizione di arrivo e l'eventuale pezzo presente all'arrivo;
 * La proprietà Colore, che indica se il pezzo è bianco o nero (Colore è un'enum).

## Obiettivo
Usare il [test-driven development](https://it.wikipedia.org/wiki/Test_driven_development) per modellare le classi Pedone, Cavallo, Torre, Alfiere, Donna (il nome usato dagli scacchisti) e Re. Creare tali classi nella cartella Modello/Pezzi ([la classe Pedone](Modello/Pezzi/Pedone.cs) già esiste).

Ciascuna di queste classi dovrà implementare  l'[interfaccia IPezzo](Modello/Pezzi/IPezzo.cs) e il suo funzionamento dovrà essere conforme alla [specifica](Documenti/SpecificaPezzi.md).

Procedere come segue:
 * Leggere il primo punto della [specifica](Documenti/SpecificaPezzi.md);
 * Scrivere un test nella [classe PezziTest](Test/PezziTest.cs) completo di istruzioni Assert. Lanciare l'applicazione per veder fallire il test (è chiamata "fase rossa");
 * Solo a questo punto, aprire la classe del pezzo in questione (es. [Modello/Pezzi/Pedone.cs](Modello/Pezzi/Pedone.cs) e scrivere la minima quantità di codice che serve a far passare il test;
 * Lanciare di nuovo il programma e verificare che il test è passato (è chiamata "fase verde");
 * Ripetere da capo tutti i passi finché non sono stati svolti tutti i punti della specifica. Tenere presente che per testare ogni punto della specifica potrebbero essere necessari uno o più test.

*Nota:* Sono stati scritti due test per il primo punto della [specifica](Documenti/SpecificaPezzi.md), ma il secondo sta fallendo. Correggere l'implementazione per farlo passare e poi proseguire con i successivi punti.