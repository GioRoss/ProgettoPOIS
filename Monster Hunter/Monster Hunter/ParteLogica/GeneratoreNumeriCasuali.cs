using System;
using System.Collections.Generic;

namespace ParteLogica
{
    // inizio della classe pubblica Generatore di Numeri Casuali
    public static class GeneratoreNumeriCasuali
    {
        // attributi interni della classe
        // in questo caso istanziamo il generatore tramite la funzione 'Random'
        private static Random generatore = new Random();
        
        // metodo per la generazione di un numero casuale compreso tra i due valori interi passati
        public static int NumeriCompresi(int valoreMinimo, int valoreMassimo)
        {
            // il metodo ritornerà un valore compreso fra i due valori
            return generatore.Next(valoreMinimo, valoreMassimo + 1);
        }
    }
}
