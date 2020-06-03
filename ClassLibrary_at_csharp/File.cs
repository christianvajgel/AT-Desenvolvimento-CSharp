using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_at_csharp
{
    class File
    {



        private static string ObterNomeArquivo()
        {
            var pastaDesktop = Environment.SpecialFolder.Desktop;

            string localDaPastaDesktop = Environment.GetFolderPath(pastaDesktop);
            string nomeDoArquivo = @"\dadosDosFuncionarios.txt";

            return localDaPastaDesktop + nomeDoArquivo;
        }

    }
}
