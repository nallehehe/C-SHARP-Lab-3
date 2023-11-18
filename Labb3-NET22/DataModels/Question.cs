using System.Collections.Generic;
using System.Security.Policy;
using System.Windows.Documents;

namespace Labb3_NET22.DataModels;

public class Question
{
    /*public string Statement { get; set; }
    public string[] Answers { get; set; }
    public int CorrectAnswer { get; set; }*/

    public int Id { get; set; }
    public string Text { get; set; }
    public List<string> Options { get; set; }
    public string CorrectAnswer { get; set; }
    
}