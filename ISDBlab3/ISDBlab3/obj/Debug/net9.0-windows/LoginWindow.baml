   M S B A M L   `   `   `  ����  ISDBlab3    ISDBlab3.LoginWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Авторизация��5   	   $	��200��6   $	��300��6*    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $&�� Имя пользователя:��6   $��0��6,   $��0��69   $��Center=�6I   �� 5   
   -   5         ��Name$ edUser��5      $��0��6"   $��1��6/   $��5q�6?   �� 5   
   $��Пароль:��6   $��1��6"   $��0��6/   $��Center=�6?   G� 5   
   -   5         G�Name$ edPwd��5      $��1��6%   $��1��62   $��5q�6B   �� 5   
   $��2��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Right=�6O   $��5q�6k   .+�5      �� -   5         ��Name$	 bOk��5      $
��ОК��6"   $��75��6/   $��5q�6:   ��5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 �@��	IsDefault
 �� Value$

 True��66   5      5      �� 5      -   5        $ bCancel��5      $��Отмена��6&   $��75��67   $��5q�6B   ��5      �� 5      " ��6   .�5       �� 	 �@��IsCancel$

 True��65   5!      5#      5$      5%      5&      