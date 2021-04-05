using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace FileParserLibrary
{
    public class TextReplacer : Replacer
    {
        public TextReplacer(string pathToFile, int maxBufferSize)
            : base(pathToFile, maxBufferSize)
        {
            
        }

        public override void ReplaceString(string searchedString, string replacedString)
        {
            string currentLine = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(_pathToFile))
                {
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        if (currentLine.Contains(searchedString))
                        {
                            currentLine = currentLine.Replace(searchedString, 
                                    replacedString);
                            ReplacementsCount++;
                        }

                        AddLineToBuffer(currentLine);
                    }

                    if (!IsEmptyBuffer)
                    {
                        File.AppendAllLines(_pathToTempFile, _buffer);
                    }
                }

                if (File.Exists(_pathToFile))
                {
                    File.Delete(_pathToFile);
                }

                File.Move(_pathToTempFile, _pathToFile);
            }
            finally
            {
                File.Delete(_pathToTempFile);
            }
        }

        private void AddLineToBuffer(string line)
        {
            _buffer.Enqueue(line);

            if (!CanAddToBuffer)
            {
                File.AppendAllLines(_pathToTempFile, _buffer);
                _buffer.Clear();
            }
        }

        private bool CanAddToBuffer
        {
            get
            {
                return _buffer.Count < _maxBufferSize;
            }
        }

        private bool IsEmptyBuffer
        {
            get
            {
                return _buffer.Count == 0;
            }
        }
    }
}
