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
        public void IndexRetornaViewResult()
        {
            //act
            var result = _controller.Index();

            //assert
            Assert.IsType<ViewResult>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void IndexChamaRepositoryUmaVez()
        {
            //arrange
            var controller = new AlunosController(_repository.Object);
            _repository.Setup(a => a.GetAlunos());

            //act
            controller.Index();

            //assert
            _repository.Verify(ar => ar.GetAlunos(), Times.Once);
        }

        [Fact]
        public void DetailsRetornaBadRequestParaIdNulo()
        {
            //Arrange
            AlunosController controller = _controller;


            //Act
            var result = controller.Details(0);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void DetailsRetornaNotFoundParaIdValido()
        {
            //arrange
            AlunosController controller = _controller;

            //act
            var result = controller.Details(30);

            //assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DetailsRetornaViewResultParaAlunoEncontrado()
        {
            //arrange
            AlunosController controller = _controller;

            Aluno aluno = new Aluno();
            aluno.Id = 1;

            _repository.Setup(a => a.GetAlunoById(1))
               .Returns(aluno);

            //act
            var result = controller.Details(1);

            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DetailsChamaRepositoryUmaVez()
        {
            //arrange
            AlunosController controller = _controller;

            Aluno aluno = new Aluno();
            aluno.Id = 2;

            _repository.Setup(a => a.GetAlunoById(2))
                .Returns(aluno);

            //act
            controller.Details(2);


            //assert
            _repository.Verify(ar => ar.GetAlunoById(2), Times.Once);
        }

        [Fact]
        public void CreateSempreRetornaView()
        {
            //Arrange
            AlunosController controller = _controller;

            //Act
            var result = controller.Create();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateVerificaSeRepositorioFoiChamadoUmaVezERetornaRedirectToAction()
        {
            //arrange
            AlunosController controller = _controller;

            Aluno aluno = new Aluno();

            aluno.Id = -5;
            aluno.Nome = null;
            aluno.Turma = null;
            aluno.Media = -15;

            //act
            var total = controller.Create(aluno);

            //assert
            _repository.Verify(ar => ar.AddAluno(aluno), Times.Once);

            Assert.IsType<RedirectToActionResult>(total);
        }
    }
}
