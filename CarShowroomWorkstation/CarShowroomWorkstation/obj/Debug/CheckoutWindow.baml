   M S B A M L   `   `   `  ����Q  MCarShowroomWorkstation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CarShowroomWorkstationCarShowroomWorkstation  5   	   +    %CarShowroomWorkstation.CheckoutWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CarShowroomWorkstation     5   	     � Title$  CheckoutWindow��5   	   $	��610��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         NormalBrush �� 
StartPoint �� EndPoint � Color � Offset  WindowBackgroundBrush �� Color  ComboBoxToggleButton �� 
TargetType	 � ColumnDefinitions
 ��Name �� CornerRadius F�Name  ComboBoxTextBox �� 
TargetType �� Property �� Value �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource �� SelectionBoxItem �� SelectionBoxItemTemplate J� IsHitTestVisible ��Name �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight  K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation!   DirectionalNavigation" �� Triggers# J� Opacity$ �� Orientation  MultiSelectComboBox% �Name& �Name' �� ElementName( ��Name) �� SelectionMode  ToggleButtonStyle1  brushWatermarkBackground  brushWatermarkForeground  brushWatermarkBorder  	 BooleanToVisibilityConverter 
 EntryFieldStyle��%  &	        &	 �     &	 �     7   7  &	 �    '�� �    7  7  7  '��     &	 �    &	 �    &	 �    &	 �    &		     &	
     �� 5   
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
 DropDownBorder��5^      8�� $��1q�5`      �� 5a   &   $��4,6,4,6q�63    . .��5b   *   ��   . $! 	Contained=�6H   5c   '   5d   #   5e      5f      5g      5i      " 5j      5l      �� 5n   
   " ��6-   .�5o      ��  �@�OverridesDefaultStyle . 66   �� 5p       �@J�SnapsToDevicePixels . 64   �� 5q       � �� 5r      �� 5s      " ��6&   .R�5t      �� ���	#CD222120$ 
7, 7, 8, 8��68   
�������$��2q�6i   $
# 0.96Q�6}   ._�5u      �� }�. $$ Vertical=�6=     . $��5,4,5,4q�6g   5v      5w      5y      5z      �� 5|   
   " ��6,   .�5~      ��  � �� 5�      �� 5�      " ��6&   .R�5�      � $% MainGrid��6:    . $
��Auto��6L   $
��Auto��6Z   	 5�      �� 5�   "   $��* �63   �� 5�   "   $��0 �63   .+�5�      � $& 
PART_Popup��5�       . $��Bottom=�5�      #��� .�6   $��1q�5�      $��2��6    ��5�   >   �� $ IsDropDownOpen� �� *TemplatedParent+.��5�   "   �� $
 DropDownBorder��6)   #��z 6A   ��6q   �� $ ActualWidth�$' MainGrid��._�5�   &   �� ��. .��5�   *   �� $( lstBox��62   # z 6B   $! 	Contained=�5�      $) Multiple=�66   #��z��6O   5�   '   5�   #   5�      d� 5�      #��z��6+   #��z��6U   $��2��6�   #���  5�   k    6   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+6k   �� 5�       .  $��4,0,0,0q�6�   ��6D   �� $ SelectedItems�$' lstBox����5�   "   �� 5�   &   .R�5�   *   ��   . $$ 
Horizontal=�6H   5�   '   5�      5�      5�      5�      5�      �� 5�   
   $ White��6;   �� 5�   
   $ LightSteelBlue��6;   �� 5�   
   $ Indigo��67   �� 5�   
   6'   �� 5�   
   " �6(   .�5�      ��  � ��$ Stretch=�64   �� 5�       � ��$ Center=�62   5�      5�      ��5�      �� 5�   
   $
 Gray��6   6)   .��5�      � * � RowDefinitions* 5�   
   �� 5�      6   �� 5�      6   �� 5�      6   �� 5�      6   �� 5�      6   �� 5�      6   �� 5�      6   �� 5�      6   �� 5�      6   �� 5�      6   �� 5�      6   	 5�   
   �� 5�      6!   �� 5�      6!   .+�5�   
   �� 
�������  
LabelStyle#��[ 5�      $��Date Of Issue��5�      (  "System.Windows.Controls.DatePicker  5�   
   ���#3F3F46$	��300��6*   $��40��5�      $��1��6!   $��20(�6.   $��Center=�5�      +   DisplayDateStart$+ 
01/01/1900X�5�      ,   SelectedDate, 5�   6   �� *SelectedDate+- �� UpdateSourceTrigger$- PropertyChanged=�$ TwoWay=�.   DisplayDateEnd. 5�      �� *Date+�� 5�   
   
�������$��2��6#   #��[ 5�      $��Choose Client��5�      �� 5�   
   $��3��6   $	��280��6   $��30��6+   $��Center=�67   $��18(�6R     TextBoxStyle#��[ 5�      ��5�      �� *ClientTextChanged+$- PropertyChanged=�$ TwoWay=���5�      ��   TextBox_Template/ �� Source#/ [ �� 5�   
   $��4��6   0 �� DisplayMemberPath$0 Surname��5�   3   $	��280��5�      $��30��6   $��18(�6+   
���������5�      �� *	Clients+1 �� SelectedItem1 5�      �� *SelectedClient+$ TwoWay=�5�   9   �� 5�   
   
�������$��1��6#   #��[ 5�      $��Choose Pay Type��5�      �� 5�   
   $��1��6   $��1��6#   $
0 Name��5�   4   $	��280��5�      $��30��6   $��18(�6+   
���������5�      �� *
PayTypes+1 5�      �� *SelectedPayType+$ TwoWay=�5�   9   �� 5�   
   
�������$��1��6#   $��2��63   #��[ 5      $��Choose Manager��5     �� 5  
   $��1��6   $��3��6"   $	��280��6/   $��30��6;   $��Center=�6G   $��18(�6b   #��[ 5     ��5     �� *ManagerTextChanged+$- PropertyChanged=�$ TwoWay=���5     �� #/ [ 6T   �� 5  
   $��1��6   $��4��6#   $0 Surname��5  4   $	��280��5	     $��30��6   $��18(�6+   
���������5     �� *
Managers+1 5     �� *SelectedManager+$ TwoWay=�5	  9   �� 5  
   
�������$��2��6#   $��5��5     #��[ 5     $��
Choose Car��5     �� 5  
   $��2��6   $��6��6&   $	��500��63   $��30��6?   $��Center=�6K   $��18(�6f   #��[ 5     ��5     �� *TextChanged+$- PropertyChanged=�$ TwoWay=���5     �� #/ [ �� 5  
   $��Car Search Results��6     GroupBoxStyle#��[ 6/   $��2��6V   $��3��6j   $��7��6|   .��5     &   System.Windows.Controls.DataGrid  -   5        2  Name$2 CarsDataGrid��5     3   
IsReadOnly3 .   DataGridStyle#��[ 5     ��5     �� *Cars+1 5     �� *SelectedCar+ 5     =  7System.Windows.Controls.Primitives.DataGridColumnHeader4 �� BasedOn��%�   '        7 �� 5     84   "  6U   .�5     ��  � �� �#FF0A0067   �� 5      � ��
 �   �68   �� 5      � ��$ 0,0,1,0q�6<   5     5     5   Columns5 5      0  *System.Windows.Controls.DataGridTextColumn  5!     ,  &System.Windows.Controls.DataGridColumn6   Header$6 
Марка��6)   7   Width5  /System.Windows.Controls.DataGridLengthConverter$7 * 6V   1  +System.Windows.Controls.DataGridBoundColumn8   Binding8 68   �� $
 Mark�6V     5"     $6 Модель��6)   $7 * 6X   8 69   �� $ Model�6X     5#     $6 Мощность��6)   $7 * 6_   8 6;   �� $ 
Horsepower�6_     5$     $6 Год выпуска��6)   $7 * 6c   8 6>   �� $ YearOfIssue�6c     5%     $6 Цена��6)   $7 * 6V   8 67   �� $ Price�6V   5'     5(     �� 5*  
   $	��250��6   $��2��6   $��10��61   $��Ok��6?     ButtonStyle#��[ 5,     ��5+     �� *AddCmd+��6,   �� *SelectedItems+$' CarsDataGrid����5-     ��   Button_Template#/ [ 5.     5/     