   M S B A M L   `   `   `  ����  PayRollSystem    PayRollSystem.SalarySheet   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  SalarySheet��5   	   $	��380��6   $	��700��6*   .��5      � .+�5   
   � .+�5      ]� .+�5      �� -   5        $��gbEdit��5      $
��Edit��6)   $��50��67   $	��Top=�6C   .��5	      c� $��35��6   .@�5
      �� -   5         ��Name$ btnEditSalary��5
   !   .��5      �� $��/Images/icons/edit.ico��6$   6F   5      �� 5      -   5        $��btnPrint��5   !   .��5      �� $��/Images/icons/print.ico��6$   6G   5      5      5      �� 5      -   5        $��gbGenerateSheet��5      $��	Operation��62   $��65��6E   $	��Top=�6Q   .��5      � .+�5      �� -   5         ��Name$ cmbMonth��5   #   $
��Left=�65   $��	60,12,0,0q�6P   $	��Top=�6c   $	��120��6{   �� 5      $
��Left=�6$   $��	10,16,0,0q�6?   $
��Wrap=�6R   $��Month��6f   $	��Top=�6s   $��2��6�   �� 5      $
��Left=�6$   $��
196,14,0,0q�6?   $
��Wrap=�6S   $
��Year��6g   $	��Top=�6s   �� 5      -   5        $ cmbYear��5   #   $
��Left=�64   $��
234,12,0,0q�6O   $	��Top=�6c   $	��120��6{   �� 5      $
��Left=�6$   $��
371,16,0,0q�6?   $
��Wrap=�6S   $��
Department��6g   $	��Top=�6y   �� 5      -   5        $ cmbDepartment��5   #   $
��Left=�6:   $��
440,14,0,0q�6U   $	��Top=�6i   $	��120��6�    �� DisplayMemberPath$ DepartmentName��6�    �� SelectedValuePath$ DepartmentID��6�   �� 5      -	   5        $��btnGenerateSheet��5   !   $��GenerateSheet��69   $
��Left=�6Q   $��
576,12,0,0q�6l   $	��Top=�6�   $��94��6�   6�   5      5      &   System.Windows.Controls.DataGrid  5      -
   5        $��datagrid��5         AutoGenerateColumns .     Columns 5      4  .System.Windows.Controls.DataGridComboBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 61      
IsReadOnly . -   5        colEmployee��	   Header$	 Employee��5   f   
   DisplayMemberPath$
 RealName��6x      SelectedValuePath$ ID��6�      SelectedValueBinding 6�   �� *
EmployeeID+6�   0  *System.Windows.Controls.DataGridTextColumn  5       $	 100 6-   $	 
BaseSalary��69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6M   �� *
BaseSalary+ �� UpdateSourceTrigger$ PropertyChanged=�6�     5!      $	 100 6-   $	 Bonus��69    6H   �� *Bonus+$ PropertyChanged=�6�     5"      $	 100 6-   $	 	Deduction��69    6L   �� *	Deduction+$ PropertyChanged=�6�     5#      $	 100 6-    . $	 AfterTaxWage��6K    6a   �� *AfterTaxWage+$ PropertyChanged=�6�   5+      5,      5.      50      51      