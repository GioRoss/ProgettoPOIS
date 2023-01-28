using System;
using System.Collections.Generic;

namespace ParteLogica
{
    // inizio della classe pubblica Missione
    public class Missione
    {
        // campi interni alla classe
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public int RicompensaPuntiEsperienza { get; set; }
        public int RicompensaSoldi { get; set; }
        public Oggetto OggettoRicompensa { get; set; }
        public List<OggettoCompletamentoMissione> OggettiCompletamentoMissione { get; set; }

        // inizio metodo costruttore
        // questo metodo prenderà in ingresso gli attributi dichiarati sopra
        // oltre che ad inizializzare la lista degli oggetti per il completamento della missione
        public Missione(int id, string nome, string descrizione, int ricompensaPuntiEsperienza, int ricompensaSoldi, Oggetto oggettoRicompensa)
        {
            this.ID                           = id;
            this.Nome                         = nome;
            this.Descrizione                  = descrizione;
            this.RicompensaPuntiEsperienza    = ricompensaPuntiEsperienza;
            this.RicompensaSoldi              = ricompensaSoldi;
            this.OggettoRicompensa            = oggettoRicompensa;

            this.OggettiCompletamentoMissione = new List<OggettoCompletamentoMissione>();
        }
    }
}
