using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        List<Aluno> GetAlunos();
        Aluno GetAlunoById(int id);
        Aluno AddAluno(Aluno aluno);
        int UpdateAluno(int id, Aluno alunoAlterado);
        Task DeleteAluno(int id);
    }
}
