   M S B A M L   `   `   `  ����  PayRollSystem%    PayRollSystem.ProjectEditWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  ProjectEditWindow��5   	   $	��800��6#   $	��600��60   .��5      � .+�5   
   ]� $	��350��6   $��0,10,0,0q�6!   $	��Top=�63   .+�5      c� -   5        $��tbEdit��5      $	��Top=�6$   $��50��69   .@�5      �� -   5        $��btnAdd��5       � ToolTip$ Refresh��6'   .��5	      �� $��Images/icons/new.ico��6   6<   5
      �� 5      -   5        $��
btnRefresh��5      $ Refresh��6+   .��5      �� $��Images/icons/clock.ico��6   6>   5      (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
dpStartEmp��5      $��45��6T   $	��Top=�6`      SelectedDate 61   �� *	startDate+6`     5      -   5        $ 	dpQuitEmp��5      $��45��6R   $	��Top=�6^    60   �� *
quitDate+6^   5      &   System.Windows.Controls.DataGrid  5      -   5        $��datagrid��5         AutoGenerateColumns .  $	��Top=�6C   $	��300��6X      Columns 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      -   5        colCheckBox��,  &System.Windows.Controls.DataGridColumn   Header$ Choose��5   n      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *
IsSelected+	 �� Mode$	 TwoWay=�6�   0  *System.Windows.Controls.DataGridTextColumn  5      -	   5        
colEmpName��
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 5   =   $
 Name��6I    .  6i   �� *
RealName+6�   4  .System.Windows.Controls.DataGridComboBoxColumn  5      $
 Rank��6-   $	
 100 6;    .    SelectedValuePath$ RankID��6�      DisplayMemberPath$ RankName��5   -   -
   5        	colRankId��   SelectedValueBinding 5   Y   �� *RankID+5   _     5      $ 
Department��6-   $	
 100 6A   $ DepartmentID��6{   $ DepartmentName��5   )    . -   5        colDepartmentId�� 5   M   �� *DepartmentID+5   y     5      -   5        dgtcAfterTaxWage��$ AfterTaxWage��5   C    . $	
 100 6k    6w   �� *AfterTaxWage+6�     5      -   5        colStartEmp��$ 	startDate��5   \    6>   �� *	startDate+6q     5      -   5        colQuitDate��$ quitDate��5   [    6>   �� *
quitDate+6o   5      5      � 5   
   -   5        $��gridPrj��5      .+�5       �� $
��Left=�6   $��
22,378,0,0q�63   $
��Wrap=�6G   $��Project Name��6[   $	��Top=�6o   $��20��6�   $��78��6�   �� 5!      -   5         ��Name$ txtProjectName��5!       �� 
IsReadOnly . $
��Left=�6]   $��23��6x   $��105,377,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��441��6�   ��6@   �� *projectName+6�   �� 5"      -   5        $ txtDescription��5"       . $
��Left=�6]   $	��116��6x   $��105,421,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��441��6�   ��6@   �� *description+6�   �� 5#      $
��Left=�6   $��
22,421,0,0q�63   $
��Wrap=�6G   $��Description��6[   $	��Top=�6n   $��23��6�   $��78��6�   �� 5$      $
��Left=�6   $��
22,632,0,0q�63   $
��Wrap=�6G   $��Cost in Wages��6[   $	��Top=�6p   $��23��6�   $��78��6�   �� 5%      -   5        $ txtCostinWage��5%       . $
��Left=�6\   $��23��6w   $��105,632,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��157��6�   ��6?   �� *
costinwage+6�   �� 5&      $
��Left=�6   $��285,632,0,0q�63   $
��Wrap=�6H   $��Cost in Others��6\   $	��Top=�6r   $��23��6�   $��82��6�   �� 5'      -   5        $ txtCostinOther��5'      $
��Left=�6K   $��23��6f   $��381,632,0,0q�6r   $
 Wrap=�6�   $	��Top=�6�   $	��165��6�   ��6.   �� *costinother+6�   �� 5(      $
��Left=�6   $��
22,670,0,0q�63   $
��Wrap=�6G   $��Cost in Total��6[   $	��Top=�6p   $��22��6�   $��78��6�   �� 5)      -   5        $ txtCostinTotal��5)       . $
��Left=�6V   $��23��6q   $��105,669,0,0q�6}   $
 Wrap=�6�   $	��Top=�6�   $	��157��6�   ��6@   �� *cost+6�   �� 5*      -   5         ��Name$ btnSave��5*      $
��Save��6&   $
��Left=�65   $��
77,713,0,0q�6P   $	��Top=�6d   $	��132��6|   $��32��6�   6�   �� 5+      -   5        $ 	btnCancel��5+      $��Cancel��6(   $
��Left=�69   $��367,713,0,0q�6T   $	��Top=�6i   $	��134��6�   $��32��6�   6�   �� 5,      $
��Left=�6   $��364,562,0,0q�63   $
��Wrap=�6H   $��
Start Date��6\   $	��Top=�6n   $��20��6�   $��64��6�     5-      -   5        $ dpStartDate��5-      $
��Left=�6Q   $��433,558,0,0q�6l   $	��Top=�6�    6.   �� *	startDate+6�   �� 5.      $
��Left=�6   $��367,602,0,0q�63   $
��Wrap=�6H   $��Due Date��6\   $	��Top=�6l     5/      -   5        $ 	dpDueDate��5/      $
��Left=�6M   $��433,598,0,0q�6h   $	��Top=�6}    6,   �� *	dueDate+6}   �� 50      $
��Left=�6   $��
22,569,0,0q�63   $
��Wrap=�6G   $��Period��6[   $	��Top=�6i   �� 51      -   5        $ 	txtPeriod��51       . $
��Left=�6;   $��23��6V   $��105,569,0,0q�6b   $
 Wrap=�6w   $	��Top=�6�   $	��120��6�   �� 52      $
��Left=�6   $��230,572,0,0q�63   $
��Wrap=�6H   $��weeks��6\   $	��Top=�6i   53      54      55      