   M S B A M L   `   `   `  ����L  HVoterFileAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:VoterFileAnalyzerVoterFileAnalyzer  5           VoterFileAnalyzer.MainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:VoterFileAnalyzer     5        N� Title$$  Voter File Analyzer - MainPage��5       N� 
Background
 �����.��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $!��Florida Voter File Analyzer��6   $��18(�67   $��2��6E   $��5, 5, 5, 20q�6Y   6p   �� 5   
   $��1��6   .+�5      �� -   5        $��Import��5      $��Import Data��6#   $	��150��6N   $��30��6Z   $��0,0,0,10q�6f   $
��Left=�6x   6�   �� 5      -   5        $��Export��5      $��Export to Excel��6#   $	��150��6R   $��30��6^   $��0,0,0,10q�6j   $
��Left=�6|   6�   �� 5      -   5        $��
AllMembers��5      $��All Members��6'   $	��150��6W   $��30��6c   $��0,0,0,10q�6o   $
��Left=�6�   6�   �� 5      -   5        $��AllByCounty��5      $��All By County��6(   $	��150��6Z   $��30��6f   $��0,0,0,10q�6r   $
��Left=�6�   6�   �� 5      -   5        $��CountySummary��5      $��County Summary��6*   $	��150��6`   $��30��6l   $��0,0,0,10q�6x   $
��Left=�6�   6�   �� 5      -   5        $��MembersByParty��5      $��Members by Party��6+   $	��150��6d   $��30��6p   $��0,0,0,10q�6|   $
��Left=�6�   6�   �� 5       -   5        $��BackupDatabase��5       $��Backup Database��6+   $	��150��6b   $��20��6n   $��	0,10,0,10q�6z   $
��Left=�6�   6�   �� 5!      -   5        $��RestoreDatabase��5!      $��Restore Database��6,   $	��150��6f   $��20��6r   $��0,0,0,10q�6~   $
��Left=�6�   6�   5"      �� 5$   
   $��1��6   $��1��6%   .+�5%      �  5&      �� 5'      $��* �6$   �� 5(      $��* �6$   .+�5+      �� $��0��6   .+�5,      �� -	   5        $��MemberCountTextBlock��5,       �� 
IsReadOnly .  �� TextWrapping$
 Wrap=�6L   6b   5-      �� 5/      $��1��6   .+�50      �� $ ��Search specific elections:��6    $
��Bold"�6B   $��12(�6T   6d   �� 51      -
   5         ��Name$ cbElectionDate��51       �� DisplayMemberPath$ Description��67    �� SelectedValuePath$ ElectionDate��6W   	 � ToolTip$	 Filter by election:��6x   $��0, 10, 20, 20q�6�   $	��150��6�   $
��Left=�6�   �� 52      -   5        $��ElectionCountTextBlock��52       $��0, 10, 0, 20q�6>   6V   �� 53      -   5        $��ElectionCountySummary��53      $%��County Summary of This Election��6:   $	��200��6�   $
��Left=�6�   6�   54      56      57      �� 59   
   $��2��6   $��2��6!   ;9Josh Bula, Center for Fine Arts Education, www.CFAEFL.org6p   5;      5<      