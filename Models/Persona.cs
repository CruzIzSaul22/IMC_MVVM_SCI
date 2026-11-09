using System;
using System.Collections.Generic;
using System.Text;

namespace IMC_MVVM_SCI.Models
{
    public class Persona
    {
        //Datos numericos necesarios para el cálculo del IMC.
        public double Estatura { get; set; }
        public double Peso { get; set; }

        //Determina el IMC de la persona utilizando los datos de la persona.
        public double CalcularIMC()
        {
            return Peso / (Estatura * Estatura);
        }
    }
}
