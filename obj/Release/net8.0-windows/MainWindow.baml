   M S B A M L   `   `   `  ���� D  @CpuReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CpuReader	CpuReader      CpuReader.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:CpuReader     LmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes       � Topmost$
  True�� � Title$ 
CpuMonitor��$	��800��$	��750��.��� -   ���	#FF151515 � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -    ��Name$ 
txtCpuName��$��0��
��� ���$��Center=�$��Center=�$��	0,25,0,15q�$��18(�$
��Bold"��� $��1��$��	0,25,0,25q�
��� ����� $��2�� �� Orientation$ 
Horizontal=�$��Center=�$��	10 0 0 50q�.+��� .+��� $��Vitesse du processeur��
��� ���$��10q�.���� -   $ 	txtClocks��
��� ���$��Center=�$��15q��� .+��� $��Charge sur le processeur��
��� ���$��10q�.���� -   $ txtLoads��
��� ���$��Center=�$��15q��� .+��� $��Consommation de watts��
��� ���$��10q�.���� -   $ txtWatts��
��� ���$��Center=�$��15q�� -    �Name$ 	pbCpuTemp��$��3��$��25�� � Minimum$ 0Q� � Maximum$	 110Q�$
��10,0q�
���   �
��� ���$	��610���� $��3��$��Center=�$��Center=�
�����������  �� ElementName$ 	pbCpuTemp��	 �� Path$	 Value�
 �� StringFormat$
 	{0:0.0}°��$��14(��� $��4��$��Center=�$ 
Horizontal=�.+��� -   $ txtCpuMinTemperature��
��� ���$��15q��� -   $ txtCpuMaxTemperature��
��� ���$��15q�