   M S B A M L   `   `   `  ����Q  MCarShowroomWorkstation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CarShowroomWorkstationCarShowroomWorkstation  5   	   1    +CarShowroomWorkstation.EditingManagerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CarShowroomWorkstation     5   	     � Title$  EditingManagerWindow��5   	   $	��500��6&   $	��900��63    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         NormalBrush �� 
StartPoint �� EndPoint � Color � Offset��%�   &	        �� 5   
   $	 0,0&�62   $	 0,1&�6C   ��5      � � 5      $ White��6#   $	 0.0Q�61   � 5      $ #3F3F46��6#   $	 1.0Q�63   5      5      5      ��5      �� 5   
    �� Color$
 Gray��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.4* �6   6,   �� 5      6   �� 5      6   �� 5      $
��0.4* �6   6,   	 � ColumnDefinitions	 5    
   �� 5!      6!   �� 5"      6!   �� 5#      $
��0.2* �6   6.   �� 5$      6!   �� 5%      6!   .+�5(   
   �� $��35��6   $��Center=�6   $��18(�69     TextBoxStyle#��[ 5*      ��5)      �� *ManagersTextChanged+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=���5+      ��   TextBox_Template �� Source# [ �� 5,   
   $	��200��6   $��1��6   $'��!Удалить выбранных��6-   $��20(�6I     ButtonStyle#��[ 5.      ��5-      �� *RemoveManagersCmd+��6<   �� *SelectedItems+ �� ElementName$ ManagersDataGrid����5/      ��   Button_Template# [ �� 50   
   $��1��6   $��2��6    $��2��61   $��Manager Editing��51      
�������.��52      &   System.Windows.Controls.DataGrid  -   5          Name$ ManagersDataGrid��52        DataGridStyle#��[ 61   ��53      �� *
Managers+ �� SelectedItem 54      �� *SelectedManager+ 55      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value��%�   '        7 �� 56      8   "  6U   .�57      ��  � �� �#FF0A0067   �� 58       � ��
 �   �68   �� 59       � ��$ 0,0,1,0q�6<   5:      5;         Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$ Email��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   ��  �� Path$ Email�6W     5>      $ Пароль��6)   $ * 6[    69   �� $ Password�6[     5?      $ Имя��6)   $ * 6T    66   �� $
 Name�6T     5@      $ Фамилия��6)   $ * 6[    6:   �� $ Surname�6[     5A      $# Номер Пасспорта��6)   $ * 6j    6B   �� $ PassportNumber�6j     5B      $! Номер Телефона��6)   $ * 6f    6A   �� $ PhoneNumber�6f     5C      $ Зарплата��6)   $ * 6[    6;   �� $ Salary�6[     5D      $  Кол-во заказов��6)   $ * 6g    6A   �� $ Orders.Count�6g   5F      5G      �� 5I   
   $��35��6   $��Center=�6   $��3��69   $��18(�6I   #��[ 5K      ��5J      �� *DateTextChanged+$
 PropertyChanged=�$ TwoWay=���5L      �� # [ �� 5M   
   $	��200��6   $��4��6   $+��%Закрепить менеджера��6-   $��18(�6K   #��[ 5O      ��5N      �� *AssociateManagerCmd+��5P      �� # [ �� 5Q   
   $��1��6   $��2��6    $��2��61   $��3��6E   $J��DНазначение на заказ нового менеджера��5R      
�������.��5S        -   5        $ OrdersDataGrid��5S      #��[ 6/      
IsReadOnly . ��5T      �� *Orders+ 68   �� *SelectedFreeOrder+ 5V      ��%�   '        7 �� 5W      8   "  6U   .�5X      ��  � �� �#FF0A0067   �� 5Y       � ��
 �   �68   �� 5Z       � ��$ 0,0,1,0q�6<   5[      5\       5]        5^      $ Дата принятия��6)   $ * 6e    6@   �� $ DateOfIssue�6e     5_      $ Заказчик��6)   $ * 6d    6;   �� $ Clients.Surname�6d     5`      $ 
Сумма��6)   $ * 6\    68   �� $ 
OrderPrice�6\   5b      5c      �� 5e   
   $	��250��6   $��1��6   $��3��6-   $��3��6:   $��Сохранить��6N   #��[ 5f   1   ��6   �� *	SaveCmd+��5g      �� # [ 5h      5i      