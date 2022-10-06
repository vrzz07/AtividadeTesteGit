using CadastroAluno.Controllers;
using CadastroAluno.Models;
using CadastroAluno.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAluno.Test
{
    class AlunosControllerTest
    {
        Mock<IAlunoRepository> _repository;
        Aluno alunoValido;

        public AlunosControllerTest()
        {
           _repository = new Mock<IAlunoRepository>();
        }

    }
}
