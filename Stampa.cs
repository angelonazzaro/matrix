using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MatriciApp
{
    public partial class Stampa : Form
    {
       

        public Stampa(double[] ris, int n_row, int n_col, string op)
        {
            InitializeComponent();

            this.Text = label_Title.Text = op;

            labelDim.Text = $"Matrice {n_row} x {n_col}";

            CreaMat(ris, n_row, n_col, op == "Riduzione a scala");


        }

        private void CreaMat(double[] mat, int n_row, int n_col, bool showPivot)
        {
            bool isPivFound = false;
       
            List<Label> lab = new List<Label>() { label11, label12, label13, label14, label15,
                                                  label21, label22, label23, label24, label25,
                                                  label31, label32, label33, label34, label35,
                                                  label41, label42, label43, label44, label45,
                                                  label51, label52, label53, label54, label55};
            for (int i = 0; i < n_row; i++)
            {

                isPivFound = false;
                for(int j = 0; j < n_col; j++)
                {
                    if (mat[i * n_col + j] != 0 && !isPivFound && showPivot)
                    {

                        lab[i * 5 + j].ForeColor = Color.Red;
                        isPivFound = true;
                    }

                    //System.Diagnostics.Debug.WriteLine(i * 5 + j);

                    lab[i * 5 + j].Visible = true;
                    lab[i * 5 + j].Text = mat[i * n_col + j].ToString();
                }
            }
                

        }           


        private void Stampa_Load(object sender, EventArgs e)
        {

        }

        private void labelDim_Click(object sender, EventArgs e)
        {

        }

        private void label_Title_Click(object sender, EventArgs e)
        {

        }
    }
}
