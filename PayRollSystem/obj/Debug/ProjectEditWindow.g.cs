﻿#pragma checksum "..\..\ProjectEditWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D26981143FD2BB251DA43F64633F2796"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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


namespace PayRollSystem {
    
    
    /// <summary>
    /// ProjectEditWindow
    /// </summary>
    public partial class ProjectEditWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar tbEdit;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn colCheckBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn colEmpName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridComboBoxColumn colRankId;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridComboBoxColumn colDepartmentId;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgtcAfterTaxWage;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProjectName;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCostinWage;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCostinOther;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCostinTotal;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpStartDate;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDueDate;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\ProjectEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPeriod;
        
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
            System.Uri resourceLocater = new System.Uri("/PayRollSystem;component/projecteditwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProjectEditWindow.xaml"
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
            
            #line 4 "..\..\ProjectEditWindow.xaml"
            ((PayRollSystem.ProjectEditWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbEdit = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 3:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.datagrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.colCheckBox = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 7:
            this.colEmpName = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.colRankId = ((System.Windows.Controls.DataGridComboBoxColumn)(target));
            return;
            case 9:
            this.colDepartmentId = ((System.Windows.Controls.DataGridComboBoxColumn)(target));
            return;
            case 10:
            this.dgtcAfterTaxWage = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 11:
            this.txtProjectName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.txtCostinWage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.txtCostinOther = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.txtCostinTotal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            return;
            case 17:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            return;
            case 18:
            this.dpStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 19:
            this.dpDueDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 20:
            this.txtPeriod = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
