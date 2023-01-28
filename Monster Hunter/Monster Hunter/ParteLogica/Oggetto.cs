using System;
using System.Collections.Generic;

namespace ParteLogica
{
    // inizio della classe pubblica Oggetto
    public class Oggetto
    {
        // campi interni della classe
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NomePlurale { get; set; }

        // inizio metodo costruttore
        public Oggetto(int id, string nome, string nomePlurale)
        {
            this.ID          = id;
            this.Nome        = nome;
            this.NomePlurale = nomePlurale;
        }
    }
}
