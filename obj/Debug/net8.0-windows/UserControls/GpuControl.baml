   M S B A M L   `   `   `  ����[  WLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF  5      D @CpuReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CpuReader.UserControlsCpuReader.UserControls 5      ^ ZSyncfusion.SfGauge.WPF, Version=29.2.7.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Gauges;assembly=Syncfusion.SfGauge.WpfSyncfusion.UI.Xaml.Gauges 5   
   ^ ZSyncfusion.SfChart.WPF, Version=29.2.7.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPFSyncfusion.UI.Xaml.Charts 5	   	   '   !CpuReader.UserControls.GpuControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      hlvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF     5      6local$clr-namespace:CpuReader.UserControls     5      YgaugeGclr-namespace:Syncfusion.UI.Xaml.Gauges;assembly=Syncfusion.SfGauge.Wpf     5   
   ^
syncfusionGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPF     5	   	   .��5      � -   5          � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5    
   �� $��0��6   $��0��6   $��6��6.   ���	#FF313131$��2q�5!       �� CornerRadius$ 5��6-   $��40q�6>   ���	#FF313131._�5"      �� -   5         ��Name$ 
txtGpuName��5"      
�������$��25(�5$      ���	#FF313131$��Center=�5&       �� Padding$ 10q�5'      $��Your Text Here��5(      5)      �� 5*   
   -   5        $ 
txtGpuData��5*      
�������$��1��5,      $��0��6   $��8��6   $��4��62   $��10q�5-      $�� ��5.      �� 5/   
   -   5        $ 
txtGpuInfo��5/      
�������6(   �� 52   
   $��Core Temperature��6   
�������$��2��6A   $��4��6N   $��0��6_   $��3��6o   $��	50,0,40,0q�6�   .��53      �� $��20q�6   $��Center=�6%   .+�54      /  )Syncfusion.UI.Xaml.Gauges.SfCircularGauge  -   5          Name$! GputemperatureCircularGauge��54   (   $	��250��56   
      Scales 58      -  'Syncfusion.UI.Xaml.Gauges.CircularScale     
StartValue$ 0Q�59         EndValue$	 100Q�5:      	   RimStrokeThickness$	 20Q�5;      
   LabelOffset$
 50Q�5<         	RimStroke �#D50000   Pointers 5@   "   /  )Syncfusion.UI.Xaml.Gauges.CircularPointer     PointerType$ NeedlePointer=�68      EnableAnimation$
 True��5A         Value$ 50Q�5B         
RangeStart$ 0Q�5C         NeedlePointerType$ Tapered=�5D         RangeEndOffset$ 0Q�5E      5H      5J      �� 5O      $��	30,20,0,0q�6   .+�5P      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   .+�5Q      �� 
�������$
��Min:��67   $��
30,0,55,15q�6C   �� 5R      -   5        $ txtGpuMinTemperature��5R   $   
�������$	��...��6U   $��5,0,60,0q�6`   5S      �� 5W      $ 
Horizontal=�6!   $��Center=�6:   .+�5X      �� 
�������$��Current:��67   $��
20,0,55,15q�6G   �� 5Y      -   5        $ txtGpuValueTemperature��5Y   $   
�������$	��...��6W   $��5,0,60,0q�6b   5Z      �� 5]      $ 
Horizontal=�6!   $��Center=�6:   .+�5^      �� 
�������$
��Max:��67   $��
36,0,55,15q�6C   �� 5_      -   5        $ txtGpuMaxTemperature��5_   $   
�������$	��...��6U   $��5,0,60,0q�6`   5`      5a      5d      5g      �� 5j   
   $��
Core Clock��6   
�������$��2��6;   $��4��6H   $��3��6Y   $��3��6i   $��	50,0,40,0q�6}   .��5k      �� $��20q�6   $��Center=�6%   .+�5l        -	   5        $ GpuCoreClockCircularGauge��5l   (   $	��250��6L    5n        $ 0Q�5o      $	 100Q�5p      $	 20Q�5q      $
 50Q�5r       �#D50000 5v   "     $ NeedlePointer=�68   $
 True��5w      $ 50Q�5x      $ 0Q�5y      $ Tapered=�5z      $ 0Q�5{      5~      5�      �� 5�      $��	30,20,0,0q�6   .+�5�      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5�      �� 
�������$
��Min:��67   $��
30,0,55,15q�6C   �� 5�      -
   5        $ txtClockMin��5�   $   
�������$	��...��6L   $��5,0,60,0q�6W   5�      �� 5�      $ 
Horizontal=�6!   $��Center=�6:   .+�5�      �� 
�������$��Current:��67   $��
20,0,55,15q�6G   �� 5�      -   5        $ txtClockValue��5�   $   
�������$	��...��6N   $��5,0,60,0q�6Y   5�      �� 5�      $ 
Horizontal=�6!   $��Center=�6:   .+�5�      �� 
�������$
��Max:��67   $��
36,0,55,15q�6C   �� 5�      -   5        $ txtClockMax��5�   $   
�������$	��...��6L   $��5,0,60,0q�6W   5�      5�      5�      5�      5�      5�      