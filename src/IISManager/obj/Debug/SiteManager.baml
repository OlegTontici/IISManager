   M S B A M L   `   `   `  ����E  AIISManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IISManager
IISManager  5          IISManager.SiteManager   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:IISManager     5        � 	Resources  5	       �� 
TargetType��%+   '��       �� 5
   
   " ��6   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��130 �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��14(�6+   ��6   �� *Name+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��	Status : ��6   �� 5      ��6   �� *Status+5      5      �� 5   
   $��Site Management��6   $��1��6,   .��5      �� .+�5      �� $��Start��6   ��6)   �� *&$OnSiteStartButtonClickedEventHandler+�� 5      $
��Stop��6   ��6(   �� *%#OnSiteStopButtonClickedEventHandler+�� 5      $��Restart��6   ��6+   �� *(&OnSiteRestartButtonClickedEventHandler+5      5       �� 5!   
   $��Site Applications��6   $��2��6/   .��5"      �  � ColumnDefinitions 5#      �� 5$      $
��0.3* �6'   �� 5%      .+�5'      �� -   5         ��Name$ Applications��5(      ��5)      �� *SiteApplications+ �� SelectedIndex 5*      �� *SelectedApplicationIndex+��5+      �� 5,      .R�5-      �� ��6(   �� *Info.ApplicationName+5.      50      #   IISManager.ApplicationManager  51      -   5          Name$ 
AppManager��52      $��1��53       � DataContext 54      �� 	 �� ElementName$	 Applications��
 �� Path$
 SelectedItem�55      56      �� 57   
   $��Full Recycle��6   $��2��6(   $��3��6<    � ToolTip$? 9Stop the site,recycle application pool and start the site��6I   58      59      