using HolaMundo.Models;
using HolaMundo.Utils;

namespace HolaMundo;

public partial class DetailsPage : ContentPage
{
	

    public DetailsPage()
	{
		InitializeComponent();
        
    }

    protected override void OnAppearing()
    {
        //Write the code of your page here
        base.OnAppearing();
        Contacto contacto = BindingContext as Contacto;
        imagen.Source = contacto.imagen;
        nombre.Text = contacto.nombre;
        telefono.Text = contacto.telefono;
        direccion.Text = contacto.direccion;
        cedula.Text = contacto.cedula;
    }

    private async void onClickEliminarContacto(object sender, EventArgs e)
	{
        Contacto contacto = BindingContext as Contacto;
        Util.listContacto.Remove(contacto);
		await Navigation.PopAsync();
	}

	private async void onClickModificarContacto(Object sender, EventArgs e)
	{

		await Navigation.PushAsync(new NewContactPage()
		{
			BindingContext = BindingContext as Contacto,
		}) ;
    }
}