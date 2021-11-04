using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MyPersonal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManPage : ContentPage
    {
        string path_image = "";
        public ManPage(StaffMan staffMan)
        {
            InitializeComponent();
            lbl_first_name.Text = staffMan.FirstName;
            lbl_last_name.Text = staffMan.LastName;
            lbl_patronymic.Text = staffMan.Patronimyc;
            
            image.Source = staffMan.Image;//"shimpanze.jpg";
            //image.Source = ImageSource.FromStream(() => new MemoryStream(staffMan.ImageByte));
            lbl_adress.Text = staffMan.Adress;
            lbl_datebirth.Text = staffMan.DateOfBirth;
            lbl_index.Text = staffMan.IndexMan.ToString();
            lbl_unit.Text = staffMan.Unit;
            path_image = staffMan.Image;
            lbl_rank.Text = staffMan.Image;
        }
        private void DeleteFriend(object sender, EventArgs e)
        {
            //var man = (StaffMan)BindingContext;
            App.Database.DeleteItem(int.Parse(lbl_index.Text));
            File.Delete(path_image);
            this.Navigation.PopAsync();

            //var friend = (Friend)BindingContext;
            //App.Database.DeleteItem(friend.Id);

        }
        private void EditFriend(object sender, EventArgs e)
        {
            //var man = (StaffMan)BindingContext;
            
            //App.Database.DeleteItem(man.IndexMan);
            

            //var friend = (Friend)BindingContext;
            //App.Database.DeleteItem(friend.Id);
            StaffMan man = new StaffMan();
            man.IndexMan = int.Parse(lbl_index.Text);
            man.FirstName = lbl_first_name.Text;
            man.LastName = lbl_last_name.Text;
            man.Patronimyc = lbl_patronymic.Text;
            man.DateOfBirth = lbl_datebirth.Text;
            man.Adress = lbl_adress.Text;
            man.Unit = lbl_unit.Text;
            man.Image = path_image;

            App.Database.SaveItem(man);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            btn_changephoto.IsVisible = true;
            btn_edit_2.IsVisible = false;
            btn_edit.IsEnabled = true;
            lbl_first_name.IsEnabled = true;
            lbl_last_name.IsEnabled = true;
            lbl_patronymic.IsEnabled = true;
            lbl_adress.IsEnabled = true;
            lbl_datebirth.IsEnabled = true;
            lbl_unit.IsEnabled = true;
        }

        private async void btn_changephoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync();
                // загружаем в ImageView
                image.Source = ImageSource.FromFile(photo.FullPath);
                string path_image_old = path_image;
                path_image = photo.FullPath;
                // / storage / emulated / 0 / Android / data /{ package name}/ files / Pictures / Test/***.jpg
                
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string filename = lbl_first_name.Text.ToLower() + "_img.jpg";
                File.Copy(path_image, Path.Combine(folderPath, filename), true);
                path_image = Path.Combine(folderPath, filename);


                //File.Delete(path_image_old);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
    }
}