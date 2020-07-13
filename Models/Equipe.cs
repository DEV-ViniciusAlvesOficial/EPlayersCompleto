using System;
using System.Collections.Generic;
using System.IO;

namespace EPlayersFinalizado.Models
{
    public class Equipe : EPlayersBase , IEquipe
    { 
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/equipe.csv";

        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }
        //CRUD


        /// <summary>
        /// Cria Equipe
        /// </summary>
        /// <param name="e create Equipe"></param>
        public void Create(Equipe e)
        {
            string[] linha = {Prepare(e)};
            
            File.AppendAllLines(PATH, linha);
        }
        /// <summary>
        /// Preparando linhas CSV
        /// </summary>
        /// <param name="Prepare linha equipe"></param>
        /// <returns></returns>
        private string Prepare(Equipe e){
            return $"{e.IdEquipe}; {e.Nome}; {e.Imagem}";
        }
        /// <summary>
        /// Deleta uma equipe
        /// </summary>
        /// <param name="Delete Equipe"></param>
        public void Delete(int IdEquipe)
        {
           List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (y => y.Split (";") [0] == IdEquipe.ToString ());
            RewriteCSV (PATH, linhas);
        }
        /// <summary>
        /// Lendo lista Equipe
        /// </summary>
        /// <returns>Equipes</returns>
        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)

            //Lê a lista até acabar
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        /// <summary>
        /// Update linha
        /// </summary>
        /// <param name="Update linha equipe"></param>
        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (y => y.Split (";") [0] == e.IdEquipe.ToString ());
            linhas.Add (Prepare (e));
            RewriteCSV (PATH, linhas);
        }
    }
}