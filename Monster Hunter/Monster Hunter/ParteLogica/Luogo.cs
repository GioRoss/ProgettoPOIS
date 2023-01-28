using System;
using System.Collections.Generic;

namespace ParteLogica
{
    // inizio della classe pubblica Luogo
    public class Luogo
    {
        // campi interni della classe
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Oggetto OggettoRichiestoPerEntrare { get; set; }
        public Missione MissioneDisponibileQui { get; set; }
        public Mostro MostroCheViveQui { get; set; }
        public Luogo DirezioneNord { get; set; }
        public Luogo DirezioneEst { get; set; }
        public Luogo DirezioneSud { get; set; }
        public Luogo DirezioneOvest { get; set; }

        // inizio metodo costruttore
        // questo metodo prenderà in ingresso gli attributi sopra citati ad esclusione delle 4 direzioni che invece verranno
        // poi usate nella classe Mondo di Gioco per collegare i vari luoghi. Si è cosi fatto per non andare a creare un costruttore
        // troppo grande
        public Luogo(int id, string nome, string descrizione, Oggetto oggettoRichiestoPerEntrare = null, Missione missioneDisponibileQui = null, Mostro mostroCheViveQui = null)
        {
            this.ID                         = id;
            this.Nome                       = nome;
            this.Descrizione                = descrizione;
            this.OggettoRichiestoPerEntrare = oggettoRichiestoPerEntrare;
            this.MissioneDisponibileQui     = missioneDisponibileQui;
            this.MostroCheViveQui           = mostroCheViveQui;
        }
    }
}
