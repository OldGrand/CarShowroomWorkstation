   M S B A M L   `   `   `  ����Q  MCarShowroomWorkstation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CarShowroomWorkstation.MVVMCarShowroomWorkstation.MVVM  5   	   -    'CarShowroomWorkstation.AddingAutoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:CarShowroomWorkstation.MVVM     5   	     � Title$  AddingAutoWindow��5   	   $	��520��6"   $	��800��6/    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         NormalBrush �� 
StartPoint �� EndPoint � Color � Offset  WindowBackgroundBrush �� Color  ComboBoxToggleButton �� 
TargetType	 � ColumnDefinitions
 ��Name �� CornerRadius F�Name  ComboBoxTextBox �� 
TargetType �� Property �� Value �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource �� SelectionBoxItem �� SelectionBoxItemTemplate J� IsHitTestVisible ��Name �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight  K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation!   DirectionalNavigation" �� Triggers��%N  &	        &	 �     &	 �     7   7  &	 �    '�� �    7  7  7  �� 5   
   $	 0,0&�62   $	 0,1&�6C   ��5      � � 5      $ White��6#   $	 0.0Q�61   � 5      $ #3F3F46��6#   $	 1.0Q�63   5      5      �� 5   
   $ #3F3F46��68   �� 5   
   " d�67   .R�5      � 	 5      �� 5      �� 5      $��20 �6'   .+�5      �� $
 Border��6   $��2��6)   $ 2��6=   8��  $��1q�5      �� 5      $��0��5       $ 2,0,0,2��5!      $��1q�5"      8�� $��0,0,1,0q�5$      F� 5%      $ Arrow��5&      $��1��5'      $��Center=�5(      $��Center=�5)      "����        � 	=  	= � z     	5*      5+      5,      �� 5.   
   " ��62   .R�5/      �� $
 PART_ContentHost��6   |�.  #��z��6A   50      �� 53   
   " ��6*   .�54      ��  � �� 55      �� 56      " ��6&   .R�57      � .+�58      d� $��ToggleButton��59   
   8��  $��2��5;   
   |�.  $ Press=�5>   
    5=   
   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+5?      �� 5@      $��ContentSite��5B   	   #��z 5A      #��z 67   #��z��6}    .  $��3,3,23,3q�5D   	   $��Center=�5E   	   $
��Left=�5F   	   �� 5G      $ PART_EditableTextBox��6&   8�� $
��Left=�5J   
   $��Center=�5K   
   $��3,3,23,3q�5L   
   |�. 
������ $y�Hidden=�5O   
   # z 5P   
   ��5H   
   Z� 5P   
   � 5Q      $��Popup��5R   	   $��Bottom=�5S   	   #��z 5T   	    . |�.  $��Slide=�5W   	   .��5X   "   � $��DropDown��5Y       . #��z 5[      #��z 5\      .+�5]   &   �� $
 DropDownBorder��5^      8�� $��1q�5`      �� 5a   &   $��4,6,4,6q�63    . .��5b   *   ��   . $! 	Contained=�6H   5c   '   5d   #   5e      5f      5g      5i      " 5j      5l      5m      ��5n      �� 5o   
   $
 Gray��6   6)   .��5q      � # � RowDefinitions# 5r   
   �� 5s      6   �� 5t      6   �� 5u      6   �� 5v      6   �� 5w      6   �� 5x      6   �� 5y      6   �� 5z      6   �� 5{      6   	 5~   
   �� 5      6!   �� 5�      6!   .+�5�   
   �� 
�������  
LabelStyle#��[ 5�      $
��Mark��5�      �� 5�   
   $��1��6     TextBoxStyle#��[ 5�      ��5�      �� *MarkValidator+$ �� UpdateSourceTrigger$$ PropertyChanged=�$ TwoWay=���5�      ��   TextBox_Template% �� Source#% [ �� 5�   
   
�������$��2��6#   #��[ 5�      $��Model��5�      �� 5�   
   $��3��6   #��[ 5�      ��5�      �� *ModelValidator+$$ PropertyChanged=�$ TwoWay=���5�      �� #% [ �� 5�   
   
�������$��4��6#   #��[ 5�      $��
Horsepower��5�      �� 5�   
   $��5��6   #��[ 5�      ��5�      �� *HorsepowerValidator+$$ PropertyChanged=�$ TwoWay=���5�      �� #% [ �� 5�   
   
�������$��1��6#   #��[ 5�      $��Year Of Issue��5�      (  "System.Windows.Controls.DatePicker  5�   
   -   5        &  Name$& YearOfIssuePicker��5�      ���#3F3F46$	��300��6E   $��40��5�      $��1��6!   $��1��6.   $��20(�6>   $��Center=�5�      '   DisplayDateStart$' 
01/01/1900X�5�      (   SelectedDate( 5�      �� *SelectedDate+$$ PropertyChanged=�$ TwoWay=�)   DisplayDateEnd) 5�      �� *Date+�� 5�   
   
�������$��1��6#   $��2��63   #��[ 5�      $��Price��5�      �� 5�   
   $��1��6   $��3��6"   #��[ 5�      ��5�   /   �� *PriceValidator+$$ PropertyChanged=�$ TwoWay=���5�      �� #% [ �� 5�   
   
�������$��4��6#   $��1��60   #��[ 5�      $��Choose Car Type��5�      �� 5�   
   $��5��6   $��1��6    * �� DisplayMemberPath$* BodyType��5�   4   $	��280��5�      $��30��6   $��18(�6+   
���������5�      �� *
CarTypes++ �� SelectedItem+ 5�      �� *SelectedCarType+$ TwoWay=�5�      �� 5�   
   
�������$��6��6#   $��2��60   #��[ 5�      $��Choose Trasmission Type��5�      �� 5�   
   $��7��6   $��2��6    $* TransmissionType��5�   9   $	��280��5�      $��30��6   $��18(�6+   
���������5�      �� *Transmissions++ 5�      �� *TransmissionsType+$ TwoWay=�5�   9   �� 5�   
   $	��250��6   $��2��6   $��8��61   $��Ok��6>     ButtonStyle#��[ 5�      ��5�      �� *
AddCommand+��5�      ��   Button_Template#% [ 5�      5�      