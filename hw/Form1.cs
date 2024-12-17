using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace hw
{
    public partial class Form1 : Form
    {
        private SoundPlayer begin = new SoundPlayer(@"C:\Users\Dzhos_ds17\Desktop\12.12.2024\2. Кто хочет стать миллионером\Ресурсы\sound\begin.wav");
        private SoundPlayer trueSound = new SoundPlayer(@"C:\Users\Dzhos_ds17\Desktop\12.12.2024\2. Кто хочет стать миллионером\Ресурсы\sound\true.wav");
        private SoundPlayer falseSound = new SoundPlayer(@"C:\Users\Dzhos_ds17\Desktop\12.12.2024\2. Кто хочет стать миллионером\Ресурсы\sound\false.wav");
        private SoundPlayer startSound = new SoundPlayer(@"C:\Users\Dzhos_ds17\Desktop\12.12.2024\2. Кто хочет стать миллионером\Ресурсы\sound\gong.wav");
        private SoundPlayer call = new SoundPlayer(@"C:\Users\Dzhos_ds17\Desktop\12.12.2024\2. Кто хочет стать миллионером\Ресурсы\sound\zvonok.wav");
        private Model model;
        private Presenter presenter;
        private Button[] variables;
        private Label[] labels;
        private int currentQuestionIndex = 0; // Индекс текущего вопроса
        private bool gameStarted = false; // Флаг, показывающий, что игра началась
        private int correctAnswers = 0;
        private string winSum = null;


        public Form1()
        {
            InitializeComponent();
            begin.Play();
            presenter = new Presenter();
            model = new Model();
            variables = new Button[] { button7, button8, button9, button10 };
            labels = new Label[] {label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15 };

            // Подписываем кнопки на событие нажатия
            foreach (var button in variables)
            {
                button.Click += Button_Click;
            }
        }

        // Обработчик старта новой игры
        private void StartNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Инициализация игры
            currentQuestionIndex = 0; // Сброс индекса текущего вопроса
            gameStarted = true; // Игра началась
            presenter.ResetButtons(variables); // Сброс состояния кнопок

            // Показ первого вопроса
            startSound.Play();
            presenter.ShowQuestion(label16, button7, button8, button9, button10, currentQuestionIndex);
        }

  

       


        // Обработчик нажатия на кнопку
        private async void Button_Click(object sender, EventArgs e)
        {
            if (!gameStarted) return; // Если игра не началась, ничего не делаем



            int clickedButton = presenter.ButtonClick(sender, e, variables);

            if (clickedButton == 0)
            {
                variables[clickedButton].BackColor = Color.Green;
                correctAnswers++;
                label17.Visible = true;
                label18.Visible = true;


                trueSound.Play();
                await Task.Delay(3000);
                label17.Visible = false;
                label18.Visible = false;
            }
            else
            {
                if (correctAnswers != 5 && correctAnswers < 5)
                {
                    correctAnswers = 0;
                }

                if (correctAnswers != 10 && correctAnswers < 15 && correctAnswers > 5)
                {
                    correctAnswers = 5;
                }
                if (correctAnswers != 10 && correctAnswers < 15 && correctAnswers > 10)
                {
                    correctAnswers = 10;
                }

                variables[clickedButton].BackColor = Color.Red;
                label17.Visible = true;
                label18.Visible = true;
                label17.BackColor = Color.Red;
                label17.Text = "Неправильно!!!";
                falseSound.Play();
                await Task.Delay(3000);
                label17.Visible = false;
                label18.Visible = false;
                presenter.ResetLabel(label17);
            }

            switch (correctAnswers)
            {
                case 1:
                    presenter.SetLabelColor(labels, label15);
                    winSum = label15.Text;
                    break;

                case 2:
                    presenter.SetLabelColor(labels, label14);
                    winSum = label14.Text;
                    break;

                case 3:
                    presenter.SetLabelColor(labels, label13);
                    winSum = label13.Text;
                    break;

                case 4:
                    presenter.SetLabelColor(labels, label12);
                    winSum = label12.Text;
                    break;

                case 5:
                    presenter.SetLabelColor(labels, label11);
                    winSum = label11.Text;
                    break;

                case 6:
                    presenter.SetLabelColor(labels, label10);
                    winSum = label10.Text;
                    break;

                case 7:
                    presenter.SetLabelColor(labels, label9);
                    winSum = label9.Text;
                    break;

                case 8:
                    presenter.SetLabelColor(labels, label8);
                    winSum = label8.Text;
                    break;

                case 9:
                    presenter.SetLabelColor(labels, label7);
                    winSum = label7.Text;
                    break;

                case 10:
                    presenter.SetLabelColor(labels, label6);
                    winSum = label6.Text;
                    break;

                case 11:
                    presenter.SetLabelColor(labels, label5);
                    winSum = label5.Text;
                    break;

                case 12:
                    label4.BackColor = Color.Coral;
                    presenter.ResetWins(labels, label4);
                    winSum = label4.Text;
                    break;

                case 13:
                    presenter.SetLabelColor(labels, label3);
                    winSum = label3.Text;
                    break;

                case 14:
                    presenter.SetLabelColor(labels, label2);
                    winSum = label2.Text;
                    break;

                case 15:
                    presenter.SetLabelColor(labels, label1);
                    winSum = label1.Text;
                    break;



            }

            // Переход к следующему вопросу
            currentQuestionIndex++;


            // Если вопросы закончились, показываем сообщение
            presenter.CheckEnd(currentQuestionIndex, gameStarted);

            // Показываем следующий вопрос
            presenter.ShowQuestion(label16, button7, button8, button9, button10, currentQuestionIndex);
            presenter.ResetButtons(variables);
        }

  

        private void button4_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                Button clicked = sender as Button;
                Bitmap img = new Bitmap("4.jpg");
                startSound.Play();
                button4.Image = img;

                if (clicked != null)
                {
                    button4.Image = img;
                    button9.Visible = false;
                    button10.Visible = false;
                    button4.Enabled = false;

                }
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                Button clicked = sender as Button;
                Bitmap img = new Bitmap("6.jpg");
                button6.Image = img;



                if (clicked != null)
                {
                    call.Play();
                    await Task.Delay(2000);

                    groupBox3.Visible = true;
                    button6.Enabled = false;

                    await Task.Delay(5000);
                    groupBox3.Visible = false;
                }
            }

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                Button clicked = sender as Button;
                Bitmap img = new Bitmap("5.jpg");
                button5.Image = img;

                if (clicked != null)
                {
                    call.Play();
                    await Task.Delay(2000);
                    label19.Visible = true;
                    label20.Visible = true;
                    string answer = button7.Text;
                    string result = "Я думаю, это " + answer;
                    label20.Text = result;
                    button5.Enabled = false;
                    await Task.Delay(3000);
                    label19.Visible = false;
                    label20.Visible = false;
                }

            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(winSum, "Ваш выигрыш");
            gameStarted = false;
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(winSum, "Вы сдались");
            gameStarted = false;
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(winSum, "Ваш выигрыш");
            gameStarted = false;
            return;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e) { }

        private void groupBox2_Enter(object sender, EventArgs e)
        {



        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

     
    }
}
