﻿#pragma checksum "..\..\..\GestionCAT.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2FF9F080B02B40A0EE312DF9F8636C00AD90D665"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Projet3;
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


namespace Projet3 {
    
    
    /// <summary>
    /// GestionCAT
    /// </summary>
    public partial class GestionCAT : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\GestionCAT.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_ajouter;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\GestionCAT.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_supprimer;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\GestionCAT.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_chercher;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\GestionCAT.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Modifier;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\GestionCAT.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_nom;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\GestionCAT.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Data_Grid;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\GestionCAT.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Nom;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Projet3;component/gestioncat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GestionCAT.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_ajouter = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\GestionCAT.xaml"
            this.btn_ajouter.Click += new System.Windows.RoutedEventHandler(this.btn_ajouter_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_supprimer = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\GestionCAT.xaml"
            this.btn_supprimer.Click += new System.Windows.RoutedEventHandler(this.btn_supprimer_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_chercher = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\GestionCAT.xaml"
            this.btn_chercher.Click += new System.Windows.RoutedEventHandler(this.btn_chercher_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Modifier = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\GestionCAT.xaml"
            this.btn_Modifier.Click += new System.Windows.RoutedEventHandler(this.btn_Modifier_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txt_nom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Data_Grid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.Nom = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

