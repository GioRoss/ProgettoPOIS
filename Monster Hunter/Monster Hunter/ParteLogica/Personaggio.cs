using System;
using System.Collections.Generic;
using System.Xml;

namespace ParteLogica
{
    // inizio della classe pubblica e sigillata Personaggio, che estende la classe Creature Viventi
    public sealed class Personaggio : CreatureViventi
    {
        // campi interni della classe
        public int Soldi { get; set; }
        public int Esperienza { get; set; }
        public int Livello { get; set; }
        public List<Inventario> Inventario { get; set; }
        public List<MissioneGiocatore> Missioni { get; set; }
        public Luogo PosizioneAttuale { get; set; }
        private static Personaggio personaggioBase;

        // metodo costruttore privato
        // questo metodo dovrà soddisfare anche i parametri della classe Creature Viventi, e quindi verranno passati alla classe citata pocanzi
        // attraverso la keyword base
        private Personaggio(int soldi, int esperienza, int livello, int puntiVitaAttuali, int maxPuntiVita) : base(puntiVitaAttuali, maxPuntiVita)
        {
            this.Soldi      = soldi;
            this.Esperienza = esperienza;
            this.Livello    = livello;

            this.Inventario = new List<Inventario>();
            this.Missioni   = new List<MissioneGiocatore>();
        }

        // metodo per creare un personaggio base posizionandolo nel luogo di partenza con gli oggetti base di partenza
        private static Personaggio PersonaggioBase()
        {
            personaggioBase                   = new Personaggio(20, 0, 0, 10, 10);
            personaggioBase.PosizioneAttuale  = MondoDiGioco.LuogoPerID(MondoDiGioco.LUOGO_ID_CITTA);
            Inventario spadaArrugginita       = new Inventario(MondoDiGioco.OggettoPerID(MondoDiGioco.OGGETTO_ID_SPADA_ARRUGGINITA), 1);
            Inventario pozioni                = new Inventario(MondoDiGioco.OggettoPerID(MondoDiGioco.OGGETTO_ID_POZIONE), 5);
            personaggioBase.Inventario.Add(spadaArrugginita);
            personaggioBase.Inventario.Add(pozioni);

            // restituisco il giocatore
            return personaggioBase;
        }

        // metodo per l'ottenimento sempre dello stesso personaggio creato
        public static Personaggio GetPersonaggio()
        {
            // se non è mai stato creato
            if(personaggioBase == null)
            {
                // lo creo
                PersonaggioBase();
            }

            // ottengo il personaggio
            return personaggioBase;
        }

        // metodo per la creazione del file xml
        public string CreaXml()
        {
            // creo una variabile di tipo documento di xml
            XmlDocument datiGiocatore = new XmlDocument();

            // creo la sezione giocatore (che ingloberà tutte le altre sezioni)
            XmlNode giocatore = datiGiocatore.CreateElement("Giocatore");
            datiGiocatore.AppendChild(giocatore);

            // creo la sezione statistiche (che sarà compresa dentro giocatore e che conterrà i vari parametri)
            XmlNode statistiche = datiGiocatore.CreateElement("Statistiche");
            giocatore.AppendChild(statistiche);

            // creo la sezione punti vita attuali dentro la sezione statistiche
            XmlNode puntiVitaAttuali = datiGiocatore.CreateElement("PuntiVitaAttuali");
            // salvo in questa sezione il dato riferente ai punti vitali
            puntiVitaAttuali.AppendChild(datiGiocatore.CreateTextNode(this.PuntiVitaAttuali.ToString()));
            statistiche.AppendChild(puntiVitaAttuali);

            // creo la sezione punti vita massimi dentro la sezione statistiche
            XmlNode puntiVitaMassimi = datiGiocatore.CreateElement("PuntiVitaMassimi");
            // salvo in questa sezione il dato riferente ai punti vita massimi
            puntiVitaMassimi.AppendChild(datiGiocatore.CreateTextNode(this.MaxPuntiVita.ToString()));
            statistiche.AppendChild(puntiVitaMassimi);

            // creo la sezione soldi dentro la sezione statistiche
            XmlNode soldi = datiGiocatore.CreateElement("Soldi");
            // salvo in questa sezione il dato riferente ai soldi che ha il giocatore
            soldi.AppendChild(datiGiocatore.CreateTextNode(this.Soldi.ToString()));
            statistiche.AppendChild(soldi);

            // creo la sezione punti esperienza dentro la sezione statistiche
            XmlNode Esperienza = datiGiocatore.CreateElement("PuntiEsperienza");
            // salvo in questa sezione il dato riferente all'esperienza del giocatore
            Esperienza.AppendChild(datiGiocatore.CreateTextNode(this.Esperienza.ToString()));
            statistiche.AppendChild(Esperienza);

            // creo la sezione livello dentro la sezione statistiche
            XmlNode Livello = datiGiocatore.CreateElement("Livello");
            // salvo in questa sezione il dato riferente al livello del giocatore
            Livello.AppendChild(datiGiocatore.CreateTextNode(this.Livello.ToString()));
            statistiche.AppendChild(Livello);

            // creo la sezione luogo attuale dentro la sezione statistiche
            XmlNode luogoAttuale = datiGiocatore.CreateElement("LuogoAttuale");
            // salvo in questa sezione il dato riferente alla posizione attuale del giocatore
            luogoAttuale.AppendChild(datiGiocatore.CreateTextNode(this.PosizioneAttuale.ID.ToString()));
            statistiche.AppendChild(luogoAttuale);

            // creo la sezione inventario (che sarà all'interno della sezione giocatore)
            XmlNode inventario = datiGiocatore.CreateElement("Inventario");
            giocatore.AppendChild(inventario);

            // creo una sezione per ogni oggetto dell'inventario
            // per ogni oggetto dell'inventario
            foreach (Inventario oggetto in this.Inventario)
            {
                // creo una sezione inventario
                XmlNode oggettoInInventario = datiGiocatore.CreateElement("Oggetto");

                // in questa sezione avrò un'attributo chiamato ID
                XmlAttribute attributoID = datiGiocatore.CreateAttribute("ID");
                // il quale valore corrisponderà all'ID dell'oggetto selezionato in questo momento
                attributoID.Value = oggetto.Dettagli.ID.ToString();
                // salvo questa informazione all'interno della sezione appena creata
                oggettoInInventario.Attributes.Append(attributoID);

                // avrò anche un'altro attributo chiamato quantità
                XmlAttribute quantityAttribute = datiGiocatore.CreateAttribute("Quantità");
                // il valore di questo attrivuto sarà dato dalla quantità dell'oggetto selezionato in queto momento
                quantityAttribute.Value = oggetto.Quantita.ToString();
                // salvo anche questa informazione dentro la sezione creata pocanzi
                oggettoInInventario.Attributes.Append(quantityAttribute);

                // la sezione 'Oggetto' sarà compreso dentro la sezione creata fuori dal foreach chiamata anch'essa 'inventario'
                inventario.AppendChild(oggettoInInventario);
            }

            // creo una sezione per le missioni (che sarà all'interno della sezione giocatore)
            XmlNode missioni = datiGiocatore.CreateElement("MissioniDelGiocatore");
            giocatore.AppendChild(missioni);

            // per una sezione per ogni missione del giocatore
            // per ogni missione del giocatore
            foreach (MissioneGiocatore missione in this.Missioni)
            {
                // creo una sezione chiamata missioni giocatore
                XmlNode missioneGiocatore = datiGiocatore.CreateElement("MissioneGiocatore");

                // in questa sezione avrò un'attributo ID
                XmlAttribute attributoID = datiGiocatore.CreateAttribute("ID");
                // il valore di questo attributo sarà l'ID della missione
                attributoID.Value = missione.Dettagli.ID.ToString();
                // salvo questa informazione all'interno della sezione appena creata
                missioneGiocatore.Attributes.Append(attributoID);

                // creo un'altro attributo chiamato è completata
                XmlAttribute isCompletedAttribute = datiGiocatore.CreateAttribute("ECompletata");
                // il valore sarà quello del parametro corrispondente 
                isCompletedAttribute.Value = missione.ECompletata.ToString();
                // salvo anche questa informazione all'intero della sezione corrente
                missioneGiocatore.Attributes.Append(isCompletedAttribute);

                // la sezione 'MissioniGiocatore' sarà compresa dentro la sezione 'MissioniDelGiocatore'
                missioni.AppendChild(missioneGiocatore);
            }

            // il metodo, tramite la proprietà InnerXml di XmlDocument, ritornerà tutto il documento
            // xml come stringa (questo perchè mi servirà poi per essere caricato)
            return datiGiocatore.InnerXml;
        }
    
        // metodo per il caricamento dei dati del giocatore dal file xml creato
        public static Personaggio CaricaDati(string salvataggio)
        {
            // provo a caricare il file, qual'ora andasse male creerei un personaggio base
            try
            {
                // creo una variabile di tipo xml documento per andare a cariare le informazioni salvate 
                XmlDocument datiGiocatore = new XmlDocument();
                // carico le informazioni
                datiGiocatore.LoadXml(salvataggio);

                // converto il dato di cui ho bisogno in intero e lo salvo nella variabile corrispondente
                // per fare questo uso la funzione SelectSingleNode passandogli il percorso che insieme ad InnerText otteniamo il valore formato stringa
                // ragion per cui poi convertiremo tutto in intero per ottenere il numero
                int puntiVitaAttuali = Convert.ToInt32(datiGiocatore.SelectSingleNode("/Giocatore/Statistiche/PuntiVitaAttuali").InnerText);
                int puntiVitaMassimi = Convert.ToInt32(datiGiocatore.SelectSingleNode("/Giocatore/Statistiche/PuntiVitaMassimi").InnerText);
                int soldi            = Convert.ToInt32(datiGiocatore.SelectSingleNode("/Giocatore/Statistiche/Soldi").InnerText);
                int esperienza       = Convert.ToInt32(datiGiocatore.SelectSingleNode("/Giocatore/Statistiche/PuntiEsperienza").InnerText);
                int livello          = Convert.ToInt32(datiGiocatore.SelectSingleNode("/Giocatore/Statistiche/Livello").InnerText);

                // istanzio il personaggio con i dati salvati
                Personaggio giocatore = new Personaggio(soldi, esperienza, livello, puntiVitaAttuali, puntiVitaMassimi);

                // converto il valore del luogo attuale in un intero e lo salvo nella variabile corrispondente
                int iDLuogoAttuale = Convert.ToInt32(datiGiocatore.SelectSingleNode("/Giocatore/Statistiche/LuogoAttuale").InnerText);
                // sposto il giocatore nell'ultima posizione registrata
                giocatore.PosizioneAttuale = MondoDiGioco.LuogoPerID(iDLuogoAttuale);

                // per ogni elemento, o nodo, oggetto in inventario
                foreach (XmlNode nodo in datiGiocatore.SelectNodes("/Giocatore/Inventario/Oggetto"))
                {
                    // converto il valore id e quantità da stringa in intero
                    int id       = Convert.ToInt32(nodo.Attributes["ID"].Value);
                    int quantita = Convert.ToInt32(nodo.Attributes["Quantità"].Value);

                    // in base al numero di oggetti che aveva il giocatore
                    for (int i = 0; i < quantita; i++)
                    {
                        // inserisco tali oggetti nell'inventario
                        giocatore.AggiungiOggettoInInventario(MondoDiGioco.OggettoPerID(id));
                    }
                }

                // per ogni elemento, o nodo, MissioneGiocatore in MissioniDelGiocatore
                foreach (XmlNode nodo in datiGiocatore.SelectNodes("/Giocatore/MissioniDelGiocatore/MissioneGiocatore"))
                {
                    // converto l'attributo ID ed ECompletata da stringa in intero
                    int id           = Convert.ToInt32(nodo.Attributes["ID"].Value);
                    bool eCompletato = Convert.ToBoolean(nodo.Attributes["ECompletata"].Value);

                    // istanzio un oggetto di tipo missioneGiocatore che corrisponderà all'id passatogli come parametro
                    MissioneGiocatore missione = new MissioneGiocatore(MondoDiGioco.MissionePerID(id));
                    // setto questa variabile in base se il giocatore ha superato o meno la missione
                    missione.ECompletata = eCompletato;

                    // aggiungo l'oggetto appena creato alle missioni del giocatore
                    giocatore.Missioni.Add(missione);
                }

                // il metodo restituirà il giocatore aggiornato 
                return giocatore;

            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return GetPersonaggio();
            }
        }

        // metodo per capire se il giocatore ha, o no, l'oggetto richiesto per entrare in un determinato luogo
        public bool HaiOggettoNecessarioPerEntrareInLuogo(Luogo luogo)
        {
            // se il luogo, che viene passato come parametro, non richiede un oggetto per entrare
            if(luogo.OggettoRichiestoPerEntrare == null)
            {
                // il metodo restituisce true (quindi il giocatore può procedere)
                return true;
            }
            // per ogni oggetto presente nell'inventario 
            foreach(Inventario oggettoInInventario in Inventario)
            {
                // se l'ID dell'oggetto (ottenibile tramite il primo parametro dell'inventario di tipo Oggetto)
                // coincide con l'ID dell'oggetto posseduto dal giocatore
                if(oggettoInInventario.Dettagli.ID == luogo.OggettoRichiestoPerEntrare.ID)
                {
                    // il metodo restituisce true (quindi il giocatore può procedere)
                    return true;
                }
            }
            // se non si verifica nessuno dei casi precedenti allora il metodo 
            // restituirà false (quindi il giocatore non può procedere)
            return false;
        }

        // metodo per capire se il giocatore ha, o no, una determinata missione
        public bool HaiQuestaMissione(Missione missione)
        {
            // per ogni missione del giocatore in Missioni
            foreach(MissioneGiocatore missioneGiocatore in Missioni)
            {
                // se l'ID della missione che ha il giocatore coincide con quella passata come parametro
                if(missioneGiocatore.Dettagli.ID == missione.ID)
                {
                    // il metodo restituisce true (quindi il giocatore ha gia la missione)
                    return true;
                }
            }
            // altrimenti il metodo restituisce false (quindi il giocatore non ha la missione)
            return false;
        }

        // metodo per capire se il giocatore ha, o no, completato una determinata missione
        public bool MissioneCompletata(Missione missione)
        {
            // per ogni missione del giocatore in Missioni
            foreach(MissioneGiocatore missioneGiocatore in Missioni)
            {
                // se l'ID della missione che ha il giocatore coincide con quella passata come parametro
                if(missioneGiocatore.Dettagli.ID == missione.ID)
                {
                    // il metodo restituisce il valore della variabile Ecompletata in quel momento
                    return missioneGiocatore.ECompletata;
                }
            }
            // altrimenti il metodo restituisce false (quindi il giocatore non ha completato la missione)
            return false;
        }

        // metodo per capire il giocatore ha tutti gli oggetti necessari al completamento di una particolare missione
        public bool HaiTuttiGliOggettiCompletamentoMissione(Missione missione)
        {
            // per ogni oggetto per il completamento della missione nella lista 
            foreach(OggettoCompletamentoMissione oggettoCompletamentoMissione in missione.OggettiCompletamentoMissione)
            {
                // setto a false questa variabile, che servirà per capire se si è trovato
                // o no l'oggetto
                bool trovaOggettoInInventarioGiocatore = false;
                // per ogni oggetto nell'inventario 
                foreach(Inventario oggettoIninventario in Inventario)
                {
                    // se l'ID dell'oggetto nell'inventario del giocatore coincide con quello per completare la missione 
                    // quindi il giocatore ha l'oggetto richiesto
                    if(oggettoIninventario.Dettagli.ID == oggettoCompletamentoMissione.Dettagli.ID)
                    {
                        // setto la variabile a true, questo significa che il giocatore ha il giocatore per andare avanti nella missione
                        trovaOggettoInInventarioGiocatore = true;
                        // se, però, la quantità non è sufficiente
                        if(oggettoIninventario.Quantita < oggettoCompletamentoMissione.Quantita)
                        {
                            // allora il metodo ritorna false
                            return false;
                        }
                    }
                }
                // se non è stato trovato alcun oggetto nell'inventario o neanche una quantità inferiore a quella richiesta
                if (!trovaOggettoInInventarioGiocatore)
                {
                    // il metodo ritornerà false (questo per segnalare che l'oggetto non è stato trovato)
                    return false;
                }
            }
            // il metodo restituisce true perchè se siamo qui vuol dire che il giocatore ha tutti gli oggetti richiesti e nella
            // quantità richiesta o superiore
            return true;
        }

        // metodo per rimuovere gli oggetti dall'inventario del giocatore una volta che si è completata la missione
        public void RimuoviOggettoCompletamentoMissione(Missione missione)
        {
            // per ogni oggetto per il completamento della missione
            foreach(OggettoCompletamentoMissione oggettoCompletamentoMissione in missione.OggettiCompletamentoMissione)
            {
                // vado a controllare l'inventario del giocatore
                foreach(Inventario OggettoIninventario in Inventario)
                {
                    // se l'ID dell'oggetto nell'inventario coincide con l'oggetto per il completamento della missione
                    if(OggettoIninventario.Dettagli.ID == oggettoCompletamentoMissione.Dettagli.ID)
                    {
                        // decremento la quantità di quell'oggetto pari alla quanità necesseria per il completamento della missione
                        OggettoIninventario.Quantita -= oggettoCompletamentoMissione.Quantita;
                    }
                }
            }
        }

        // metodo per aggiungere un oggetto all'inventario, per esempio qual'ora si completasse una missione
        public void AggiungiOggettoInInventario(Oggetto oggettoDaAggiungere)
        {
            // per ogni oggetto nell'inventario
            foreach(Inventario OggettoIninventario in Inventario)
            {
                // se l'ID dell'oggetto nell'inventario coincide con l'ID dell'oggetto da aggiungere 
                if(OggettoIninventario.Dettagli.ID == oggettoDaAggiungere.ID)
                {
                    // incremento di uno la quantità dell'oggetto
                    OggettoIninventario.Quantita++;
                    // ho fatto quindi esco dal metodo
                    return;
                }
            }
            // creo l'oggetto da aggiungere
            Inventario oggettoAggiunto = new Inventario(oggettoDaAggiungere, 1);
            // se il giocatore non aveva quel tipo di oggetto nell'inventario allora ne aggiungo direttamente uno
            Inventario.Add(oggettoAggiunto);
        }

        // metodo per segnalare quando il giocatore completa una missione
        public void SegnalaMissioneCompletata(Missione missione)
        {
            // per ogni missione del giocatore
            foreach(MissioneGiocatore missioneGiocatore in Missioni)
            {
                // se l'ID della missione combacia con quello della missione passata come parametro
                if(missioneGiocatore.Dettagli.ID == missione.ID)
                {
                    // setto la variabile riferita al completamento di una missione a true
                    missioneGiocatore.ECompletata = true;
                    // ho fatto quindi esco dal metodo
                    return;
                }
            }
        }

        // metodo per aumento livello del giocatore
        public void AggiungiPuntiEsperienza(int puntiEsperienzaDaAggiungere)
        {
            // presa l'esperienza di un mostro, vado ad incrementare di volta in volta l'esprienza del giocatore
            this.Esperienza   += puntiEsperienzaDaAggiungere;
            // aumento il livello in base alla formula
            this.Livello      = (this.Esperienza / 100) + 1;
            // modifico i punti vita massimi in base alla crescita del livello 
            this.MaxPuntiVita = (this.Livello * 10);
        }
    }
}
