   M S B A M L   `   `   `  ����[  WLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF  5      ^ ZSyncfusion.SfGauge.WPF, Version=29.2.7.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Gauges;assembly=Syncfusion.SfGauge.WpfSyncfusion.UI.Xaml.Gauges 5      ^ ZSyncfusion.SfChart.WPF, Version=29.2.7.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPFSyncfusion.UI.Xaml.Charts 5      D @CpuReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CpuReader.UserControlsCpuReader.UserControls 5	      -   'CpuReader.UserControls.DashboardControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      hlvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF     5      YgaugeGclr-namespace:Syncfusion.UI.Xaml.Gauges;assembly=Syncfusion.SfGauge.Wpf     5      ^
syncfusionGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPF     5      6local$clr-namespace:CpuReader.UserControls     5	      .��5      � -   5          � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5    
   �� $��0��6   $��0��6   $��6��6/   ���	#FF313131$��2q�5!        �� CornerRadius$ 5��64   $��40q�6E   ���	#FF313131._�5"      �� -   5         ��Name$ 
txtMbdName��5"      
�������$��25(�5$      ���	#FF313131$��Center=�5&       �� Padding$ 10q�5'      $��Your Text Here��5(      5)      �� 5+   
   -   5         ��Name$ 	gbCpuName��5+      
�������$��2��6:   $��4��6G   $��0��6X   $��2��6h   $��	50,0,40,0q�6|   .��5,      �� $��20q�6   $��Center=�6%   .+�5-      /  )Syncfusion.UI.Xaml.Gauges.SfCircularGauge  -   5          Name$! CPUtemperatureCircularGauge��5-   (   $	��250��5/   
      Scales 51      -  'Syncfusion.UI.Xaml.Gauges.CircularScale     
StartValue$ 0Q�52      	   EndValue$		 100Q�53      
   RimStrokeThickness$
 20Q�54         LabelOffset$ 50Q�55         	RimStroke �#D50000   Pointers 59   "   /  )Syncfusion.UI.Xaml.Gauges.CircularPointer     PointerType$ NeedlePointer=�68      EnableAnimation$
 True��5:         Value$ 50Q�5;         
RangeStart$ 0Q�5<         NeedlePointerType$ Tapered=�5=         RangeEndOffset$ 0Q�5>      5A      5C      �� 5E       �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5F      �� 
�������$��Current:��63   $��
50,0,55,15q�6C   �� 5G      -   5        $ txtValueTemperature��5G       
�������$	��...��6P   $��5,0,60,0q�6[   5H      �� 5I      -   5         ��Name$ btnCpuDetails��5I       � Cursor$
 Hand��61   
�������$��Center=�6T   ��5J      �� 5K       �� 
TargetType" ��6*   .R�5L      �� ���#D50000$��20q�5N        �� Padding$ 20q�5O   !   ���	#FF313131$��2q�5Q   !   $ 5��5R   !   ._�5T   "   �� $��Center=�63   $��Center=�6P   5U      5V      .��5W   '   	Details5Y      5[      5^      �� 5a   
   -   5        $ 	gbGpuName��5a      
�������$��2��6;   $��4��6H   $��2��6Y   $��2��6i   $��	50,0,40,0q�6~   .��5b      �� $��20q�6   $��Center=�6%   .+�5c        -   5        $! GPUtemperatureCircularGauge��5c   (   $	��250��6M    5e        $ 0Q�5f      $		 100Q�5g      $
 20Q�5h      $ 50Q�5i       �#D50000 5l   "     $ NeedlePointer=�68   $
 True��5m   !   $ 50Q�5n   !   $ 0Q�5o   !   $ Tapered=�5p   "   $ 0Q�5q   !   5s      5u      �� 5y      $ 
Horizontal=�6   $��Center=�66   .+�5z      �� 
�������$��Current:��63   $��
50,0,55,15q�6C   �� 5{      -	   5        $ txtGpuValueTemperature��5{       
�������$	��...��6S   $��5,0,60,0q�6^   5|      �� 5~      -
   5        $ btnGpuDetails��5~      $
 Hand��61   
�������$��Center=�6T   ��5      �� 5�      " ��6*   .R�5�      �� ���#D50000$��20q�5�   "   $ 20q�5�   "   ���	#FF313131$��2q�5�   "   $ 5��5�   "   ._�5�   "   �� $��Center=�63   $��Center=�6P   5�      5�      .��5�   '   	Details5�      5�      5�      �� 5�   
   -   5        $ gbStorageName��5�      
�������$��2��6?   $��4��6L   $��4��6]   $��2��6m   $��	50,0,40,0q�6�   .��5�      �� $��20q�6   $��Center=�6%   .+�5�        -   5        $% StoragetemperatureCircularGauge��5�   (   $	��250��5�       5�        $ 0Q�5�      $		 100Q�5�      $
 20Q�5�      $ 50Q�5�       �#D50000 5�   "     $ NeedlePointer=�68   $
 True��5�   !   $ 50Q�5�   !   $ 0Q�5�   !   $ Tapered=�5�   "   $ 0Q�5�   !   5�      5�      �� 5�      $��	30,20,0,0q�6   .+�5�      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5�      �� 
�������$
��Min:��67   $��
30,0,55,15q�6C   �� 5�      -   5        $ txtStorageMinTemperature��5�   $   
�������$	��...��6Y   $��5,0,60,0q�6d   5�      �� 5�      $ 
Horizontal=�6!   $��Center=�6:   .+�5�      �� 
�������$��Current:��67   $��
20,0,55,15q�6G   �� 5�      -   5        $  txtStorageValueTemperature��5�   $   
�������$	��...��6[   $��5,0,60,0q�6f   5�      �� 5�      $ 
Horizontal=�6!   $��Center=�6:   .+�5�      �� 
�������$
��Max:��67   $��
36,0,55,15q�6C   �� 5�      -   5        $ txtStorageMaxTemperature��5�   $   
�������$	��...��6Y   $��5,0,60,0q�6d   5�      5�      5�      5�      5�      5�      