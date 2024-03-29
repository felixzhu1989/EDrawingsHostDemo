﻿using eDrawings.Interop.EModelViewControl;
using System.Windows.Controls;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms.Integration;

namespace EDrawingsWpfHost
{
    /// <summary>
    /// eDrawingsHostControl.xaml 的交互逻辑
    /// </summary>
    public partial class EDrawingsHostControl : UserControl
    {
        private EModelViewControl m_Ctrl;
        public EDrawingsHostControl()
        {
            InitializeComponent();
            var host = new WindowsFormsHost();
            var ctrl = new EDrawingsHost();
            ctrl.ControlLoaded += OnControlLoaded;
            host.Child = ctrl;
            this.AddChild(host);
        }
        public string FilePath
        {
            get { return (string)GetValue(FilePathProperty); }
            set { SetValue(FilePathProperty, value); }
        }
        public static readonly DependencyProperty FilePathProperty=
            DependencyProperty.Register(nameof(FilePath),typeof(string),typeof(EDrawingsHostControl),new FrameworkPropertyMetadata(OnFilePathPropertyChanged));

        private static void OnFilePathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as EDrawingsHostControl).OpenFile(e.NewValue as string);
        }

        private void OpenFile(string filePath)
        {
            if (m_Ctrl == null)
            {
                throw new NullReferenceException("eDrawings control is not loaded");
            }

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                m_Ctrl.CloseActiveDoc("");
            }
            else
            {
                m_Ctrl.OpenDoc(filePath, false, false, false, "");
            }
        }

        
        private void OnControlLoaded(EModelViewControl ctrl)
        {
            m_Ctrl = ctrl;
            m_Ctrl.OnFinishedLoadingDocument += OnFinishedLoadingDocument;
            m_Ctrl.OnFailedLoadingDocument += OnFailedLoadingDocument;
        }

        private void OnFailedLoadingDocument(string fileName, int errorCode, string errorString)
        {
            Trace.WriteLine($"{fileName} failed to loaded: {errorString}");
        }

        private void OnFinishedLoadingDocument(string fileName)
        {
            Trace.WriteLine($"{fileName} loaded");
        }

    }
}
