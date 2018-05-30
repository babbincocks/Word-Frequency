using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Word_Frequency_Counter
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
            dgResults.DataSource = null;


            string file = null;
            string words;
            List<WordCount> sortedWords = new List<WordCount>();
            List<string> cWords = new List<string>();
            List<string> usedWord = new List<string>();

            try
            {
                using (OpenFileDialog newDialog = new OpenFileDialog())
                {
                    newDialog.InitialDirectory = "C:\\";
                    newDialog.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";
                    newDialog.FilterIndex = 1;
                    newDialog.RestoreDirectory = true;

                    if (newDialog.ShowDialog() == DialogResult.OK)
                    {
                        file = newDialog.FileName;
                    }
                }
                
                if (file != null)
                {
                    
                    words = File.ReadAllText(file);
                    cWords = words.Split(' ', '.', ',', '?', '!', '\n', '\r', ';', '/').ToList();


                    
                    foreach(string word in cWords)
                    {

                        cWords = cWords.Where(cword => !string.IsNullOrEmpty(cword)).ToList();

                        WordCount checkWord = new WordCount(word.ToLower(), 1);
                        if(!usedWord.Contains(checkWord.Word))
                        {
                            usedWord.Add(checkWord.Word);
                            sortedWords.Add(checkWord);
                        }
                        else if(cWords.Contains(checkWord.Word))
                        {
                            int i = usedWord.IndexOf(checkWord.Word);
                            sortedWords[i].Count = sortedWords[i].Count;
                        }
                    }

                    var list = new BindingList<WordCount>(sortedWords);
                    dgResults.DataSource = list;
                    
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
