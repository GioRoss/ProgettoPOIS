using System;
using System.Collections.Generic;

namespace ParteLogica
{
    // inizio della classe pubblica Oggetto Ottenibile
    public class OggettoOttenibile
    {
        // campi interni della classe 
        public Oggetto Dettagli { get; set; }
        public int PercentualeDrop { get; set; }
        public bool EOggettoBase { get; set; }

        // inizio metodo costruttore
        public OggettoOttenibile(Oggetto dettagli, int percentualeDrop, bool eOggettoBase)
        {
            this.Dettagli        = dettagli;
            this.PercentualeDrop = percentualeDrop;
            this.EOggettoBase    = eOggettoBase;
        }
    }
}
