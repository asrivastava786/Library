﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace RText_to_Csv
{
    public class Class1
    {
        public static void Convert(string TextFilePath, string CsvFilePath)
        {
            string[] TextFileRead = System.IO.File.ReadAllLines(TextFilePath); //Read txt File
            List<string> list = new List<string>(TextFileRead);
            List<string> file = new List<string>();

            IEnumerable<int> dot = TextFileRead.ToList().Select(x => x.Split('-').Count()); 
            int Maxdot = TextFileRead.ToList().Select(x => x.Split('-').Count()).Max(); //Max line 

            IEnumerable<bool> index = dot.ToList().Select(x => x.Equals(Maxdot)); //get line have max count
            int z = index.ToList().IndexOf(true); 

            bool z2 = index.ToList()[z + 2]; 
            int column = 0;

            if (z2.Equals(true))
            {
                column = TextFileRead.ToList()[z + 1].Split('|').Count();
            }

            StreamWriter csv = File.CreateText(CsvFilePath); //create .csv if not already created
            foreach (var item in list)
            {
                string[] count = item.Split('|'); //split row

                if (count.Count() == column)
                {
                    IEnumerable<string> trimmed = count.Select(x => x.Trim());
                    string singleString = string.Join(";", trimmed.ToArray());
                    csv.WriteLine(singleString);
                    file.Add(singleString);
                }
            }
        }
    }
}
