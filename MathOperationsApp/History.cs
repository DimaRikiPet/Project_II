using System;
using System.Collections.Generic;
using System.IO;

namespace MathOperationsApp
{
    public class History
    {
        private List<string> _calculations = new List<string>();

        public void AddCalculation(string calculation)
        {
            _calculations.Add(calculation);
        }

        public void ExportToTxt(string filePath)
        {
            File.WriteAllLines(filePath, _calculations);
        }

        public void ShowHistory()
        {
            foreach (var calc in _calculations)
            {
                Console.WriteLine(calc);
            }
        }
    }
}