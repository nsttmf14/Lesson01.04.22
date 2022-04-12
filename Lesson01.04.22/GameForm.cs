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
    public partial class GameForm : Form
    {
        private readonly Random rnd = new Random();
        private readonly List<PictureBox> picList;
        private int choose = 0, score = 0;

        List<string> results = new List<string>();

        public List<string> Results
        {
            get { return results; }
            set { results = value; }
        }
        public GameForm()
        {
            InitializeComponent();
            picList = new List<PictureBox>()
{
pictureBox1, pictureBox2, pictureBox3, pictureBox4,
pictureBox5, pictureBox6, pictureBox7, pictureBox8,
pictureBox9, pictureBox10, pictureBox11, pictureBox12,
pictureBox13, pictureBox14, pictureBox15,
pictureBox16, pictureBox17, pictureBox18, pictureBox19,
pictureBox20, pictureBox21,pictureBox22, pictureBox23,
pictureBox24, pictureBox25
};
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            LoadImages();

            choose = rnd.Next(0, 24);
            score = 0;

            GameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (GameProgressBar.Value != 100)
            {
                GameProgressBar.Value++;
            }
            else
            {
                GameTimer.Stop();
                results.Add(DateTime.Now.ToShortDateString() + "| Проигрыш");
                FailForm FF = new FailForm();
                FF.Show();
            }
        }

        private void CounterLabel_TextChanged(object sender, EventArgs e)
        {

            if (CounterLabel.Text == "10")
            {
                GameTimer.Stop();
                MessageBox.Show("Вы справились", "Успех");
                results.Add(DateTime.Now.ToShortDateString() + "| Победа");
            }
        }

        private void GameForm_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                var element = (PictureBox)sender;

                //Если ЛКМ по нужному PictureBox'у, то прибавляем балл и меняем позицию
                if (e.Button == MouseButtons.Left && element == picList[choose])
                {
                    picList[choose].Image = Properties.Resources.CheckMark;
                    score++;

                    CounterLabel.Text = score.ToString();

                    choose = rnd.Next(0, 24);

                    System.Threading.Thread.Sleep(1500);
                    LoadImages();

                }
                else if (e.Button == MouseButtons.Left && element != picList[choose])
                {
                    element.Image = Properties.Resources.Cross;
                }
            }
            catch
            {
                //Если нажали не на PictureBox, то ничего не произойдёт, т.к. вылетит ошибка
            }
        }

        private void LoadImages()
        {
            for (int i = 0; i < picList.Count - 1; i++)
            {
                picList[i].Image = Properties.Resources.Closed;
            }
        }
    }
}
