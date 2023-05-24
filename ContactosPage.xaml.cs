using HolaMundo.Models;
using HolaMundo.Services;
using HolaMundo.Utils;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace HolaMundo;


public partial class ContactosPage : ContentPage
{
    
    readonly IServicioApi _servicioApi = new ServicioApi();

    public ContactosPage()
    {
        InitializeComponent();
        //_servicioApi = servicioApi;

        //listaContactos.ItemsSource = Util.listContacto;

    }

   

    private async void DetalleItem(object sender, SelectedItemChangedEventArgs e)
    {
        Contacto contacto = (Contacto)e.SelectedItem;
        await Navigation.PushAsync(new DetailsPage()
        {
            BindingContext = contacto
        });
    }

    protected async override void OnAppearing()
    {
        //Write the code of your page here

        base.OnAppearing();
        var listaContacto = await _servicioApi.ListarContactos();
        var contactos = new ObservableCollection<Contacto>(listaContacto);
        Console.WriteLine("###################consulta");
        listaContactos.ItemsSource = contactos;

    }

    private async void onClickNuevoContacto(object sender, EventArgs e)
	{
        //var page = Navigation.NavigationStack.LastOrDefault();
        await Navigation.PushAsync(new NewContactPage());
        //Navigation.RemovePage(page);

    }

}