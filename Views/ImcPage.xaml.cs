using Microsoft.Maui.Controls;
using IMC_MVVM_SCI.ViewModels;

namespace IMC_MVVM_SCI.Views;


public partial class ImcPage : ContentPage
{
	public ImcPage()
	{
        // Crea los controles definidos en el XAML.
        InitializeComponent();

        // Conecta la pantalla con sus datos y comandos.
        BindingContext = new IMCviewModel();
    }
}