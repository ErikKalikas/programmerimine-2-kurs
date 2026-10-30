using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Iseseisevtöö_Kolm_rakendust
{
    public class MathQuizForm : Form
    {
        Random random = new Random();
        Timer timer = new Timer();

        Label timeLabel = new Label();

        Label num1 = new Label();
        Label num2 = new Label();
        Label num3 = new Label();
        Label num4 = new Label();
        Label num5 = new Label();
        Label num6 = new Label();
        Label num7 = new Label();
        Label num8 = new Label();

        Label plus = new Label();
        Label minus = new Label();
        Label multiply = new Label();
        Label divide = new Label();

        NumericUpDown answer1 = new NumericUpDown();
        NumericUpDown answer2 = new NumericUpDown();
        NumericUpDown answer3 = new NumericUpDown();
        NumericUpDown answer4 = new NumericUpDown();

        int correct1;
        int correct2;
        int correct3;
        int correct4;

        int timeLeft = 30;

        public MathQuizForm()
        {
            Text = "Math Quiz";
            Size = new Size(500, 400);
            StartPosition = FormStartPosition.CenterScreen;

            // Время
            Label timeText = new Label();
            timeText.Text = "Time Left:";
            timeText.Location = new Point(280, 20);
            timeText.Size = new Size(80, 30);

            timeLabel.Text = "30";
            timeLabel.Location = new Point(370, 20);
            timeLabel.Size = new Size(50, 30);
            timeLabel.Font = new Font("Arial", 14);

            Controls.Add(timeText);
            Controls.Add(timeLabel);

            //*//

            num1.Text = "?";
            num1.Location = new Point(50, 70);
            num1.Size = new Size(50, 30);
            num1.Font = new Font("Arial", 14);

            plus.Text = "+";
            plus.Location = new Point(110, 70);
            plus.Size = new Size(30, 30);
            plus.Font = new Font("Arial", 16);
            plus.TextAlign = ContentAlignment.MiddleCenter;

            num2.Text = "?";
            num2.Location = new Point(150, 70);
            num2.Size = new Size(50, 30);
            num2.Font = new Font("Arial", 14);

            answer1.Location = new Point(230, 70);

            //*//
            num3.Text = "?";
            num3.Location = new Point(50, 120);
            num3.Size = new Size(50, 30);
            num3.Font = new Font("Arial", 14);

            minus.Text = "-";
            minus.Location = new Point(110, 120);
            minus.Size = new Size(30, 30);
            minus.Font = new Font("Arial", 16);
            minus.TextAlign = ContentAlignment.MiddleCenter;

            num4.Text = "?";
            num4.Location = new Point(150, 120);
            num4.Size = new Size(50, 30);
            num4.Font = new Font("Arial", 14);

            answer2.Location = new Point(230, 120);

            //*//
            num5.Text = "?";
            num5.Location = new Point(50, 170);
            num5.Size = new Size(50, 30);
            num5.Font = new Font("Arial", 14);

            multiply.Text = "*";
            multiply.Location = new Point(110, 170);
            multiply.Size = new Size(30, 30);
            multiply.Font = new Font("Arial", 16);
            multiply.TextAlign = ContentAlignment.MiddleCenter;

            num6.Text = "?";
            num6.Location = new Point(150, 170);
            num6.Size = new Size(50, 30);
            num6.Font = new Font("Arial", 14);

            answer3.Location = new Point(230, 170);

            //*//е
            num7.Text = "?";
            num7.Location = new Point(50, 220);
            num7.Size = new Size(50, 30);
            num7.Font = new Font("Arial", 14);

            divide.Text = "/";
            divide.Location = new Point(110, 220);
            divide.Size = new Size(30, 30);
            divide.Font = new Font("Arial", 16);
            divide.TextAlign = ContentAlignment.MiddleCenter;

            num8.Text = "?";
            num8.Location = new Point(150, 220);
            num8.Size = new Size(50, 30);
            num8.Font = new Font("Arial", 14);

            answer4.Location = new Point(230, 220);

            //*//
            Controls.Add(num1);
            Controls.Add(num2);
            Controls.Add(num3);
            Controls.Add(num4);
            Controls.Add(num5);
            Controls.Add(num6);
            Controls.Add(num7);
            Controls.Add(num8);

            Controls.Add(plus);
            Controls.Add(minus);
            Controls.Add(multiply);
            Controls.Add(divide);

            Controls.Add(answer1);
            Controls.Add(answer2);
            Controls.Add(answer3);
            Controls.Add(answer4);

            //*//
            Button startButton = new Button();
            startButton.Text = "Start the quiz";
            startButton.Location = new Point(170, 290);
            startButton.Size = new Size(150, 40);
            startButton.Click += StartQuiz;

            Controls.Add(startButton);

            // Nupp, millega saab mängu varem lõpetada
            Button endButton = new Button();
            endButton.Text = "Lõpeta";
            endButton.Location = new Point(330, 290);
            endButton.Size = new Size(100, 40);
            endButton.Click += EndQuiz;

            Controls.Add(endButton);

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        void StartQuiz(object sender, EventArgs e)
        {
            timeLeft = 30;
            timeLabel.Text = "30";

            // +
            int a = random.Next(1, 10);
            int b = random.Next(1, 10);

            num1.Text = a.ToString();
            num2.Text = b.ToString();
            correct1 = a + b;

            // -
            a = random.Next(10, 20);
            b = random.Next(1, 10);

            num3.Text = a.ToString();
            num4.Text = b.ToString();
            correct2 = a - b;

            // *
            a = random.Next(1, 10);
            b = random.Next(1, 10);

            num5.Text = a.ToString();
            num6.Text = b.ToString();
            correct3 = a * b;

            // /
            b = random.Next(1, 10);
            int result = random.Next(1, 10);

            a = b * result;

            //*//
            num7.Text = a.ToString();
            num8.Text = b.ToString();
            correct4 = result;

            answer1.Value = 0;
            answer2.Value = 0;
            answer3.Value = 0;
            answer4.Value = 0;

            timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            timeLabel.Text = timeLeft.ToString();

            if (timeLeft == 0)
            {
                ShowResult();
            }
        }

        // Kui vajutatakse "Lõpeta"
        void EndQuiz(object sender, EventArgs e)
        {
            // Kui mäng ei käi, siis ei tee midagi
            if (timer.Enabled == false)
            {
                return;
            }

            ShowResult();
        }

        // Peatab taimeri ja näitab, mitu vastust on õiged
        void ShowResult()
        {
            timer.Stop();

            int score = 0;

            if (answer1.Value == correct1)
            {
                score++;
            }

            if (answer2.Value == correct2)
            {
                score++;
            }

            if (answer3.Value == correct3)
            {
                score++;
            }

            if (answer4.Value == correct4)
            {
                score++;
            }

            MessageBox.Show(
                "Õigeid vastuseid: " + score + " / 4",
                "Tulemus"
            );
        }
    }
}
