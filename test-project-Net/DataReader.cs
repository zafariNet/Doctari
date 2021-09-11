namespace test_project_Net
{
    /// <summary>
    /// Reader for address information
    /// </summary>
    class DataReader
    {
        /// <summary>
        /// read content from 'testdaten' using resources
        /// </summary>
        /// <returns>content from 'testdaten.txt'</returns>
        /// <remarks>text file 'testdaten.txt' is linked in resources</remarks>
        public string ReadData()
        {
            var content = Properties.Resources.testdaten;
            return content;
        }
    }
}
