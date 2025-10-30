using FullStackCI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackCITest.DTOs
{
    public class CalculadoraTest
    {


        // [Unidad]_[Escenario]_[ResultadoEsperado]
        [Fact]
        public void Sumar_DosNumerosPositivos_RetornaLaSuma()
        {
            // Arrange
            var calculadora = new Calculadora();
            string operacion = "sumar";
            double resultadoEsperado = 15;

            calculadora.Operacion = operacion;
            calculadora.Numero1 = 5;
            calculadora.Numero2 = 10;
            // Act
            double resultado = calculadora.Calcular();
            // Assert
            Assert.Equal(resultadoEsperado, resultado);
            Assert.Equal(operacion, "sumar");
        }
        [Fact]
        public void dividir_DosNumerosPositivos_RetornaLaDivision()
        {
            // Arrange
            var calculadora = new Calculadora();
            string operacion = "dividir";
            double resultadoEsperado = 0.5;

            calculadora.Operacion = operacion;
            calculadora.Numero1 = 5;
            calculadora.Numero2 = 10;
            // Act
            double resultado = calculadora.Calcular();
            // Assert

            Assert.Equal(resultadoEsperado, resultado);
            Assert.NotEmpty(operacion);
        }

        [Fact]
        public void dividir_DosNumerosPositivos_RetornaLaExepcion()
        {
            // Arrange
            var calculadora = new Calculadora();
            string operacion = "dividir";

            calculadora.Operacion = operacion;
            calculadora.Numero1 = 5;
            calculadora.Numero2 = 0;

            // Act & Assert
            var error = Assert.Throws<DivideByZeroException>(() => calculadora.Calcular());
            Assert.IsType<DivideByZeroException>(error);
            Assert.NotEmpty(operacion);
        }

        [Fact]
        public void multiplicar_DosNumerosPositivos_RetornaLaMultiplicacion()
        {
            // Arrange
            var calculadora = new Calculadora();
            string operacion = "multiplicar";
            double resultadoEsperado = 50;
            calculadora.Operacion = operacion;
            calculadora.Numero1 = 5;
            calculadora.Numero2 = 10;
            // Act
            double resultado = calculadora.Calcular();
            // Assert
            Assert.Equal(resultadoEsperado, resultado);
            Assert.NotEmpty(operacion);
        }

        [Fact]
        public void restar_DosNumerosPositivos_RetornaLaResta()
        {
            // Arrange
            var calculadora = new Calculadora();
            string operacion = "restar";
            double resultadoEsperado = -5;
            calculadora.Operacion = operacion;
            calculadora.Numero1 = 5;
            calculadora.Numero2 = 10;
            // Act
            double resultado = calculadora.Calcular();
            // Assert
            Assert.Equal(resultadoEsperado, resultado);
            Assert.NotEmpty(operacion);
        }


        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 5)]
        public void sumar_DosNumerosPositivos_RetornaLaSuma(double n1, double n2)
        {
            // Arrange
            var calculadora = new Calculadora();

            double resultadoEsperado = 3;
            // Act
            double resultado = calculadora.Sumar(n1,n2);
            // Assert
            Assert.Equal(resultadoEsperado, resultado);
     
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 5)]
        public void restar_DosNumerosPositivos_RetornaLaResta2(double n1, double n2)
        {
            // Arrange
            var calculadora = new Calculadora();

            double resultadoEsperado = 3;
            // Act
            double resultado = calculadora.Restar(n1, n2);
            // Assert
            Assert.Equal(resultadoEsperado, resultado);

        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 5)]
        public void multiplicar_DosNumerosPositivos_RetornaLaMultiplicacion2(double n1, double n2)
        {
            // Arrange
            var calculadora = new Calculadora();

            double resultadoEsperado = 3;
            // Act
            double resultado = calculadora.Multiplicar(n1, n2);
            // Assert
            Assert.Equal(resultadoEsperado, resultado);

        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 5)]
        public void divicion_DosNumerosPositivos_RetornaLaDivicion2(double n1, double n2)
        {
            // Arrange
            var calculadora = new Calculadora();

            double resultadoEsperado = 3;
            // Act
            double resultado = calculadora.Dividir(n1, n2);
            // Assert
            Assert.Equal(resultadoEsperado, resultado);

        }

    }
}
