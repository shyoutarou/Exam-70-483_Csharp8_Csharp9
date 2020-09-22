using System;
using System.Collections.Generic;

namespace C8_Using
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> m_oEnum = new List<string>() { "1", "2", "3" };
            IEnumerable<string> m_oArray = new string[] { "1", "2", "3" };
            IEnumerable<string> myStrings = new[] { "first item", "Second item" };
            WriteLinesToFile(myStrings);


            Console.ReadKey();
        }

        static int WriteLinesToFile(IEnumerable<string> lines)
        {
            using var file = new System.IO.StreamWriter("WriteLines2.txt");
            // Notice how we declare skippedLines after the using statement.
            int skippedLines = 0;
            foreach (string line in lines)
            {
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
                else
                {
                    skippedLines++;
                }
            }
            // Notice how skippedLines is in scope here.
            return skippedLines;
            // file is disposed here
        }

        static void EscreverNoArquivo(IEnumerable<string> linhas)
        {
            using (var arquivo = new System.IO.StreamWriter("WriteLines2.txt"))
            {
                foreach (string linha in linhas)
                {
                    // se linha não contém 'teste' escreve a linha no arquivo
                    if (!linha.Contains("Second"))
                    {
                        arquivo.WriteLine(linha);
                    }
                }
            }   // arquivo é liberado aqui
        }

    }
}
