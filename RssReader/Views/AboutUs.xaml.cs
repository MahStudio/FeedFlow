using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RssReader.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutUs : Page
    {
        private DataTransferManager dataTransferManager;
        public AboutUs()
        {
            this.InitializeComponent();
            info.Text ="V " + GetAppVersion();
            var culture = new CultureInfo("en-us");
            ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // register this page as share source
            this.dataTransferManager = DataTransferManager.GetForCurrentView();
            this.dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.DataRequested);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // unregister as share source
            this.dataTransferManager.DataRequested -= new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.DataRequested);
        }


        private void DataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            Uri dataPackageUri = new Uri("https://www.microsoft.com/store/apps/9NBLGGH4TM7Z");
            DataPackage requestData = e.Request.Data;
            requestData.Properties.Title = "Feed Flow";
            requestData.SetWebLink(dataPackageUri);
            requestData.Properties.Description = "The best RSS reader app that ou can find in Windows Store !";
        }

        
        public static string GetAppVersion()
        {

            Package package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;

            return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);

        }

       

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("mailto:mohsens22@outlook.com?subject=FeedFlow_U2_Feedback"));
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("mailto:mohsens22@outlook.com?subject=FeedFlow_U2_Translate"));
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("ms-windows-store://review/?ProductId=9NBLGGH4TM7Z");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
        }
    }
}
