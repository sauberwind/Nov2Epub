using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace Nov2Epub
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            javaBox.Text = Properties.Settings.Default.JavaPath;
            epubCheckBox.Text = Properties.Settings.Default.EpubCheckPath;
        }

        private void GenerateEPUB(object sender, RoutedEventArgs e)
        {

            EpubArchiver.ArchiveEpub(@"C:\temp\OOPforDogs", @"C:\temp\OOP.epub");

            return;


            if (IsValidInputs() == true)
            {
                //設定ファイルを上書きする
                Properties.Settings.Default.JavaPath = javaBox.Text;
                Properties.Settings.Default.EpubCheckPath = epubCheckBox.Text;
                Properties.Settings.Default.Save();

                var epub = @"C:\Users\saube_000\Desktop\OOPforDogs.epub";
                var epubCheck = new EpubCheckWrapper(javaBox.Text,epubCheckBox.Text,epub);
                epubCheck.CheckEpub();



            }
        }
        //ファイルがドラッグされてきたらうける
        private void OnPreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) != null)
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        //ファイルがドロップされたらテキストボックスに表示する
        private void OnDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null)
            {
                var textBox = sender as TextBox;
                textBox.Text = files[0];
            }
        }

        private void OnWindowClosed(object sender, System.EventArgs e)
        {
            if (true)
            {
                //設定を保存する
                Properties.Settings.Default.Save();
            }
        }
        private bool IsValidInputs()
        {
            bool ret = true;

            //小説ファイルが存在する
            if (File.Exists(novel.Text) != true)
            {
                ret = false;
            }

            //EpubChekの設定を確認
            if (IsValidEpubCheckInputs() != true)
            {
                ret = false;
            }


            return ret;
        }

        //EpubCheckの設定を確認する
        bool IsValidEpubCheckInputs()
        {
            bool ret = true;

            //javaファイルが存在してするか
            if (File.Exists(javaBox.Text) != true)
            {
                ret = false;
            }
            else
            {   //java.exeか？
                var exeName = Path.GetFileName(javaBox.Text);
                if (string.Compare(exeName, "java.exe", true) != 0)
                {
                    ret = false;
                }
            }

            //EpubCheckファイルが存在しているか
            if (File.Exists(epubCheckBox.Text) != true)
            {
                ret = false;
            }
            else
            {
                //jarファイルか?
                var ext = Path.GetExtension(epubCheckBox.Text);
                if (string.Compare(ext, ".jar", true) != 0)
                {
                    ret = false;
                }
            }
            return ret;
        }
    }
}
