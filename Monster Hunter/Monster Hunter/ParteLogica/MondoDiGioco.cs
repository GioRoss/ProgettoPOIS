using System;
using System.Collections.Generic;

namespace ParteLogica
{
    // inizio della classe statica Mondo di Gioco
    public static class MondoDiGioco
    {
        // attributi interni della classe
        // liste che ospiteranno i vari oggetti, mostri, missioni e luoghi del gioco
        public static List<Oggetto> Oggetti   = new List<Oggetto>();
        public static List<Mostro> Mostri     = new List<Mostro>();
        public static List<Missione> Missioni = new List<Missione>();
        public static List<Luogo> Luoghi      = new List<Luogo>();

        // costanti intere numeriche, riferite ai vori oggetti (che comprendono anche pozioni ed armi) per
        // distingere i vari oggetti all'interno del mondo di gioco
        public const int OGGETTO_ID_SPADA_ARRUGGINITA     = 1;
        public const int OGGETTO_ID_SPADA_DI_FERRO        = 2;
        public const int OGGETTO_ID_SPADA_DI_FUOCO        = 3;
        public const int OGGETTO_ID_SPADA_DELL_EROE       = 4;
        public const int OGGETTO_ID_PILA                  = 5;
        public const int OGGETTO_ID_POZIONE               = 6;
        public const int OGGETTO_ID_IPERPOZIONE           = 7;
        public const int OGGETTO_ID_BACCAGIALLA           = 8;
        public const int OGGETTO_ID_OSSA_DI_SCHELETRO     = 9;
        public const int OGGETTO_ID_OCCHIO_DI_ORCO        = 10;
        public const int OGGETTO_ID_PELO_DI_GORILLA       = 11;
        public const int OGGETTO_ID_CARNE_DI_ELFO         = 12;
        public const int OGGETTO_ID_SQUAMA_DI_DRAGO       = 13;
        public const int OGGETTO_ID_RAGNATELA_APPICCICOSA = 14;
        public const int OGGETTO_ID_CRISTALLO_LUCENTE_BLU = 15;
        public const int OGGETTO_ID_FULMINE_ASSASSINO     = 16;
        public const int OGGETTO_ID_CENERE_ARDENTE        = 17;
        public const int OGGETTO_ID_MEDAGLIA_VALORE       = 18;

        // costanti intere numeriche, riferite ai vari mostri, per distinguergli l'un dall'altro
        // all'interno del mondo di gioco 
        public const int MOSTRO_ID_DRAGO_FINALE           = 1;
        public const int MOSTRO_ID_GOLEM_DI_PIETRA        = 2;
        public const int MOSTRO_ID_SOLDATO_SCHELETRO      = 3;
        public const int MOSTRO_ID_RAGNO_GIGANTE          = 4;
        public const int MOSTRO_ID_ELFO                   = 5;
        public const int MOSTRO_ID_ORCO                   = 6;
        public const int MOSTRO_ID_TOPO_ELETTRICO         = 7;
        public const int MOSTRO_ID_GORILLA                = 8;
        public const int MOSTRO_ID_SERPENTE_DELLE_SABBIE  = 9;

        // costanti intere numeriche, riferite alle missioni, per distinguere le missioni le une
        // dalle altre all'interno del mondo di gioco
        public const int MISSIONE_ID_PROVA_VALORE    = 1;
        public const int MISSIONE_ID_AIUTA_LA_CITTA  = 2;

        // costanti intere numeriche, riferite ai vari luoghi, per distinguerli gli uni dagli
        // altri all'interno del mondo di gioco
        public const int LUOGO_ID_CITTA               = 1;
        public const int LUOGO_ID_ENTRATA_REGNO       = 2;
        public const int LUOGO_ID_PONTE_DI_LEGNO      = 3;
        public const int LUOGO_ID_CAVERNA_ELETTRICA   = 4;
        public const int LUOGO_ID_SENTIERO_RADURA     = 5;
        public const int LUOGO_ID_FORESTA_BANANE      = 6;
        public const int LUOGO_ID_PIAZZA_CENTRALE     = 7;
        public const int LUOGO_ID_FORESTA             = 8;
        public const int LUOGO_ID_TANA_ORCO           = 9;
        public const int LUOGO_ID_ENTRATA_GROTTA      = 10;
        public const int LUOGO_ID_DESERTO_ROVENTE     = 11;
        public const int LUOGO_ID_TORRE_DRAGO         = 12;

        // inizio metodo costruttore 
        // questo metodo conterrà i metodi per 'popolare' le varie liste e nient'altro dal momento che, essendo statica, non è possibile istanziarla.
        // Essendo questa classe statica, il costruttore verrà eseguito solo la prima volta che qualcuno usa questa classe,
        // quindi quando avviamo il gioco e vogliamo visualizzare le informazioni sulla posizione corrente
        // del giocatore da questa classe verrà eseguito il metodo costruttore e gli elenchi verranno popolati
        static MondoDiGioco()
        {
            PopolareOggetti();
            PopolareMostri();
            PopolareMissioni();
            PopolareLuoghi();
        }

        // questo metodo serve per andare a popolare gli oggetti di gioco, quindi ad istanziarli e successivamente
        // ad inserirli nella lista degli oggetti che potranno poi essere usati/presi durante l'avventura.
        // Gli oggetti verranno poi aggiunti alla lista degli oggetti
        private static void PopolareOggetti()
        {
            Arma spadaArrugginita      = new Arma(OGGETTO_ID_SPADA_ARRUGGINITA, "Spada arrugginita", "Spade arrugginite", 3, 8);
            Arma spadaDiFerro          = new Arma(OGGETTO_ID_SPADA_DI_FERRO, "Spada di ferro", "Spade di ferro", 10, 20);
            Arma spadaDiFuoco          = new Arma(OGGETTO_ID_SPADA_DI_FUOCO, "Spada di fuoco", "Spade di fuoco", 45, 75);
            Arma spadaEroe             = new Arma(OGGETTO_ID_SPADA_DELL_EROE, "Spada dell'eroe", "Spade dell'eroe", 200, 500);
            Oggetto pila               = new Oggetto(OGGETTO_ID_PILA, "Pila", "Pile");
            Oggetto ossaScheletro      = new Oggetto(OGGETTO_ID_OSSA_DI_SCHELETRO, "Osso di scheletro", "Ossa di scheletri");
            Oggetto occhioOrco         = new Oggetto(OGGETTO_ID_OCCHIO_DI_ORCO, "Occhio di orco", "Occhi di orco");
            Oggetto peloGorilla        = new Oggetto(OGGETTO_ID_PELO_DI_GORILLA, "Pelo di gorilla", "Peli di gorilla");
            Oggetto carneElfo          = new Oggetto(OGGETTO_ID_CARNE_DI_ELFO, "Carne di elfo", "Carni di elfo");
            Oggetto squamaDrago        = new Oggetto(OGGETTO_ID_SQUAMA_DI_DRAGO, "Squama di drago", "Squame di drago");
            Oggetto ragnatelaAppiccosa = new Oggetto(OGGETTO_ID_RAGNATELA_APPICCICOSA, "Ragnatela appiccicosa", "Ragnatele appiccicose");
            Oggetto cristalloBlu       = new Oggetto(OGGETTO_ID_CRISTALLO_LUCENTE_BLU, "Cristallo lucente blu", "Cristalli lucenti blu");
            Oggetto fulmineAssassino   = new Oggetto(OGGETTO_ID_FULMINE_ASSASSINO, "Fulmine assassino", "Fulmini assassini");
            Oggetto cenereArdente      = new Oggetto(OGGETTO_ID_CENERE_ARDENTE, "Cenere ardente", "Ceneri ardenti");
            Oggetto medagliaValore     = new Oggetto(OGGETTO_ID_MEDAGLIA_VALORE, "Medaglia al valore", "Medaglie al valore");
            PozioneCura baccaGialla    = new PozioneCura(OGGETTO_ID_BACCAGIALLA, "Baccagialla", "Bacchegialle", 5);
            PozioneCura pozione        = new PozioneCura(OGGETTO_ID_POZIONE, "Pozione", "Pozioni", 7);
            PozioneCura iperpozione    = new PozioneCura(OGGETTO_ID_IPERPOZIONE, "Iperpozione", "Iperpozioni", 40);

            // aggiungo gli oggetti nella lista degli oggetti
            Oggetti.Add(spadaArrugginita);
            Oggetti.Add(spadaDiFerro);
            Oggetti.Add(spadaDiFuoco);
            Oggetti.Add(spadaEroe);
            Oggetti.Add(pila);
            Oggetti.Add(ossaScheletro);
            Oggetti.Add(occhioOrco);
            Oggetti.Add(peloGorilla);
            Oggetti.Add(carneElfo);
            Oggetti.Add(squamaDrago);
            Oggetti.Add(ragnatelaAppiccosa);
            Oggetti.Add(cristalloBlu);
            Oggetti.Add(fulmineAssassino);
            Oggetti.Add(cenereArdente);
            Oggetti.Add(medagliaValore);
            Oggetti.Add(baccaGialla);
            Oggetti.Add(pozione);
            Oggetti.Add(iperpozione);
        }

        // questo metodo serve per andare a popolare il mondo dei gioco dei mostri, istanziandoli, quindi, e inserendoli poi nella lista
        // dei mostri che potremmo trovare durante l'avventura.
        // I mostri verranno poi aggiunti alla lista dei mostri
        private static void PopolareMostri()
        {
            Mostro drago = new Mostro(MOSTRO_ID_DRAGO_FINALE, "Drago delle fiamme oscure", 30, 200, 100, 300, 300);
            OggettoOttenibile squamaDiDrago = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_SQUAMA_DI_DRAGO), 75, false);
            OggettoOttenibile cenereArdente = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_CENERE_ARDENTE), 90, true);
            drago.OggettiOttenibili.Add(squamaDiDrago);
            drago.OggettiOttenibili.Add(cenereArdente);

            Mostro golem = new Mostro(MOSTRO_ID_GOLEM_DI_PIETRA, "Golem di pietra", 25, 50, 50, 100, 100);
            OggettoOttenibile iperpozione = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_IPERPOZIONE), 100, true);
            golem.OggettiOttenibili.Add(iperpozione);

            Mostro soldatoScheletro           = new Mostro(MOSTRO_ID_SOLDATO_SCHELETRO, "Soldato scheletro", 3, 10, 5, 10, 10);
            OggettoOttenibile spadaDiFerro    = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_SPADA_DI_FERRO), 20, false);
            OggettoOttenibile ossaDiScheletro = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_OSSA_DI_SCHELETRO), 90, true);
            OggettoOttenibile pozione         = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_POZIONE), 50, false);
            soldatoScheletro.OggettiOttenibili.Add(spadaDiFerro);
            soldatoScheletro.OggettiOttenibili.Add(ossaDiScheletro);
            soldatoScheletro.OggettiOttenibili.Add(pozione);

            Mostro ragnoGigante = new Mostro(MOSTRO_ID_RAGNO_GIGANTE, "Ragno gigante", 30, 45, 30, 70, 70);
            OggettoOttenibile ragnatelaAppiccicosa = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_RAGNATELA_APPICCICOSA), 100, true);
            ragnoGigante.OggettiOttenibili.Add(ragnatelaAppiccicosa);

            Mostro elfo = new Mostro(MOSTRO_ID_ELFO, "Elfo della raduna", 5, 15, 8, 20, 20);
            OggettoOttenibile carneDielfo         = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_CARNE_DI_ELFO), 75, true);
            OggettoOttenibile cristalloLucenteBlu = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_CRISTALLO_LUCENTE_BLU), 25, false);
            elfo.OggettiOttenibili.Add(carneDielfo);
            elfo.OggettiOttenibili.Add(cristalloLucenteBlu);

            Mostro orco = new Mostro(MOSTRO_ID_ORCO, "Orco bruto", 40, 50, 40, 70, 70);
            OggettoOttenibile occhioDiOrco = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_OCCHIO_DI_ORCO), 100, true);
            OggettoOttenibile spadaDiFuoco = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_SPADA_DI_FUOCO), 80, false);
            orco.OggettiOttenibili.Add(occhioDiOrco);
            orco.OggettiOttenibili.Add(spadaDiFuoco);

            Mostro topoElettrico               = new Mostro(MOSTRO_ID_TOPO_ELETTRICO, "Topo elettrico", 5, 12, 5, 15, 15);
            OggettoOttenibile pila             = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_PILA), 75, true);
            OggettoOttenibile baccagialla      = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_BACCAGIALLA), 75, false);
            OggettoOttenibile fulmineAssassino = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_FULMINE_ASSASSINO), 65, false);
            topoElettrico.OggettiOttenibili.Add(pila);
            topoElettrico.OggettiOttenibili.Add(baccagialla);
            topoElettrico.OggettiOttenibili.Add(fulmineAssassino);

            Mostro gorilla = new Mostro(MOSTRO_ID_GORILLA, "Gorilla", 8, 20, 10, 20, 20);
            OggettoOttenibile peloDiGorilla = new OggettoOttenibile(OggettoPerID(OGGETTO_ID_PELO_DI_GORILLA), 100, true);
            gorilla.OggettiOttenibili.Add(peloDiGorilla);

            Mostro serpenteSabbie = new Mostro(MOSTRO_ID_SERPENTE_DELLE_SABBIE, "Serpente delle sabbie", 30, 45, 30, 55, 55);
            // questo oggetto è gia stato istanziato sotto il golem, perciò non richiede di essere re-istanziato
            serpenteSabbie.OggettiOttenibili.Add(iperpozione);

            // aggiungo i mostri nella lista dei mostri
            Mostri.Add(drago);
            Mostri.Add(golem);
            Mostri.Add(soldatoScheletro);
            Mostri.Add(ragnoGigante);
            Mostri.Add(elfo);
            Mostri.Add(orco);
            Mostri.Add(topoElettrico);
            Mostri.Add(gorilla);
            Mostri.Add(serpenteSabbie);
        }

        // questo metodo serve per andare a popolare il mondo di gioco con le missione che dovranno essere svolte all'interno del gioco.
        // Ogni missione darà come ricompensa soldi, esperienza ed oggetti.
        // Le missioni verranno poi aggiunti alla lista delle missioni
        private static void PopolareMissioni()
        {
            Missione provaValore = new Missione(MISSIONE_ID_PROVA_VALORE, "Mostra il tuo valore", "Per mostrarti degno di entrare nel regno devi portarmi almeno: 2 fulmini assassini," +
                " 1 pila e 2 peli di gorilla. Verrai ricompensato con una medaglia al valore che ti permetterà di accedere in città.", 50, 20, OggettoPerID(OGGETTO_ID_MEDAGLIA_VALORE));
            OggettoCompletamentoMissione pila             = new OggettoCompletamentoMissione(OggettoPerID(OGGETTO_ID_PILA), 1);
            OggettoCompletamentoMissione fulmineAssassino = new OggettoCompletamentoMissione(OggettoPerID(OGGETTO_ID_FULMINE_ASSASSINO), 2);
            OggettoCompletamentoMissione peloDiGorilla    = new OggettoCompletamentoMissione(OggettoPerID(OGGETTO_ID_PELO_DI_GORILLA), 2);
            provaValore.OggettiCompletamentoMissione.Add(pila);
            provaValore.OggettiCompletamentoMissione.Add(fulmineAssassino);
            provaValore.OggettiCompletamentoMissione.Add(peloDiGorilla);

            Missione aiutaCitta = new Missione(MISSIONE_ID_AIUTA_LA_CITTA, "Aiuta la città uccidendo la grande bestia", "Per favore giovane forestiero, aiutaci. La città è sotto" +
                " attacco ormai da giorni da una bestia enorme, la potrai trovare ad est di qua. Se ci riuscirai verrai ben ricompensato!", 500, 200, OggettoPerID(OGGETTO_ID_SPADA_DELL_EROE));
            OggettoCompletamentoMissione cenereArdente = new OggettoCompletamentoMissione(OggettoPerID(OGGETTO_ID_CENERE_ARDENTE), 1);
            aiutaCitta.OggettiCompletamentoMissione.Add(cenereArdente);

            // aggiungo le missioni nella lista delle missioni
            Missioni.Add(provaValore);
            Missioni.Add(aiutaCitta);
        }

        // questo metodo serve per andare a popolare il mondo di gioco con i luoghi che si visiteranno durante l'avventura
        // con i rispettivi mostri o missioni che incontreremo visitando quel particolare luogo.
        // I luoghi verranno poi aggiunti alla lista dei luoghi
        private static void PopolareLuoghi()
        {
            Luogo citta = new Luogo(LUOGO_ID_CITTA, "Città", "Ti risvegli in questo posto, ti senti strano, un po intorpidito. Pensi solo a come sei arrivato qua.");

            Luogo entrataRegno = new Luogo(LUOGO_ID_ENTRATA_REGNO, "Entrata del regno", "Vedi due grandi statue di due cavalieri al di la delle quali si erge un sontuoso regno. " +
                "Capisci subito che quella è la strada da percorrere. Abbassando lo sguardo però noti ai piedi delle statue una guardia. Sembra proprio che voglia dirti qualcosa.");
            entrataRegno.MissioneDisponibileQui = MissionePerID(MISSIONE_ID_PROVA_VALORE);

            Luogo ponteLegno = new Luogo(LUOGO_ID_PONTE_DI_LEGNO, "Ponte di legno", "E' un ponte di legno ma pieno zeppo di scheletri soldato.");
            ponteLegno.MostroCheViveQui = MostroPerID(MOSTRO_ID_SOLDATO_SCHELETRO);

            Luogo cavernaElettrica = new Luogo(LUOGO_ID_CAVERNA_ELETTRICA, "Caverna elettrica", "Una strana caverna popolate da strane creature gialle con guancie rosse.");
            cavernaElettrica.MostroCheViveQui = MostroPerID(MOSTRO_ID_TOPO_ELETTRICO);

            Luogo sentieroRadura = new Luogo(LUOGO_ID_SENTIERO_RADURA, "Un simpatico sentiero nella radura", "Sembra tranquillo qui. Finchè non scorgi strani tipi con orecchie a punta.");
            sentieroRadura.MostroCheViveQui = MostroPerID(MOSTRO_ID_ELFO);

            Luogo forestaBanane = new Luogo(LUOGO_ID_FORESTA_BANANE, "Una foresta", "Una foresta! Aspetta....sono banane quelle?");
            forestaBanane.MostroCheViveQui = MostroPerID(MOSTRO_ID_GORILLA);

            Luogo piazzaCentrale = new Luogo(LUOGO_ID_PIAZZA_CENTRALE, "La piazza del centro del regno", "Una piazza con una bellissima fontana al centro ornata da statue d'oro.");
            piazzaCentrale.OggettoRichiestoPerEntrare = OggettoPerID(OGGETTO_ID_MEDAGLIA_VALORE);
            piazzaCentrale.MissioneDisponibileQui = MissionePerID(MISSIONE_ID_AIUTA_LA_CITTA);

            Luogo foresta = new Luogo(LUOGO_ID_FORESTA, "Una foresta molto tetra", "Sembra una normale foresta, se non fosse per la fitta rete di ragnatele.");
            foresta.MostroCheViveQui = MostroPerID(MOSTRO_ID_RAGNO_GIGANTE);

            Luogo tanaOrco = new Luogo(LUOGO_ID_TANA_ORCO, "Tana degli orchi", "Più che una tana sembra una grotta. Se non fosse per la puzza e gli orchi sarebbe anche carino qui.");
            tanaOrco.MostroCheViveQui = MostroPerID(MOSTRO_ID_ORCO);

            Luogo entrataGrotta = new Luogo(LUOGO_ID_ENTRATA_GROTTA, "E' un'entrata di una grotta", "Oh no stanno uscendo golem da ovunque!");
            entrataGrotta.MostroCheViveQui = MostroPerID(MOSTRO_ID_GOLEM_DI_PIETRA);

            Luogo desertoRovente = new Luogo(LUOGO_ID_DESERTO_ROVENTE, "Il deserto rovente", "Si muore di caldo qui...oltre ad essere pieno di serpente enormi.");
            desertoRovente.MostroCheViveQui = MostroPerID(MOSTRO_ID_SERPENTE_DELLE_SABBIE);

            Luogo torreDrago = new Luogo(LUOGO_ID_TORRE_DRAGO, "La torre del drago", "Un enorme drago che stranamente sa di fragola..");
            torreDrago.MostroCheViveQui = MostroPerID(MOSTRO_ID_DRAGO_FINALE);

            // dopo aver istanziato i vari luoghi con i rispettivi mostri o missioni andiamo a collegare tutti i luoghi
            // fra di loro creando, così, un percorso percorribile dal giocatore, tenendo a mente che il punto di partenza
            // sarà il luogo denominato 'Città'.
            // Qual'ora non fosse presente un percorso tra un luogo ed un'altro, allora vorrà dire che quel percorso sarà 'null',
            // concetto che verrà poi utilizzato per l'interfaccia grafica nella classe MonsterHunter.cs
            citta.DirezioneNord = entrataRegno;

            entrataRegno.DirezioneNord  = piazzaCentrale;
            entrataRegno.DirezioneEst   = ponteLegno;
            entrataRegno.DirezioneOvest = sentieroRadura;
            entrataRegno.DirezioneSud   = citta;

            ponteLegno.DirezioneEst   = cavernaElettrica;
            ponteLegno.DirezioneOvest = entrataRegno;

            cavernaElettrica.DirezioneOvest = ponteLegno;

            sentieroRadura.DirezioneEst   = entrataRegno;
            sentieroRadura.DirezioneOvest = forestaBanane;

            forestaBanane.DirezioneEst = sentieroRadura;

            piazzaCentrale.DirezioneNord  = entrataGrotta;
            piazzaCentrale.DirezioneEst   = desertoRovente;
            piazzaCentrale.DirezioneOvest = foresta;
            piazzaCentrale.DirezioneSud   = entrataRegno;

            foresta.DirezioneOvest = tanaOrco;
            foresta.DirezioneEst   = piazzaCentrale;

            tanaOrco.DirezioneEst = foresta;

            entrataGrotta.DirezioneSud = piazzaCentrale;

            desertoRovente.DirezioneEst   = torreDrago;
            desertoRovente.DirezioneOvest = piazzaCentrale;

            torreDrago.DirezioneOvest = desertoRovente;

            // aggiungo i luoghi nella lista dei luoghi
            Luoghi.Add(citta);
            Luoghi.Add(entrataRegno);
            Luoghi.Add(ponteLegno);
            Luoghi.Add(cavernaElettrica);
            Luoghi.Add(sentieroRadura);
            Luoghi.Add(forestaBanane);
            Luoghi.Add(piazzaCentrale);
            Luoghi.Add(foresta);
            Luoghi.Add(tanaOrco);
            Luoghi.Add(entrataGrotta);
            Luoghi.Add(desertoRovente);
            Luoghi.Add(torreDrago);
        }

        // metodo per ottenere un particolare oggetto dalla lista degli oggetti tramite l'ID
        public static Oggetto OggettoPerID(int id)
        {
            // per ogni elemento di tipo Oggetto presente nella lista 'Oggetti'  
            foreach(Oggetto oggetto in Oggetti)
            {
                // se l'ID dell'oggetto in questione nella lista combacia
                // con l'ID dell'oggetto da cercare passatogli come parametro  
                if(oggetto.ID == id)
                {
                    // il metodo ritornerà l'oggetto cercato
                    return oggetto;
                }
            }
            // altrimenti non ritorno nulla
            return null;
        }

        // metodo per ottenere una particolare missione dalla lista delle missioni tramite l'ID
        public static Missione MissionePerID(int id)
        {
            // per ogni elemento di tipo Missione presente nella lista 'Missioni'
            foreach(Missione missione in Missioni)
            {
                // se l'ID della missione in questione nella lista combacia
                // con l'ID della missione da cercare passatogli come parametro
                if(missione.ID == id)
                {
                    // il metodo ritornerà la missione cercata
                    return missione;
                }
            }
            // altrimenti non ritornerà nulla
            return null;
        }

        // metodo per ottenere un particolare mostro dalla lista dei mostri tramite l'ID
        public static Mostro MostroPerID(int id)
        {
            // per ogni elemento di tipo Mostro presente nella lista 'Mostri'
            foreach (Mostro mostro in Mostri)
            {
                // se l'ID del mostro in questione nella lista combacia
                // con l'ID del mostro da cercare passatogli come parametro
                if (mostro.ID == id)
                {
                    // il metodo ritornerà il mostro cercato
                    return mostro;
                }
            }
            // altrimenti non ritornerà nulla
            return null;
        }

        // metodo per ottenere un particolare luogo dalla lista dei luoghi tramite l'ID.
        // Questo metodo, a differenza dei precedenti, non verrà utilizzato direttamente in questa classe
        // ma in MonsterHunter.cs per selezionare un luogo specifico dalla lista
        public static Luogo LuogoPerID(int id)
        {
            // per ogni elemento di tipo Luogo presente nella lista 'Luoghi'
            foreach (Luogo luogo in Luoghi)
            {
                // se l'ID del luogo in questione nella lista combacia
                // con l'ID del luogo da cercare passatogli come parametro
                if (luogo.ID == id)
                {
                    // il metodo ritornerà il luogo cercato
                    return luogo;
                }
            }
            // altrimenti non ritornerà nulla
            return null;
        }
    }
}
