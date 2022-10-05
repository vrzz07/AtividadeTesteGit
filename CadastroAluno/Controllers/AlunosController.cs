using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroAluno.Data;
using CadastroAluno.Models;
using CadastroAluno.Repositories;
using CadastroAluno.Repositories.Interfaces;

namespace CadastroAluno.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepository _repository;

        public AlunosController(IAlunoRepository repository)
        {
            _repository = repository;
        }

        // GET: Alunos
        public IActionResult Index()
        {
            return View( _repository.GetAlunos());
        }

        // GET: Alunos/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var aluno = _repository.GetAlunoById(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Turma,Media")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _repository.AddAluno(aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var aluno = _repository.GetAlunoById(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,Turma,Media")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.UpdateAluno(id, aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var aluno =_repository.GetAlunoById(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAluno(id);
            return RedirectToAction(nameof(Index));
        }
    }
}