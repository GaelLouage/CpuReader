   M S B A M L   `   `   `  ����D  @CpuReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CpuReader	CpuReader  5   	       CpuReader.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CpuReader     5   	   LmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     5	        � Title$  CPU Monitor��5
   	   $	��800��6   $	��750��6*   .��5      � -   5        ���	#FF151515 � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 	panel_cpu��5   3   $��1��6   $��6��6"   $	��Top=�6F   $��Center=�6^   .+�5      �� -   5         ��Name$ 
txtCpuName��5   %   $��0��6   
��� ���$��Center=�6M   $��Center=�6h   $��	0,25,0,15q�6�   $��18(�5    <   $
��Bold"�5!   B   5"      �� 5$      $��1��6   $��	0,25,0,25q�6%   
��� ���$
��5500��6L   6[   �� 5&      $��2��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $��	10 0 0 50q�6\   .+�5'      �� .+�5(      �� $��	CPU speed��6    
��� ���$��10q�6G   .��5)      �� -   5        $ 	txtClocks��5)   %   
��� ���$��Center=�6L   $��15q�6i   5*      5+      �� 5,      .+�5-      �� $��CPU Load��6    
��� ���$��10q�6F   .��5.      �� -   5        $ txtLoads��5.   %   
��� ���$��Center=�6K   $��15q�6h   5/      50      �� 51      .+�52      �� $��CPU Watt consumption��6    
��� ���$��10q�6R   .��53      �� -   5        $ txtWatts��53   %   
��� ���$��Center=�6K   $��15q�6h   54      55      56      �� 59      $��3��6   .+�5:      � -   5         �Name$ 	pbCpuTemp��5:   *   $��25��6    � Minimum$ 0Q�6=   $
��15,0q�6J   
���   �
��� ���$	��610��6   �� 5=      -   5        $ txtCpuTempPgb��5=      $��Center=�5>      $��Center=�6&   
�������$��	0,-29,0,0q�5?      $��14(�5@   @   5A      5C      �� 5E      $��4��6   $��Center=�6&   $ 
Horizontal=�6C   .+�5F      �� -	   5        $ txtCpuMinTemperature��5F      
��� ���$��15q�6N   �� 5G      -
   5        $ txtCpuMaxTemperature��5G      
��� ���$��15q�6N   5H      5J      5O      5P      