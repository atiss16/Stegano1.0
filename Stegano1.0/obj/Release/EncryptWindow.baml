   M S B A M L   `   `   `  ���� E  AStegano1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Stegano1._0Stegano1._0      Stegano1._0.EncryptWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:Stegano1._0     -     � Title$  EncryptWindow��$	��450��$	��800�� � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�����  �� ImageSource$ 	img/1.jpg�� j� Stretch$ UniformToFill=� j� TileMode$
 None=�.���� .+���  �� Orientation$ 
Horizontal=�$��0,0,0,10q�.+��� -    ��Name$ btnReturnFromEncrypt��$
��Left=�$��10,5,0,0q�$��40��$��40��   	btnReturn#��[  .��←�� $��20(�$��Center=����#2b2b33$��
250,10,0,0q�.��!Скрыть сообщение�� -   $ btnCloseEncrypt��  btnClose#��[ $��Right=�$��	265,5,0,0q�$��40��$��40���� $ 
Horizontal=�.+��� .+��� ���#ff7285$��	10,25,0,0q����	#B52b2b33.��Напишите текст:�� -   	 ��Name$	 tbTextForEncode��$	��400��$	��180��
 �� TextWrapping$

 Wrap=�$��10,0,0,0q� �� 	MaxLength$ 562497��" �� VerticalScrollBarVisibility$ Visible=� �� AcceptsReturn . �� $ 
Horizontal=�$��	10,15,0,0q����	#CC2b2b33.+��� -    ��Name$ lblCountOfSymbols��$	��200��$��50�����#ff7285�� -   $ lblAllowableAmount��$	��200��$��50�����#ff7285�� $ 
Horizontal=�$��	15,20,0,0q�.+��� -   $ btnBrowseText��  btnBrowseText#��[ $	��120��$��25��$��0,0,0,0q��� -   $ btnCrypt��  
btnEncrypt#��[ $��60��$��25��$��30,0,0,0q�.��Скрыть�� -	   $ lbltest1��$��10,5,0,0q�$	��400��
�������$��30��$��10(��� -
   $ lbltest2��$	��400��
�������$��30��$��10(��� $	��380��.+��� -    ��Name$ 	imgEncode��$	��290��$	��290��$��10,0,0,0q��� $ 
Horizontal=�$��	40,25,0,0q�.+��� -   $ btnBrowseImg��  btnBrowseImg#��[ $	��180��.��Загрузить�� -   $ 
btnSaveImg��  btnSave#��[ $��90��$��30,0,0,0q�.��Сохранить