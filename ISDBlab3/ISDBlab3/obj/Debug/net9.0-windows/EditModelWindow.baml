   M S B A M L   `   `   `  ����  ISDBlab3    ISDBlab3.EditModelWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$/  )Редактирование модели��5   	   $	��250��6'   $	��400��64    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Код модели:��6   $��0��6&   $��0��63   $��Center=�6C   �� 5   
   -   5         ��Name$ edCode��5      $��0��6"   $��1��6/   $��5q�6?    �� 
IsReadOnly$
 True��6J   �� 5   
   $$��Название модели:��6   $��1��6+   $��0��68   $��Center=�6H   �� 5   
   -   5        $ edName��5      $��1��6"   $��1��6/   $��5q�6?   �� 5   
   $��Тип модели:��6   $��2��6&   $��0��63   $��Center=�6C   �� 5   
   -   5        $ edType��5      $��2��6"   $��1��6/   $��5q�6?   �� 5   
   $��3��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Right=�6O   $��5q�6k   .+�5      �� -   5         ��Name$	 bOk��5      $��Сохранить��6"   $��75��66   $��5q�6A    �� 	IsDefault$
 True��6^   �� 5      -   5        $ bCancel��5      $��Отмена��6&   $��75��67   $��5q�6B   	 �� IsCancel$
	 True��6c   5      5      5      