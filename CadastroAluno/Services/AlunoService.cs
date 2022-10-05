using CadastroAluno.Models;
using CadastroAluno.Repositories.Interfaces;
using CadastroAluno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepo;

        public AlunoService(IAlunoRepository alunoRepo)
        {
            _alunoRepo = alunoRepo;
        }

        public List<Aluno> GetAlunos()
        {
            return _alunoRepo.GetAlunos();
        }
    }
}
