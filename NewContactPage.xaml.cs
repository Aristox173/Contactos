namespace HolaMundo;
using HolaMundo.Utils;
using HolaMundo.Models;
using System.Collections.ObjectModel;
using HolaMundo.Services;

public partial class NewContactPage : ContentPage
{
	Contacto contacto;
    readonly IServicioApi _servicioApi = new ServicioApi();
    public NewContactPage()
	{
		InitializeComponent();
       // _servicioApi = servicioApi;
    }

    protected override void OnAppearing()
    {
        //Write the code of your page here
        base.OnAppearing();
        contacto = BindingContext as Contacto;
        if (contacto != null)
        {	
            nombre.Text = contacto.nombre;
            direccion.Text = contacto.direccion;
            telefono.Text = contacto.telefono;
            cedula.Text = contacto.cedula;
			cedula.IsEnabled = false;
		}
		else
		{
            cedula.IsEnabled = true;
        }

    }

    private async void onClickGuardarContacto(object sender, EventArgs e)
	{
		if (contacto == null)
		{
			contacto = new Contacto()
			{
				nombre = nombre.Text,
				direccion = direccion.Text,
				telefono = telefono.Text,
				cedula = cedula.Text,
				imagen = "imagen1.png"
			};
			await _servicioApi.GuardarContacto(contacto);
			//Util.listContacto.Add(contacto);
			// var page = Navigation.NavigationStack.LastOrDefault();
			// await Navigation.PushAsync(new Contactos());
			//Navigation.RemovePage(page);
		}
		else
		{
			contacto.nombre= nombre.Text;
			contacto.direccion= direccion.Text;
			contacto.telefono= telefono.Text;
			contacto.cedula=cedula.Text;
			await _servicioApi.EditarContacto(contacto.cedula, contacto);
            BindingContext = contacto;
		}
        await Navigation.PopAsync();
    }
}