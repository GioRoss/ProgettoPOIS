using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using ParteLogica;

namespace Monster_Hunter
{
    // inizio della classe pubblica parziale (in quanto la soluzione è divisa in due progetti) MonsterHunter
    public partial class MonsterHunter : Form
    {
        // attributi interni della classe
        private Personaggio giocatore;
        private Mostro mostroAttuale;
        private const string FILE_SALVATAGGIO = "DatiGiocatore.xml";

        // inizio metodo costruttore
        // questo metodo andrà ad inizilizzare tutti i dati del giocatore di inizio gioco, dal luogo di partenza
        // alla quantità di denaro, esperienza, oggetti iniziali ecc. del giocatore
        public MonsterHunter()
        {
            // metodo che carica la pagina compilata di un componente 
            InitializeComponent();

            if (File.Exists(FILE_SALVATAGGIO))
            {
                giocatore = Personaggio.CaricaDati(File.ReadAllText(FILE_SALVATAGGIO));
                MuovitiVerso(giocatore.PosizioneAttuale);
                MostraImmagini(giocatore.PosizioneAttuale);
            }
            else
            {
                // acquisisco il personaggio
                giocatore = Personaggio.GetPersonaggio();
                MuovitiVerso(giocatore.PosizioneAttuale);
            }
            
            // stampo, nelle relative 'labels' i vari parametri 
            lblPuntiVita.Text  = giocatore.PuntiVitaAttuali.ToString();
            lblEsperienza.Text = giocatore.Esperienza.ToString();
            lblSoldi.Text      = giocatore.Soldi.ToString();
            lblLivello.Text    = giocatore.Livello.ToString();
        }

        // questo metodo fa riferimento al pulsante 'Nord' nell'interfaccia grafica
        // quando verrà cliccato eseguirà i due metodi 'Muovitierso' e 'MostraImmagini'
        private void btnNord_Click(object sender, EventArgs e)
        {
            MuovitiVerso(giocatore.PosizioneAttuale.DirezioneNord);
            MostraImmagini(giocatore.PosizioneAttuale);
        }

        // questo metodo fa riferimento al pulsante 'Est' nell'interfaccia grafica
        // quando verrà cliccato eseguirà i due metodi 'Muovitierso' e 'MostraImmagini'
        private void btnEst_Click(object sender, EventArgs e)
        {
            MuovitiVerso(giocatore.PosizioneAttuale.DirezioneEst);
            MostraImmagini(giocatore.PosizioneAttuale);
        }

        // questo metodo fa riferimento al pulsante 'Sud' nell'interfaccia grafica
        // quando verrà cliccato eseguirà i due metodi 'Muovitierso' e 'MostraImmagini'
        private void btnSud_Click(object sender, EventArgs e)
        {
            MuovitiVerso(giocatore.PosizioneAttuale.DirezioneSud);
            MostraImmagini(giocatore.PosizioneAttuale);
        }

        // questo metodo fa riferimento al pulsante 'Ovest' nell'interfaccia grafica
        // quando verrà cliccato eseguirà i due metodi 'Muovitierso' e 'MostraImmagini'
        private void btnOvest_Click(object sender, EventArgs e)
        {
            MuovitiVerso(giocatore.PosizioneAttuale.DirezioneOvest);
            MostraImmagini(giocatore.PosizioneAttuale);
        }

        // questo metodo fa riferimetno al pulsante 'Usa' a fianco del menu a tendina riferito alle armi
        // quando verrà cliccato quindi, utilizzerà l'arma nel menu a tendina a fianco infliggendo un danno randomico
        // ad un mostro.
        // Se il mostro esaurirà i propri punti vita allora verrà segnalato nell'apposito riquadro assegnando poi al giocatore
        // i relativi punti esperienza e soldi, oltre questo il giocatore otterrà anche l'oggetto ottenibile dal mostro in base alla percentuale
        // di drop.
        // Fatto ciò il gioco fa "ritornare" il giocatore nello stesso luogo facendo cosi ricomparire un'altro mostro ricominciando il processo da capo
        // Se, invece, il mostro non dovesse morire, allora attaccherebbe il giocatore e nel caso il giocatore dovesse esaurire
        // i propri punti vita allora il gioco lo sposterebbe al luogo di inizio, ovvero 'città' 
        private void btnUsaArma_Click(object sender, EventArgs e)
        {
            // la variabile 'armaAttuale' prende l'arma selezionata nel comboBox (menu a tendina riferito alle armi)
            Arma armaAttuale  = (Arma)cboArmi.SelectedItem;

            // la variabile 'dannoAlMostro' prenderà un numero casuale compreso fra il danno minimo e il danno massimo dell'arma selezonata
            int dannoAlMostro = GeneratoreNumeriCasuali.NumeriCompresi(armaAttuale.DannoMinimo, armaAttuale.DannoMassimo);

            // decremento i punti vita attuali del mostro pari al valore precedentemente creato
            mostroAttuale.PuntiVitaAttuali -= dannoAlMostro;
            // segnalo al giocatore che ha colpito il mostro e quanto danno ha inflitto
            rtbMessaggi.Text += "Hai colpito il mostro " + mostroAttuale.Nome + " per " + dannoAlMostro.ToString() + " punti!" + Environment.NewLine;

            // se i punti vita del mostro scendono a 0
            if (mostroAttuale.PuntiVitaAttuali <= 0)
            {
                // segnalo al giocatore che ha sconfitto il mostro
                rtbMessaggi.Text += Environment.NewLine;
                rtbMessaggi.Text += "Hai sconfitto il mostro " + mostroAttuale.Nome + Environment.NewLine;
                // invoca il metodo presente nella classe 'Personaggio' per aggiungere i punti esperienza guadagnati 
                giocatore.AggiungiPuntiEsperienza(mostroAttuale.RicompensaPuntiEsperienza);
                rtbMessaggi.Text += "Ricevi " + mostroAttuale.RicompensaPuntiEsperienza.ToString() + " punti esperienza" + Environment.NewLine;
                // aggiungo i soldi ottenibili dal mostro al giocatore e glielo segnalo
                giocatore.Soldi  += mostroAttuale.RicompensaSoldi;
                rtbMessaggi.Text += "Ricevi " + mostroAttuale.RicompensaSoldi.ToString() + " guil" + Environment.NewLine;

                // pulisco i precedenti messaggi
                rtbMessaggi.Clear();

                // creo una lista di oggetti di tipo inventario che conterrà gli oggetti ottenuti sconfiggendo i vari mostri
                List<Inventario> oggettiOttenuti = new List<Inventario>();
                // per ogni oggetto presente nella lista degli OggettiOttenibili del mostro attuale
                foreach (OggettoOttenibile oggettoOttenuto in mostroAttuale.OggettiOttenibili)
                {
                    // se il numero casuale (compreso fra 0,99) è minore uguale del valore della percentuale di drop dell'oggetto
                    if (GeneratoreNumeriCasuali.NumeriCompresi(0, 99) <= oggettoOttenuto.PercentualeDrop)
                    {
                        // aggiungo l'oggetto nella lista inventario pari ad una quantità
                        Inventario oggetto = new Inventario(oggettoOttenuto.Dettagli, 1);
                        oggettiOttenuti.Add(oggetto);
                    }
                }
                // se non si è riuscito ad ottenere oggetti tramite il precedente foreach 
                if (oggettiOttenuti.Count == 0)
                {
                    // per ogni oggetto presente nella lista degli OggettiOttenibili del mostro attuale
                    foreach (OggettoOttenibile oggettoOttenuto in mostroAttuale.OggettiOttenibili)
                    {
                        // se l'oggetto è un oggetto base
                        if (oggettoOttenuto.EOggettoBase)
                        {
                            // aggiungo l'oggetto nella lista inventario pari ad una quantità 
                            Inventario oggettoBase = new Inventario(oggettoOttenuto.Dettagli, 1);
                            oggettiOttenuti.Add(oggettoBase);
                        }
                    }
                }
                // per ogni oggetto nell'inventario creato poc'anzi per contenere gli oggetti ottenuti dai mostri
                foreach (Inventario oggettoInventario in oggettiOttenuti)
                {
                    // aggiungo gli oggetti nell'inventario effettivo del giocatore 
                    giocatore.AggiungiOggettoInInventario(oggettoInventario.Dettagli);

                    // se la quantità è pari ad uno 
                    if(oggettoInventario.Quantita == 1)
                    {
                        // segnalo al giocatore che ha preso l'oggetto tramite il nome singolare
                        rtbMessaggi.Text += "Hai preso " + oggettoInventario.Quantita.ToString() + " " + oggettoInventario.Dettagli.Nome + Environment.NewLine;
                    }
                    else
                    {
                        // se la quantità è superiore ad uno allora segnalo al giocatore che preso piu oggetti tramite il nome plurale
                        rtbMessaggi.Text += "Hai preso " + oggettoInventario.Quantita.ToString() + " " + oggettoInventario.Dettagli.NomePlurale + Environment.NewLine;
                    }
                }

                // aggiorno le varie 'label'
                lblPuntiVita.Text  = giocatore.PuntiVitaAttuali.ToString();
                lblSoldi.Text      = giocatore.Soldi.ToString();
                lblEsperienza.Text = giocatore.Esperienza.ToString();
                lblLivello.Text    = giocatore.Livello.ToString();

                // se sconfiggo il drago finale 
                if ((mostroAttuale.ID == MondoDiGioco.MOSTRO_ID_DRAGO_FINALE))
                {
                    // mostro questo messaggio pop-up
                    MessageBox.Show("Questo è l'ultimo mostro da battere per completare la seconda, ed ultima, missione del gioco. \nMa non ti preoccupare puoi continuare comunque a giocare" +
                        " e a divertirti quanto vuoi, e miraccomando, non scordarti di tornare dal re nella piazza centrale per riscuotre il tuo meritatissimo premio!");
                }

                // aggiorno l'inventario nell'interfaccia grafica (aggiungo le righe necessarie nel dataGridView)
                AggiornaListaInventarioInUI();
                // aggiorno la lista della armi nell'interfaccia grafica (aggiungo eventuali armi nel comboBox [menu a tendina])
                AggiornaListaArmiInUI();
                // aggiorno la lista delle pozioni nell'interfaccia grafica (aggiungo eventuali pozioni nel comboBox [menu a tendina])
                AggiornaListaPozioniInUI();
                // "sposto" il giocatore nello stesso luogo cosi da far ricomparire un'altro mostro
                MuovitiVerso(giocatore.PosizioneAttuale);
            }
            // se sono qui vuol dire che il mostro non è morto ed i suoi punti vita sono maggiori di 0
            else
            {
                // la variabile 'dannoAlGiocatore' prenderà un numero casuale compreso fra 0 e il danno massimo del mostro attuale
                int dannoAlGiocatore = GeneratoreNumeriCasuali.NumeriCompresi(0, mostroAttuale.DannoMassimo);

                // segnalo al giocatore che il mostro lo ha attaccato
                rtbMessaggi.Text += "Il mostro " + mostroAttuale.Nome + " ti ha attaccato togliendoti " + dannoAlGiocatore.ToString() + " punti vita" + Environment.NewLine;
                // decremento i punti vita del giocatore con il valore casuale preso prima
                giocatore.PuntiVitaAttuali -= dannoAlGiocatore;
                // aggiorno la 'label' inerente alla vita del giocatore dopo l'accatto del mostro
                lblPuntiVita.Text = giocatore.PuntiVitaAttuali.ToString();

                // se i punti vita del giocatore scendono al di sotto dello 0 o se siano proprio zero
                if(giocatore.PuntiVitaAttuali <= 0)
                {
                    // segnalo al giocatore che il mostro l'ha ucciso
                    rtbMessaggi.Text += "Il mostro " + mostroAttuale.Nome + "ti ha ucciso :(" + Environment.NewLine;
                    // "sposto" il giocatore alla parte iniziale quindi la 'città'
                    MuovitiVerso(MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_CITTA));
                    // mostro l'immagine della città nell'UI
                    MostraImmagini(giocatore.PosizioneAttuale);
                }
            }
        }

        // questo metodo fa riferimetno al pulsante 'Usa' a fianco del menu a tendina riferito alle pozioni
        // quando verrà cliccato quindi, utilizzerà la pozione nel menu a tendina a fianco curando il giocatore.
        // Una volta utilizzata una pozione questa verrà consumata e quindi dovrà essere tolta dall'inventario del giocatore.
        // Quando il giocatore si sarò curato verrà riattaccato dal mostro, il quale potrebbe potenzialmente uccidere il
        // giocatore perciò, in quel caso verrebbe "spostato" nel luogo inziale, come accadeva sopra
        private void btnUsaPozioni_Click(object sender, EventArgs e)
        {
            // la variabile 'pozione' prende la pozione selezionata nel comboBox (menu a tendina riferito alle pozioni)
            PozioneCura pozione = (PozioneCura)cboPozioni.SelectedItem;

            // aggiungiamo la quantità da guarire ai punti vita attuali del giocatore
            giocatore.PuntiVitaAttuali += pozione.QuantitaDaGuarire;

            // se i punti vita attuali del giocatore superano i punti vita massimi che può ottenere 
            if (giocatore.PuntiVitaAttuali > giocatore.MaxPuntiVita)
            {
                // i punti vita attuali del giocatore prendono il valore dei punti vita massimi del medesimo
                giocatore.PuntiVitaAttuali = giocatore.MaxPuntiVita;
            }
            // per ogni elemento di tipo inventario nell'inventario del giocatore
            foreach (Inventario oggettoInventario in giocatore.Inventario)
            {
                // se l'ID dell'elemento corrisponde all'ID della pozione
                if(oggettoInventario.Dettagli.ID == pozione.ID)
                {
                    // decremento la quantità di quell'elemento di uno
                    oggettoInventario.Quantita--;
                    break;
                }
            }

            // segnalo al giocatore che ha usato la pozione
            rtbMessaggi.Text += "Hai usato una " + pozione.Nome + Environment.NewLine;

            // la variabile 'dannoAlGiocatore' prenderà un numero casuale compreso fra 0 e il danno massimo del mostro attuale
            int dannoAlGiocatore = GeneratoreNumeriCasuali.NumeriCompresi(0, mostroAttuale.DannoMassimo);
            // segnalo al giocatore che il mostro lo ha attaccato
            rtbMessaggi.Text += "Il mostro " + mostroAttuale.Nome + " ti ha attaccato togliendoti " + dannoAlGiocatore.ToString() + " punti vita" + Environment.NewLine;
            // decremento i punti vita del giocatore con il valore casuale preso prima
            giocatore.PuntiVitaAttuali -= dannoAlGiocatore;
            // se i punti vita del giocatore scendono al di sotto dello 0 o se siano proprio zero
            if (giocatore.PuntiVitaAttuali <= 0)
            {
                // segnalo al giocatore che il mostro l'ha ucciso
                rtbMessaggi.Text += "Il mostro " + mostroAttuale.Nome + " ti ha ucciso :(" + Environment.NewLine;
                // "sposto" il giocatore alla parte iniziale quindi la 'città'
                MuovitiVerso(MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_CITTA));
            }

            // aggiorno la 'label' inerente alla vita del giocatore dopo l'attacco del mostro
            lblPuntiVita.Text = giocatore.PuntiVitaAttuali.ToString();
            // aggiorno l'inventario nell'interfaccia grafica (aggiungo le righe necessarie nel dataGridView)
            AggiornaListaInventarioInUI();
            // aggiorno la lista delle pozioni nell'interfaccia grafica (aggiungo eventuali pozioni nel comboBox [menù a tendina])
            AggiornaListaPozioniInUI();
        }

        // questo metodo è il metodo che verrà invocato ogni volta che il giocatore cliccherà su un pulsante di movimento
        // questo metodo, quindi, in ordine andrà a controllare
        // - se il giocatore dispone dell'oggetto necessario per entrare nella nova zona, qual'ora la zona lo necessitasse
        // - ogni volta che il giocatore entrerà in una nuova zona gli verrà ricaricata la vita
        // - se c'è una missione disponibile nel nuovo luogo, ed in caso affermativo controlla se il giocatore dovesse avere già quella missione
        //   (se cosi non fosse gli verrebbe assegnata) se cosi fosse controlla se il giocatore ha gia completata questa missione,
        //   se cosi non fosse controlla se l'ha completata in quel momento in quanto possiede tutti gli oggetti necessari
        // - se c'è un mostro che vive nella nuova zona facendo comparire i bottoni per usare le armi e le pozioni con i relativi menù a tendina
        private void MuovitiVerso(Luogo nuovoLuogo)
        {
            // se il metodo restituirà true vorrà dire che il giocatore avrà gli oggetti o che il luogo non necessiterà di 
            // oggetti per entrare.
            // se il luogo prevede un oggetto per entrare e il giocatore non possiede ancora quell'oggetto tornerà false
            // con la negazione, l'if in caso il risultato fosse false mostrerà il messaggio all'utente ed uscirà dal metodo
            if (!giocatore.HaiOggettoNecessarioPerEntrareInLuogo(nuovoLuogo))
            {
                // mostro il messaggio all'utente
                rtbMessaggi.Text += "Devi avere " + nuovoLuogo.OggettoRichiestoPerEntrare.Nome + " per entrare in questo luogo." + Environment.NewLine;
                // esco dal metodo
                return;
            }
            // assegno alla posizione attuale del giocatore il luogo passatogli come parametro, quindi per esempio nel caso 
            // il giocatore fosse andato (dal luogo di partenza) a nord il nuovo luogo sarebbe 'entrata del regno'
            giocatore.PosizioneAttuale = nuovoLuogo;

            // se dalla posizione attuale, esiste un luogo in qualche direzione mostrerò i pulsanti di navigazione
            // altrimenti no
            btnNord.Visible  = (nuovoLuogo.DirezioneNord != null);
            btnEst.Visible   = (nuovoLuogo.DirezioneEst != null);
            btnSud.Visible   = (nuovoLuogo.DirezioneSud != null);
            btnOvest.Visible = (nuovoLuogo.DirezioneOvest != null);

            // mostro nel richTextBox in alto (riferito al luogo) i dati del luogo
            rtbLuogo.Text = nuovoLuogo.Nome + Environment.NewLine;
            rtbLuogo.Text += nuovoLuogo.Descrizione + Environment.NewLine;

            // ricarico tutta la vita del giocatore
            giocatore.PuntiVitaAttuali = giocatore.MaxPuntiVita;
            // aggiorno la 'label' con gli attuali punti vita
            lblPuntiVita.Text = giocatore.PuntiVitaAttuali.ToString();

            // se c'è una missione in questo luogo
            if (nuovoLuogo.MissioneDisponibileQui != null)
            {
                // dichiaro due varibili di tipo booleano
                // questa variabile andrà a salvare il risultato del metodo presente nella classe 'Personaggio' e quindi sarà
                // true nel caso c'è una missione nella lista delle missioni presente in quel luogo, oppure false
                bool giocatoreHaGiaMissione = giocatore.HaiQuestaMissione(nuovoLuogo.MissioneDisponibileQui);
                // questa variabile andrà a salvare il risultato del metodo presente nella classe 'Personaggio' e quindi sarà
                // true se la missione è stata completata, altrimenti false
                bool giocatoreHaGiaCompletatoMissione = giocatore.MissioneCompletata(nuovoLuogo.MissioneDisponibileQui);

                // se il risultato della variabile è true (quindi il giocatore ha già la missione)
                if (giocatoreHaGiaMissione)
                {
                    // se il risultato di questa variabile sarà true (quindi il giocatore ha già completata la missione) salta questo if
                    // se, invece, il risultato della variabile sarà false (quindi non ha completato la missione)
                    if (!giocatoreHaGiaCompletatoMissione)
                    {
                        // dichiaro una variabile booleana che salverà il risultato del metodo presente nella classe 'Personaggio', il quale
                        // restituirà false qual'ora il giocatore non abbia gli oggetti o non nella giusta quantità, altrimenti resituirà true
                        bool giocatoreHaTuttiGliOggettiPerMissione = giocatore.HaiTuttiGliOggettiCompletamentoMissione(nuovoLuogo.MissioneDisponibileQui);

                        // se il risultato della variabile è true  (il giocatore ha tutti gli oggetti e nella giusta quantità)
                        if (giocatoreHaTuttiGliOggettiPerMissione)
                        {
                            // segnalo al giocatore che ha completato la missione
                            rtbMessaggi.Text += Environment.NewLine + "Hai completato la missione " + nuovoLuogo.MissioneDisponibileQui.Nome + Environment.NewLine;
                            // rimuovo dall'inventario gli oggetti che servivano per completare la missione
                            giocatore.RimuoviOggettoCompletamentoMissione(nuovoLuogo.MissioneDisponibileQui);
                            // segnalo al giocatore gli oggetti che andrà a ricevere
                            rtbMessaggi.Text += "Ricevi: " + Environment.NewLine;
                            rtbMessaggi.Text += nuovoLuogo.MissioneDisponibileQui.RicompensaPuntiEsperienza.ToString() + " punti esperienza" + Environment.NewLine;
                            rtbMessaggi.Text += nuovoLuogo.MissioneDisponibileQui.RicompensaSoldi.ToString() + " guil" + Environment.NewLine;
                            rtbMessaggi.Text += nuovoLuogo.MissioneDisponibileQui.OggettoRicompensa.Nome + Environment.NewLine;
                            rtbMessaggi.Text += Environment.NewLine;
                            // invoca il metodo per aggiungere i punti esperienza al giocatore cosicchè possa aumentare anche i suoi punti vita massimi
                            giocatore.AggiungiPuntiEsperienza(nuovoLuogo.MissioneDisponibileQui.RicompensaPuntiEsperienza);
                            // aggiungo la ricompensa in denaro per aver superato la missione
                            giocatore.Soldi += nuovoLuogo.MissioneDisponibileQui.RicompensaSoldi;
                            // aggiungo gli oggetti della ricompensa per aver superato la missione nell'inventario del giocatore
                            giocatore.AggiungiOggettoInInventario(nuovoLuogo.MissioneDisponibileQui.OggettoRicompensa);
                            // segnalo che la missione è stata superata modificando, tramite il metodo, la variabile corrispondente nella missione
                            giocatore.SegnalaMissioneCompletata(nuovoLuogo.MissioneDisponibileQui);
                        }
                    }
                }
                // altrimenti il giocatore non aveva ancora quella missione
                else
                {
                    // elimino le precedenti scritte
                    rtbMessaggi.Clear();

                    // segnalo al giocatore che sta prendendo una nuova missione 
                    rtbMessaggi.Text += "Ricevi la missione " + nuovoLuogo.MissioneDisponibileQui.Nome + Environment.NewLine;
                    rtbMessaggi.Text += nuovoLuogo.MissioneDisponibileQui.Descrizione + Environment.NewLine;
                    rtbMessaggi.Text += "Per completare la missione devi tornare con: " + Environment.NewLine;

                    // per ogni elemento nella lista degli oggetti per il completamento di una missione legati a quel luogo 
                    foreach (OggettoCompletamentoMissione oggettoCompletamentoMissione in nuovoLuogo.MissioneDisponibileQui.OggettiCompletamentoMissione)
                    {
                        // se la quantità di quell'oggetto è pari ad uno
                        if (oggettoCompletamentoMissione.Quantita == 1)
                        {
                            // segnalo al giocatore l'ggetto da portare con il nome singolare
                            rtbMessaggi.Text += oggettoCompletamentoMissione.Quantita.ToString() + " " + oggettoCompletamentoMissione.Dettagli.Nome + Environment.NewLine;
                        }
                        else
                        {
                            // altrimenti segnalo al giocatore l'oggetto da portare con il nome plurale
                            rtbMessaggi.Text += oggettoCompletamentoMissione.Quantita.ToString() + " " + oggettoCompletamentoMissione.Dettagli.NomePlurale + Environment.NewLine;
                        }
                    }
                    // mando a capo le scritte
                    rtbMessaggi.Text += Environment.NewLine;

                    // aggiungo la missione alla lista delle missioni del giocatore nella classe 'Personaggio'
                    MissioneGiocatore nuovaMissione = new MissioneGiocatore(nuovoLuogo.MissioneDisponibileQui);
                    giocatore.Missioni.Add(nuovaMissione);
                }
            }

            // se c'è un mostro in questo luogo
            if(nuovoLuogo.MostroCheViveQui != null)
            {
                // segnalo al giocatore che appare un mostro
                rtbMessaggi.Text += "\nIl mostro " + nuovoLuogo.MostroCheViveQui.Nome + " ti attacca all'improvviso" + Environment.NewLine;

                // creo un mostro base di tipo mostro
                Mostro mostroBase = MondoDiGioco.MostroPerID(nuovoLuogo.MostroCheViveQui.ID);
                // utilizzo la variabile globale 'mostroAttuale' per creare il mostro attuale sulla base del mostro base
                this.mostroAttuale = new Mostro(mostroBase.ID, mostroBase.Nome, mostroBase.DannoMassimo, mostroBase.RicompensaPuntiEsperienza, 
                    mostroBase.RicompensaSoldi, mostroBase.PuntiVitaAttuali, mostroBase.MaxPuntiVita);

                // per ogni elemento negli oggetti ottenibili da un mostro
                foreach(OggettoOttenibile oggettoOttenibile in mostroBase.OggettiOttenibili)
                {
                    // aggiungo al mostro attuale i gli oggetti ottenibili da quel particolare mostro
                    this.mostroAttuale.OggettiOttenibili.Add(oggettoOttenibile);
                }

                // rendo visibile i vari bottoni e menu a tendina
                cboArmi.Visible       = true;
                cboPozioni.Visible    = true;
                btnUsaArma.Visible    = true;
                btnUsaPozioni.Visible = true;
            }
            //altrimenti se non c'è
            else
            {
                // in questo caso il mostro non c'è, quindi sarà null
                this.mostroAttuale = null;
                // rendo i bottoni ed il menu a tendina invisibile
                cboArmi.Visible       = false;
                cboPozioni.Visible    = false;
                btnUsaArma.Visible    = false;
                btnUsaPozioni.Visible = false;
            }

            //  aggiorno l'inventario nell'interfaccia grafica (aggiungo le righe necessarie nel dataGridView)
            AggiornaListaInventarioInUI();
            // aggiorno la lista delle missioni nell'interfaccia grafica (aggiungo le righe necessarie nel dataGridView)
            AggiornaListaMissioniInUI();
            // aggiorno la lista delle armi nell'interfaccia grafica (aggiungo eventuali armi nel comboBox [menù a tendina])
            AggiornaListaArmiInUI();
            // aggiorno la lista delle pozioni nell'interfaccia grafica (aggiungo eventuali pozioni nel comboBox [menù a tendina])
            AggiornaListaPozioniInUI();
        }

        // metodo per aggiornare l'inventario del giocatore
        // questo metodo aggiorna il dataGridView riferito all'inventario del giocatore
        // quando il giocatore acquisira un nuovo oggetto questo metodo aggiungerà una riga
        // con il corrispondente oggetto
        private void AggiornaListaInventarioInUI()
        {
            // rendo invisibile l'header delle righe
            dgvInventario.RowHeadersVisible = false;

            // creo due colonne
            dgvInventario.ColumnCount = 2;
            // la prima colonna si chiamerà 'nome' con una larghezza di 197
            dgvInventario.Columns[0].Name  = "Nome";
            dgvInventario.Columns[0].Width = 197;
            // la seconda colonna si chiamerà 'quantità'
            dgvInventario.Columns[1].Name  = "Quantità";
            // ogni volta che si aggiorna l'inventario vengono eliminate le righe cosi da mantenere
            // pulito visivamente il dataGridView
            dgvInventario.Rows.Clear();

            // per ogni elemento nell'inventario del giocatore
            foreach(Inventario oggettoInventario in giocatore.Inventario)
            {
                // se la quantità di quell'elemento è superiore a 0
                if(oggettoInventario.Quantita > 0)
                {
                    // aggiungo una riga con quell'elemento
                    dgvInventario.Rows.Add(new[] { oggettoInventario.Dettagli.Nome, oggettoInventario.Quantita.ToString()});
                }
            }
        }

        // metodo per aggiornare la lista delle missioni del giocatore
        // questo metodo aggiorna il dataGridView riferito alla lista delle missioni del giocatore
        // quando il giocatore acquisira una nuova missione questo metodo aggiungerà una riga
        // con la corrispondente missione
        private void AggiornaListaMissioniInUI()
        {
            //rendo invisibile l'header delle righe
            dgvMissioni.RowHeadersVisible = false;

            // creo due colonne
            dgvMissioni.ColumnCount = 2;
            // la prima colonna si chiamerà 'nome' con una larghezza di 197
            dgvMissioni.Columns[0].Name  = "Nome";
            dgvMissioni.Columns[0].Width = 197;
            // la seconda colonna si chiamerà 'quantità'
            dgvMissioni.Columns[1].Name = "Completata?";
            // ogni volta che si aggiorna l'inventario vengono eliminate le righe cosi da mantenere
            // pulito visivamente il dataGridView
            dgvMissioni.Rows.Clear();

            // per ogni missione che ha il giocatore
            foreach (MissioneGiocatore missioneGiocatore in giocatore.Missioni)
            {
                // aggiungo una riga con quella missione
                dgvMissioni.Rows.Add(new[] { missioneGiocatore.Dettagli.Nome, missioneGiocatore.ECompletata.ToString() });
            }
        }

        // metodo per aggiornare le armi nel menù a tendina del giocatore
        // questo metodo aggiorna il comboBox, quindi il menu a tendina, riferito alle armi
        // quando il giocatore prenderà una nuova arma questa comparirà in questo menù
        private void AggiornaListaArmiInUI()
        {
            // creo una lista di armi 
            List<Arma> armi = new List<Arma>();

            // per ogni elemento nell'inventario del giocatore
            foreach(Inventario oggettoInventario in giocatore.Inventario)
            {
                // se l'elemento presente nell'inventario del giocatore è di tipo arma
                if(oggettoInventario.Dettagli is Arma)
                {
                    // se la quantità di questo elemento è superiore a 0 nell'inventario
                    if(oggettoInventario.Quantita > 0)
                    {
                        // aggiungo l'oggetto presente nell'inventario del giocatore
                        // nella lista delle armi 
                        armi.Add((Arma)oggettoInventario.Dettagli);
                    }
                }
            }
            // se nella lista non sono presente elementi
            if(armi.Count == 0)
            {
                // rendo invisibile il menu a tendina ed il bottone per le armi
                cboArmi.Visible    = false;
                btnUsaArma.Visible = false;
            }
            // se sono qui vuol dire che c'è almeno un elemento
            else
            {
                // imposto l'origine dati per l'oggetto
                cboArmi.DataSource    = armi;
                // mostro il nome singolare dell'oggetto nel comboBox
                cboArmi.DisplayMember = "Nome";
                // specifico una proprietà specifica
                cboArmi.ValueMember   = "ID";
                // indice dell'elemento selezionato, cosi da rendere sempre visibile l'arma selezionata
                cboArmi.SelectedIndex = 0;
            }
        }

        // metodo per aggiornare le pozioni nel menù a tendina del giocatore
        // questo metodo aggiorna il comboBox, quindi il menu a tendina, riferito alle pozioni
        // quando il giocatore prenderà una nuova pozione comparirà in questo menù
        private void AggiornaListaPozioniInUI()
        {
            // creo una lista di pozioni
            List<PozioneCura> pozioni = new List<PozioneCura>();

            // per ogni elemento nell'inventario del giocatore
            foreach(Inventario oggettoInventario in giocatore.Inventario)
            {
                // se l'oggetto è una pozione
                if(oggettoInventario.Dettagli is PozioneCura)
                {
                    // se la quantità è superiore a 0 nell'inventario
                    if(oggettoInventario.Quantita > 0)
                    {
                        // aggiungo l'oggetto presente nell'inventario del giocatore
                        // nella lista delle pozioni 
                        pozioni.Add((PozioneCura)oggettoInventario.Dettagli);
                    }
                }
            }
            // se nella lista non sono presente elementi
            if (pozioni.Count == 0)
            {
                // rendo invisibile il menu a tendina ed il bottone per le armi
                cboPozioni.Visible    = false;
                btnUsaPozioni.Visible = false;
            }
            // se sono qui vuol dire che c'è almeno un elemento
            else
            {
                // imposto l'origine dati per l'oggetto
                cboPozioni.DataSource    = pozioni;
                // mostro il nome singolare dell'oggetto nel comboBox
                cboPozioni.DisplayMember = "Nome";
                // specifico una proprietà specifica
                cboPozioni.ValueMember   = "ID";
                // indice dell'elemento selezionato, cosi da rendere sempre visibile la pozione selezionata
                cboPozioni.SelectedIndex = 0;
            }
        }

        // questo metodo serve, ogni volta che il giocatore si sposta all'interno del mondo di gioco, ad aggiornare
        // le immagini nel riquadro a destra dell'interfaccia grafica cambiando di volta in volta l'immagine raffigurante
        // il luogo dove si è o il mostro da combattere
        private void MostraImmagini(Luogo luogoAttualeGiocatore)
        {
            // se il luogo attuale del giocatore è uguale al luogo iniziale
            if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_CITTA))
            {
                // mostro la relativa immagine
                pictureBoxDestra.Image = Properties.Resources.Città;
            }
            else if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_ENTRATA_REGNO))
            {
                pictureBoxDestra.Image = Properties.Resources.entrata_regno;
            }
            else if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_PONTE_DI_LEGNO))
            {
                pictureBoxDestra.Image = Properties.Resources.ponte_di_legno;
            }
            else if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_CAVERNA_ELETTRICA))
            {
                pictureBoxDestra.Image = Properties.Resources.caverna_elettrica;
            }
            else if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_SENTIERO_RADURA))
            {
                pictureBoxDestra.Image = Properties.Resources.radura;
            }
            else if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_FORESTA_BANANE))
            {
                pictureBoxDestra.Image = Properties.Resources.foresta_banane;
            }
            else if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_PIAZZA_CENTRALE))
            {
                pictureBoxDestra.Image = Properties.Resources.piazza_centrale;
            }
            else if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_DESERTO_ROVENTE))
            {
                pictureBoxDestra.Image = Properties.Resources.Deserto;
            }
            else if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_FORESTA))
            {
                pictureBoxDestra.Image = Properties.Resources.foresta;
            }
            else if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_TANA_ORCO))
            {
                pictureBoxDestra.Image = Properties.Resources.tana_orchi;
            }
            else if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_ENTRATA_GROTTA))
            {
                pictureBoxDestra.Image = Properties.Resources.entrata_grotta;
            }
            else if (luogoAttualeGiocatore == MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_TORRE_DRAGO))
            {
                pictureBoxDestra.Image = Properties.Resources.torre_finale_drago;
            }
        }

        // questo metodo fa riferimento al bottone 'mapap' presente fra i comandi di movimento
        // questo metodo non fa altro che avviare il secondo WindowsForm relativo alla mappa dove conterrà 
        // le immagini statiche dell'intera mappa di gioco per aiutare il giocatore ad orientarsi qual'ora 
        // ne avesse bisogno
        private void btnMappa_Click(object sender, EventArgs e)
        {
            // creo un'istanza della MappaDiGioco
            MappaDiGioco mappa = new MappaDiGioco();
            // decido la posizione iniziale della schermata
            mappa.StartPosition = FormStartPosition.CenterParent;
            // visualizza il form come una finestra di dialogo
            mappa.ShowDialog(this);
        }

        // metodo per chiudere il gioco
        private void btnChiudiGioco_Click(object sender, EventArgs e)
        {
            Close();
        }

        // questo metodo fa riferimento al bottone salva 
        private void btnSalva_Click(object sender, EventArgs e)
        {
            // scrive un file xml con i dati del giocatore in quell'istante
            File.WriteAllText(FILE_SALVATAGGIO, giocatore.CreaXml());
        }

        // questo metodo fa riferimento al bottone cancella salvataggio
        private void btnCancellaSalvataggio_Click(object sender, EventArgs e)
        {
            try
            {
                string percorsoSalvataggio = Directory.GetCurrentDirectory();

                if (File.Exists(FILE_SALVATAGGIO))
                {
                    File.Delete(percorsoSalvataggio + @"\DatiGiocatore.xml");
                }
                else
                {
                    MessageBox.Show("Non è stato trovato nessun salvataggio di gioco, oppure è stato già cancellato.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore " + ex + " Ops qualcosa è andato storto, probabilmente c'è stato un problema con la directory :(");
            }
        }
    }
}
