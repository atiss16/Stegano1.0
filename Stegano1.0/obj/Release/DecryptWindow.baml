   M S B A M L   `   `   `  ���� E  AStegano1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Stegano1._0Stegano1._0      Stegano1._0.DecryptWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:Stegano1._0     -     � Title$  DecryptWindow��$	��450��$	��800�� � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=����� -   imgEncr�� �� ImageSource$ 	img/1.jpg�� j� Stretch$ UniformToFill=� j� TileMode$
 None=�.���� .+���  �� Orientation$ 
Horizontal=�$��0,0,0,20q�.+��� -    ��Name$ btnReturnFromDecrypt��$
��Left=�$��10,5,0,0q�$��40��$��40��   	btnReturn#��[  .��←�� $��20(�$��Center=����#2b2b33$��
250,10,0,0q�.��#!Извлечь сообщение�� -   $ btnCloseDecrypt��  btnClose#��[ $��Right=�$��	255,5,0,0q�$��40��$��40���� $ 
Horizontal=�.+��� .+��� ���#ff7285$��10,5,0,0q����	#B52b2b33.��$"Извлеченный текст:�� -   	 ��Name$	 tbDecryptText��$	��400��$	��240��
 �� TextWrapping$

 Wrap=�$��10,0,0,0q� �� 
IsReadOnly . " �� VerticalScrollBarVisibility$ Visible=� �� AcceptsReturn . �� -   $ btnSaveText��{�.  $��	20,15,0,0q�$
��Left=�$	��200��  btnSaveText#��[ �� -    ��Name$ 
lblExample��$	��400��$��40��
�������$��10,5,0,0q��� -   $ lblExample2��$	��400��$��40��
��������� $	��380��.+��� -	    ��Name$ 	imgDecode��$	��290��$	��265��$��40,0,0,0q��� $ 
Horizontal=�$��	35,20,0,0q�.+��� -
   $ btnBrowseImg��  btnBrowseImg#��[ $	��175��.��Загрузить�� -   $ 
btnDecrypt��  
btnDecrypt#��[ $��80��$��40,0,0,0q�.��Расшифровать