   M S B A M L   `   `   `  ����B  >Projet3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Projet3Projet3  5   	       Projet3.GestionCAT   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Projet3     5   	     � Title$  
GestionCAT��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ btn_ajouter��5
      $��Ajouter��6&   $
��Left=�68   $��
400,81,0,0q�6S   $	��Top=�6g   6   �� 5   
   -   5        $ btn_supprimer��5      $��	Supprimer��6(   $
��Left=�6<   $��
465,80,0,0q�6W   $	��Top=�6k   6�   �� 5   
   -   5        $ btn_chercher��5      $��Chercher��6(   $
��Left=�6;   $��
541,81,0,0q�6V   $	��Top=�6j   6�   �� 5   
   -   5        $ btn_Modifier��5      $��Modifier��6(   $
��Left=�6;   $��
604,81,0,0q�6V   $	��Top=�6j   6�   �� 5   
   -   5         ��Name$ txt_nom��5   P   $
��Left=�6a   $��
122,96,0,0q�6|    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6   ��  �� ElementName$ 	Data_Grid�� �� Path$ SelectedItem.Nom�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	Data_Grid��5      $��	0,151,0,0q�6'   ��6:   �� *data+   Columns 5      5      �� 5   
   -   5         ��Name$	 Nom��5      $	��Nom��6   $
��Left=�6+   $��	57,88,0,0q�6F   $	��Top=�6Y   5      5      