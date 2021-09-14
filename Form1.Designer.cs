
namespace MatriciApp
{
    partial class FormHome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.label_Title = new System.Windows.Forms.Label();
            this.label_credits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxScelta = new System.Windows.Forms.ComboBox();
            this.buttonAddCol = new System.Windows.Forms.Button();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonRemCol = new System.Windows.Forms.Button();
            this.buttonRemRow = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelDim = new System.Windows.Forms.Label();
            this.buttonEsegui = new System.Windows.Forms.Button();
            this.labelScalare = new System.Windows.Forms.Label();
            this.numericUpDownScalare = new System.Windows.Forms.NumericUpDown();
            this.labelOP = new System.Windows.Forms.Label();
            this.labelDim2 = new System.Windows.Forms.Label();
            this.buttonRemCol2 = new System.Windows.Forms.Button();
            this.buttonAddCol2 = new System.Windows.Forms.Button();
            this.buttonReset2 = new System.Windows.Forms.Button();
            this.buttonRemRow2 = new System.Windows.Forms.Button();
            this.buttonAddRow2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScalare)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Title.Location = new System.Drawing.Point(274, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(453, 40);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Risolutore universale di matrici";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_credits
            // 
            this.label_credits.AutoSize = true;
            this.label_credits.Location = new System.Drawing.Point(1, 546);
            this.label_credits.Name = "label_credits";
            this.label_credits.Size = new System.Drawing.Size(748, 15);
            this.label_credits.TabIndex = 1;
            this.label_credits.Text = "Credits: Francesco Granozio, Yuri Brandi, Angelo Nazzaro, Giuseppe D\'Ambrosio, Fr" +
    "ancesco Bosso, Antonio Russomando, Carmine Pio Nardo";
            this.label_credits.Click += new System.EventHandler(this.label_credits_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(148, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Scegli l\'operazione da eseguire";
            // 
            // comboBoxScelta
            // 
            this.comboBoxScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScelta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxScelta.FormattingEnabled = true;
            this.comboBoxScelta.Items.AddRange(new object[] {
            "Determinante",
            "Complementi algebrici",
            "Trasposta",
            "Inversa",
            "Somma matrici",
            "Prodotto per scalare",
            "Prodotto righe per col.",
            "Riduzione in scala",
            "Rango"});
            this.comboBoxScelta.Location = new System.Drawing.Point(173, 463);
            this.comboBoxScelta.Name = "comboBoxScelta";
            this.comboBoxScelta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxScelta.Size = new System.Drawing.Size(169, 29);
            this.comboBoxScelta.TabIndex = 9;
            this.comboBoxScelta.SelectedIndexChanged += new System.EventHandler(this.comboBoxScelta_SelectedIndexChanged);
            // 
            // buttonAddCol
            // 
            this.buttonAddCol.Location = new System.Drawing.Point(244, 100);
            this.buttonAddCol.Name = "buttonAddCol";
            this.buttonAddCol.Size = new System.Drawing.Size(39, 23);
            this.buttonAddCol.TabIndex = 8;
            this.buttonAddCol.Text = "+";
            this.buttonAddCol.UseVisualStyleBackColor = true;
            this.buttonAddCol.Click += new System.EventHandler(this.buttonAddCol_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(34, 192);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(41, 23);
            this.buttonAddRow.TabIndex = 9;
            this.buttonAddRow.Text = "+";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonRemCol
            // 
            this.buttonRemCol.Enabled = false;
            this.buttonRemCol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRemCol.Location = new System.Drawing.Point(199, 100);
            this.buttonRemCol.Name = "buttonRemCol";
            this.buttonRemCol.Size = new System.Drawing.Size(39, 23);
            this.buttonRemCol.TabIndex = 10;
            this.buttonRemCol.Text = "-";
            this.buttonRemCol.UseVisualStyleBackColor = true;
            this.buttonRemCol.Click += new System.EventHandler(this.buttonRemCol_Click);
            // 
            // buttonRemRow
            // 
            this.buttonRemRow.Enabled = false;
            this.buttonRemRow.Location = new System.Drawing.Point(34, 163);
            this.buttonRemRow.Name = "buttonRemRow";
            this.buttonRemRow.Size = new System.Drawing.Size(41, 23);
            this.buttonRemRow.TabIndex = 11;
            this.buttonRemRow.Text = "-";
            this.buttonRemRow.UseVisualStyleBackColor = true;
            this.buttonRemRow.Click += new System.EventHandler(this.buttonRemRow_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(302, 100);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(89, 23);
            this.buttonReset.TabIndex = 12;
            this.buttonReset.Text = "Azzera";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelDim
            // 
            this.labelDim.AutoSize = true;
            this.labelDim.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDim.Location = new System.Drawing.Point(34, 93);
            this.labelDim.Name = "labelDim";
            this.labelDim.Size = new System.Drawing.Size(133, 30);
            this.labelDim.TabIndex = 13;
            this.labelDim.Text = "Matrice 1 x 1";
            this.labelDim.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelDim.Click += new System.EventHandler(this.labelDim_Click);
            // 
            // buttonEsegui
            // 
            this.buttonEsegui.BackColor = System.Drawing.Color.White;
            this.buttonEsegui.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEsegui.Enabled = false;
            this.buttonEsegui.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonEsegui.FlatAppearance.BorderSize = 0;
            this.buttonEsegui.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonEsegui.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonEsegui.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEsegui.ForeColor = System.Drawing.Color.Black;
            this.buttonEsegui.Image = global::MatriciApp.Properties.Resources.play_button__2_;
            this.buttonEsegui.Location = new System.Drawing.Point(729, 427);
            this.buttonEsegui.Name = "buttonEsegui";
            this.buttonEsegui.Size = new System.Drawing.Size(65, 65);
            this.buttonEsegui.TabIndex = 14;
            this.buttonEsegui.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonEsegui.UseVisualStyleBackColor = false;
            this.buttonEsegui.Click += new System.EventHandler(this.buttonEsegui_Click);
            // 
            // labelScalare
            // 
            this.labelScalare.AutoSize = true;
            this.labelScalare.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelScalare.Location = new System.Drawing.Point(675, 155);
            this.labelScalare.Name = "labelScalare";
            this.labelScalare.Size = new System.Drawing.Size(153, 28);
            this.labelScalare.TabIndex = 15;
            this.labelScalare.Text = "Inserisci scalare: ";
            this.labelScalare.Visible = false;
            this.labelScalare.Click += new System.EventHandler(this.labelScalare_Click);
            // 
            // numericUpDownScalare
            // 
            this.numericUpDownScalare.DecimalPlaces = 2;
            this.numericUpDownScalare.Location = new System.Drawing.Point(719, 200);
            this.numericUpDownScalare.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownScalare.Name = "numericUpDownScalare";
            this.numericUpDownScalare.Size = new System.Drawing.Size(65, 23);
            this.numericUpDownScalare.TabIndex = 16;
            this.numericUpDownScalare.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownScalare.Visible = false;
            this.numericUpDownScalare.ValueChanged += new System.EventHandler(this.numericUpDownScalare_ValueChanged);
            // 
            // labelOP
            // 
            this.labelOP.AutoSize = true;
            this.labelOP.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelOP.Location = new System.Drawing.Point(479, 182);
            this.labelOP.Name = "labelOP";
            this.labelOP.Size = new System.Drawing.Size(35, 47);
            this.labelOP.TabIndex = 17;
            this.labelOP.Text = "?";
            this.labelOP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelOP.Visible = false;
            this.labelOP.Click += new System.EventHandler(this.labelOP_Click);
            // 
            // labelDim2
            // 
            this.labelDim2.AutoSize = true;
            this.labelDim2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDim2.Location = new System.Drawing.Point(594, 93);
            this.labelDim2.Name = "labelDim2";
            this.labelDim2.Size = new System.Drawing.Size(133, 30);
            this.labelDim2.TabIndex = 18;
            this.labelDim2.Text = "Matrice 1 x 1";
            this.labelDim2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelDim2.Visible = false;
            this.labelDim2.Click += new System.EventHandler(this.labelDim2_Click);
            // 
            // buttonRemCol2
            // 
            this.buttonRemCol2.Enabled = false;
            this.buttonRemCol2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRemCol2.Location = new System.Drawing.Point(755, 100);
            this.buttonRemCol2.Name = "buttonRemCol2";
            this.buttonRemCol2.Size = new System.Drawing.Size(39, 23);
            this.buttonRemCol2.TabIndex = 19;
            this.buttonRemCol2.Text = "-";
            this.buttonRemCol2.UseVisualStyleBackColor = true;
            this.buttonRemCol2.Visible = false;
            this.buttonRemCol2.Click += new System.EventHandler(this.buttonRemCol2_Click);
            // 
            // buttonAddCol2
            // 
            this.buttonAddCol2.Location = new System.Drawing.Point(800, 100);
            this.buttonAddCol2.Name = "buttonAddCol2";
            this.buttonAddCol2.Size = new System.Drawing.Size(39, 23);
            this.buttonAddCol2.TabIndex = 20;
            this.buttonAddCol2.Text = "+";
            this.buttonAddCol2.UseVisualStyleBackColor = true;
            this.buttonAddCol2.Visible = false;
            this.buttonAddCol2.Click += new System.EventHandler(this.buttonAddCol2_Click);
            // 
            // buttonReset2
            // 
            this.buttonReset2.Location = new System.Drawing.Point(855, 100);
            this.buttonReset2.Name = "buttonReset2";
            this.buttonReset2.Size = new System.Drawing.Size(89, 23);
            this.buttonReset2.TabIndex = 21;
            this.buttonReset2.Text = "Azzera";
            this.buttonReset2.UseVisualStyleBackColor = true;
            this.buttonReset2.Visible = false;
            this.buttonReset2.Click += new System.EventHandler(this.buttonReset2_Click);
            // 
            // buttonRemRow2
            // 
            this.buttonRemRow2.Enabled = false;
            this.buttonRemRow2.Location = new System.Drawing.Point(594, 163);
            this.buttonRemRow2.Name = "buttonRemRow2";
            this.buttonRemRow2.Size = new System.Drawing.Size(41, 23);
            this.buttonRemRow2.TabIndex = 22;
            this.buttonRemRow2.Text = "-";
            this.buttonRemRow2.UseVisualStyleBackColor = true;
            this.buttonRemRow2.Visible = false;
            this.buttonRemRow2.Click += new System.EventHandler(this.buttonRemRow2_Click);
            // 
            // buttonAddRow2
            // 
            this.buttonAddRow2.Location = new System.Drawing.Point(594, 192);
            this.buttonAddRow2.Name = "buttonAddRow2";
            this.buttonAddRow2.Size = new System.Drawing.Size(41, 23);
            this.buttonAddRow2.TabIndex = 23;
            this.buttonAddRow2.Text = "+";
            this.buttonAddRow2.UseVisualStyleBackColor = true;
            this.buttonAddRow2.Visible = false;
            this.buttonAddRow2.Click += new System.EventHandler(this.buttonAddRow2_Click);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1078, 561);
            this.Controls.Add(this.buttonAddRow2);
            this.Controls.Add(this.buttonRemRow2);
            this.Controls.Add(this.buttonReset2);
            this.Controls.Add(this.buttonAddCol2);
            this.Controls.Add(this.buttonRemCol2);
            this.Controls.Add(this.labelDim2);
            this.Controls.Add(this.labelOP);
            this.Controls.Add(this.numericUpDownScalare);
            this.Controls.Add(this.labelScalare);
            this.Controls.Add(this.buttonEsegui);
            this.Controls.Add(this.labelDim);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonRemRow);
            this.Controls.Add(this.buttonRemCol);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.buttonAddCol);
            this.Controls.Add(this.comboBoxScelta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_credits);
            this.Controls.Add(this.label_Title);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrici App";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScalare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_credits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxScelta;
        private System.Windows.Forms.Button buttonAddCol;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonRemCol;
        private System.Windows.Forms.Button buttonRemRow;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelDim;
        private System.Windows.Forms.Button buttonEsegui;
        private System.Windows.Forms.Label labelScalare;
        private System.Windows.Forms.NumericUpDown numericUpDownScalare;
        private System.Windows.Forms.Label labelOP;
        private System.Windows.Forms.Label labelDim2;
        private System.Windows.Forms.Button buttonRemCol2;
        private System.Windows.Forms.Button buttonAddCol2;
        private System.Windows.Forms.Button buttonReset2;
        private System.Windows.Forms.Button buttonRemRow2;
        private System.Windows.Forms.Button buttonAddRow2;
    }
}

