   M S B A M L   `   `   `  ����B  >Projet3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Projet3Projet3  5   	       Projet3.GestionRes   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Projet3     5   	     � Title$  
GestionRes��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65   .��5	      � .+�5
   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ DatePicker_Res��5
      $
��Left=�6-   $��
160,24,0,0q�6H   $	��Top=�6\     5   
   -   5        $ DatePicker_retour��5      $
��Left=�60   $��
161,70,0,0q�6K   $	��Top=�6_   	� 5   
   -   5         	�Name$ rd_oui��5      $	��oui��6&   $
��Left=�64   $��161,129,0,0q�6O   $	��Top=�6d   	� 5   
   -   5        $ rd_non��5      $	��non��6&   $
��Left=�64   $��270,128,0,0q�6O   $	��Top=�6d   �� 5   
   -   5         ��Name$ cmb_nomA��5      $
��Left=�6�   $��161,162,0,0q�6�   $	��Top=�6�   $	��120��6�    J� RenderTransformOrigin$ 0.858,0.457&�6�    �� Text 6&   ��  �� ElementName$
 DATA�� �� Path$ SelectedItem.AdherentID���6f   �� *AdherentsName+6�   �� 5   
   -   5        $ cmb_titreLivre��5      $
��Left=�6N   $��161,204,0,0q�6i   $	��Top=�6~   $	��120��6�   ��6+   �� *
titreLivre+6�   �� 5   
   $��Date Reservation��6   $
��Left=�6+   $��	53,22,0,0q�6F   $	��Top=�6Y   �� 5   
   $��Date RetourPrevu��6   $
��Left=�6+   $��	53,68,0,0q�6F   $	��Top=�6Y   $ 0.474,2.505&�6q   �� 5   
   $��Est Emprunte��6   $
��Left=�6'   $��
53,123,0,0q�6B   $	��Top=�6V   $ 0.474,2.505&�6n   �� 5   
   $��Nom Adherent��6   $
��Left=�6'   $��
53,158,0,0q�6B   $	��Top=�6V   $ 0.474,2.505&�6n   �� 5   
   $��Titre de livre ��6   $
��Left=�6*   $��53,0,0,0q�6E   $��Center=�6W   $ 0.474,2.505&�6r   �� 5   
   -   5        	 ��Name$	 btn_Supprimer��5      $��	Supprimer��6(   $
��Left=�6<   $��
400,22,0,0q�6W   $	��Top=�6k   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$

 DATA��5      $��	0,245,0,0q�6"   ��65   �� *data+   Columns 5      5      5      5      