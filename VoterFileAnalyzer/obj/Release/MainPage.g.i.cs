﻿#pragma checksum "..\..\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2CD73A24A5CC5055B1EE56A5A6E35883"
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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using VoterFileAnalyzer;


namespace VoterFileAnalyzer {
    
    
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Import;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Export;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AllMembers;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AllByCounty;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CountySummary;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MembersByParty;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MemberCountTextBlock;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbElectionDate;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ElectionCountTextBlock;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ElectionCountySummary;
        
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
            System.Uri resourceLocater = new System.Uri("/VoterFileAnalyzer;component/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainPage.xaml"
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
            this.Import = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\MainPage.xaml"
            this.Import.Click += new System.Windows.RoutedEventHandler(this.Import_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Export = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\MainPage.xaml"
            this.Export.Click += new System.Windows.RoutedEventHandler(this.Export_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AllMembers = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\MainPage.xaml"
            this.AllMembers.Click += new System.Windows.RoutedEventHandler(this.AllMembers_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AllByCounty = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\MainPage.xaml"
            this.AllByCounty.Click += new System.Windows.RoutedEventHandler(this.AllByCounty_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CountySummary = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\MainPage.xaml"
            this.CountySummary.Click += new System.Windows.RoutedEventHandler(this.CountySummary_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MembersByParty = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\MainPage.xaml"
            this.MembersByParty.Click += new System.Windows.RoutedEventHandler(this.MembersByParty_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MemberCountTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.cbElectionDate = ((System.Windows.Controls.ComboBox)(target));
            
            #line 47 "..\..\MainPage.xaml"
            this.cbElectionDate.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbElectionDate_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ElectionCountTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.ElectionCountySummary = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\MainPage.xaml"
            this.ElectionCountySummary.Click += new System.Windows.RoutedEventHandler(this.ElectionCountySummary_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

