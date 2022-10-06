<<<<<<< HEAD
﻿using CadastroAluno.Controllers;
=======
﻿using Bogus;
using CadastroAluno.Controllers;
>>>>>>> f20f616934f661096d36d796d9990ee8a8c42677
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
