using Labb3_NET22.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for aEditQuiz.xaml
    /// </summary>
    public partial class aEditQuiz : Window
    {
        private Quiz quiz;
        private List<Question> questions;

        public aEditQuiz()
        {
            InitializeComponent();
            quiz = new Quiz();
            questions = Quiz.LoadUserQuestions();

            ShowAllQuestions.ItemsSource = questions;
        }

        private void SaveQuestion(object sender, RoutedEventArgs e)
        {
            Quiz.SaveUserQuestions(questions);

            MessageBox.Show("The quiz questions have been saved.");
        }

        private void AddQuestion(object sender, RoutedEventArgs e)
        {
            string Text = QuestionTitle.Text;
            string question1 = ChangeQAnswer1.Text;
            string question2 = ChangeQAnswer2.Text;
            string question3 = ChangeQAnswer3.Text;

            string correctAnswer = SelectCorrectAnswer();

            int maxId = questions.Max(q => q.Id);

            int newId = maxId + 1;

            Question question = new Question()
            {
                Id = newId,
                Text = Text,
                Options = new List<string> { question1, question2, question3 },
                CorrectAnswer = correctAnswer

            };
            questions.Add(question);

            Quiz.SaveUserQuestions(questions);

            RefreshList();
        }

        private void RemoveQuestion(object sender, RoutedEventArgs e)
        {
            if (ShowAllQuestions.SelectedItem != null)
            {
                Question removeQuestion = (Question)ShowAllQuestions.SelectedItem;

                questions.RemoveAll(q => q.Id == removeQuestion.Id);

                questions.Remove(removeQuestion);
                 
                Quiz.SaveUserQuestions(questions);

                RefreshList();
            }
        }

        private void ResetQuestions(object sender, RoutedEventArgs e)
        {
            questions = Quiz.LoadDefaultQuestions();

            MessageBox.Show("You have reset the questions.");

            RefreshList();
        }

        private void ToMenu(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();
        }

        private void ShowAllQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShowAllQuestions.SelectedItem is Question question)
            {

                QuestionTitle.Text = question.Text;
                ChangeQAnswer1.Text = question.Options[0];
                ChangeQAnswer2.Text = question.Options[1];
                ChangeQAnswer3.Text = question.Options[2];
            }
        }

        private string SelectCorrectAnswer()
        {
            if (CorrectAnswer1.IsChecked == true)
            {
                return ChangeQAnswer1.Text;
            }
            else if (CorrectAnswer2.IsChecked == true)
            {
                return ChangeQAnswer1.Text;
            }
            else if (CorrectAnswer3.IsChecked == true)
            {
                return ChangeQAnswer1.Text;
            }

            return string.Empty;
        }

        private void RefreshList()
        {
            ShowAllQuestions.ItemsSource = null;
            ShowAllQuestions.ItemsSource = questions;

            Quiz.SaveUserQuestions(questions);
        }

    }
}
