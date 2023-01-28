using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster_Hunter
{
    static class Program
    {
        // Punto di ingresso principale dell'applicazione
        // inizio del metodo main
        static void Main()
        {
            // attributi interni della classe 
            string testoApertura = "Questo gioco è stato creato puramente a scopo didattico per l'esame di Ingegneria del software per l'università di Urbino da parte degli studenti " +
                "Attarantato Kevin e Roselli Giorgia, pertanto non è stato dato peso ad aspetti come trama, gameplay, colonna sonora ecc.\nBuon divertimento!";
            string testoChiusura = "    Grazie per aver giocato!\n \tA presto.";

            // mostra il messaggio di ingresso
            MessageBox.Show(testoApertura);
            // metodo che abilita la funzione per gli stili di visualizzazione per l'applicazione
            Application.EnableVisualStyles();
            // questo metodo, che prende in ingresso il parametro false cosi i controlli utilizzino la classe basata su GDI TextRenderer, garantisce la compatibilità visiva
            // tra Windows Form che eseguono il rendering del testo utilizzando la classe TextRenderer e le applicazioni .NET Framework
            // che eseguono il rendering del testo utilizzando la classe Graphics
            Application.SetCompatibleTextRenderingDefault(false);
            // esegue l'appliacazione
            MonsterHunter gioco = new MonsterHunter();
            Application.Run(gioco);
            // mostra il messaggio di uscita
            MessageBox.Show(testoChiusura);
        }
    }
}
