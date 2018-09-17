using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Exc1.Entity;
using Exc1.Model;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Exc1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<User> users;
        public  ObservableCollection<User> Users
        { get => UserModel.GetUser(); set => UserModel.SetUser(value); }

        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Name = this.Name.Text;
            user.Email = this.Email.Text;
            user.Phone = this.Phone.Text;
            user.Avatar = this.Avatar.Text;
            user.Address = this.Address.Text;
            UserModel.AddUser(user);

        }
      
    }
}
