using CadastroAluno.Data;
using CadastroAluno.Models;
using CadastroAluno.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {

        private readonly CadastroAlunoContext _context;

        public AlunoRepository(CadastroAlunoContext context)
        {
            _context = context;
        }

        public List<Aluno> GetAlunos()
        {
            return _context.Aluno.ToList();
        }

        public Aluno GetAlunoById(int id)
        {
            return  _context.Aluno.FirstOrDefault(c => c.Id == id);
        }

        public Aluno AddAluno(Aluno aluno)
        {

            _context.Aluno.Add(aluno);
            _context.SaveChanges();

            return aluno;
        }

        public int UpdateAluno(int id, Aluno alunoAlterado)
        {
            var aluno = _context.Aluno.FirstOrDefault(c => c.Id == id);

            if (aluno == null)
                return 0;

            aluno.AtualizarDados(alunoAlterado.Nome, alunoAlterado.Turma, alunoAlterado.Media);

            _context.Entry(aluno).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public async Task DeleteAluno(int id)
        {
            var aluno = await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);

            _context.Aluno.Remove(aluno);
            _context.SaveChanges();
        }
    }
}