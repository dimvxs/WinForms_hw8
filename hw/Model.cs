using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hw.Model;

namespace hw
{
    internal class Model
    {
        public string filePath = "questions.txt";
        public struct QuestionsBlock
        {
            public string question;
            public string answer1;
            public string answer2;
            public string answer3;
            public string answer4;
            public int correctAnswer;


            public int GetCorrectAnswer()
            {
                return correctAnswer;
            }
      
        }

        public List<QuestionsBlock> Questions = new List<QuestionsBlock>();

        public void Read()
        {
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

            for(int i = 0; i < lines.Length; i += 5)
            {
                if (i + 4 >= lines.Length) break;

                QuestionsBlock block = new QuestionsBlock
                {
                    question = lines[i],
                    answer1 = lines[i + 1],
                    answer2 = lines[i + 2],
                    answer3 = lines[i + 3],
                    answer4 = lines[i + 4],
                    correctAnswer = 0
                };

                Questions.Add(block);
           
            }

        }

   

     

    }
    
   
}
