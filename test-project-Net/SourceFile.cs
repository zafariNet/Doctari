using System.IO;

namespace test_project_Net
{
    /// <summary>
    /// Reader for address information
    /// </summary>
    public class FileDataSource
    {
        
        /// <summary>
        /// read content from 'testdaten' using resources
        /// </summary>
        /// <returns>content from 'testdaten.txt'</returns>
        /// <remarks>text file 'testdaten.txt' is linked in resources</remarks>
        public string ReadPersonData()
        {

            StreamReader sr = new StreamReader(@"data/testdaten.txt" ,System.Text.Encoding.UTF8, true);
          
            var content = sr.ReadToEnd();
            return content;
        }

        public string ReadStateData()
        {

            StreamReader sr = new StreamReader(@"data/States.txt", System.Text.Encoding.UTF8, true);

            var content = sr.ReadToEnd(); ;
            sr.Close();
            return content;
        }

        public void WriteNewState(string state)
        {
            var str = new StreamWriter(@"data/States.txt",true);
            str.WriteLine(state);
            str.Close();

        }
    }
}
