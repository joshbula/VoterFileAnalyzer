   M S B A M L   `   `   `  ����L  HVoterFileAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:VoterFileAnalyzerVoterFileAnalyzer  5      "    VoterFileAnalyzer.ImportPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:VoterFileAnalyzer     5        N� Title$&   Voter File Analyzer - ImportPage��5	      .��5      � 
�������$��
5,5,5,-182q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��200 �6   .+�5   
   �� .+�5      �� $
��20px(�6   $��Select Files to Import:��6(   6I   �� 5      -   5        $��lblReportErrors��5      
���  ��6B   �� 5      $��Membership File��6   $
��Bold"�6/   $��0,10,0,0q�6A   6U   �� 5      -   5        $��lblMemberFile��5      $����Select an excel spreadsheet (.xlsx) with your organization's membership list. It should start with an ID column and also include columns named FirstName, LastName, HomeCity, HomeCounty, HomeEmail��6-   $
��Wrap=�6�   6  �� 5      -   5        $��btnSelectMembershipFile��5   +   $��Select File��6   $��30��6p   $��80��6|   $
��Left=�6�   �� 5      -   5        $��lblMembershipFilePath��5      67   �� 5!      $��Voter Extract��6   $
��Bold"�6-   $��0,10,0,0q�6?   6S   �� 5"      -   5        $��lblVoterExtract��5"      $X��RSelect the folder on your computer with the Florida Voter File Voter Extract files��6/   $
��Wrap=�6�   �� 5$      -   5         ��Name$ btnSelectVoterExtract��5$   -   $��Select Folder��6   $��30��6p   $��80��6|   $
��Left=�6�   �� 5%      -   5         ��Name$ lblVoterExtractPath��5%      �� 5'      $��Voter History��6   $
��Bold"�6-   $��0,10,0,0q�6?   6S   �� 5(      -   5        $��lblVoterHistory��5(      $X��RSelect the folder on your computer with the Florida Voter File Voter History files��6/   $
��Wrap=�6�   �� 5*      -	   5        $ btnSelectVoterHistory��5*   -   $��Select Folder��6   $��30��6p   $��80��6|   $
��Left=�6�   �� 5+      -
   5        $ lblVoterHistoryPath��5+      �� 5-      -   5        $��btnImportFiles��5-   :   $��4��6   $	��150��6"   $��60��6.   $��Import Files��6m   5/      �� 51   
   -   5        $��tbStatus��51      $��1��6"   $��0��62   $��Status��6@   6P   52      53      