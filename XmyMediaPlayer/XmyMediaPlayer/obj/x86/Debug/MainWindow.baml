   M S B A M L   `   `   `  ����I  EXmyMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:XmyMediaPlayerXmyMediaPlayer  5   	   R NXmyMediaPlayer.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbFclr-namespace:XmyMediaPlayer.Controls;assembly=XmyMediaPlayer.ControlsXmyMediaPlayer.Controls 5   	       XmyMediaPlayer.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .localclr-namespace:XmyMediaPlayer     5   	   ZcontrolFclr-namespace:XmyMediaPlayer.Controls;assembly=XmyMediaPlayer.Controls     5   	   0  *XmyMediaPlayer.Controls.CustomChromeWindow    CornerRadius$  2��5   	      CaptionHeight$ 22Q�6      DefaultColor   CaptionBackground# [  6-   
������� � Icon$2 ,/XmyMediaPlayer;component/XmyMediaPlayer.ico��5   	    � Title$ 心梦缘播放器��5	   	   $	��560��5
   	   $	��420��6   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,    � 	Resources 5   
   &    XmyMediaPlayer.TimeSpanConverter  TimeSpanConverter��%   &	         5      6B   5      .+�5   
   �  5      �� 5      $��8* �6    �� 5      $��25 �6    .+�5      �� $��1q�6   #��[  6)   ._�5      r� -   5         r�Name$ mediaElement��5       r� LoadedBehavior$ Manual=�65   	 r� Volume	 6M   �� 
 �� ElementName$
 volumeSlider�� �� Path$ Value�5      5       � 5"      $��1��6   
������� � ColumnDefinitions 5#      �� 5$      $
��auto �6'   66   �� 5%      $��* �6'   63   �� 5&      $
��auto �6'   66   �� 5'      $
��auto �6'   66   .+�5*      �� -   5        $��0��5*      $��7��6)    � ToolTip$ 后退��65     btnMediaControlStyle#��[ 6B   6p   �� 5+      -   5        $��2��5+      $��8��6)   $ 快进��65   #��[ 6B   6p   �� 5-      -   5        $��slider��5-      $��1��6'   $	��0,5q�6�     MediaPlayerSlider#��[ 5.      $��Center=�6D    � Value 5-   7   �� *CurrentTime+ �� Mode$ TwoWay=� � Maximum 6b   �� *DurationTime+$ OneWay=�5/   @   �� 51      $��3��6   $��0,2,0,0q�6.    �� Orientation$ 
Horizontal=�6?   $��Center=�6X   .+�52      �� 
�������$
��Left=�6�   $	��5,0q�6�   ��6    �� *Value+ �� 	Converter# [ $ OneWay=�$
 slider��6�   �� 53      
�������/66   �� 54      
�������$��Right=�6�   $	��5,0q�6�   ��6    �� *DurationTime+$ OneWay=�# [ 6�   55      56      57      � 59   
   $��1��6   $��60��6   .+�5;      �� $ 
Horizontal=�6   $��40��63   $��Center=�6?   $��Center=�6\   $��20,0,0,0q�6w   .+�5=      �� -   5         ��Name$ btnPreMediaFile��5=      #��[ 64   $��9��6b   $��25(�6n   6~   d� 5>      -   5         d�Name$ PlayControl��5>        btnMediaPlayStyle#��[ 64   $��;��6b    d� 	IsChecked 5?      �� *IsPlayPause+$ TwoWay=�5@      �� 5A      -   5        $ btnNextMediaFile��5A      #��[ 64   $��:��6b   $��25(�6n   6~   5C      �� 5E      $��2��6   $ 
Horizontal=�6'   $��Right=�6@   $��Center=�6\   $��5q�6w   .+�5F      �� $ 音量��6   $��X��6)   $��25(�62   $��Webdings)�6@   #��[  6V   6�   �� 5G      -   5         ��Name$ volumeSlider��5G       � Minimum$ 0Q�6/   $ 1Q�6;   $	 0.5Q�6G   $	��160��6S   $��Center=�6_     CustomStyleForSlider#��[ 6z   5H      5I      5J      5K      