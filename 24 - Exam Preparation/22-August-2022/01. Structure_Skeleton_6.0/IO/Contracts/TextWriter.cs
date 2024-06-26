﻿

using System.IO;
using BookingApp.IO.Contracts;

public class TextWriter : IWriter
    {

        public TextWriter() 
        {
            File.Delete(path);
        }

        private string path = "../../../output.txt";

        public void Write(string text)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(text);
            }
        }

        public void WriteLine(string text)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            { 
                writer .WriteLine(text);
            }
        }
    }

