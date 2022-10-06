using CadastroAluno.Models;
using System;
using Xunit;

namespace CadastroAluno.Test
{
    public class AlunoTest
    {
        [Theory]
        [InlineData("Tiringa", "T91")]
        [InlineData("", "A02")]
        [InlineData("", "")]
        [InlineData("Kiriko", "")]
        public void AtualizarDadosAlteraNomeETurma(string nome, string turma)
        {
            //arrange
            Aluno aluno = new Aluno();
            aluno.Nome = "Cassidy";
            aluno.Turma = "T91";

            //act
            aluno.AtualizarDados(nome, turma);

            //assert
            Assert.Equal(aluno.Nome, nome);
            Assert.Equal(aluno.Turma, turma);
        }


        [Fact]
        public void VerificaAprovacaoRetornaFalse()
        {
            //arrange
            Aluno aluno = new Aluno();
            aluno.Media = 5;

            //assert
            Assert.True(aluno.VerificaAprovacao());
        }

        [Fact]
        public void VerificaAprovacaoRetornaTrue()
        {
            //arrange
            Aluno aluno = new Aluno();
            aluno.Media = 4;

            //assert
            Assert.False(aluno.VerificaAprovacao());
        }

        [Fact]
        public void AtualizarMediaAtualizaMedia()
        {
            //arrange
            Aluno aluno = new Aluno();
            aluno.Media = 10;

            //act
            aluno.AtualizaMedia(10);

            //assert
            Assert.Equal(10, aluno.Media);
        }

    }
}