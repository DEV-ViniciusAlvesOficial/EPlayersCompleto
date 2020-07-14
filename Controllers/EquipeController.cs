using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPlayersFinalizado.Models;
using Microsoft.AspNetCore.Http;

namespace EPlayersFinalizado.Controllers
{
    public class EquipeController : Controller
    {
       Equipe equipemodel = new Equipe(); 
        public IActionResult Index()
        {
            ViewBag.Equipes = equipemodel.ReadAll();
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe equipe = new Equipe();
            equipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            equipe.Nome = form["Nome"];
            equipe.Imagem = form["Imagem"];

            equipemodel.Create(equipe); 
                      
             ViewBag.Equipes = equipemodel.ReadAll();
             return LocalRedirect("~/Equipe");
        }
    }
}
 
        