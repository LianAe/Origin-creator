   M S B A M L   `   `   `  ����I  EOrigin creator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Origin_creatorOrigin_creator  5      E'clr-namespace:Origin_creator.ViewModelsOrigin_creator.ViewModels  5      G CXamlInverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:XamlInverter;assembly=XamlInverterXamlInverter 5
      ;"clr-namespace:Origin_creator.ViewsOrigin_creator.Views  5      #    Origin_creator.OriginMainMenu   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Origin_creator     5      >
viewModels'clr-namespace:Origin_creator.ViewModels     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5	      CxamlInverter0clr-namespace:XamlInverter;assembly=XamlInverter  5
      .views"clr-namespace:Origin_creator.Views  5      $	��600��5      $	��400��5        � 	Resources  5      '  !XamlInverter.BooleanValueInverter   Inverter��%   &	          5   
   6,   5      .��50      �  � ColumnDefinitions 51   
   �� 52      $
��2.5* �6   $	��250��6,   �� 53      $��* �6   $	��150��6)   �� 54      $��1* �6   $	��150��6*   �� 55      $��1* �6   $	��150��6*    � RowDefinitions 57   
   �� 58      $��40 �6   �� 59      $��* �6   $	��150��6'   �� 5:      $��3* �6   �� 5;      $��40 �6     5>   
    �� DataType8   2Origin_creator.ViewModels.SelectablePowerViewModel$   Origin_creator.SelectablePower��%G   (��       5?      *, +)�� 6   "  6   .R�5@        5A      5B      .+�5E   
   ��  �� Orientation$ 
Horizontal=�6   $��4��6.   .+�5F      �� $��25(�5G      $��5q�5H   0   ��6   �� *TxtOriginName+60   �� 5I      $��5q�64   ��6   �� *ItemIconPath+6A   5J      �� 5K   
   $��4��5L      $��3��5M      $��Bottom=�5N      ���#93C5C75O      �� 5R   
   $��1��5S      $��5q�5T      $��Description��5U      �� 5V   
   $��1��5X      $��5,25,5,5q�5Y      ���#4E797A���#93C5C7$��2q�5\       �� TextWrapping$
 Wrap=�5]      ��5W      �� *TxtOriginDescription+ �� 
IsReadOnly 5^      �� *ReadonlyMode+� 5a   
   $��1��5b      $��1��5c      $��5,20,5,0q�5d      .+�5f      �� $��5q�6   .+�5g      �� $��Impact:��6   "  Xceed.Wpf.Toolkit.ByteUpDown  5h      $��60��5i      ���#4E797A���#93C5C7$��2q�5l      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 3X�5m         Minimum$ 1X�5n      	   Value	 5o      �� *Impact+,  &Xceed.Wpf.Toolkit.Primitives.InputBase
   
IsReadOnly
 5p      �� *ReadonlyMode+5q      �� 5t      $��5q�6   .+�5u      �� $��Icon:��6   �� 5v      $��60��6    �� SelectedItem 6)   �� *SelectedIcon+��6O   �� *ListIconsName+{�6u   �� *ReadonlyMode+ �� 	Converter# [  5w      5x      5y      � 5|   
   $��2��5}      $��5q�5~      ���#474747 5�      �� 5�      $��30 �6    �� 5�      $��* �6    �� 5�      $��80 �6    .+�5�      �� $��4��5�      $��Center=�5�      $��20(�5�      ��5�      �� *TxtPowerName+�� 5�      $��3��5�      $
��10,0q�5�      $��Bottom=�5�      ���#93C5C75�      �� 5�      $��1��6   $
��Auto=�6(   .��5�      � .+�5�      �� $��5q�6!   .+�5�      �� $��Description��6$   �� 5�      $	��100��5�      $��60��5�      $	��300��5�      ���#4E797A���#93C5C7$��2q�5�      $
 Wrap=�5�      ��5�      �� *TxtPowerDescription+5�      5�      �� 5�      $��5q�6!   $��Bottom=�6,   .+�5�      �� $
��Type��6$   �� 5�      $	��100��5�      ���#4E797A���#93C5C7$��2q�5�      ��5�      �� *	TxtType+5�      �� 5�      $��5q�6!   $��Bottom=�6,   .+�5�      �� $��	Condition��6$   �� 5�      $	��100��5�      ���#4E797A���#93C5C7$��2q�5�      ��5�      �� *TxtCondition+5�      �� 5�      $��5q�6!   $ 
Horizontal=�6,   $��Bottom=�6E   .+�5�      �� $��0,0,5,0q�6$   $��Hidden:��65   �� 5�      ���#4E797A���#93C5C7$��2q�5�       d� 	IsChecked 5�      �� *IsPowerHidden+5�      5�      5�      5�      � 5�      $��2��5�      $��4��5�      $��Center=�5�      $��Bottom=�5�      {�.  .+�5�      �� $��5q�5�      ���#4E797A$��New power...��5�      $��20(�5�      ���#98887Ey�5�      �� *ReadonlyModeVisibility+5�      �� 5�      $��5q�5�      ���#4E797A$��
Edit power��5�      $��20(�5�      ���#98887Ey�5�      �� *ReadonlyModeVisibility+�� 5�      $��5q�5�      ���#874444$��Delete power��5�      $��20(�5�      ���#98887Ey�5�      �� *ReadonlyModeVisibility+5�      5�      �� 5  
   $��2��5     $��1��5     $��5q�5     $��Powers��5     �� 5  
   $��2��5
     $��1��5     $��5,25,5,5q�5     ���#4E797A
���������5     �� *
ListPowers+ 5	     �� *SelectedPower+5     �� 5  
   $��1��5     $��2��5     $��2��5     $��2��5     $��5q�5     y�5     �� *ReadonlyModeVisibility+.@�5     �� $��Vanilla powers��6   .��5     �� ���#474747
�������$��Stretch=�5      $��Disabled=�5!     ��5     �� *VanillaPowersToSelect+ 5     �� *SelectedVanillaPower+5"     5#     �� 5$     $��Custom powers��6   {�.  .��5&     �� ���#474747
�������5(     5)     5*     �� 5+  
   $��2��5,     $��2��5-     $��40��5.     $��10q�5/     $��Right=�50     $��Bottom=�51     ���#4E797A$	��❮��53     $��30(�54     
���������56     �� *AddPowerCommand+y�57     �� *ReadonlyModeVisibility+�� 58  
   $��2��59     $��3��5:     $��40��5;     $��10q�5<     $
��Left=�5=     $��Bottom=�5>     ���#4E797A$	��❯��5@     $��30(�5A     
���������5C     �� *RemovePowerCommand+y�5D     �� *ReadonlyModeVisibility+�� 5F  
   $��3��5G     $��4��5H     $��Center=�5I     $ 
Horizontal=�5J     .+�5K     �� $��5q�5L     ���#4E797A$��20(�5O     
���������5N     �� *
BtnEditing+��5Q     �� *EditingModeCommand+�� 5R     $��5q�5S     ���#4E797A$��20(�5V     
���������5U     �� *BtnSaveChanges+y�5X     �� *ReadonlyModeVisibility+��5Y     �� *SaveOriginCommand+�� 5Z     $��5q�5[     ���#874444$��Delete Origin��5]     $��20(�5^     {�.  ���#98887E5`     5a     5c     5d     