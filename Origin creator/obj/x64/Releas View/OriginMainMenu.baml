   M S B A M L   `   `   `  ���� I  EOrigin creator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Origin_creatorOrigin_creator  #    Origin_creator.OriginMainMenu   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:Origin_creator     X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  $	��600��$	��400��.���   � ColumnDefinitions  �� $
��3.6* �$	��250���� $��* �$	��150���� $
��1.3* �$	��150���� $
��1.3* �$	��150�� � RowDefinitions �� $��40 ��� $��* �$	��150���� $��3* ��� $��40 �.+��� $��Example Origin��$��25(�$��4���� $��3�����#93C5C7$��Bottom=�$��4���� $��Description��$��1��$��5q��� ���#4E797A���#93C5C7$��2q�$��1��$��5, 25, 5, 5q� �� TextWrapping$
 Wrap=�� $��1��$��1��$��
5, 20, 5,0q�.+��� $��5q�.+��� $��Impact:��"  Xceed.Wpf.Toolkit.ByteUpDown  $��60���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 3X�   Minimum$ 1X�   Value$ 1X����#4E797A���#93C5C7$��2q��� $��5q�.+��� $��Icon:���� $��60��.@��� .��Stone�� .��Grass�� .��Cobblestone� ���#474747$��2��$��5q� �� $��30 ��� $��* ��� $��80 �.+��� $��Example Power��$��20(�$��4��$��Center=��� $��3�����#93C5C7$��Bottom=�$��10, 0q��� $��1��$
��Auto=�.��� .+��� $��5q�.+��� $��Description���� $E��?(bsp.)You receive damage over time while in contact with water.��$	��100��$	��300��$��60�����#4E797A���#93C5C7$��2q�$
 Wrap=��� $��5q�.+��� $
��Type���� $.��((bsp.)"type": "origins:damage_over_time"��$	��100�����#4E797A���#93C5C7$��2q��� $��5q� �� Orientation$ 
Horizontal=�.+��� $��Hidden:��$��0,0,5,0q��� ���#4E797A���#93C5C7$��2q��� $��5q�$ 
Horizontal=�.+��� $��(Bsp.)interval:��$��0,0,5,0q�  $ 20X����#4E797A���#93C5C7$��2q��� $��5q�.+��� $��(Bsp.)Condition:��$��0,0,5,0q��� $a��[(bsp.)"condition":{"fluid_condition": {"type": "origins:in_tag", "tag": "minecraft:water"}}��$	��100�����#4E797A���#93C5C7$��2q�$
 Wrap=�� $��3��$��4��$��Center=�$��Bottom=�.+��� $��New power...��$��20(����#4E797A
�������$��5q��� $��
Edit power��$��20(����#4E797A
�������$��5q��� $��Delete power��$��20(����#874444
�������$��5q��� $��Powers��$��2��$��1��$��5q��� ���#4E797A
�������$��2��$��1��$��
5, 25,5, 5q�.@��� .��Hydrophobia�� .��	Nocturnal�� .��Arthtopod (Hidden)�� ���#474747$��1��$��2��$��2��$��2��$��5q�.@��� $��Vanilla powers��.���� ���#474747
�������$��Disabled=�.@�$   Origin_creator.SelectablePower  �� ���#4E797A$��Center=�$��5q�.���� .+��� $��Gills��$��20(� �� TextAlignment$ Center=��� $2��,You can breathe underwater, but not on land.��$ Justify=�$
��Wrap=��� $��Custom powers��.���� ���#474747
�������.@��� ���#4E797A$��Center=�$��5q�.���� .+��� $��Aerial Combatant��$��20(�$ Center=��� $@��:You deal substantially more damage while in Elytra flight.��$ Justify=�$
��Wrap=��� $	��❮��$��30(�$��40�����#4E797A
�������$��2��$��2��$��Right=�$��Bottom=�$��10q��� $	��❯��$��30(�$��40�����#4E797A
�������$��2��$��3��$
��Left=�$��Bottom=�$��10q��� $��3��$��4��$��Center=�$ 
Horizontal=�.+��� $��Exit editing��$��20(����#4E797A
�������$��5q��� $��Save changes��$��20(����#4E797A
�������$��5q��� $��Delete Origin��$��20(����#874444
�������$��5q�