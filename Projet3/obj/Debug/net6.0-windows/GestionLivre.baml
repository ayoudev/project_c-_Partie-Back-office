   M S B A M L   `   `   `  ����B  >Projet3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Projet3Projet3  5   	       Projet3.GestionLivre   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Projet3     5   	     � Title$  GestionLivre��5   	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�67   .��5	      � .+�5
   
   �� -   5         ��Name$ btn_Ajouter��5
      $��Ajouter��6&   $
��Left=�68   $	��100��6S   $��
336,37,0,0q�6_   $	��Top=�6s   6�   �� 5   
   -   5        $ Btn_Supprimer��5      $��	Supprimer��6(   $
��Left=�6<   $	��100��6W   $��
336,78,0,0q�6e   $	��Top=�6y   6�   �� 5   
   -   5        $ btn_Chercher��5      $��Chercher��6'   $
��Left=�6:   $	��100��6V   $��336,118,0,0q�6b   $	��Top=�6w   6�   �� 5   
   -   5        $ btn_Modifier��5      $��Modifier��6'   $
��Left=�6:   $	��100��6U   $��336,152,0,0q�6b   $	��Top=�6w    J� RenderTransformOrigin$ -1.413,0.002&�6�   6�   �� 5   
   -   5         ��Name$ 	txt_titre��5      $
��Left=�6l   $��
112,44,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6&   ��  �� ElementName$ datagrid_livre�� �� Path$ SelectedItem.titre�6�   �� 5   
   -   5        $ 
txt_auteur��5      $
��Left=�6l   $��
112,84,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6&   �� $ datagrid_livre��$ SelectedItem.Auteur�6�   �� 5   
   -   5        $ 	txt_image��5      $
��Left=�6o   $��112,198,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6'   �� $ datagrid_livre��$ SelectedItem.URLimage�6�   �� 5   
   -   5         ��Name$ 
cmb_nomCat��5      $
��Left=�6M   $��112,156,0,0q�6h   $	��Top=�6}   $	��120��6�   ��6'   �� *CategoryNames+6�   �� 5   
   $��Titre��6   $
��Left=�6    $��	26,44,0,0q�6;   $	��Top=�6N   �� 5   
   $��Auteur��6   $
��Left=�6!   $��	26,80,0,0q�6<   $	��Top=�6O   �� 5   
   $��Disponible :��6   $
��Left=�6'   $��
16,114,0,0q�6B   $	��Top=�6V   �� 5   
   $��Nom Categorie��6   $
��Left=�6(   $��
16,156,0,0q�6C   $	��Top=�6W   �� 5   
   $��Image��6   $
��Left=�6    $��
26,194,0,0q�6;   $	��Top=�6O   $ 
0.553,6.28&�6g   &   System.Windows.Controls.DataGrid  5   
   -	   5        	  Name$	 datagrid_livre��5      $��0,307,10,10q�6H   ��6+   �� *data+
   Columns
 5      5      	� 5   
   -
   5         	�Name$ rd_non��5      $	��Non��6'   $
��Left=�65   $��125,122,0,0q�6P   $	��Top=�6e   	� 5   
   -   5        $ rd_oui��5      $	��Oui��6&   $
��Left=�64   $��257,120,0,0q�6O   $	��Top=�6d   �� 5   
   -   5         ��Name$ 
pictureBox��5      $
��Left=�6$   $	��155��6?   $��
585,47,0,0q�6L   $	��Top=�6`   $	��167��6x   �� 5    
   -   5        $ 
btn_Apload��5       $��Apload��6%   $
��Left=�66   $��645,222,0,0q�6Q   $	��Top=�6f   $ 0.764,2.204&�6�   �� 5!   
   -   5        $ txt_prix��5!      $
��Left=�6i   $��112,245,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6%   �� $ datagrid_livre��$ SelectedItem.prix�6�   �� 5"   
   -   5        $ txt_quantité��5"      $
��Left=�6q   $��112,275,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6(   �� $ datagrid_livre��$ SelectedItem.quantite�6�   �� 5#   
   $
��Prix��6   $
��Left=�6   $��
26,245,0,0q�6:   $	��Top=�6N   $ 0.553,1.812&�6f   �� 5$   
   $��	Quantité��6   $
��Left=�6#   $��
24,271,0,0q�6>   $	��Top=�6R   $ 0.553,1.812&�6j   5&      5'      