   M S B A M L   `   `   `  ����  AutoDocs    AutoDocs.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	   $
��1000��6   $
��1000��6)    � WindowState$ Normal=�68    � WindowStyle$
 None=�6M    � 	Resources 5	         DescriptionStyle �� 
TargetType �� Property �� Value  ButtonStyle  DirectoryInputStyle��%�  &	        &	 �     &	 �    �� 5
   
   " ��6)   .�5      ��  � ��$ 26(�6)   �� 5       � ��
 �����6+   �� 5       � ��$ 20q�6'   �� 5       � ��$
 Wrap=�6-   5      �� 5   
   " ��6$   .�5      ��  � ��$ 22(�6)   �� 5       � ��
 ����6+   �� 5       � ��
 �����6+   �� 5       � ��$ 30,15q�6(   �� 5       � ��$ 20q�6'   �� 5       � ��$ 0q�60   5      �� 5   
   " ��6,   .�5      ��  � �� �#b5d1ff6+   �� 5       � ��$ 22(�6)   �� 5       � ��$ 10q�6(   �� 5       � ��$ 60��6'   �� 5       � ��$ 	0,0,128,0q�6'   �� 5        � ��$ Center=�62   5!      5"      .��5$      � 
������� � RowDefinitions 5%   
   �� 5&      $
��Auto �6   �� 5(      $��* �6   �� 5*      $
��Auto �6   .+�5/   
   �� $��0��6    �� Padding$ 20q�6   $	��Top=�6+   
�������._�50      � 	 � ColumnDefinitions	 51      �� 52      $
��Auto �6'   �� 53      $��* �6'   .+�57      �� $	��100��6   $��20q�6%   ��58      �� 59      
 �� 	UriSource
 6&   �� *TitleImageDirectory+5;      �� 5>      $��1��6   $��Right=�6(   $	��100��6D   $��20q�6Q   ��5?      �� 5@      
 6&   �� *LogoImageDirectory+5B      5D      5E      �� 5H   
   $��1��6   $ 20q�6   
�������._�5I      �� #��[  6   ecAutoDocs is an application designed to automatically generate documentation based on your codebase.�� 5K      ��By analyzing your code, it produces structured documentation that gives you insights into your namespaces, classes, functions, variables, and more.�� 5N      ecThis ensures that you always have up-to-date and easily accessible documentation for your projects.�� 5P      �� 5Q      jhUse the text field bellow to enter the folder directory of your project, or use the button to locate it.5S      5T      �� 5W   
   $��2��6   $ 20q�6   $��Bottom=�6+   
�������._�5X      � 	 5Y      �� 5Z      $
��Auto �6'   �� 5[      $��* �6'   �� 5\      $
��Auto �6'   .+�5`      �� -   5        $��btnOpenFolder��5`      $��Open Folder��5a      $��Center=�5b      #��[ 5d      $��0��5e      �� 5h      -   5        $��txtDirectory��5h      $��1��5j      $��2��5k      #��[ 5l      ��5i      �� *	Directory+ �� UpdateSourceTrigger$ PropertyChanged=�5l      �� 5o      -   5        $��	btnAction��5o      $��Go��5p      $��Center=�5q      $��2��5s      ��5t      �� 5u      " ��6     �� BasedOn# [ 64   .�5v      ��  � �� �#ff456d6;    �� Triggers 5w      �� 5x   "    �� Binding 6.   �� *IsDirectoryValid+ �� Value True6S   .a�5y   &   ��  � ��
 ����6C   5z   #   5|      5~      5�      5�      5�      5�      