using IMC_MVVM_SCI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace IMC_MVVM_SCI.ViewModels
{
    public class IMCviewModel : INotifyPropertyChanged
    {
        //Los Entry capturan texto, incluso si son números

        public string PTexto { get; set; } = "";

        public string ETexto { get; set; } = "";

        private string resultado = "Ingresa tus datos.";

        public string Resultado 
        { 
            get { return resultado; }
            set 
            {
                resultado = value;

                //Avisamos al Label que el resultado cambió para que se actualice.
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resultado)));
            }
        }

        //El botón usara este comando mediante binding.
        public ICommand CalcularImcCommand { get; }

        public IMCviewModel()
        {
            //Al ejecutar el comando, se llama a Calcular.
            CalcularImcCommand = new Command(Calcular);
        }

        //El Binding escucha este evento.
        public event PropertyChangedEventHandler? PropertyChanged;

        private void Calcular()
        {
            //Validamos cada campo por separado.
            double peso;
            bool pesoValido = double.TryParse(PTexto, out peso);

            if (pesoValido == false || !double.IsFinite(peso) || peso <= 0)
            {
                Resultado = "Ingresa un peso válido mayor que cero.";
                return; //Termina sin hacer el cálculo.
            }

            double estatura;
            bool estaturaValida = double.TryParse(ETexto, out estatura);

            if (estaturaValida == false || !double.IsFinite(estatura) || estatura <= 0)
            {
                Resultado = "Ingresa una estatura válida mayor que cero.";
                return; //Termina sin hacer el cálculo.
            }

            // Creamos el modelo y le asignamos los datos.
            Persona persona = new Persona();
            persona.Peso = peso;
            persona.Estatura = estatura;

            // El modelo realiza la operación.
            double imc = persona.CalcularIMC();

            // Evitamos mostrar un resultado numérico inválido.
            if (!double.IsFinite(imc))
            {
                Resultado = "Revisa el peso y la estatura.";
                return;
            }

            // F2 muestra el número con dos decimales.
            Resultado = "Tu IMC es: " + imc.ToString("F2");

        }
    }
}
