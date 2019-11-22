using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace shudu
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data.ColumnCount = 9;
            data.RowCount = 9;
            for (int i = 0; i < 9; i++)
            {
                data.Columns[i].Width = 41;
                data.Rows[i].Height = 40;
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    data.Rows[i].Cells[j].Value = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (data.Rows[i].Cells[j].Value.ToString() == "")
                        data.Rows[i].Cells[j].Value = ".";
                }
            solveSudoku();
        }
        bool solved = false;
        private void solveSudoku()
        {
            recursive(0, 0);
        }
        private void recursive(int row, int col)
        {
            if (data.Rows[row].Cells[col].Value.ToString()==".")
            {
                int i = 1;
                for (; i < 10; i++)
                    if (TF(i, row, col))
                    {
                        write(i, row, col);
                        writenext(row, col);
                        if (!solved) del( row, col);
                    }
            }
            else writenext( row, col);
        }
        private  bool TF( int num, int row, int col)
        {
            int rowindex = row / 3, colindex = col / 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (data.Rows[rowindex * 3 + i].Cells[colindex * 3 + j].Value.ToString() == num.ToString())
                        return false;
                }
            for (int i = 0; i < 9; i++)
            {
                if (data.Rows[row].Cells[i].Value.ToString() == num.ToString() || data.Rows[i].Cells[col].Value.ToString() == num.ToString())
                    return false;
            }
            return true;
        }
        private void write( int num, int row, int col)
        {
            data.Rows[row].Cells[col].Value = num.ToString();
        }
        private  void writenext(int row, int col)
        {
            if (row == 8 && col == 8) solved = true;
            else if (col < 8) recursive(row, col + 1);
            else if (row < 8) recursive(row + 1, 0);
        }
        private void del(int row, int col)
        {
            data.Rows[row].Cells[col].Value = ".";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            solved = false;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    data.Rows[i].Cells[j].Value = "";
                }
            }
        }
    }
}
