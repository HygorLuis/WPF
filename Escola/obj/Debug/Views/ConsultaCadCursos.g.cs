﻿#pragma checksum "..\..\..\Views\ConsultaCadCursos.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6DB523BA8D24F8F2B8622DF6963D5C1C9D1F048C"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using Escola.Views;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.IconPacks;
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


namespace Escola.Views {
    
    
    /// <summary>
    /// ConsultaCadCursos
    /// </summary>
    public partial class ConsultaCadCursos : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Views\ConsultaCadCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVoltar;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Views\ConsultaCadCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboCurso;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\ConsultaCadCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboPeriodo;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\ConsultaCadCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboModalidadeCurso;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Views\ConsultaCadCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
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
            System.Uri resourceLocater = new System.Uri("/Escola;component/views/consultacadcursos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ConsultaCadCursos.xaml"
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
            
            #line 14 "..\..\..\Views\ConsultaCadCursos.xaml"
            ((Escola.Views.ConsultaCadCursos)(target)).Initialized += new System.EventHandler(this.ConsultaCadCursos_OnInitialized);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnVoltar = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Views\ConsultaCadCursos.xaml"
            this.btnVoltar.Click += new System.Windows.RoutedEventHandler(this.BtnVoltar_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cboCurso = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\..\Views\ConsultaCadCursos.xaml"
            this.cboCurso.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CboCurso_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cboPeriodo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 39 "..\..\..\Views\ConsultaCadCursos.xaml"
            this.cboPeriodo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CboPeriodo_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cboModalidadeCurso = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\Views\ConsultaCadCursos.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

