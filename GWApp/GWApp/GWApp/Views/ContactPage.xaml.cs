using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



using System.ComponentModel;
using Xamarin.Essentials;

namespace GWApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
            BindingContext = new ContactViewModel();
        }
    }
    public class ContactViewModel
    {
        public Command SmsCommand { get; }
        public Command EmailCommand { get; }
        public Command PhoneCommand { get; }
        public Command NavigateCommand { get; }

        public Contact Contact { get; }

        public ContactViewModel(Contact contact)
        {
            Contact = contact;
        }

        public ContactViewModel()
        {
            Contact = new Contact
            {
                Name = "Green World",
                Address = "167 Madras St",
                City = "Christchurch",
                Country = "New Zealand",
                ZipCode = "8021",
                Email = "contact@greenworld.co.nz",
                PhoneNumber = "03-963 0033"
            };

            SmsCommand = new Command(async () => await ExecuteSmsCommand());
            EmailCommand = new Command(async () => await ExecuteEmailCommand());
            PhoneCommand = new Command(ExecutePhoneCommand);
            NavigateCommand = new Command(async () => await ExecuteNavigateCommand());
        }

        async Task ExecuteSmsCommand()
        {
            try
            {
                await Sms.ComposeAsync(new SmsMessage(string.Empty, Contact.PhoneNumber));
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        async Task ExecuteEmailCommand()
        {
            try
            {
                await Email.ComposeAsync(string.Empty, string.Empty, Contact.Email);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        void ExecutePhoneCommand()
        {
            try
            {
                PhoneDialer.Open(Contact.PhoneNumber);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        async Task ExecuteNavigateCommand()
        {
            try
            {
                await Map.OpenAsync(new Placemark
                {
                    Thoroughfare = Contact.Address,
                    Locality = Contact.City,
                    AdminArea = Contact.Country,
                    PostalCode = Contact.ZipCode
                });
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        void ProcessException(Exception ex)
        {
            if (ex != null)
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}