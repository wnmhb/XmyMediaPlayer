   M S B A M L   `   `   `  ����I  EWnmMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WnmMediaPlayerWnmMediaPlayer  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089b ^Microsoft.Windows.Shell, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35   HeaderButton  �� 
TargetType �� Property �� Value �� 
TargetType �Name J� SnapsToDevicePixels �� Triggers P� Property P� Value3   -System.Windows.Media.Effects.DropShadowEffect	    Color
    	Direction    ShadowDepth    
BlurRadius  HeaderCloseButton �� BasedOn �� Triggers'   !WnmMediaPlayer.CustomChromeWindow*  $Microsoft.Windows.Shell.WindowChrome   ResizeBorderThickness   GlassFrameThickness   CaptionHeight �� RelativeSource �� AncestorType   CornerRadius   CornerRadius �� CornerRadius J� Effect � RowDefinitions   CaptionBackground   CaptionHeight �� Path   IsHitTestVisibleInChrome/  )Microsoft.Windows.Shell.SystemParameters2   Current �� Source �� Orientation  ��Name! ��Name"   ResizeGripDirection# �� 
TargetName$ ]� 
Conditions% �� Property& �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      Kshell?http://schemas.microsoft.com/winfx/2006/xaml/presentation/shell  5      &localclr-namespace:WnmMediaPlayer  5      %�  &	        &	 �    7   '  9   7   7   7   7  �� 5      "  ��6!   .�5   
   ��  � ��$ 18(�6%   �� 5	   
    � ��$ Webdings)�6'   �� 5
   
    � ��$ 5,0,0,0q�6#   �� 5   
    � ��$ Right=�60   �� 5   
    � ��$	 Top=�6.   �� 5   
    � �� �#FDFDFD6'   �� 5   
    � |� .  6&   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      � $ btnGrid��6   .+�5      �� #��z��6+   ��. # z 6�   #��z��6�   5       5      P� 5       �@J�IsMouseOver . . �5      ��  �@J�Effect 5   "      5   &   $	 White��67   $
 0Q�6E   $ 0Q�6S   $ 20Q�6c   5      5      5      5       5!      �� 5#      "  ��6&   8    5$   
   P� 5%       �@J�IsMouseOver . . �5&      ��  � �� �	#FFF9EE906/   5'      5)      �� 5-      "   6   .�5.   
   ��  �@�WindowStyle$
 None=�6(   �� 5/   
    �@�AllowsTransparency .  6/   �� 50   
    � ��
 ���� 6'   �� 51   
    � ��$ 1q�6,   �� 52   
    � �� �#6666666(   �� 53   
    �@ CaptionHeight$ 20Q�6*   �� 55   
    �@ WindowChrome 56        57      $ 6q�6%   $ 0q�6?    58      �� *CaptionHeight+ �� *FindAncestor+"   59      �� *CornerRadius+ �� *FindAncestor+"  5:      5<      �� 5>   
    � �� 5?      �� 5@      "  6#   .R�5B      �� $��PART_ClientAreaBorder��6   # z 6:   # z 6h   #��z��5C      #��z��6R   ._�5D      �  5E      �� 5F   "   $
��auto �60   6@   �� 5G   "   $��* �60   6=   .+�5J      �� $��PART_ClientHeaderBorder��6%   $��0,0,0,1q�6D   ���#1A4A7B#��z 6t   ._�5K   "   � $	��Top=�6'   #��z 6@   ��5L   '   �� $= 7(shell:WindowChrome.WindowChrome).ResizeBorderThickness� �� *TemplatedParent+.+�5M   &   �� $��	PART_Icon��6,    . $
��Left=�6q   ��5N   0   ��  �� *TemplatedParent+$
 Icon���5O   0   �� $ SmallIconSize.Width�# Z ��5P   0   �� $ SmallIconSize.Height�# Z �� 5Q   &   $��
PART_Title��60   $��Center=�6B   $
��Left=�6]   $��20,0,0,0q�6x   #��z��5R   }   ��60   ��  �� *TemplatedParent+$ Title�6�   �� 5T   &   $ 
Horizontal=�61   $��Right=�6J   ��5U   5   �� $) #WindowCaptionButtonsLocation.Height�# Z .+�5V   *   �� $��PART_MinimizeWindowButton��61   |�.   . $0��*shell:SystemCommands.MinimizeWindowCommand��5X   1   8��  $��31��5Z   1   $��Webdings)�6<   $��0��6R   5[   +   �� 5\   *   $��PART_MaximizeWindowButton��61   |�.   . $0��*shell:SystemCommands.MaximizeWindowCommand��5^   1   8�� $��2,0,0,0q�5`   1   $��31��6B   $��Webdings)�6M   $��1��6c   5a   +   �� 5b   *   $��PART_RestoreWindowButton��61   |�.   . $/��)shell:SystemCommands.RestoreWindowCommand��5d   1   8�� $��2,0,0,0q�5f   1   $��31��6B   $��Webdings)�6M   $��2��6c   $y�	Collapsed=�5g   1   5h   +   �� 5i   *   $��PART_CloseWindowButton��61   |�.   . $-��'shell:SystemCommands.CloseWindowCommand��5k   1   8�� $��2,0,0,0q�5m   1   $��31��6B   $��Webdings)�6N   $��r��6d   5n   +   5o   '   5p   #   5q      �� 5s      $  PART_ClientContentBorder��6%   
�������$��1��6Z   ._�5t   "   � .+�5u   &   �� .u�5v   *   �� $��PART_RootContentPresenter��6;   5w   '   �� 5x   &   $! WindowResizeGrip��61   $" BottomRight=�5y   )   $��Right=�5z   )   $��Bottom=�6F   $y�	Collapsed=�5{   )   ��.  6@   5|   #   5}      5~      5       5�      P� 5�       �@�WindowState$ 	Maximized=�69   . �5�      �� $# PART_MaximizeWindowButton��6%    � y�$ 	Collapsed=�6b   �� 5�      $# PART_RestoreWindowButton��6%    � y�$ Visible=�6a   5�      P� 5�       �@�
ResizeMode$ CanMinimize=�68   . �5�      �� $# PART_MaximizeWindowButton��6%    � {� .  6a   �� 5�      $# PART_RestoreWindowButton��6%    � {� .  6`   5�      P� 5�       �@�
ResizeMode$ NoResize=�68   . �5�      �� $# PART_MinimizeWindowButton��6%    � y�$ 	Collapsed=�6b   �� 5�      $# PART_MaximizeWindowButton��6%    � y�$ 	Collapsed=�6b   �� 5�      $# PART_RestoreWindowButton��6%    � y�$ 	Collapsed=�6a   5�      P� 5�       62   Z�  �@�Icon. �5�      �� $# 	PART_Icon��6%    � ��$R L/BIZNEST.Education.CloudTest.Controls;component/Images/DefaultSystemIcon.png��6N   5�      ]� 5�      $ 5�      �� 5�   "   % �@�
ResizeMode$& CanResizeWithGrip=�6I   �� 5�   "   % �@�WindowState$& Normal=�6J   ./�5�      �� $# WindowResizeGrip��6%    � y�$ Visible=�6Y   5�      5�      5�      5�      5�      