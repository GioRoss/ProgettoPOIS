using System;
using System.Collections.Generic;

namespace ParteLogica
{
    // inizio della classe pubblica Mostro, che estende la classe Creature Viventi
    public class Mostro : CreatureViventi
    {
        // campi interni della classe
        public int ID { get; set; }
        public string Nome { get; set; }
        public int DannoMassimo { get; set; }
        public int RicompensaPuntiEsperienza { get; set; }
        public int RicompensaSoldi { get; set; }
        public List<OggettoOttenibile> OggettiOttenibili { get; set; }

        // inizio metodo costruttore
        // questo metodo dovrà soddisfare anche i parametri della classe CreatureViventi, e quindi verranno passati alla classe citata pocanzi
        // attraverso la keyword base
        public Mostro(int id, string nome, int dannoMassimo, int ricompensaPuntiEsperienza, int ricompensaSoldi, int puntiVitaAttuali, int maxPuntiVita) : base(puntiVitaAttuali, maxPuntiVita)
        {
            this.ID                        = id;
            this.Nome                      = nome;
            this.DannoMassimo              = dannoMassimo;
            this.RicompensaPuntiEsperienza = ricompensaPuntiEsperienza;
            this.RicompensaSoldi           = ricompensaSoldi;

            this.OggettiOttenibili         = new List<OggettoOttenibile>();
        }
    }
}
