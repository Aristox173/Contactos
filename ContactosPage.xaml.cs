using HolaMundo.Models;
using HolaMundo.Utils;
using System.Collections.ObjectModel;

namespace HolaMundo;


public partial class ContactosPage : ContentPage
{
	public ContactosPage()
	{
		InitializeComponent();

		
		//listaContactos.ItemsSource = Util.listContacto;
					
	}

	private async void DetalleItem(object sender, SelectedItemChangedEventArgs e)
	{
		Contacto contacto = (Contacto)e.SelectedItem;
		await Navigation.PushAsync(new DetailsPage()
		{
			BindingContext = contacto
		}) ;
    }

    protected override void OnAppearing()
    {
        //Write the code of your page here
		base.OnAppearing();
        var contactos = new ObservableCollection<Contacto>(Util.listContacto);
		listaContactos.ItemsSource = contactos;
   
    }

    private async void onClickNuevoContacto(object sender, EventArgs e)
	{
        //var page = Navigation.NavigationStack.LastOrDefault();
        await Navigation.PushAsync(new NewContactPage());
        //Navigation.RemovePage(page);

    }

}