﻿#pragma checksum "..\..\..\Views\CadastroCursos.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B78A9A1F6925B9A3FBD66E36FD1733195BF41B66"
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
    /// CadastroCursos
    /// </summary>
    public partial class CadastroCursos : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Views\CadastroCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVoltar;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Views\CadastroCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCurso;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\CadastroCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboPeriodo;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\CadastroCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboModalidadeCurso;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Views\CadastroCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/Escola;component/views/cadastrocursos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\CadastroCursos.xaml"
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
            
            #line 14 "..\..\..\Views\CadastroCursos.xaml"
            ((Escola.Views.CadastroCursos)(target)).Initialized += new System.EventHandler(this.CadastroCursos_OnInitialized);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnVoltar = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Views\CadastroCursos.xaml"
            this.btnVoltar.Click += new System.Windows.RoutedEventHandler(this.BtnVoltar_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtCurso = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cboPeriodo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cboModalidadeCurso = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\Views\CadastroCursos.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

