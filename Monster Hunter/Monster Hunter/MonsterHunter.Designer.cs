
namespace Monster_Hunter
{
    partial class MonsterHunter
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPuntiVita = new System.Windows.Forms.Label();
            this.lblSoldi = new System.Windows.Forms.Label();
            this.lblEsperienza = new System.Windows.Forms.Label();
            this.lblLivello = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboArmi = new System.Windows.Forms.ComboBox();
            this.cboPozioni = new System.Windows.Forms.ComboBox();
            this.btnUsaArma = new System.Windows.Forms.Button();
            this.btnUsaPozioni = new System.Windows.Forms.Button();
            this.btnNord = new System.Windows.Forms.Button();
            this.btnEst = new System.Windows.Forms.Button();
            this.btnSud = new System.Windows.Forms.Button();
            this.btnOvest = new System.Windows.Forms.Button();
            this.rtbLuogo = new System.Windows.Forms.RichTextBox();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.dgvMissioni = new System.Windows.Forms.DataGridView();
            this.btnMappa = new System.Windows.Forms.Button();
            this.pictureBoxDestra = new System.Windows.Forms.PictureBox();
            this.pictureBoxSinistra = new System.Windows.Forms.PictureBox();
            this.btnChiudiGioco = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnCancellaSalvataggio = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbMessaggi = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSinistra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Punti Vita:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Guil:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Esperienza:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Livello:";
            // 
            // lblPuntiVita
            // 
            this.lblPuntiVita.AutoSize = true;
            this.lblPuntiVita.Location = new System.Drawing.Point(110, 19);
            this.lblPuntiVita.Name = "lblPuntiVita";
            this.lblPuntiVita.Size = new System.Drawing.Size(0, 13);
            this.lblPuntiVita.TabIndex = 4;
            // 
            // lblSoldi
            // 
            this.lblSoldi.AutoSize = true;
            this.lblSoldi.Location = new System.Drawing.Point(110, 45);
            this.lblSoldi.Name = "lblSoldi";
            this.lblSoldi.Size = new System.Drawing.Size(0, 13);
            this.lblSoldi.TabIndex = 5;
            // 
            // lblEsperienza
            // 
            this.lblEsperienza.AutoSize = true;
            this.lblEsperienza.Location = new System.Drawing.Point(110, 73);
            this.lblEsperienza.Name = "lblEsperienza";
            this.lblEsperienza.Size = new System.Drawing.Size(0, 13);
            this.lblEsperienza.TabIndex = 6;
            // 
            // lblLivello
            // 
            this.lblLivello.AutoSize = true;
            this.lblLivello.Location = new System.Drawing.Point(110, 99);
            this.lblLivello.Name = "lblLivello";
            this.lblLivello.Size = new System.Drawing.Size(0, 13);
            this.lblLivello.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 531);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Seleziona Azione";
            // 
            // cboArmi
            // 
            this.cboArmi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArmi.FormattingEnabled = true;
            this.cboArmi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboArmi.Location = new System.Drawing.Point(369, 559);
            this.cboArmi.Name = "cboArmi";
            this.cboArmi.Size = new System.Drawing.Size(121, 21);
            this.cboArmi.TabIndex = 9;
            // 
            // cboPozioni
            // 
            this.cboPozioni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPozioni.FormattingEnabled = true;
            this.cboPozioni.Location = new System.Drawing.Point(369, 593);
            this.cboPozioni.Name = "cboPozioni";
            this.cboPozioni.Size = new System.Drawing.Size(121, 21);
            this.cboPozioni.TabIndex = 10;
            // 
            // btnUsaArma
            // 
            this.btnUsaArma.Location = new System.Drawing.Point(620, 559);
            this.btnUsaArma.Name = "btnUsaArma";
            this.btnUsaArma.Size = new System.Drawing.Size(75, 23);
            this.btnUsaArma.TabIndex = 11;
            this.btnUsaArma.Text = "Usa";
            this.btnUsaArma.UseVisualStyleBackColor = true;
            this.btnUsaArma.Click += new System.EventHandler(this.btnUsaArma_Click);
            // 
            // btnUsaPozioni
            // 
            this.btnUsaPozioni.Location = new System.Drawing.Point(620, 593);
            this.btnUsaPozioni.Name = "btnUsaPozioni";
            this.btnUsaPozioni.Size = new System.Drawing.Size(75, 23);
            this.btnUsaPozioni.TabIndex = 12;
            this.btnUsaPozioni.Text = "Usa";
            this.btnUsaPozioni.UseVisualStyleBackColor = true;
            this.btnUsaPozioni.Click += new System.EventHandler(this.btnUsaPozioni_Click);
            // 
            // btnNord
            // 
            this.btnNord.Location = new System.Drawing.Point(493, 433);
            this.btnNord.Name = "btnNord";
            this.btnNord.Size = new System.Drawing.Size(75, 23);
            this.btnNord.TabIndex = 13;
            this.btnNord.Text = "Nord";
            this.btnNord.UseVisualStyleBackColor = true;
            this.btnNord.Click += new System.EventHandler(this.btnNord_Click);
            // 
            // btnEst
            // 
            this.btnEst.Location = new System.Drawing.Point(573, 459);
            this.btnEst.Name = "btnEst";
            this.btnEst.Size = new System.Drawing.Size(75, 23);
            this.btnEst.TabIndex = 14;
            this.btnEst.Text = "Est";
            this.btnEst.UseVisualStyleBackColor = true;
            this.btnEst.Click += new System.EventHandler(this.btnEst_Click);
            // 
            // btnSud
            // 
            this.btnSud.Location = new System.Drawing.Point(493, 487);
            this.btnSud.Name = "btnSud";
            this.btnSud.Size = new System.Drawing.Size(75, 23);
            this.btnSud.TabIndex = 15;
            this.btnSud.Text = "Sud";
            this.btnSud.UseVisualStyleBackColor = true;
            this.btnSud.Click += new System.EventHandler(this.btnSud_Click);
            // 
            // btnOvest
            // 
            this.btnOvest.Location = new System.Drawing.Point(412, 459);
            this.btnOvest.Name = "btnOvest";
            this.btnOvest.Size = new System.Drawing.Size(75, 23);
            this.btnOvest.TabIndex = 16;
            this.btnOvest.Text = "Ovest";
            this.btnOvest.UseVisualStyleBackColor = true;
            this.btnOvest.Click += new System.EventHandler(this.btnOvest_Click);
            // 
            // rtbLuogo
            // 
            this.rtbLuogo.Location = new System.Drawing.Point(347, 19);
            this.rtbLuogo.Name = "rtbLuogo";
            this.rtbLuogo.ReadOnly = true;
            this.rtbLuogo.Size = new System.Drawing.Size(562, 105);
            this.rtbLuogo.TabIndex = 17;
            this.rtbLuogo.Text = "";
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.AllowUserToResizeRows = false;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventario.Location = new System.Drawing.Point(16, 130);
            this.dgvInventario.MultiSelect = false;
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.Size = new System.Drawing.Size(312, 309);
            this.dgvInventario.TabIndex = 19;
            // 
            // dgvMissioni
            // 
            this.dgvMissioni.AllowUserToAddRows = false;
            this.dgvMissioni.AllowUserToDeleteRows = false;
            this.dgvMissioni.AllowUserToResizeRows = false;
            this.dgvMissioni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMissioni.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMissioni.Location = new System.Drawing.Point(16, 446);
            this.dgvMissioni.MultiSelect = false;
            this.dgvMissioni.Name = "dgvMissioni";
            this.dgvMissioni.ReadOnly = true;
            this.dgvMissioni.Size = new System.Drawing.Size(312, 189);
            this.dgvMissioni.TabIndex = 20;
            // 
            // btnMappa
            // 
            this.btnMappa.Location = new System.Drawing.Point(493, 459);
            this.btnMappa.Name = "btnMappa";
            this.btnMappa.Size = new System.Drawing.Size(75, 23);
            this.btnMappa.TabIndex = 23;
            this.btnMappa.Text = "Mappa";
            this.btnMappa.UseVisualStyleBackColor = true;
            this.btnMappa.Click += new System.EventHandler(this.btnMappa_Click);
            // 
            // pictureBoxDestra
            // 
            this.pictureBoxDestra.Image = global::Monster_Hunter.Properties.Resources.Città;
            this.pictureBoxDestra.Location = new System.Drawing.Point(713, 130);
            this.pictureBoxDestra.Name = "pictureBoxDestra";
            this.pictureBoxDestra.Size = new System.Drawing.Size(198, 193);
            this.pictureBoxDestra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDestra.TabIndex = 22;
            this.pictureBoxDestra.TabStop = false;
            // 
            // pictureBoxSinistra
            // 
            this.pictureBoxSinistra.Image = global::Monster_Hunter.Properties.Resources.Eroe;
            this.pictureBoxSinistra.Location = new System.Drawing.Point(228, 32);
            this.pictureBoxSinistra.Name = "pictureBoxSinistra";
            this.pictureBoxSinistra.Size = new System.Drawing.Size(100, 92);
            this.pictureBoxSinistra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSinistra.TabIndex = 21;
            this.pictureBoxSinistra.TabStop = false;
            // 
            // btnChiudiGioco
            // 
            this.btnChiudiGioco.Location = new System.Drawing.Point(714, 421);
            this.btnChiudiGioco.Name = "btnChiudiGioco";
            this.btnChiudiGioco.Size = new System.Drawing.Size(198, 40);
            this.btnChiudiGioco.TabIndex = 24;
            this.btnChiudiGioco.Text = "Chiudi gioco";
            this.btnChiudiGioco.UseVisualStyleBackColor = true;
            this.btnChiudiGioco.Click += new System.EventHandler(this.btnChiudiGioco_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(714, 329);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(198, 40);
            this.btnSalva.TabIndex = 25;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnCancellaSalvataggio
            // 
            this.btnCancellaSalvataggio.Location = new System.Drawing.Point(714, 375);
            this.btnCancellaSalvataggio.Name = "btnCancellaSalvataggio";
            this.btnCancellaSalvataggio.Size = new System.Drawing.Size(198, 40);
            this.btnCancellaSalvataggio.TabIndex = 26;
            this.btnCancellaSalvataggio.Text = "Cancella Salvataggio";
            this.btnCancellaSalvataggio.UseVisualStyleBackColor = true;
            this.btnCancellaSalvataggio.Click += new System.EventHandler(this.btnCancellaSalvataggio_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Eroe:";
            // 
            // rtbMessaggi
            // 
            this.rtbMessaggi.Location = new System.Drawing.Point(348, 129);
            this.rtbMessaggi.Name = "rtbMessaggi";
            this.rtbMessaggi.ReadOnly = true;
            this.rtbMessaggi.Size = new System.Drawing.Size(360, 286);
            this.rtbMessaggi.TabIndex = 28;
            this.rtbMessaggi.Text = "";
            // 
            // MonsterHunter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(921, 651);
            this.Controls.Add(this.rtbMessaggi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancellaSalvataggio);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.btnChiudiGioco);
            this.Controls.Add(this.btnMappa);
            this.Controls.Add(this.pictureBoxDestra);
            this.Controls.Add(this.pictureBoxSinistra);
            this.Controls.Add(this.dgvMissioni);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.rtbLuogo);
            this.Controls.Add(this.btnOvest);
            this.Controls.Add(this.btnSud);
            this.Controls.Add(this.btnEst);
            this.Controls.Add(this.btnNord);
            this.Controls.Add(this.btnUsaPozioni);
            this.Controls.Add(this.btnUsaArma);
            this.Controls.Add(this.cboPozioni);
            this.Controls.Add(this.cboArmi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLivello);
            this.Controls.Add(this.lblEsperienza);
            this.Controls.Add(this.lblSoldi);
            this.Controls.Add(this.lblPuntiVita);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MonsterHunter";
            this.Text = "Gioco: Monster Hunter";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSinistra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPuntiVita;
        private System.Windows.Forms.Label lblSoldi;
        private System.Windows.Forms.Label lblEsperienza;
        private System.Windows.Forms.Label lblLivello;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboArmi;
        private System.Windows.Forms.ComboBox cboPozioni;
        private System.Windows.Forms.Button btnUsaArma;
        private System.Windows.Forms.Button btnUsaPozioni;
        private System.Windows.Forms.Button btnNord;
        private System.Windows.Forms.Button btnEst;
        private System.Windows.Forms.Button btnSud;
        private System.Windows.Forms.Button btnOvest;
        private System.Windows.Forms.RichTextBox rtbLuogo;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.DataGridView dgvMissioni;
        private System.Windows.Forms.PictureBox pictureBoxSinistra;
        private System.Windows.Forms.PictureBox pictureBoxDestra;
        private System.Windows.Forms.Button btnMappa;
        private System.Windows.Forms.Button btnChiudiGioco;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnCancellaSalvataggio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbMessaggi;
    }
}

