   M S B A M L   `   `   `  ����D  @CpuReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CpuReader.UserControlsCpuReader.UserControls  5      [ WLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF 5      ^ ZSyncfusion.SfGauge.WPF, Version=29.2.7.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Gauges;assembly=Syncfusion.SfGauge.WpfSyncfusion.UI.Xaml.Gauges 5      ^ ZSyncfusion.SfChart.WPF, Version=29.2.7.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPFSyncfusion.UI.Xaml.Charts 5	      '    !CpuReader.UserControls.CpuControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:CpuReader.UserControls     5      hlvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF     5      YgaugeGclr-namespace:Syncfusion.UI.Xaml.Gauges;assembly=Syncfusion.SfGauge.Wpf     5      ^
syncfusionGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPF     5	      ]	 YSyncfusion.Shared.WPF, Version=29.2.7.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c891chart!http://schemas.syncfusion.com/wpf   	 5
      .��5      � -   5          � ColumnDefinitions  5   
   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5!   
   �� $��0��6   $��0��6   $��6��6/   ���	#FF313131$��2q�5"        �� CornerRadius$ 5��64   $��40q�6E   ���	#FF313131._�5#      �� -   5         ��Name$ 
txtCpuName��5#      
�������$��25(�5%      ���	#FF313131$��Center=�5'       �� Padding$ 10q�5(      $��Your Text Here��5)      5*      �� 5+   
   $��TEMPERATURE��6   
�������$��1��6;   $��3��6H   $��0��6Y   $��2��6i   $��	0,-50,0,0q�6~   $	��300��6�   $	��400��6�   .��5,      �� .+�5-      /  )Syncfusion.UI.Xaml.Gauges.SfCircularGauge  -   5          Name$ temperatureCircularGauge��5-   (   $	��250��5/         Scales 51      -  'Syncfusion.UI.Xaml.Gauges.CircularScale     
StartValue$ 0Q�52   !      EndValue$	 100Q�53   !   	   RimStrokeThickness$	 20Q�54   !   
   LabelOffset$
 50Q�55   !      	RimStroke �#D50000   Pointers 59   "   /  )Syncfusion.UI.Xaml.Gauges.CircularPointer     PointerType$ NeedlePointer=�68      EnableAnimation$
 True��5:         Value$ 50Q�5;         
RangeStart$ 0Q�5<         NeedlePointerType$ Tapered=�5=          RangeEndOffset$ 0Q�5>      5A      5C      �� 5E       �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5F      �� 
�������$
��Min:��63   $��	0,20,40,0q�6?   �� 5G      -   5        $ txtMinTemperature��5G       
�������$	��...��6N   $��20q�6Y   5H      �� 5J      $ 
Horizontal=�6   $��Center=�66   .+�5K      �� 
�������$��Current:��63   $��
20,0,55,15q�6C   �� 5L      -   5        $ txtValueTemperature��5L       
�������$	��...��6P   $��5,0,60,0q�6[   5M      �� 5O      $ 
Horizontal=�6   $��Center=�66   $��	0,10,0,40q�6S   .+�5P      �� 
�������$
��Max:��63   $��0,0,40,0q�6?   �� 5Q      -   5        $ txtMaxTemperature��5Q       
�������$	��...��6N   $��
20,0,20,10q�6Y   5R      5U      5X      �� 5^   
   $��POWER��6   
�������$��1��66   $��3��6C   $��1��6T   $��3��6d   $	��300��6y   $	��400��6�   $��
20,-50,0,0q�6�   .��5_      �� .+�5`        -   5        $ wattageCircularGauge��5`   (   $	��250��6F    5b        $ 0Q�5c   !   $	 100Q�5d   !   $	 20Q�5e   !   $
 50Q�5f   !    �#D50000 5j   "     $ NeedlePointer=�68   $
 True��5k   %   $ 50Q�5l   %   $ 0Q�5m   %   $ Tapered=�5n   %   $ 0Q�5o   %   5q      5s      �� 5t      $ 
Horizontal=�6   $��Center=�66   .+�5u      �� 
�������$
��Min:��63   $��	0,20,40,0q�6?   �� 5v      -   5        $ txtMinWattage��5v       
�������$	��...��6J   $��20q�6U   5w      �� 5y      $ 
Horizontal=�6   $��Center=�66   .+�5z      �� 
�������$��Current:��63   $��
20,0,55,15q�6C   �� 5{      -	   5        $ txtCurrentWattage��5{       
�������$	��...��6N   $��5,0,60,0q�6Y   5|      �� 5      $ 
Horizontal=�6   $��Center=�66   $��	0,10,0,40q�6S   .+�5�      �� 
�������$
��Max:��63   $��0,0,40,0q�6?   �� 5�      -
   5        $ txtMaxWattage��5�       
�������$	��...��6J   $��
20,0,20,10q�6U   5�      5�      5�      �� 5�   
   $
��Load��6   
�������$��1��65   $��4��6B   $��3��6S   $��3��6c   $��100,-95,60,0q�6x   $	��500��6�   .��5�      5  /LiveChartsCore.SkiaSharpView.WPF.CartesianChart  $��3��5�      $��0��5�      $��6��5�         Series 5�   !   �� *LoadChart.Series+   XAxes 5�      �� *LoadChart.XAxes+   YAxes 5�      �� *LoadChart.YAxes+5�      5�      �� 5�   
   $��	Frequency��6   
�������$��4��6<   $��6��5�      $��0��5�      $��6��5�      $��60q�6   .��5�         6!   �� *FrequenciesChart.Series+ 5�      �� *FrequenciesChart.XAxes+ 5�      �� *FrequenciesChart.YAxes+5�      5�      5�      