   M S B A M L   `   `   `  ����E  AIISManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IISManager
IISManager  5   	       IISManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:IISManager     5   	     � Title$  
MainWindow��5   	   $	��900��6   $	��600��6+   $	��900��6;   $	��600��6G    � WindowStartupLocation$ CenterScreen=�6T   .��5
      � -   5         �Name$ RootContainer��5
       � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5   
   �� $	��IIS��6   .��5   
   � $��0��6    � RowDefinitions 5      �� 5      $��30 �6    �� 5      .+�5      �� $��	Reset IIS��6   $��0��6-   $��5q�6p   ��6:   �� *#!OnResetIISButtonClickEventHandler+6p   �� 5      $��0��6   $��Bottom=�6)   �� 5      -   5         ��Name$ 	SitesList��5   ,    �� SelectedIndex$ 0��6   $��1��6?   $
��Auto��6L   $��0q�6Z   ��6n   �� *SiteManagerViewModels+��5      �� 5      .R�5      �� ��6(   �� *
SiteName+5      5      5      5      � 5    
   $��1��6   .+�5!         IISManager.SiteManager   � DataContext 6    ��  �� ElementName$ 	SitesList��	 �� Path$	 SelectedItem�5"      5#      5$      