﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nov2Epub
{
    /// <summary>
    /// EpubCheckResultDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class EpubCheckResultDialog : Window
    {
        public EpubCheckResultDialog()
        {
            InitializeComponent();
        }

        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
