   M S B A M L   `   `   `  ����B  >Projet3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Projet3Projet3  5   	       Projet3.GestionAD   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Projet3     5   	     � Title$  	GestionAD��5   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   .��5	      � .+�5
   
   � .+�5      �� -   5         ��Name$ txt_nom��5      $
��Left=�6`   $��	99,74,0,0q�6{    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6'   ��  �� ElementName$
 DATA�� �� Path$ SelectedItem.Nom�6�   �� 5      -   5        $ 
txt_prenom��5      $
��Left=�6f   $��
99,109,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6*   �� $
 DATA��$ SelectedItem.Prenom�6�   �� 5      -   5        $ txt_tele��5      $
��Left=�6g   $��
99,156,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6(   �� $
 DATA��$ SelectedItem.telephone�6�   �� 5      -   5        $ txt_adr��5      $
��Left=�6d   $��
99,222,0,0q�6   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6'   �� $
 DATA��$ SelectedItem.adresse�6�   �� 5      -   5        $ 	txt_email��5      $
��Left=�6d   $��
99,277,0,0q�6   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6)   �� $
 DATA��$ SelectedItem.Email�6�   �� 5      $	��Nom��6   $
��Left=�6"   $��	26,74,0,0q�6=   $	��Top=�6P    J� RenderTransformOrigin$ 1.782,-1.27&�6h   �� 5      $��Prenom��6   $
��Left=�6%   $��
24,105,0,0q�6@   $	��Top=�6T   $ 
0.52,2.873&�6l   �� 5      $��	Telephone��6   $
��Left=�6(   $��
24,152,0,0q�6C   $	��Top=�6W   $ 
0.52,2.873&�6o   �� 5      $��Adresse��6   $
��Left=�6&   $��
24,214,0,0q�6A   $	��Top=�6U   $ 
0.52,2.873&�6m   �� 5      $��Email��6   $
��Left=�6$   $��
24,269,0,0q�6?   $	��Top=�6S   $ 
0.52,2.873&�6k   �� 5      -   5        $��	Supprimer��5      $
��Left=�6)   $��
272,98,0,0q�6D   $	��Top=�6X   $	��100��6�   �� 5      -   5        $��Chercher��5      $
��Left=�6(   $��272,137,0,0q�6C   $	��Top=�6X   $ 0.5,0.5&�6p   $	��100��6�   6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$
 DATA��5      $��	0,323,0,0q�6&   ��69   �� *data+   Columns 5      5      �� 5      -	   5        	 ��Name$	 
btn_Export��5      $��Export��6)   $
��Left=�6:   $	��100��6U   $��272,178,0,0q�6a   $	��Top=�6v   $ -6.385,8.319&�6�   �� 5      -
   5        $	 
btn_import��5      $��Import��6)   $
��Left=�6:   $	��100��6U   $��272,211,0,0q�6a   $	��Top=�6v   $ -6.385,8.319&�6�   6�   5      5       5!      