   M S B A M L   `   `   `  ���� L  HVoterFileAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:VoterFileAnalyzerVoterFileAnalyzer  "    VoterFileAnalyzer.ImportPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:VoterFileAnalyzer       N� Title$&   Voter File Analyzer - ImportPage��.��� 
�������$��
0,0,0,-182q� � RowDefinitions �� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $��* ��� $	��200 �.+��� .+��� $
��20px(�$��Select Files to Import:���� -   $��lblReportErrors��
���  ���� $��Membership File��$
��Bold"�$��0,10,0,0q��� -   $��lblMemberFile��$����Select an excel spreadsheet (.xlsx) with your organization's membership list. It should start with an ID column and also include columns named FirstName, LastName, HomeCity, HomeCounty, HomeEmail��$
��Wrap=��� -   $��btnSelectMembershipFile��$��Select File��$��30��$��80��$
��Left=��� -   $��lblMembershipFilePath���� $��Voter Extract��$
��Bold"�$��0,10,0,0q��� -   $��lblVoterExtract��$X��RSelect the folder on your computer with the Florida Voter File Voter Extract files��$
��Wrap=��� -    ��Name$ btnSelectVoterExtract��$��Select Folder��$��30��$��80��$
��Left=��� -    ��Name$ lblVoterExtractPath���� $��Voter History��$
��Bold"�$��0,10,0,0q��� -   $��lblVoterHistory��$X��RSelect the folder on your computer with the Florida Voter File Voter History files��$
��Wrap=��� -	   $ btnSelectVoterHistory��$��Select Folder��$��30��$��80��$
��Left=��� -
   $ lblVoterHistoryPath���� -   $��btnImportFiles��$��4��$	��150��$��60��$��Import Files���� -   $��tbStatus��$��1��$��0��$��Status��