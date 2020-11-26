using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace GWApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabShell : Xamarin.Forms.TabbedPage
    {
        public TabShell()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}