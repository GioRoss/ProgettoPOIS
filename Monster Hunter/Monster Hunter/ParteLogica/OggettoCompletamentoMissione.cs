using System;
using System.Collections.Generic;

namespace ParteLogica
{
    // inizio della classe pubblica OggettoCompletamentoMissione
    public class OggettoCompletamentoMissione
    {
        // campi interni della classe
        public Oggetto Dettagli { get; set; }
        public int Quantita { get; set; }

        // inizio metodo costruttore
        public OggettoCompletamentoMissione(Oggetto dettagli, int quantita)
        {
            this.Dettagli = dettagli;
            this.Quantita = quantita;
        }
    }
}
