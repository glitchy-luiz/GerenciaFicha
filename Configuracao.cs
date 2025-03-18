//using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace coisaboa
{
    class Configuracao
    {
        private readonly string _caminhoArquivo = "appsettings.json";

        public void SalvarChars(List<Person> chars)
        {
            try
            {
                string json = JsonConvert.SerializeObject(chars, Formatting.Indented);

                File.WriteAllText(_caminhoArquivo, json);
                Console.WriteLine("Lista de pessoas salva com sucesso no arquivo JSON.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar as pessoas no arquivo JSON: " + ex.Message);
            }
        }

        public void AdicionarChar(Person person)
        {
            try
            {
                List<Person> chars = new List<Person>();

                if (File.Exists(_caminhoArquivo))
                {
                    string jsonExistente = File.ReadAllText(_caminhoArquivo);
                    chars = JsonConvert.DeserializeObject<List<Person>>(jsonExistente) ?? new List<Person>();
                }

                chars.Add(person);

                string jsonAtualizado = JsonConvert.SerializeObject(chars, Formatting.Indented);
                File.WriteAllText(_caminhoArquivo, jsonAtualizado);

                Console.WriteLine("Novo personagem adicionado com sucesso ao arquivo JSON.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao salvar personagem {person.Name} no arquivo json: " + ex.Message);
            }
        }

        public List<Person> CarregarChars()
        {
            try
            {
                if (File.Exists(_caminhoArquivo))
                {
                    string json = File.ReadAllText(_caminhoArquivo);

                    return JsonConvert.DeserializeObject<List<Person>>(json) ?? new List<Person>();
                }
                else
                {
                    Console.WriteLine("Arquivo JSON não encontrado.");
                    return new List<Person>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar as pessoas do arquivo JSON: " + ex.Message);
                return new List<Person>();
            }
        }

        public Person BuscarChar(string nome)
        {
            foreach (var person in CarregarChars())
            {
                if (person.Name == nome)
                {
                    return person;
                }
            }
            return null;
        }

        public void ExcluirPersonagem(string nome)
        {
            var chars = CarregarChars();

            var personagem = chars.FirstOrDefault(p => p.Name.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (personagem != null)
            {
                chars.Remove(personagem);
                SalvarChars(chars);
                Console.WriteLine($"Personagem {nome} excluído com sucesso.");
            }
            else
            {
                Console.WriteLine($"Personagem com o nome {nome} não encontrado.");
            }
        }

        public void EditarPersonagem(string nome, Person novosDados)
        {
            var chars = CarregarChars();

            var personagem = chars.FirstOrDefault(p => p.Name.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (personagem != null)
            {
                personagem.Name = novosDados.Name;
                personagem.Life = novosDados.Life;
                personagem.Strengh = novosDados.Strengh;
                personagem.Energy = novosDados.Energy;
                personagem.Sanity = novosDados.Sanity;
                personagem.Inteligent = novosDados.Inteligent;
                personagem.Agility = novosDados.Agility;
                personagem.Ocult = novosDados.Ocult;
                personagem.Endurecy = novosDados.Endurecy;
                personagem.habilidades = novosDados.habilidades;
                personagem.pericias = novosDados.pericias;

                SalvarChars(chars);
                Console.WriteLine($"Personagem {nome} atualizado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Personagem com o nome {nome} não encontrado.");
            }
        }
    }
}