   M S B A M L   `   `   `  ����  ISDBlab3    ISDBlab3.ModelsWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Модели��5   	   $	��400��6   $	��600��6%    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� -   5         ��Name$ 	AddButton��5      $��Добавить��6(   $	��100��6;   $��5q�6G   6R   �� 5      -   5        $ 
EditButton��5      $ ��Редактировать��6)   $	��100��6A   $��5q�6M   6X   �� 5      -   5        $ DeleteButton��5      $��Удалить��6+   $	��100��6=   $��5q�6I   6T   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ModelsDataGrid��5      $��1��6+      AutoGenerateColumns$ False��68      
IsReadOnly$
 True��6T   $��0,0,0,10q�6f      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Код модели��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
model_code+6X     5      $#	 Название модели��6%   $
 * 6]    6>   �� *
model_name+6]     5      $	 Тип модели��6%   $
 * 6X    69   �� *
model_type+6X   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5      �� -   5        $��Закрыть��5      $	��100��6'   $��5q�63   6>   5      5      5      