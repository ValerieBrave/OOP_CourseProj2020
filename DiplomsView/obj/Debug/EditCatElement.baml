   M S B A M L   `   `   `  ����F  BDiplomsView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DiplomsViewDiplomsView  5   	        DiplomsView.EditCatElement   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DiplomsView     5   	     � Title$  EditCatElement��5   	   $	��400��6    $	��400��6-    � 
ResizeMode$ NoResize=�69   .��5	      � -   5         �Name$
 grid��5	       � RowDefinitions 5
   
   �� 5      $��80 �6   �� 5      $��80 �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ old_id_help��5      $��0��6)   $��Имя:��66   $��10,10,10,45q�6B   $��2��6W   �� 5   
   -   5        $ old_id��5      $��0��6$   $��3��61   $��
10,40,10,0q�6E   �� 5   
   -   5        $ new_id_help��5      $��2��6)   $��Новое имя:��66   $��10,0,23,184q�6H   �� 5   
   -   5         ��Name$ new_id��5      $��2��6"   $��10,27,10,143q�6/   $��2��6E   �� 5   
   -   5         ��Name$ btnSaveEdit��5      $��2��6&   $��100,160,100,17q�63   $��2��6K   $��Изменить��6_   $��35��6r   6~   5      5      