   M S B A M L   `   `   `  ����C  ?FarmEdit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FarmEdit.ControlsFarmEdit.Controls  5      "    FarmEdit.Controls.SingleSave   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:FarmEdit.Controls     5      ���#fff.��5	      � $��0��6   $��0��6     � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5        $��tbTitle��5   F   $��0��6   $��26(�6!    �� TextAlignment$ Center=�6/   $
��Bold"�6U   SaveGame Name6v   �� 5   
   -   5        $��btnBack��5   o   $��0��6   $��14(�6   $
��Left=�6,   $��26��6G   $	��5,0q�6S   $
��10,7q�6a   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	����6      FASolid#��[  6,   
���   �$��12(�6e   $��0,0,5,0q�6s   $��Center=�6�   6�   �� 5      	All Saves6'   5      5      �� 5   
   $��1��6   $��18(�6!   $��
10,10,10,0q�6/   $
��Bold"�6C   $��	Underline{�6U   	General6z   &   System.Windows.Controls.DataGrid  5    
   -   5        $��
dgSaveData��5    j   $��Stretch=�6   $��
10,2,10,10q�61   $��2��6E   $	��Top=�6R      HeadersVisibility$ Column=�6|      
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�    J� IsManipulationEnabled .  6�   �� 5!   
   $��3��6   $��18(�6!   $��
10,10,10,0q�6/   $
��Bold"�6C   $��	Underline{�6U   	Finance6z     5"   
   -   5        $��dgFinancialData��5"   j   $��Stretch=�6   $��
10,2,10,10q�61   $��4��6E   $	��Top=�6R   $ Column=�6�    . $ * 6�    .  6�   �� 5#   
   $��5��6   $��18(�6!   $��
10,10,10,0q�6/   $
��Bold"�6C   $��	Underline{�6U   	Weather6z     5$   
   -   5        $��dgWeatherData��5$   j   $��Stretch=�6   $��
10,2,10,10q�61   $��6��6E   $	��Top=�6R   $ Column=�6    . $ * 6�    .  6�   �� 5%   
   $��7��6   $��18(�6!   $��
10,10,10,0q�6/   $
��Bold"�6C   $��	Underline{�6U   Silos6x     5&   
   -   5        $��
dgSiloData��5&   j   $��Stretch=�6   $��
10,2,10,10q�61   $��8��6E   $	��Top=�6R   $ Column=�6|    . $ * 6�    .  6�   5'      5(      