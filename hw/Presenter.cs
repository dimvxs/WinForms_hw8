using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw
{
    internal class Presenter
    {

        public Model model;


        public Presenter(Model m)
        {
            model = m;
            model.Read();
        }

        public Presenter()
        {
            model = new Model();
            model.Read();
        }


        public void ShowQuestion(Label label, Button button1, Button button2, Button button3, Button button4, int i)
        {
            if (i >= model.Questions.Count) return;
            label.Text = model.Questions[i].question;
            button1.Text = model.Questions[i].answer1;
            button2.Text = model.Questions[i].answer2;
            button3.Text = model.Questions[i].answer3;
            button4.Text = model.Questions[i].answer4;
       
        }

        public void ResetWins(Label[] labels, Label label1)
        {
            foreach (var label in labels)
            {
                if (label != label1)
                    label.BackColor = Color.Black;
            }
        }

        public void CheckEnd(int currentQuestionIndex, bool gameStarted)
        {
            if (currentQuestionIndex == 15)
            {
                MessageBox.Show("Игра завершена!");
                gameStarted = false;
                return;
            }
        }

        public void SetLabelColor(Label[] labels, Label label)
        {
           
                    label.BackColor = Color.Coral;
                    ResetWins(labels, label);

              

            }


      
        public void ResetButtons(Button[] variables)
        {
            foreach (var button in variables)
            {
                button.BackColor = Color.Black;
            }
        }

        public void ResetLabel(Label label17)
        {
            label17.Text = "Правильно";
            label17.BackColor = Color.Green;
        }

        public int ButtonClick(object sender, EventArgs e, Button[] variables)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                int index = Array.IndexOf(variables, clickedButton);
                if (index != -1) return index;
            }
            return -1;
        }


    }


}
