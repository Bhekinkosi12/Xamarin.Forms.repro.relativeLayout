using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReproRelativeLayout
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var relativeLayout = new RelativeLayout { HorizontalOptions = LayoutOptions.FillAndExpand };
            
            Content = relativeLayout;
            
            var button = new Button { Text = "Hello GitHub - Click me" };
            
            button.Clicked += (sender, e) => relativeLayout.Children.Clear();
            
            relativeLayout.Children.Add(button, widthConstraint: Constraint.RelativeToParent(r => r.Width));
            
            for (var i = 0; i < 20; i++)
            {
                relativeLayout.Children.Add(new Button() { Text = "I do nothing" },
                    yConstraint: Constraint.RelativeToView(relativeLayout.Children.Last(), (r, v) => v.Y + v.Height));
            }
        }
    }
}
