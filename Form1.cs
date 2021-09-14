using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace MatriciApp
{
    public partial class FormHome : Form
    {
        int East = 0;

        int n_col = 1, n_row = 1;
        NumericUpDown[,] tb1 = new NumericUpDown[8, 8];

        int n_col2 = 1, n_row2 = 1;
        NumericUpDown[,] tb2 = new NumericUpDown[8, 8];

        public static int n_col_ris, n_row_ris;
        public static double[] vetris;


        const int bound = 5;
        const int xCoord1 = 120;
        const int xCoord2 = 680;
      

        public FormHome()
        {
            InitializeComponent();

            NuovaCol(tb1);
        }

        private void NuovaCol(NumericUpDown[,] tb)
        {
            int j, numRow, xCoord;

            if (tb == tb1)
            {
                j = n_col - 1;
                numRow = n_row;
                xCoord = xCoord1;
            }
            else
            {
                j = n_col2 - 1;
                numRow = n_row2;
                xCoord = xCoord2;
            }


            for (int i = 0; i < numRow; i++) {


                if (!this.Contains(tb[i, j]))
                {
                    //var tb = new TextBox();
                    //Random r = new Random();
                    //int num = r.Next(1, 1000);
                    //MatrixNodes[i, j] = tb;

                    tb[i, j] = new NumericUpDown();

                    tb[i, j].DecimalPlaces = 2;
                    tb[i, j].Name = "Node_" + i + "_" + j;
                     // tb[i, j].Value = i*10 + j;  //Solo per debug
                     tb[i, j].Text = "";
                    
                    tb[i, j].Size = new System.Drawing.Size(60, 23);
                    tb[i, j].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                    tb[i, j].Location = new Point(xCoord + (j * 70), 140 + (i * 30));


                    tb[i, j].Controls[0].Visible = false;
                    tb[i, j].Maximum = new decimal(new int[] { 1000, 0, 0, 0});
                    tb[i, j].Minimum = new decimal(new int[] {1000, 0, 0,-2147483648});

                    tb[i, j].Visible = true;
                    this.Controls.Add(tb[i, j]);
                }
                else
                {
                    tb[i, j].Text = ""; //Commentare per non ripulire
                    tb[i, j].Visible = true;
                }
            }
        }

        private void DelCol(NumericUpDown[,] tb)
        {
            int j, numRow;

            if (tb == tb1)
            {
                j = n_col - 1;
                numRow = n_row;
            }
            else
            {
                j = n_col2 - 1;
                numRow = n_row2;
            }

            for (int i = 0; i < numRow; i++)
            {
                tb[i, j].Visible = false;
               //this.Controls.Remove(tb[i, j]);


            }
        }


        private void NuovaRow(NumericUpDown[,]tb)
        {
            int i, numCol, xCoord;

            if (tb == tb1)
            {
                i = n_row - 1;
                numCol = n_col;
                xCoord = xCoord1;
            }
            else
            {
                i = n_row2 - 1;
                numCol = n_col2;
                xCoord = xCoord2;
            }

            for (int j = 0; j < numCol; j++)
            {
                if (!this.Contains(tb[i, j]))
                {
                    //var tb = new TextBox();
                    //Random r = new Random();
                    //int num = r.Next(1, 1000);
                    //MatrixNodes[i, j] = tb;
                    tb[i, j] = new NumericUpDown();

                    tb[i, j].DecimalPlaces = 2;
                    tb[i, j].Name = "Node_" + i + "_" + j;
                    //tb[i, j].Value = i * 10 + j;  //Solo per debug
                    tb[i, j].Text = "";

                    tb[i, j].Size = new System.Drawing.Size(60, 23);
                    tb[i, j].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                   
                    tb[i, j].Location = new Point(xCoord + (j * 70), 140 + (i * 30));
                    tb[i, j].Visible = true;

                    tb[i, j].Controls[0].Visible = false;
                    tb[i, j].Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
                    tb[i, j].Minimum = new decimal(new int[] { 1000, 0, 0, -2147483648 });

                    this.Controls.Add(tb[i, j]);
                }
                else
                {
                    tb[i, j].Text = ""; //Commentare per non ripulire
                    tb[i, j].Visible = true;
                }

            }
        }

        private void DelRow(NumericUpDown[,] tb)
        {
            int i, numCol;

            if (tb == tb1)
            {
                i = n_row - 1;
                numCol = n_col;          
            }
            else
            {
                i = n_row2 - 1;
                numCol = n_col2; 
            }
 
            for (int j = 0; j < numCol; j++)
            {
                tb[i, j].Visible = false;
                //this.Controls.Remove(tb[i, j]);

            }
        }


        private void buttonAddCol_Click(object sender, EventArgs e)
        {

            n_col++;
            NuovaCol(tb1);
            aggiornaDim(tb1);

            if (!buttonRemCol.Enabled)
                buttonRemCol.Enabled = true;

            if (n_col == bound)
                buttonAddCol.Enabled = false;

        }


        private void buttonAddRow_Click(object sender, EventArgs e)
        {
           
            n_row++;
            NuovaRow(tb1);
            aggiornaDim(tb1);

            if (!buttonRemRow.Enabled)
                buttonRemRow.Enabled = true;

            if (n_row == bound)
                buttonAddRow.Enabled = false;


        }

        private void buttonRemCol_Click(object sender, EventArgs e)
        {
            DelCol(tb1);
            n_col--;
            aggiornaDim(tb1);

            if (!buttonAddCol.Enabled)
                buttonAddCol.Enabled = true;

            if (n_col == 1)
                buttonRemCol.Enabled = false;

        }

        private void buttonRemRow_Click(object sender, EventArgs e)
        {
            DelRow(tb1);
            n_row--;
            aggiornaDim(tb1);

            if (!buttonAddRow.Enabled)
                buttonAddRow.Enabled = true;

            if (n_row == 1)
                buttonRemRow.Enabled = false;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n_row; i++)
                for (int j = 0; j < n_col; j++)
                    tb1[i, j].Text = "";
    
        }

        private void buttonAddCol2_Click(object sender, EventArgs e)
        {
            n_col2++;
            NuovaCol(tb2);
            aggiornaDim(tb2);

            if (!buttonRemCol2.Enabled)
                buttonRemCol2.Enabled = true;

            if (n_col2 == bound)
                buttonAddCol2.Enabled = false;
        }

        private void buttonAddRow2_Click(object sender, EventArgs e)
        {
            n_row2++;
            NuovaRow(tb2);
            aggiornaDim(tb2);

            if (!buttonRemRow2.Enabled)
                buttonRemRow2.Enabled = true;

            if (n_row2 == bound)
                buttonAddRow2.Enabled = false;
        }

        private void buttonRemCol2_Click(object sender, EventArgs e)
        {
            DelCol(tb2);
            n_col2--;
            aggiornaDim(tb2);

            if (!buttonAddCol2.Enabled)
                buttonAddCol2.Enabled = true;

            if (n_col2 == 1)
                buttonRemCol2.Enabled = false;

        }


        private void buttonRemRow2_Click(object sender, EventArgs e)
        {
            DelRow(tb2);
            n_row2--;
            aggiornaDim(tb2);

            if (!buttonAddRow2.Enabled)
                buttonAddRow2.Enabled = true;

            if (n_row2 == 1)
                buttonRemRow2.Enabled = false;
        }

        private void buttonReset2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n_row2; i++)
                for (int j = 0; j < n_col2; j++)
                    tb2[i, j].Text = "";

        }

        private void aggiornaDim(NumericUpDown[,] tb)
        {
            if(tb == tb1)
                labelDim.Text = "Matrice " + n_row + " x " + n_col;
            else
                labelDim2.Text = "Matrice " + n_row2 + " x " + n_col2;
        }

        private void resetMatrix(NumericUpDown[,] tb)
        {
            int numRow, numCol;

            if (tb == tb1)
            {
                numRow = n_row;
                numCol = n_col;

                buttonRemCol.Enabled = buttonRemRow.Enabled = false;
                buttonAddCol.Enabled = buttonAddRow.Enabled = true;

                n_row = n_col = 1;

                aggiornaDim(tb1);
            }
            else
            {
                numRow = n_row2;
                numCol = n_col2;

                buttonRemCol2.Enabled = buttonRemRow2.Enabled = false;
                buttonAddCol2.Enabled = buttonAddRow2.Enabled = true;

                n_row2 = n_col2 = 1;

                aggiornaDim(tb2);
            }

            for (int i = 0; i < numRow; i++)
                for (int j = 0; j < numCol; j++)
                {
                    tb[i, j].Text = "";
                    tb[i, j].Visible = false;
                }


        }

        private void label_credits_Click(object sender, EventArgs e)
        {
            East++;
            if(East == 5)
            {
                MessageBox.Show("Un saluto dai componenti ❤️💖", "Easter egg",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
  
        }

        private void comboBoxScelta_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEsegui.Enabled = true;

            labelOP.Visible = labelDim2.Visible = buttonAddCol2.Visible = buttonAddRow2.Visible = buttonRemCol2.Visible = buttonRemRow2.Visible = buttonReset2.Visible = numericUpDownScalare.Visible = labelScalare.Visible = false;

            if (this.Contains(tb2[0, 0]))
                resetMatrix(tb2);

            switch (comboBoxScelta.SelectedIndex)
            {

                case 4:
                    {
                        
                        labelOP.Text = "+";
                        labelOP.Visible = true;
                        labelDim2.Visible = buttonAddCol2.Visible = buttonAddRow2.Visible = buttonRemCol2.Visible = buttonRemRow2.Visible = buttonReset2.Visible = true;
                        NuovaCol(tb2);
                    }
                    break;

                case 5:
                    {
                        labelOP.Text = "x";
                        labelOP.Visible = true;
                  
                        labelScalare.Visible = numericUpDownScalare.Visible = true;
                    }break;

                case 6:
                    {
                        labelOP.Text = "x";
                        labelOP.Visible = true;
                        labelDim2.Visible = buttonAddCol2.Visible = buttonAddRow2.Visible = buttonRemCol2.Visible = buttonRemRow2.Visible = buttonReset2.Visible = true;
                        NuovaCol(tb2);

                    }break;
            }
          
        }

       
        private double[] ConvertToDouble(NumericUpDown[,] tb, ref int numRow, ref int numCol)
        {
            int vetSize;
            bool isEmpty = false;

            if (tb == tb1)
            {
                numRow = n_row;
                numCol = n_col;
            }
            else
            {
                numRow = n_row2;
                numCol = n_col2;
            }

            vetSize = numRow * numCol;
            double[] mat = new double[vetSize];

            try
            {
                for (int i = 0; i < numRow; i++)
                    for (int j = 0; j < numCol; j++)
                    {
                        if (tb[i, j].Text == "")
                        {
                            isEmpty = true;
                            mat[i * numCol + j] = 0;
                        }
                        else
                            mat[i * numCol + j] = Convert.ToDouble(tb[i, j].Value);
                    }
                if (isEmpty)
                {
                    DialogResult res = MessageBox.Show("Sono presenti degli elementi vuoti.\n" +
                        "Verranno convertiti automaticamente in 0.\nDesideri continuare?", "Attenzione",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (res == DialogResult.No)
                        return null;

                }
 
            }
            catch(Exception e)
            {
                MessageBox.Show("Eccezione" + e.ToString(), "Errore",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            return mat;
        }


        private void buttonEsegui_Click(object sender, EventArgs e)
        {

            int righe = 0, colonne = 0;
            double[] vet = ConvertToDouble(tb1, ref righe, ref colonne);

            if (vet == null)
                return;

            switch (comboBoxScelta.SelectedIndex)
            {
                case 0:
                    {
                        
                        if(righe != colonne)
                        {
                            MessageBox.Show("Il determinante è una funzione definita solamente su spazi di matrici quadrate", "Attenzione",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        MessageBox.Show("Il determinante è: " + Matrix.Determinant(vet, righe, colonne), "Determinante",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }break;

                case 1:
                    {
                        if (righe != colonne)
                        {
                            MessageBox.Show("Le matrici non quadrate non possiedono una matrice dei complementi algebrici.", "Attenzione",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        double[] algebrici = Matrix.Algebrics(vet, righe, colonne);
                        Stampa st = new Stampa(algebrici, righe, colonne, "Matrice dei complementi algebrici");
                        st.ShowDialog();

                    }
                    break;

                case 2:
                    {
                        double[] trasposta = Matrix.Transpose(vet, righe, colonne);

                        for(int i = 0; i < colonne; i++)
                        {
                            for(int j = 0; j < righe; j++)
                            {
                                System.Diagnostics.Debug.WriteLine(vet[i * righe + j]);
                            }
                            System.Diagnostics.Debug.WriteLine("\n");
                        }

                        Stampa st = new Stampa(trasposta, colonne, righe, "Matrice trasposta");
                        st.ShowDialog();
                    }
                    break;

                case 3:
                    {
                        if (righe != colonne)
                        {   
                            MessageBox.Show("Le matrici non quadrate non sono invertibili.", "Attenzione",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        double det = Matrix.Determinant(vet, righe, colonne);
                        
                        if(det == 0)
                        {
                            MessageBox.Show("Le matrici con determinante nullo non non sono invertibili", "Attenzione",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }

                        det = Math.Pow(det, -1);
                        double[] inversa = Matrix.Algebrics(vet, righe, colonne);
                        inversa = Matrix.Transpose(inversa, righe, colonne);
                        Matrix.ProdScalar(inversa, righe, colonne, det);

                        Stampa st = new Stampa(inversa, righe, colonne, "Matrice inversa");
                        st.ShowDialog();
                        //inversa.ToList().ForEach(i => System.Diagnostics.Debug.WriteLine(i.ToString()));

                    }
                    break;

                case 4:
                    {
                        int righe2 = 0, colonne2 = 0;
                        double[] vet2= ConvertToDouble(tb2, ref righe2, ref colonne2);

                        if (vet2 == null)
                            return;

                        if (righe != righe2 || colonne != colonne2)
                        {
                            MessageBox.Show("Le matrici devono avere la stessa dimensione", "Attenzione",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;

                        }

                        double[] sommata = Matrix.SumMatrix(vet, vet2, righe, colonne);
                        Stampa st = new Stampa(sommata, righe, colonne, "Somma tra matrici");
                        st.ShowDialog();
                        //sommata.ToList().ForEach(i => System.Diagnostics.Debug.WriteLine(i.ToString()));
                    }
                    break;

                case 5:
                    {
                        double scalare = 0;
                        try
                        {
                            scalare = Convert.ToDouble(numericUpDownScalare.Value);
                        }
                        catch
                        {
                            MessageBox.Show("Scalare non valido", "Errore",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if(scalare == 0)
                        {
                            MessageBox.Show("Lo scalare non può essere nullo", "Dati non validi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        double[] moltiplicata = new double[righe * colonne];
                        Array.Copy(vet, moltiplicata, vet.Length);
                        Matrix.ProdScalar(moltiplicata, righe, colonne, scalare);

                        Stampa st = new Stampa(moltiplicata, righe, colonne, "Prodotto per uno scalare");
                        st.ShowDialog();
                        //moltiplicata.ToList().ForEach(i => System.Diagnostics.Debug.WriteLine(i.ToString()));

                    }
                    break;


                case 6:
                    {
                        int righe2 = 0, colonne2 = 0;
                        double[] vet2 = ConvertToDouble(tb2, ref righe2, ref colonne2);

                        if (vet2 == null)
                            return;

                        if (colonne != righe2)
                        {
                            MessageBox.Show("Il numero di colonne della prima matrice deve essere uguale alle righe della seconda", "Attenzione",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        double[] moltiplicata = Matrix.RowsCols(vet, vet2, righe, colonne, colonne2);

                        Stampa st = new Stampa(moltiplicata, righe, colonne2, "Prodotto righe per colonne");
                        st.ShowDialog();
                        //moltiplicata.ToList().ForEach(i => System.Diagnostics.Debug.WriteLine(i.ToString()));
                    }
                    break;


                case 7:
                    {
                        double[] ridotta = new double[righe * colonne];
                        Array.Copy(vet, ridotta, vet.Length);
                        Matrix.RiduzioneGaussiana(ridotta, righe, colonne);

                        Stampa st = new Stampa(ridotta, righe, colonne, "Riduzione a scala");
                        st.ShowDialog();

                        //ridotta.ToList().ForEach(i => System.Diagnostics.Debug.WriteLine(i.ToString()));
                    }
                    break;
                case 8:
                    {
                        double[] ridotta = new double[righe * colonne];
                        Array.Copy(vet, ridotta, vet.Length);
                        Matrix.RiduzioneGaussiana(ridotta, righe, colonne);
                        MessageBox.Show("Il rango è: " + Matrix.Rank(ridotta, righe, colonne), "Rango",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

            }
        }

        private void labelScalare_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownScalare_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelDim2_Click(object sender, EventArgs e)
        {

        }

        private void labelOP_Click(object sender, EventArgs e)
        {

        }

        private void labelDim_Click(object sender, EventArgs e)
        {
        }

    }
}
