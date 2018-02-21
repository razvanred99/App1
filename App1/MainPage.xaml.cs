using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public async void buttonClickAsync(object sender,RoutedEventArgs e)
        {
            var text = txboxName.Text.Trim();

            if (text == "")
            {
                var dialog = new MessageDialog("You have to write something in the TextBox", "Error");
                dialog.Options = MessageDialogOptions.None;
                dialog.Commands.Add(new UICommand { Label="OK", Id=45});
                dialog.Commands.Add(new UICommand("Cancel",cmd=>
                {
                    Debug.WriteLine("Operation aborted");
                }));

                var command = await dialog.ShowAsync();
                try
                {
                    if (((int)command.Id) == 45)
                    {
                        Debug.WriteLine("Hello");
                    }
                }catch(NullReferenceException)
                {
                    Debug.Write("Cancel button pressed");
                }

            }
            else
            {
                txbWrite.Text = "Hello "+text;
            }
      
        }
    }
}
