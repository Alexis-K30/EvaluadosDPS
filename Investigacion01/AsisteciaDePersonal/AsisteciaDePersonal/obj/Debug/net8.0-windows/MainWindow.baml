   M S B A M L   `   `   `  ����N  JAsisteciaDePersonal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AsisteciaDePersonalAsisteciaDePersonal  5   	   $    AsisteciaDePersonal.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:AsisteciaDePersonal     5   	     � Title$  
MainWindow��5   	   $	��539��6   $	��910��6)   .��5	      � $��1,0,0,-5q�6   .+�5
   
   �� -   5         ��Name$ 	lblNombre��5
      $��Nombre completo: ��6#   $
��Left=�6?   $��
115,82,0,0q�6Z   $	��Top=�6n   $��16(�6�   $��Times New Roman)�6�   �� 5   
   -   5         ��Name$ 	txtNombre��5      $
��Left=�6%   $��
254,86,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��180��6�   $��16(�6�   $��Times New Roman)�6�   �� 5   
   -   5        $ 	lblTitulo��5      $,��&Control de asistencias a capacitación��6#   $��Center=�6S   $��0,25,0,0q�6p   $	��Top=�6�   $��20(�6�   $
��Bold"�6�   $��Times New Roman)�6�   �� 5   
   -   5        $ lblFechaNac��5      $��Fecha de nacimiento: ��6%   $
��Left=�6E   $��115,164,0,0q�6`   $	��Top=�6u   $��Times New Roman)�6�   $��16(�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
dpFechaNac��5      $
��Left=�6)   $��271,166,0,0q�6D   $	��Top=�6Y   $	��158��6q   $��14(�6}   $��Times New Roman)�6�   �� 5   
   -   5        $ lblCargo��5      $��Cargo:��6"   $
��Left=�63   $��
527,82,0,0q�6N   $	��Top=�6b   $��16(�6z   $��Times New Roman)�6�   �� 5   
   -   5         ��Name$ cmbCargo��5      $
��Left=�6%   $��
585,85,0,0q�6@   $	��Top=�6T   $	��188��6l   $��25��6x   $��16(�6�   $��Times New Roman)�6�   .@�5      �� $��Operador de Empacadora��6   �� 5      $��Operario de fundición��6   �� 5      $��Coordinador de Bodega��6   �� 5      $��Supervisor de producción��6   �� 5      $��Director de operaciones��6   �� 5      $��Secretario Médico��6   �� 5      $ ��Auxiliar superior de apoyo��6   �� 5      $'��!Administrador de Recursos Humanos��6   5      �� 5   
   -   5        $ 	lblSueldo��5      $��Sueldo bruto mensual:��6#   $
��Left=�6C   $��527,164,0,0q�6^   $	��Top=�6s   $��Times New Roman)�6�   $��16(�6�   �� 5   
   -	   5        $ 	txtSueldo��5      $
��Left=�6%   $��690,168,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $��83��6�   $��Times New Roman)�6�   $��16(�6�   �� 5!   
   -
   5         ��Name$ btnRegistrar��5!      $��	Registrar��6'   $
��Left=�6V   $��115,440,0,0q�6q   $	��Top=�6�   $��Times New Roman)�6�   $��16(�6�   $��30��6�   $��83��6�   �� 5"   
   -   5        $ btnSalir��5"      $��Salir��6#   $
��Left=�63   $��690,439,0,0q�6N   $	��Top=�6c   $��Times New Roman)�6{   $��16(�6�   $��32��6�   $��83��6�   6�   &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ dgAsistencias��5$         
IsReadOnly$
 True��6*   	   CanUserAddRows$	 False��6<   
   AutoGenerateColumns$
 False��6S   $��10,230,10,110q�6�   $��Times New Roman)�6�   $��16(�6�      Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre completo��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Nombre+6Y     5'      $ Edad (en años)��6%   $ * 6V    6=   �� *Edad+6V     5(      $ Cargo��6%   $ * 6N    64   �� *Cargo+6N     5)      $ Sueldo Neto Mensual($)��6%   $ * 6t    6E   �� *
SueldoNeto+ �� StringFormat$ C��6t   5+      5,      5-      