   M S B A M L   `   `   `  ����E  AStudyStash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:StudyStash
StudyStash  5   	       StudyStash.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:StudyStash     5   	     � Title$  
MainWindow��5   	   $
��1000��6   $
��1280��6*   ���	#FF429C9A.��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
    � -   5          �Name$ 	MainFrame��5        � NavigationUIVisibility$ Hidden=�6#   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� -   5        $��5q�5      $��10q�6    $��Cascadia Mono)�6-   
������� J� Opacity$
 0.99Q�6_   ���	#00000000$	��195��5   -   $��Upload��6Q   5      �� 5      -   5        $��
Add images��5   -   $��5q�6B   
�������$��20q�6d   6s   �� 5      -   5         ��Name$ CategoryComboBox��5      
�������$	��314��6H   $��5q�6T   ���	#000000006_   �� 5      -   5        $��Filter��5      $��5q�6E   
���   �
�������$	��121��6z   ���	#00000000$��Cascadia Code)�6�   �� 5      -   5        $��View all items��5      $��5q�6I   $��10q�6T   
�������$	��200��6x   $��Cascadia Code)�6�   6�   5       �� 5"   
   -   5         ��Name$ PdfListView��5"      $��1��6(   $��10,10,10,10q�65   
������� �� View 5#      �� 5$      	 �� AllowsColumnReorder$
	 True��6   .P�5%      �� $
��Name��6%   
 �� Width$	
 400��63   6A   �� 5&      $��Category��6%   $	
 150��6a    �� DisplayMemberBinding 67   �� *
Category+6o   �� 5'      $��Open Pdf��6%   $	
 150��67    �� CellTemplate 5(      �� 5)      .R�5*   "   ��  ��Name$ OpenPdfButton��6e   -   5        $��Open Pdf��5*   ?   $��Center=�6|   $��Center=�6�   
 � Tag 6R   �� *Id+��5+   &   �� 5,   *    �� 
TargetType" ��6:   .R�5-   .   ��  �� CornerRadius$ 10��65   
���r���
���r��� �� Padding$ 10q�6p   ._�5.   2   �� $��Center=�6C   $��Center=�6`   6}   5/   /   50   +   52   #   53      55      �� 56      $��Action��6%   $	
 150��65    57      �� 58      .R�59   "   �� $ DeleteButton��6)   -	   5        $��
Delete Pdf��59   ?    6l   �� *Id+��5:   &   �� 5;   *   " ��6:   .R�5<   .   �� $ 10��65   
���r���
���r���$ 10q�6p   ._�5=   2   �� $��Center=�6C   $��Center=�6`   6}   5>   /   5?   +   5A   #   5B      5D      �� 5E      $��
Date Added��6%   $	
 200��6d    69   �� *	DateAdded+6r   5F      5H      5I      5J      