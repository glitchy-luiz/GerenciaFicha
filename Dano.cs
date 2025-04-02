using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

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

        public static string CalcularPericia(Pericia pericia, Person person)
        {
            var dados = ValorAtributo(pericia, person);
            var bonus = pericia.bonus.ToString();
            return CalcularDano($"{dados}d20 + {bonus}");
        }

        public static string ValorAtributo(Pericia pericia, Person person)
        {
            if (pericia.atribute == "Força")
            {
                return person.Strengh.ToString();
            }
            else if (pericia.atribute == "Inteligência")
            {
                return person.Inteligent.ToString();
            }
            else if (pericia.atribute == "Agilidade")
            {
                return person.Agility.ToString();
            }
            else if (pericia.atribute == "Presença")
            {
                return person.Ocult.ToString();
            }
            else if (pericia.atribute == "Vigor")
            {
                return person.Endurecy.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
