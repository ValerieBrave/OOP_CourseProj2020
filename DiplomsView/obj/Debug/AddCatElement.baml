   M S B A M L   `   `   `  ����F  BDiplomsView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DiplomsViewDiplomsView  5   	       DiplomsView.AddCatElement   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DiplomsView     5   	     � Title$  AddCatElement��5   	   $	��300��6   $	��400��6,    � 
ResizeMode$ NoResize=�68   .��5	      � -   5         �Name$
 grid��5	       � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��70 �6   �� 5      .+�5   
   �� -   5         ��Name$ cat_name_help��5      $��62,13,62,10q�6+   $��2��6@   $��16(�6T   $@��:Добавление нового руководителя��6b   �� 5   
   -   5        $ new_id_help��5      $��1��6)   $��Имя:��66   $��
30,6,66,42q�6B   $��16(�6V   �� 5   
   -   5         ��Name$ new_id��5      $��1��6"   $��30,28,30,10q�6/   $��2��6D   �� 5   
   -   5         ��Name$ btn_AddElement��5      $��Готово��6)   $��2��6:   $��98,93,98,18q�6G   $��2��6\   6p   5      5      