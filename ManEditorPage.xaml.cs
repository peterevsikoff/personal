using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Drawing;
//using Android.Graphics;
//using System.Drawing.Drawing2D;

namespace MyPersonal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManEditorPage : ContentPage
    {
        string image_path;
        public ManEditorPage()
        {
            InitializeComponent();
        }
        private void SaveFriend(object sender, EventArgs e)
        {
            var man = (StaffMan)BindingContext;
            if (!String.IsNullOrEmpty(man.FirstName))
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string filename = man.FirstName.ToLower() + "_img.jpg";
                File.Copy(image_path, Path.Combine(folderPath, filename), true);
                man.Image = Path.Combine(folderPath, filename);
                //Image fromFile = Image.FromFile(image_path);
                //Bitmap newImage = new Bitmap(fromFile.Width, fromFile.Height);
                //using (Graphics gr = Graphics.FromImage(newImage))
                //{
                //    gr.SmoothingMode = SmoothingMode.HighQuality;
                //    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                //    gr.DrawImage(fromFile, new Rectangle(0, 0, 50, 50)); //fromFile.Width / 2, fromFile.Height / 2));
                //}
                //newImage.Save(Path.Combine(folderPath, filename);


                //File.Copy(image_path, Path.Combine(folderPath, filename), true);
                //man.Image = Path.Combine(folderPath, filename);
                App.Database.SaveItem(man);
                //StreamImageSource streamImageSource = (StreamImageSource)img.Source;
                //System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
                //Task<Stream> task = streamImageSource.Stream(cancellationToken);
                //Stream stream = task.Result;




                //man.ImageByte = GetImageStreamAsBytes(stream);

                //man.ImageByte = Download(image_path)//ReadFully(img.Source);

                //string folderPath = System.Environment.CurrentDirectory + "/Resources/drawable";//Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);




                //File.WriteAllText(Path.Combine(folderPath, filename), textEditor.Text);
                //File.WriteAllBytes(Path.Combine(folderPath, filename), img.Source);
                //img.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                //Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
                //panel1.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                //bitmap.Save(saveFileDialog1.FileName);
            }
            this.Navigation.PopAsync();
        }
        public async Task<byte[]> Download(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                byte[] fileArray = await client.GetByteArrayAsync(url);
                return fileArray;
            }

        }
        //private static byte[] GetBytesFromImage(string imagePath)
        //{
        //    var imgFile = new File(imagePath);
        //    var stream = new FileInputStream(imgFile);
        //    var bytes = new byte[imgFile.Length()];
        //    stream.Read(bytes);
        //    return bytes;
        //}
        //public async Task<byte[]> GetBytesFromImage(string filePath)
        //{
        //    ConvertImageToBW(filePath);

        //    // Create another bitmap that will hold the results of the filter.
        //    Bitmap thresholdedBitmap = Bitmap.CreateBitmap(BitmapFactory.DecodeFile(filePath));

        //    thresholdedBitmap = BitmapFactory.DecodeFile(thresholdedImagePath);

        //    byte[] bitmapData;
        //    using (var stream = new MemoryStream())
        //    {
        //        thresholdedBitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
        //        bitmapData = stream.ToArray();
        //    }

        //    return bitmapData;
        //}
        public byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }

        }
        private void DeleteFriend(object sender, EventArgs e)
        {
            var man = (StaffMan)BindingContext;
            App.Database.DeleteItem(man.IndexMan);
            this.Navigation.PopAsync();

            //var friend = (Friend)BindingContext;
            //App.Database.DeleteItem(friend.Id);
            
        }
        private void EditFriend(object sender, EventArgs e)
        {
            var man = (StaffMan)BindingContext;
            App.Database.SaveItem(man);
            //App.Database.DeleteItem(man.IndexMan);
            this.Navigation.PopAsync();

            //var friend = (Friend)BindingContext;
            //App.Database.DeleteItem(friend.Id);

        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void btn_photo_Clicked(object sender, EventArgs e)
        {
            try
            {
                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync();
                // загружаем в ImageView
                img.Source = ImageSource.FromFile(photo.FullPath);
                image_path = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
    }
}