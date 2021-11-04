using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyPersonal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            carusel_unit.ItemsSource = App.Database.GetItems();
            List<CarouselWithUnit> carouselWithUnits = new List<CarouselWithUnit>();
            
            

            foreach (StaffMan s in App.Database.GetItems())
            {
                string chelovek = " человек";
                string cheloveka = " человека";
                string chel = "";
                int kolvo = (from t in App.Database.GetItems()
                             where t.Unit == s.Unit.ToString()
                             select t).Count();
                if (kolvo == 2 || kolvo == 3 || kolvo == 4 || kolvo == 22 || kolvo == 23 || kolvo == 24 || kolvo == 32 || kolvo == 33 || kolvo == 34)
                {
                    chel = cheloveka;
                }
                else 
                {
                    chel = chelovek;
                }
                carouselWithUnits.Add(new CarouselWithUnit {Unit = s.Unit, Kolvo = kolvo.ToString() + chel});
            }
            var c = (from x in carouselWithUnits
                     select x).Distinct();
            carusel_unit.ItemsSource = carouselWithUnits.GroupBy(x => x.Unit).Select(y=>y.First());
        }
        private async void lst_people_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //StaffMan item = e.SelectedItem as StaffMan;
            //if (item != null)
            //    await DisplayAlert("Выбран", $"{item.FirstName}", "OK");
            //lbl_unit.Text = e.SelectedItem.ToString();
            StaffMan item = e.SelectedItem as StaffMan;
            if (item != null)
                await Navigation.PushAsync(new ManPage(item));
        }

        private void carusel_unit_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            CarouselWithUnit item = e.CurrentItem as CarouselWithUnit;
            if (item != null)
            {
                //lst_people.ItemsSource = App.Database.GetItems();
                var list = from t in App.Database.GetItems()
                           where t.Unit == item.Unit.ToString()
                           select t;
                lst_people.ItemsSource = list;
            }
        }

        private async void btn_add_Clicked(object sender, EventArgs e)
        {
            //Friend friend = new Friend();
            //FriendPage friendPage = new FriendPage();
            //friendPage.BindingContext = friend;
            //await Navigation.PushAsync(friendPage);

            StaffMan man = new StaffMan();
            ManEditorPage manEditorPage = new ManEditorPage();
            manEditorPage.BindingContext = man;
            await Navigation.PushAsync(manEditorPage);
        }
    }
}
