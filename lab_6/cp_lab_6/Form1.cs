using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cp_lab_6
{
    public partial class Form1 : Form
    {
        Solver solver = new Solver();

        private void ModifySize(int size)
        {
            MatrixAView.RowCount = size;
            MatrixAView.ColumnCount = size;
            MatrixCView.RowCount = size;
            MatrixCView.ColumnCount = size;
            VectorBView.RowCount = size;
            VectorBView.ColumnCount = 1;
            VectorXView.RowCount = size;
            VectorXView.ColumnCount = 1;
        }

        private double[,] ReadMatrix(DataGridView view)
        {
            bool isValid = true;

            int rows = view.RowCount;
            int cols = view.ColumnCount;
            double[,] matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (view.Rows[i].Cells[j].Value != null &&
                        double.TryParse(view.Rows[i].Cells[j].Value.ToString(), out double value))
                    {
                        matrix[i, j] = value;
                    }
                    else
                    {
                        view[j, i].Style.ForeColor = Color.Red;
                        isValid = false;
                    }
                }
            }
            if (!isValid)
            {
                return null;
            }
            return matrix;
        }

        private double[] ReadVector(DataGridView view)
        {
            bool isValid = true;

            int rows = view.RowCount;
            double[] vector = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                if (view.Rows[i].Cells[0].Value != null &&
                    double.TryParse(view.Rows[i].Cells[0].Value.ToString(), out double value))
                {
                    vector[i] = value;
                }
                else
                {
                    view[0, i].Style.ForeColor = Color.Red;
                }
            }
            if (!isValid)
            {
                return null;
            }
            return vector;
        }

        public Form1()
        {
            InitializeComponent();

            ModifySize(1);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            int size = (int)DimentionUpDown.Value;

            foreach (var control in Controls)
            {
                if (control is DataGridView view)
                {
                    view.Rows.Clear();
                    view.Columns.Clear();
                }
            }

            ModifySize(size);
        }

        private void DimentionUpDown_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)DimentionUpDown.Value;

            ModifySize(size);
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            int size = (int)DimentionUpDown.Value;

            double[,] matrixA = ReadMatrix(MatrixAView);
            double[,] matrixC;

            double[] vectorB = ReadVector(VectorBView);
            double[] vectorX;

            int methodIndex = MethodComboBox.SelectedIndex;
            if (methodIndex < 0)
            {
                MessageBox.Show("Please select a solution method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (matrixA == null || vectorB == null)
            {
                MessageBox.Show("Invalid input data. Please correct the highlighted fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                switch (methodIndex)
                {
                    case 0:
                        vectorX = solver.LUDecomposition(matrixA, vectorB, out matrixC);
                        break;
                    case 1:
                        vectorX = solver.Gauss(matrixA, vectorB, out matrixC);
                        break;
                    default:
                        MessageBox.Show("Selected method is not implemented.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < size; i++)
            {
                VectorXView.Rows[i].Cells[0].Value = vectorX[i];
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    MatrixCView.Rows[i].Cells[j].Value = matrixC[i, j];
                }
            }
        }

        private void MatrixAView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                MatrixAView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
            }
        }

        private void VectorBView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                VectorBView.Rows[e.RowIndex].Cells[0].Style.ForeColor = Color.Black;
            }
        }
    }
}
