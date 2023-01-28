using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster_Hunter
{
    // inizio della classe pubblica parziale (in quanto la soluzione è divisa in due progetti) MappaDiGioco
    public partial class MappaDiGioco : Form
    {
        // inizio metodo costruttore
        public MappaDiGioco()
        {
            // metodo che carica la pagina compilata di un componente
            InitializeComponent();
            // metodo per l'inserimento delle immagine nella griglia della mappa
            InserisciImmagini();
        }

        // metodo per l'inserimento delle varie immagini nei vari settori
        private void InserisciImmagini()
        {
            foto_3_2.Image = Properties.Resources.Città2;
            foto_2_2.Image = Properties.Resources.entrata_regno2;
            foto_2_1.Image = Properties.Resources.radura2;
            foto_2_0.Image = Properties.Resources.foresta_banane2;
            foto_2_3.Image = Properties.Resources.ponte_di_legno2;
            foto_2_4.Image = Properties.Resources.caverna_elettrica2;
            foto_1_2.Image = Properties.Resources.piazza_centrale2;
            foto_1_3.Image = Properties.Resources.Deserto2;
            foto_1_4.Image = Properties.Resources.torre_finale_drago2;
            foto_1_1.Image = Properties.Resources.foresta2;
            foto_1_0.Image = Properties.Resources.tana_orchi2;
            foto_0_2.Image = Properties.Resources.entrata_grotta2;

            // stampa del messaggio riportato nel riquadro sotto la mappa
            rtbSotto.Text  = "Questa raffigurata sopra è la mappa di gioco." + Environment.NewLine + "La mappa si divide in 12 aree mentre le frecce " +
                "rosse indicano la direzione dove è possibile muoversi. Le zone nere sono delle regioni non ancora scoperte." + Environment.NewLine + 
                "Per entrare in alcune zone sarà necessario avere un particolare oggetto ottenibile completando la relativa missione.";
        }

        // questo metodo fa riferimento al pulsante 'Chiudi' nell'interfaccia grafica 
        // chiude la finestra
        private void btnChiudiMappa_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
