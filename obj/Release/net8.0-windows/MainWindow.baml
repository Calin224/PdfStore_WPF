   M S B A M L   `   `   `  ���� E  AStudyStash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:StudyStash
StudyStash      StudyStash.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:StudyStash       � Title$  
MainWindow��$	��500��$
��1280�����	#FF429C9A.���  � RowDefinitions �� $
��Auto ��� $��* �.+� � -     �Name$ 	MainFrame��  � NavigationUIVisibility$ Hidden=��� $��0�� �� Orientation$ 
Horizontal=�$��10q�.+��� -   $��5q�$��10q�$��Cascadia Mono)�
������� J� Opacity$
 0.99Q����	#00000000$	��195��$��Upload���� -   $��
Add images��$��5q�
�������$��20q��� -    ��Name$ CategoryComboBox��$	��314��$��5q����	#00000000�� -   $��Filter��$��5q�
���   �
�������$	��121�����	#00000000$��Cascadia Code)��� -    ��Name$ PdfListView��$��1��$��10,10,10,10q�
������� �� View �� 	 �� AllowsColumnReorder$
	 True��.P��� $
��Name��
 �� Width$	
 400�� �� CellTemplate �� .R��� $ 
Horizontal=�.+���  ��Name$ PdfNameLabel������ *
FileName+��  ��Name$ OpenPdfButton��-   $��Open Pdf��$��Center=�$��Center=�
 � Tag �� *Id+�� $��Category��$	
 150�� �� DisplayMemberBinding �� *
Category+�� $��Action��$	
 150�� �� .R��� $ DeleteButton��-   $��
Delete Pdf�� �� *Id+����  �� 
TargetType" ��.R���  �� CornerRadius$ 10��
�������
������� �� Padding$ 10q�._��� $��Center=�$��Center=��� $��
Date Added��$	
 200�� �� *	DateAdded+