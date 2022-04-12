using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson01._04._22
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }
        GameForm game = new GameForm();
        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                MessageBox.Show("Сначала введите имя", "Ошибка");
            }
            else
            {
                game.Show();
               
            }
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllLines(sfd.FileName, game.Results);
            }
        }
    }
}
