using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParserTask
{
    class Viewer
    {
        #region Private

        private string _startMessage;

        #endregion

        public Viewer(string startMessage)
        {
            _startMessage = startMessage;
        }

        public void ShowMessage(int countOverlap)
        {
            Console.WriteLine(_startMessage);
            Console.WriteLine(countOverlap);
        }

        public void ShowInstruction(string instruction)//todo
        {
            Console.WriteLine(instruction);
        }
    }
}
