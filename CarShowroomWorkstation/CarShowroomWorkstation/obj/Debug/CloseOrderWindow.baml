   M S B A M L   `   `   `  ����Q  MCarShowroomWorkstation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CarShowroomWorkstationCarShowroomWorkstation  5   	   -    'CarShowroomWorkstation.CloseOrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CarShowroomWorkstation     5   	     � Title$  CloseOrderWindow��5   	   $	��450��6"   $	��800��6/    � WindowStartupLocation$ CenterScreen=�5	   	   ��5
      �� 5   
    �� Color$
 Gray��6   6)    � 	Resources 5         NormalBrush �� 
StartPoint �� EndPoint � Color � Offset  WindowBackgroundBrush  ComboBoxToggleButton �� 
TargetType	 � ColumnDefinitions
 ��Name �� CornerRadius F�Name  ComboBoxTextBox �� 
TargetType �� Property �� Value �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource �� SelectionBoxItem �� SelectionBoxItemTemplate J� IsHitTestVisible ��Name �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight  K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation!   DirectionalNavigation" �� Triggers��%N  &	        &	 �     &	 �     7   7  &	 �    '�� �    7  7  7  �� 5   
   $	 0,0&�62   $	 0,1&�6C   ��5      � � 5      $ White��6#   $	 0.0Q�61   � 5      $ #3F3F46��6#   $	 1.0Q�63   5      5      �� 5   
   $ #3F3F46��68   �� 5   
   " d�67   .R�5      � 	 5      �� 5      �� 5      $��20 �6'   .+�5      �� $
 Border��6   $��2��6)   $ 2��6=   8��  $��1q�5!      �� 5"      $��0��5#      $ 2,0,0,2��5$      $��1q�5%      8�� $��0,0,1,0q�5'      F� 5(      $ Arrow��5)      $��1��5*      $��Center=�5+      $��Center=�5,      "����        � 	=  	= � z     	5-      5.      5/      �� 51   
   " ��62   .R�52      �� $
 PART_ContentHost��6   |�.  #��z��6A   53      �� 56   
   " ��6*   .�57      ��  � �� 58      �� 59      " ��6&   .R�5:      � .+�5;      d� $��ToggleButton��5<   
   8��  $��2��5>   
   |�.  $ Press=�5A   
    5@   
   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+5B      �� 5C      $��ContentSite��5E   	   #��z 5D      #��z 67   #��z��6}    .  $��3,3,23,3q�5G   	   $��Center=�5H   	   $
��Left=�5I   	   �� 5J      $ PART_EditableTextBox��6&   8�� $
��Left=�5M   
   $��Center=�5N   
   $��3,3,23,3q�5O   
   |�. 
������ $y�Hidden=�5R   
   # z 5S   
   ��5K   
   Z� 5S   
   � 5T      $��Popup��5U   	   $��Bottom=�5V   	   #��z 5W   	    . |�.  $��Slide=�5Z   	   .��5[   "   � $��DropDown��5\       . #��z 5^      #��z 5_      .+�5`   &   �� $
 DropDownBorder��5a      8�� $��1q�5c      �� 5d   &   $��4,6,4,6q�63    . .��5e   *   ��   . $! 	Contained=�6H   5f   '   5g   #   5h      5i      5j      5l      " 5m      5o      5p      .��5q      � # � RowDefinitions# 5r   
   �� 5s      $
��0.6* �6   6,   �� 5t      6   �� 5u      6   �� 5v      $
��0.5* �6   6,   	 5y   
   �� 5z      $
��0.2* �6   6.   �� 5{      $��1* �6   6,   �� 5|      $
��0.2* �6   6.   .+�5   
   �� 
�������$��1��6#   $	��Top=�63     
LabelStyle#��[ 5�      $��Search Order By Date��5�      �� 5�   
   $��1��6   $��30��6"   $	��300��6.   $��Bottom=�6:   $��18(�6U     TextBoxStyle#��[ 5�      ��5�      �� *DateTextChanged+$ �� UpdateSourceTrigger$$ PropertyChanged=�$ TwoWay=���5�      ��   TextBox_Template% �� Source#% [ �� 5�   
   $��Car Search Results��6     GroupBoxStyle#��[ 6/   $��1��6V   $��1��6f   $��2��6s   .��5�      &   System.Windows.Controls.DataGrid  -   5        &  Name$& OrdersDataGrid��5�      '   
IsReadOnly' .   DataGridStyle#��[ 5�      (   AutoGenerateColumns( .  ��5�      �� *Orders+) �� SelectedItem) 5�      �� *SelectedOrder+ 5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader* �� BasedOn��%�   '        7 �� 5�      8*   "  6U   .�5�      ��  � �� �#FF0A0067   �� 5�       � ��
 �   �68   �� 5�       � ��$ 0,0,1,0q�6<   5�      5�      +   Columns+ 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn,   Header$, Дата принятия��6)   -   Width5  /System.Windows.Controls.DataGridLengthConverter$- * 6e   1  +System.Windows.Controls.DataGridBoundColumn.   Binding. 6@   �� $ DateOfIssue�6e     5�      $, Заказчик��6)   $- * 6d   . 6;   �� $ Clients.Surname�6d     5�      $, Дата закрытия��6)   $- * 6j   . 6@   �� $ DateOrderClosing�6j     5�      $, 
Сумма��6)   $- * 6\   . 68   �� $ 
OrderPrice�6\     5�      $%, Время выполнения��6)   $- * 6e   . 6C   �� $ LeadTime�6e   5�      5�      �� 5�   
   $	��250��6   $��1��6   $��3��6-   $��Ok��6:    	 ButtonStyle#��[	 5�      ��5�      �� *AddCmd+��64   �� *SelectedItems+/ �� ElementName$/ OrdersDataGrid����5�      ��  
 Button_Template#% [
 5�      5�      