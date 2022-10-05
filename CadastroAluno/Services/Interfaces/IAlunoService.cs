using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Services.Interfaces
{
    public interface IAlunoService
    {
        List<Aluno> GetAlunos();
    }
}
