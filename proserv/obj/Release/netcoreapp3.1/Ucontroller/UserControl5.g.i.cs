﻿#pragma checksum "..\..\..\..\Ucontroller\UserControl5.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D5C5FE3C5B135A47960AF90C917DD23647AF15A6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using proserv.Ucontroller;


namespace proserv.Ucontroller {
    
    
    /// <summary>
    /// UserControl5
    /// </summary>
    public partial class UserControl5 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Ucontroller\UserControl5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image barkodgörüntüle;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Ucontroller\UserControl5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label statusLabel1;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Ucontroller\UserControl5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboFormat;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Ucontroller\UserControl5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEncode;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Ucontroller\UserControl5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtDecode;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Ucontroller\UserControl5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox vertical_txt;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Ucontroller\UserControl5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox horizontal_txt;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Ucontroller\UserControl5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMargin;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Ucontroller\UserControl5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtvari1;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\Ucontroller\UserControl5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtvari2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/proserv;component/ucontroller/usercontrol5.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Ucontroller\UserControl5.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.barkodgörüntüle = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.statusLabel1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            
            #line 26 "..\..\..\..\Ucontroller\UserControl5.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDecode_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 27 "..\..\..\..\Ucontroller\UserControl5.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnEncode_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 28 "..\..\..\..\Ucontroller\UserControl5.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnPrint_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cboFormat = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.txtEncode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TxtDecode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.vertical_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.horizontal_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.txtMargin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.txtvari1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.txtvari2 = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

