   M S B A M L   `   `   `  ����  PayRollSystem$    PayRollSystem.ProjectEditAdmin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  ProjectEditWindowForAdmin��5   	   $	��800��6+   $	��600��68   .��5      � .+�5   
   ]� $	��350��6   $��0,10,0,0q�6!   $	��Top=�63   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��datagrid��5         AutoGenerateColumns .  $	��Top=�6C      Columns 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      -   5        colCheckBox��,  &System.Windows.Controls.DataGridColumn   Header$ Choose��5   B      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6e   �� *
IsSelected+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   0  *System.Windows.Controls.DataGridTextColumn  5      $ 
Department��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6`    .  6=   �� *DepartmentName+6�   5      5      � 5   
   -   5        $��gridPrj��5      .+�5      �� $
��Left=�6   $��
22,378,0,0q�63   $
��Wrap=�6G   $��Project Name��6[   $	��Top=�6o   $��20��6�   $��78��6�   �� 5      -   5        	 ��Name$	 txtProjectName��5      $
��Left=�6K   $��23��6f   $��105,377,0,0q�6r   
 �� TextWrapping$

 Wrap=�6�   $	��Top=�6�   $	��441��6�   ��6.   �� *projectName+6�   �� 5      -   5        $	 txtDescription��5      $
��Left=�6K   $	��116��6f   $��105,421,0,0q�6s   $

 Wrap=�6�   $	��Top=�6�   $	��441��6�   ��6.   �� *description+6�   �� 5      $
��Left=�6   $��
22,421,0,0q�63   $
��Wrap=�6G   $��Description��6[   $	��Top=�6n   $��23��6�   $��78��6�   �� 5       $
��Left=�6   $��
22,632,0,0q�63   $
��Wrap=�6G   $��Cost in Wages��6[   $	��Top=�6p   $��23��6�   $��78��6�   �� 5!      -   5        $	 txtCostinWage��5!       �� 
IsReadOnly . $
��Left=�6[   $��23��6v   $��105,632,0,0q�6�   $

 Wrap=�6�   $	��Top=�6�   $	��157��6�   ��6-   �� *
costinwage+6�   �� 5"      $
��Left=�6   $��285,632,0,0q�63   $
��Wrap=�6H   $��Cost in Others��6\   $	��Top=�6r   $��23��6�   $��82��6�   �� 5#      -   5        $	 txtCostinOther��5#      $
��Left=�6K   $��23��6f   $��381,632,0,0q�6r   $

 Wrap=�6�   $	��Top=�6�   $	��165��6�   ��6.   �� *costinother+6�   �� 5$      $
��Left=�6   $��
22,670,0,0q�63   $
��Wrap=�6G   $��Cost in Total��6[   $	��Top=�6p   $��22��6�   $��78��6�   �� 5%      -	   5        $	 txtCostinTotal��5%       . $
��Left=�6V   $��23��6q   $��105,669,0,0q�6}   $

 Wrap=�6�   $	��Top=�6�   $	��157��6�   ��6@   �� *cost+6�   �� 5&      -
   5         ��Name$ btnSave��5&      $
��Save��6&   $
��Left=�65   $��
77,713,0,0q�6P   $	��Top=�6d   $	��132��6|   $��32��6�   6�   �� 5'      -   5        $ 	btnCancel��5'      $��Cancel��6(   $
��Left=�69   $��367,713,0,0q�6T   $	��Top=�6i   $	��134��6�   $��32��6�   6�   �� 5(      $
��Left=�6   $��364,562,0,0q�63   $
��Wrap=�6H   $��
Start Date��6\   $	��Top=�6n   $��20��6�   $��64��6�   (  "System.Windows.Controls.DatePicker  5)      -   5          Name$ dpStartDate��5)      $
��Left=�6Q   $��433,558,0,0q�6l   $	��Top=�6�      SelectedDate 6.   �� *	startDate+6�   �� 5*      $
��Left=�6   $��367,602,0,0q�63   $
��Wrap=�6H   $��Due Date��6\   $	��Top=�6l     5+      -   5        $ 	dpDueDate��5+      $
��Left=�6M   $��433,598,0,0q�6h   $	��Top=�6}    6,   �� *	dueDate+6}   �� 5,      $
��Left=�6   $��
22,569,0,0q�63   $
��Wrap=�6G   $��Period��6[   $	��Top=�6i   �� 5-      -   5        $	 	txtPeriod��5-       . $
��Left=�6;   $��23��6V   $��105,569,0,0q�6b   $

 Wrap=�6w   $	��Top=�6�   $	��120��6�   �� 5.      $
��Left=�6   $��230,572,0,0q�63   $
��Wrap=�6H   $��weeks��6\   $	��Top=�6i   5/      51      53      