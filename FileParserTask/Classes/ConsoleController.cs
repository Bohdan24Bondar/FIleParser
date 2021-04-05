using FileParserLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParserTask
{
    class ConsoleController
    {
        #region Private

        private string[] _args;

        #endregion

        public ConsoleController(string [] args)
        {
            _args = (string[])args.Clone();
        }

        public void Run()
        {
            try
            {
                ParametersValidator validator = new ParametersValidator(_args[0]);
                ApplicationMode mode = (ApplicationMode)_args.Length;

                switch (mode)
                {
                    case ApplicationMode.CountString:
                        if (validator.IsExistFile
                                && !validator.IsStringEmpty(_args[1]))
                        {
                            ExecuteCountedMode();
                        }
                        break;
                    case ApplicationMode.ReplaceString:
                        if (validator.IsExistFile
                                && !validator.IsStringEmpty(_args[1])
                                && !validator.IsStringEmpty(_args[2]))
                        {
                            ExecuteReplacedMode();
                        }
                        break;
                    default:
                        //todo instruction
                        break;
                }
            }
            catch (IOException) // todo
            {
                Console.WriteLine("Instruction");// todo
            }
        }

        private void ExecuteCountedMode()
        {
            int countOverlap;
            Viewer displayer = new Viewer(string.Format("Count of" +
                    " overlaps of string\n<{0}>", _args[0])); //todo

            Analyzer stringCounter = new TextAnalyzer(_args[0], _args[1]);
            stringCounter.GetCountStringOverlaps(out countOverlap);
            displayer.ShowMessage(countOverlap);
        }

        private void ExecuteReplacedMode()
        {
            Viewer displayer = new Viewer(string.Format("Count of" +
                    " replaced string \n<{0}>", _args[0])); //todo

            Replacer stringReplacer = new TextReplacer(_args[0], 1000);//todo const
            stringReplacer.ReplaceString(_args[1],_args[2]);
            displayer.ShowMessage(stringReplacer.ReplacementsCount);
        }
    }
}
