using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using ZXing;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace proserv.Ucontroller
{
    /// <summary>
    /// Interaction logic for UserControl5.xaml
    /// </summary>
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {
            InitializeComponent();
            Window_Loaded();
            txtvari1.Text = "2";
            txtvari2.Text = "2";
            horizontal_txt.Text = "100";
            vertical_txt.Text = "100";
           
        }
        private void Window_Loaded()
        {
            

            var formatList = new List<KeyValuePair<string, BarcodeFormat>>
            {
                new KeyValuePair<string, BarcodeFormat>("CODE_128", BarcodeFormat.CODE_128),
                new KeyValuePair<string, BarcodeFormat>("CODE_39", BarcodeFormat.CODE_39),
                new KeyValuePair<string, BarcodeFormat>("CODE_93", BarcodeFormat.CODE_93),
                new KeyValuePair<string, BarcodeFormat>("QR_CODE", BarcodeFormat.QR_CODE)
            };

            cboFormat.DisplayMemberPath = "Key";
            cboFormat.SelectedValuePath = "Value";
            cboFormat.ItemsSource = formatList;
            cboFormat.SelectedIndex = 0;
        }
        private void btnEncode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtEncode.Text)) return;

                // Barkodı oluştur
                Bitmap barcodeBitmap = GenerateBarcode();

                // Barkodu görüntüle
                DisplayBarcode(barcodeBitmap);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private Bitmap GenerateBarcode()
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = (BarcodeFormat)cboFormat.SelectedValue
            };

            if (!String.IsNullOrWhiteSpace(txtMargin.Text))
            {
                if (writer.Options == null)
                    writer.Options = new ZXing.Common.EncodingOptions();

                writer.Options.Margin = int.Parse(txtMargin.Text.Trim());
            }

            return writer.Write(txtEncode.Text);
        }

        private void DisplayBarcode(Bitmap barcodeBitmap)
        {
            barkodgörüntüle.Source = BitmapToImageSource(barcodeBitmap);
            statusLabel1.Content = "Barkod görüntü boyutu: " + barkodgörüntüle.Source.Width + "x" + barkodgörüntüle.Source.Height;
        }

        private void PrintBarcode(Bitmap barcodeBitmap)
        {
            int verticalMargin = string.IsNullOrWhiteSpace(vertical_txt.Text) ? 100 : int.Parse(vertical_txt.Text);
            int horizontalMargin = string.IsNullOrWhiteSpace(horizontal_txt.Text) ? 100 : int.Parse(horizontal_txt.Text);
            int vari1 = string.IsNullOrWhiteSpace(txtvari1.Text) ? 2 : int.Parse(txtvari1.Text);
            int vari2 = string.IsNullOrWhiteSpace(txtvari2.Text) ? 2 : int.Parse(txtvari2.Text);

            // Barkodu etikete yerleştirmek için ZPL kodunu oluşturun
            string zplCode = "^XA^FO" + horizontalMargin + "," + verticalMargin + "^BY" + vari1 + "," + vari2+"^B" + cboFormat.SelectedValue.ToString() + ",150,Y,N^FD" + txtEncode.Text + "^FS^XZ";

            // Yazıcı adını ayarlayın (Zebra yazıcının adı veya paylaşılan ağırlık yazıcının adı olmalıdır)
            string printerName = "ZDesigner S4M-203dpi ZPL"; // Yazıcınızın adını buraya yazın

            try
            {
                // ZPL kodunu yazıcıya gönderin
                RawPrinterHelper.SendStringToPrinter(printerName, zplCode);

                MessageBox.Show("Yazdırma başarılı!", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yazdırma hatası: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnDecode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (barkodgörüntüle.Source == null) return;

                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode((Bitmap)ImageSourceToBitmap(barkodgörüntüle.Source));
                if (result != null)
                    TxtDecode.Text = result.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Bitmap'i ImageSource'a dönüştüren yardımcı bir yöntem.
        private ImageSource BitmapToImageSource(Bitmap bitmap)
        {
            var bitmapImage = new BitmapImage();
            var ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Position = 0;
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = ms;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            return bitmapImage;
        }

        // ImageSource'ı Bitmap'e dönüştüren yardımcı bir yöntem.
        private Bitmap ImageSourceToBitmap(ImageSource imageSource)
        {
            var bitmapSource = (BitmapSource)imageSource;
            var width = bitmapSource.PixelWidth;
            var height = bitmapSource.PixelHeight;
            var stride = width * ((bitmapSource.Format.BitsPerPixel + 7) / 8);
            var pixels = new byte[height * stride];
            bitmapSource.CopyPixels(pixels, stride, 0);
            var bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            var data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bitmap.PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
            bitmap.UnlockBits(data);
            return bitmap;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtEncode.Text)) return;

                // Barkodı oluştur
                Bitmap barcodeBitmap = GenerateBarcode();

                // Barkodu yazdır
                PrintBarcode(barcodeBitmap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
