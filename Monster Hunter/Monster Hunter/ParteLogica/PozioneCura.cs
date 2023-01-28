using System;
using System.Collections.Generic;

namespace ParteLogica
{
    // inizio della classe pubblica Pozione di Cura, la quale estende la classe Oggetto
    public class PozioneCura : Oggetto
    {
        // campi interni della classe
        public int QuantitaDaGuarire { get; set; }

        // metodo costruttore
        // questo metodo dovrà soddisfare anche parametri della classe Oggetto, e quindi verranno passati alla classe citata pocanzi
        // attraverso la keyword base
        public PozioneCura(int id, string nome, string nomePlurale, int quantitaDaGuarire) : base(id, nome, nomePlurale)
        {
            this.QuantitaDaGuarire = quantitaDaGuarire;
        }
    }
}
