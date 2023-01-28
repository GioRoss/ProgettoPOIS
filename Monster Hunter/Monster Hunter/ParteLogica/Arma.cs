using System;
using System.Collections.Generic;

namespace ParteLogica
{
    // inizio della classe pubblica Arma, la quale estende la classe Oggetto
    public class Arma : Oggetto
    {
        // campi interni della classe 
        public int DannoMinimo { get; set; }
        public int DannoMassimo { get; set; }

        // inizio metodo costruttore
        // questo metodo dovrà soddisfare anche i parametri della classe Oggetto, e quindi verranno passati alla classe citata pocanzi
        // attraverso la keyword base
        public Arma(int id, string nome, string nomePlurale, int dannoMinimo, int dannoMassimo) : base(id, nome, nomePlurale)
        {
            this.DannoMinimo  = dannoMinimo;
            this.DannoMassimo = dannoMassimo;
        }
    }
}
