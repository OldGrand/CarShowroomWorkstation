   M S B A M L   `   `   `  ����Q  MCarShowroomWorkstation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CarShowroomWorkstationCarShowroomWorkstation  5   	   /    )CarShowroomWorkstation.RegistrationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CarShowroomWorkstation     5   	     � Title$  RegistrationWindow��5   	   $	��450��6$   $	��700��61    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   ��5      �� 5   
    �� ImageSource$A ;pack://application:,,,/Resources/RegistrationBackGround.png��6   .��5      �  +� FocusedElement 6   ��  �� ElementName$ EmailTextBox�� � RowDefinitions 5   
   �� 5      6   �� 5      $��50 �6   6*   �� 5      $��60 �6   6*   �� 5      $��50 �6   6*   �� 5      $��60 �6   6*   �� 5      $��50 �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$ 	EmaiLabel��5      $��Email��6#   
�������   
LabelStyle#��[  6F   �� 5   
   -   5        	 ��Name$	 EmailTextBox��5      $��1��6(     TextBoxStyle#��[ 65   ��6[   ��   TextBox_Template
 �� Source#
 [ .��6�    � ToolTip 5      _� 5       -   5         _�Name$ EmailToolTip��5       $y�Hidden=�60   $��20(�6D    _� PlacementTarget 6R   �� *EmailTextBox+.��6{   caПользователь с указанной почтой уже зарегистрирован5"      .��5#      5$      �� 5&   
   -   5        $ PasswordLabel��5&      $��2��6'   $��Password��64   
�������#��[  6Z   �� 5'   
   -   5        $	 PasswordTextBox��5'      $��3��6+   $��50��68   #��[ 6D   ��6j   �� #
 [ �� 5)   
   -   5        $ ConfirmPasswordLabel��5)      $��4��6.   $��Confirm Password��6;   
�������#��[  6i   �� 5*   
   -   5        $	 ConfirmPasswordTextBox��5*      $��5��62   $��50��6?   #��[ 6K   ��6q   �� #
 [ �� 5,   
   -   5         ��Name$ RegistrationButton��5,      $	��250��6-   $��6��69   $��Продолжить��6F     ButtonStyle#��[ 6[   ��6�   ��   Button_Template#
 [ 5-      5.      