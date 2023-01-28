using System;
using System.Collections.Generic;


namespace ParteLogica
{
    // inizio della classe pubblica Missione Giocatore
    // questa classe, anche se può sembrare molto simile alla classe Missione, contiene le informazioni 
    // sulla missione stessa e se il giocatore abbia completato o meno la medesima missione.
    // Questo ci servirà nella classe Monster Hunter.cs
    public class MissioneGiocatore
    {
        // campi interni della classe
        public Missione Dettagli { get; set; }
        public bool ECompletata { get; set; }

        // inizio metodo costruttore
        public MissioneGiocatore(Missione dettagli)
        {
            this.Dettagli    = dettagli;
            this.ECompletata = false;
        }
    }
}
