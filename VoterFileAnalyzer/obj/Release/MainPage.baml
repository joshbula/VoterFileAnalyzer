   M S B A M L   `   `   `  ���� L  HVoterFileAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:VoterFileAnalyzerVoterFileAnalyzer       VoterFileAnalyzer.MainPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:VoterFileAnalyzer       N� Title$$  Voter File Analyzer - MainPage�� N� 
Background
 �����.��� $��5q� � RowDefinitions �� $
��Auto ���  � ColumnDefinitions �� $��* ��� $��* �.+��� $!��Florida Voter File Analyzer��$��18(�$��2��$��5, 5, 5, 20q��� $��1��.+��� -   $��Import��$��Import Data��$	��150��$��30��$��0,0,0,10q�$
��Left=��� -   $��Export��$��Export to Excel��$	��150��$��30��$��0,0,0,10q�$
��Left=��� -   $��
AllMembers��$��All Members��$	��150��$��30��$��0,0,0,10q�$
��Left=��� -   $��AllByCounty��$��All By County��$	��150��$��30��$��0,0,0,10q�$
��Left=��� -   $��CountySummary��$��County Summary��$	��150��$��30��$��0,0,0,10q�$
��Left=��� -   $��MembersByParty��$��Members by Party��$	��150��$��30��$��0,0,0,10q�$
��Left=��� $��1��$��1��.+��  �� $��* ��� $��* �.+��� $��0��.+��� -   $��MemberCountTextBlock���� $��1��.+��� $ ��Search specific elections:��$
��Bold"�$��12(��� -    ��Name$ cbElectionDate�� �� DisplayMemberPath$ Description�� �� SelectedValuePath$ ElectionDate�� � ToolTip$ Filter by election:��$��0, 10, 20, 20q�$	��150��$
��Left=��� -	   $��ElectionCountTextBlock��$��0, 10, 0, 20q��� -
   $��ElectionCountySummary��$%��County Summary of This Election��$	��200��$
��Left=�