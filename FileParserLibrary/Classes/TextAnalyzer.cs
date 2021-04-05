using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.SqlServer.Server;

namespace FileParserLibrary
{
    public class TextAnalyzer : Analyzer
    {
        #region Private

        private StreamReader _fileReader;
        private string _necessaryString;

        #endregion
        
        public TextAnalyzer(string pathToFile, string necessaryString)
            : base(pathToFile)
        {
            _necessaryString = necessaryString;
        }

        public override void GetCountStringOverlaps(out int countOverlaps)
        {
            using (StreamReader reader = new StreamReader(_pathToFile))
            {
                countOverlaps = 0;
                string line = string.Empty;

                while ((line = _fileReader.ReadLine()) != null)
                {
                    if (line.Contains(_necessaryString))
                    {
                        string[] lines = line.Split(new string[] { _necessaryString },
                                StringSplitOptions.RemoveEmptyEntries);
                        countOverlaps += (lines.Length - 1);
                    }
                }
            }
        }
    }
}
