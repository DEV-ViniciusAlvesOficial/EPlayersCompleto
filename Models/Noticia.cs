using System;
using Microsoft.Extensions.Primitives;
using System.IO;
using System.Collections.Generic;

namespace EPlayersFinalizado.Models
{
    public class Noticia : EPlayersBase , INoticia
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/noticia.csv";

        /// <summary>
        /// Cria FolderAndFile Noticia
        /// </summary>
        public Noticia()
        {
            CreateFolderAndFile(PATH);
        }
        //CRUD


        /// <summary>
        /// Cria Noticia
        /// </summary>
        /// <param name="n">Noticia</param>
        public void Create(Noticia n)
        {
            string[] linha = {Prepare(n)};
            
            File.AppendAllLines(PATH, linha);
        }
        /// <summary>
        /// Preparando linhas CSV
        /// </summary>
        /// <param name="n">Noticia</param>
        /// <returns>Id;título;Texto;Imagem;</returns>
        private string Prepare(Noticia n){
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }
        /// <summary>
        /// Deleta uma noticia
        /// </summary>
        /// <param name="IdNoticia">Id da noticia</param>
        public void Delete(int IdNoticia)
        {
           List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (y => y.Split (";") [0] == IdNoticia.ToString ());
            RewriteCSV (PATH, linhas);
        }


        /// <summary>
        /// Lendo lista Noticia
        /// </summary>
        /// <returns>Noticia</returns>
        public List<Noticia> ReadAll()
        {
            List<Noticia> noticias = new List<Noticia>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)

            //Lê a lista até acabar
            {
                string[] linha = item.Split(";");
                Noticia noticia = new Noticia();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }

        /// <summary>
        /// Update noticias
        /// </summary>
        /// <param name="n">Noticias</param>
        public void Update(Noticia n)
        {
            List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (y => y.Split (";") [0] == n.IdNoticia.ToString ());
            linhas.Add (Prepare (n));
            RewriteCSV (PATH, linhas);
        }
    }
}
    
