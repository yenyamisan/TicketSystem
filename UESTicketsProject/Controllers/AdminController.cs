using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UESTicketsProject.Data.Entities;
using UESTicketsProject.Data.Repositories.Interfaces;

namespace UESTicketsProject.Controllers
{
    public class AdminController : Controller
    {
        private IRolRepository _rolRepository;
        private IDepartamentoRepository _departamentoRepository;
        public AdminController(IRolRepository rolRepository, IDepartamentoRepository departamentoRepository)
        {
            _rolRepository = rolRepository;
            _departamentoRepository = departamentoRepository;
        }
        public ActionResult AgregarRol()
        {
            var model = new Rol();
            return View(model);
        }

        public ActionResult ListarRoles()
        {
            var model = _rolRepository.GetAll().ToList();
            return View(model);
        }

        public ActionResult CrearRol(Rol model)
        {
            _rolRepository.Save(model);
            return RedirectToAction("ListarRoles");
        }


        public ActionResult ListarDepartamentos()
        {
            var model = _departamentoRepository.GetAll().ToList();
            return View(model);
        }

        public ActionResult AgregarDepartamento()
        {
            var model = new Departamento();
            return View(model);
        }

        public ActionResult CrearDepartamento(Departamento model)
        {
            _departamentoRepository.Save(model);
            return RedirectToAction("ListarDepartamentos");

        }
    }
}