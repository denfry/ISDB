﻿#pragma checksum "..\..\..\EditBookWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6262C2DA59F7BB88869DEB6F74E83FB112C4327A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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


namespace ISDBlab3 {
    
    
    /// <summary>
    /// EditBookWindow
    /// </summary>
    public partial class EditBookWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\EditBookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edNdoc;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\EditBookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker edDat;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\EditBookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edPostKod;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\EditBookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPost;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\EditBookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edSyrie;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\EditBookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edKol;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\EditBookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edCena;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\EditBookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bOk;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\EditBookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ISDBlab3;component/editbookwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditBookWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.edNdoc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.edDat = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.edPostKod = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cbPost = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\..\EditBookWindow.xaml"
            this.cbPost.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbPost_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.edSyrie = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.edKol = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.edCena = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.bOk = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\EditBookWindow.xaml"
            this.bOk.Click += new System.Windows.RoutedEventHandler(this.bOk_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.bCancel = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\EditBookWindow.xaml"
            this.bCancel.Click += new System.Windows.RoutedEventHandler(this.bCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

