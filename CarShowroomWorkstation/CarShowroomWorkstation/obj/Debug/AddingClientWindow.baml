   M S B A M L   `   `   `  ����Q  MCarShowroomWorkstation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CarShowroomWorkstationCarShowroomWorkstation  5   	   /    )CarShowroomWorkstation.AddingClientWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CarShowroomWorkstation     5   	     � Title$  AddingClientWindow��5   	   $	��450��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�5	   	   ��5
      �� 5   
    �� Color$
 Gray��6   6)   .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� 
�������   
LabelStyle#��[  5      $
��Name��5      �� 5    
   $��1��6     TextBoxStyle#��[ 5!      ��5       �� *NameValidator+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=���5"      ��   TextBox_Template �� Source# [ �� 5$   
   
�������$��2��6#   #��[  5%      $��Surname��5&      �� 5'   
   $��3��6   #��[ 5(      ��5'      �� *SurnameValidator+$ PropertyChanged=�$ TwoWay=���5)      �� # [ �� 5+   
   
�������$��1��6#   #��[  5,      $��Phone Number��5-      �� 5.   
   $��1��6   $��1��6"   #��[ 5/      ��5.   /   �� *PhoneNumValidator+$ PropertyChanged=�$ TwoWay=���50      �� # [ .��6R    � ToolTip 51      _� 52      .��53      �� B@Введите значение в формате 37529111 11 116K   54      .��55      56      �� 58   
   
�������$��1��6#   $��2��63   #��[  59      $��Pasport Number��5:      �� 5;   
   $��1��6   $��3��6"   #��[ 5<      ��5;   /   �� *PasportNumValidator+$ PropertyChanged=�$ TwoWay=���5=      �� # [ .��6R    5>      _� 5?      .��5@      �� <:Введите значение в формате AA0000006E   5A      .��5B      5C      �� 5E   
   
�������$��2��6#   $��4��67   #��[  5F      $��Address��5G      �� 5H   
   $��5��6   $��2��6   $	��380��63   #��[ 5I      ��5H   ?   �� *AddressValidator+$ PropertyChanged=�$ TwoWay=���5J      �� # [ �� 5K   
   $	��250��6   $��2��6   $��8��61   $��Ok��6>     ButtonStyle#��[ 6p   ��6K   �� *AddClientCommand+��6�   ��   Button_Template# [ 5L      5M      