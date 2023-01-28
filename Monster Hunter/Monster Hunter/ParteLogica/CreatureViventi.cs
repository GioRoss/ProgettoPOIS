using System;
using System.Collections.Generic;

namespace ParteLogica
{
    // inizio della classe pubblica Creature Viventi
    public class CreatureViventi
    {
        // campi interni della classe
        public int PuntiVitaAttuali { get; set; }
        public int MaxPuntiVita { get; set; }

        // inizio metodo costruttore
        public CreatureViventi(int puntiVitaAttuali, int maxPuntiVita)
        {
            this.PuntiVitaAttuali  = puntiVitaAttuali;
            this.MaxPuntiVita = maxPuntiVita;
        }
    }
}
