using CadastroAluno.Controllers;
﻿using Bogus;
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
    public class AlunosControllerTest
    {
        private Mock<IAlunoRepository> _repository;
        private AlunosController _controller;


        public AlunosControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();
            _controller = new AlunosController(_repository.Object);
        }

        [Fact]
        public void IndexRetornaOuNaoRetorna()
        {
            //act
            var result = _controller.Index();

            //assert
            var okResult = Assert.IsType<ViewResult>(result);


            Assert.NotNull(result);
        }

    }
}
