   M S B A M L   `   `   `  ����D  @CpuReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CpuReader	CpuReader  5   	       CpuReader.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CpuReader     5   	   LmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     5	      -   5        ���	#FF151515  � Title$  Hardware Monitor��5
   	   $
��1200��6"   $
��1400��60    � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�6   .��5      � -   5         � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   ]� $��0��6   $��0��6$   $��6��61   $��2��6B   ���#D500006V   ]� 5   
   $��0��6   $��0��6$   $��7��63   ���#D50000$��30��6]   $	��Top=�6i   .+�5       ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��150,-20,70,0q�6N   .+�5!      �� -   5         ��Name$ txtMinimizeApp��5!      $��-��64   
�������$��50(�6P   $��Center=�6^    � Cursor$
 Hand��6y   $��
40,10,-2,5q�6�   6�   �� 5"      -   5        $ txtCloseApp��5"      $��x��61   
�������$��25(�6M   $��Center=�6[   $
��Bold"�6v   $
 Hand��6�   $��
40,10,-2,0q�6�   6�   5#      5$      �� 5%   
   -   5        $��Images/topIco.png��5%      $��0��6+   $��0��68   $��2��6H   $
 Hand��6\   $	��100��6j   $	��100��6v   6�   �� 5'   
   -   5         ��Name$ btnCpu��5'      $��Images/cpu.png��6    $��1��68   $��0��6E   $��2��6U   $
 Hand��6i   $	��100��6w   $	��100��6�   6�   �� 5(   
   -   5        $ btnGpu��5(      $��Images/gpu.png��6!   $��2��69   $��0��6F   $��2��6V   $
 Hand��6j   $	��100��6x   $	��100��6�   6�   �� 5)   
   -   5        	 ��Name$	 MainContent��5)      $��0��5*      $��6��6   $��2��5+      $��6��5,      5-      5.      