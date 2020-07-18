using System.Collections.Generic;

namespace EPlayersFinalizado.Models
{
    public interface INoticia
    {
        
         void Create(Noticia n);
         List<Noticia> ReadAll();
         void Update(Noticia n);
         void Delete(int IdNoticia);

    }
}