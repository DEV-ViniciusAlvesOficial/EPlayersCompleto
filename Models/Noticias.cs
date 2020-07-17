using System;

namespace EPlayersFinalizado.Models
{
    public class Noticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        internal dynamic ReadAll()
        {
            throw new NotImplementedException();
        }

        internal void Create(Noticias novaNoticia)
        {
            throw new NotImplementedException();
        }

        internal void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}