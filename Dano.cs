using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace coisaboa
{
    public class Dano
    {
        public static string CalcularDano(string entrada)
        {
            Random rand = new Random();
            var regex = new Regex(@"([+-]?\d+)(d\d+)?");
            var matches = regex.Matches(entrada.Replace(" ", ""));

            int danoTotal = 0;
            string resultadoDados = "";

            foreach (Match match in matches)
            {
                if (match.Groups[2].Success) // Se tiver a parte "dX" (dados)
                {
                    int quantidade = int.Parse(match.Groups[1].Value);
                    int lados = int.Parse(match.Groups[2].Value.Substring(1));

                    int somaDados = 0;
                    for (int i = 0; i < quantidade; i++)
                    {
                        int dadoRolado = rand.Next(1, lados + 1);
                        somaDados += dadoRolado;
                        resultadoDados += dadoRolado + (i < quantidade - 1 ? " + " : "");
                    }

                    danoTotal += somaDados;
                    resultadoDados += $" (total {somaDados})\n";
                }
                else
                {
                    int valorAdicional = int.Parse(match.Groups[1].Value);
                    danoTotal += valorAdicional;
                    resultadoDados += valorAdicional + " (adicional)\n";
                }
            }

            //totalDanoLabel.Text = "Dano Total: " + danoTotal;
            return resultadoDados;
        }
    }
}
