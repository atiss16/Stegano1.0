﻿#pragma checksum "..\..\EncryptWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F0D585ABC1F63E09317FD99550FA7A47"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Stegano1._0;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Stegano1._0 {
    
    
    /// <summary>
    /// EncryptWindow
    /// </summary>
    public partial class EncryptWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReturnFromEncrypt;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCloseEncrypt;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTextForEncode;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCountOfSymbols;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAllowableAmount;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBrowseText;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCrypt;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbltest1;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbltest2;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgEncode;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBrowseImg;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\EncryptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSaveImg;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Stegano1.0;component/encryptwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EncryptWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\EncryptWindow.xaml"
            ((Stegano1._0.EncryptWindow)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.MouseLeftButtonDown_EncryptWindowMove);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnReturnFromEncrypt = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\EncryptWindow.xaml"
            this.btnReturnFromEncrypt.Click += new System.Windows.RoutedEventHandler(this.BtnReturnFromEncrypt_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnCloseEncrypt = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\EncryptWindow.xaml"
            this.btnCloseEncrypt.Click += new System.Windows.RoutedEventHandler(this.BtnCloseEncrypt_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbTextForEncode = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\EncryptWindow.xaml"
            this.tbTextForEncode.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TbTextForEncode_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblCountOfSymbols = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblAllowableAmount = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btnBrowseText = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\EncryptWindow.xaml"
            this.btnBrowseText.Click += new System.Windows.RoutedEventHandler(this.BtnBrowseText_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCrypt = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\EncryptWindow.xaml"
            this.btnCrypt.Click += new System.Windows.RoutedEventHandler(this.BtnCrypt_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lbltest1 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lbltest2 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.imgEncode = ((System.Windows.Controls.Image)(target));
            return;
            case 12:
            this.btnBrowseImg = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\EncryptWindow.xaml"
            this.btnBrowseImg.Click += new System.Windows.RoutedEventHandler(this.BtnBrowseImg_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnSaveImg = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\EncryptWindow.xaml"
            this.btnSaveImg.Click += new System.Windows.RoutedEventHandler(this.BtnSaveImg_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

