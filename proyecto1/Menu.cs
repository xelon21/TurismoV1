using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto1
{
    public partial class MenuTurismoReal : Form
    {

        public MenuTurismoReal()
        {           
            InitializeComponent();

            this.IsMdiContainer = true;
        }
        private void MenuTurismoReal_Load(object sender, EventArgs e)
        {
            MenuStrip menuStrip = new MenuStrip();

            List<Menu> listaMenu = new List<Menu>()
            {
                new Menu()
                {
                    nombre = "Inicio",   
                    subMenu = new List<SubMenu>(){
                        new SubMenu()
                        {
                            nombre = "Check-In"
                        },
                        new SubMenu()
                        {
                            nombre = "Check-Out"
                        },
                        new SubMenu()
                        {
                            nombre = "Salir"
                        }
                    }
                },
                new Menu()
                {
                    nombre = "Ingresar",
                    subMenu = new List<SubMenu>(){
                        new SubMenu()
                        {
                            nombre = "Inventario"
                        },
                        new SubMenu()
                        {
                            nombre = "Departamento"
                        },
                         new SubMenu()
                        {
                            nombre = "Gastos Departamentos"
                        }
                    }
                },
                new Menu()
                {
                    nombre = "Administración",
                    subMenu= new List<SubMenu>()
                    {
                        new SubMenu()
                        { 
                            nombre = "Informes"
                        },
                        new SubMenu()
                        {
                            nombre = "Usuarios"
                        },
                        new SubMenu()
                        {
                            nombre = "Servicio Extra"
                        }                       
                    }
                }
            };      

            bool si = true;

            foreach (Menu menu in listaMenu)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(menu.nombre);

                if(menu.nombre == "Administración")
                {
                    if (LoginUsuario.rol == 1)
                    {
                        if (menu.subMenu != null)
                        {
                            foreach (SubMenu subMenu in menu.subMenu)
                            {
                                ToolStripMenuItem subMenuItem = new ToolStripMenuItem(subMenu.nombre, null, submenuSelected);
                                menuItem.DropDownItems.Add(subMenuItem);
                            }
                        }

                        menuStrip.Items.Add(menuItem);
                    }
                }
                else
                {
                    if(menu.nombre != "Administración")
                    {
                        if(menu.subMenu != null)
                        {
                            foreach (SubMenu subMenu in menu.subMenu)
                            {
                                ToolStripMenuItem subMenuItem = new ToolStripMenuItem(subMenu.nombre, null, submenuSelected);
                                menuItem.DropDownItems.Add(subMenuItem);
                            }
                        }

                        menuStrip.Items.Add(menuItem);
                    }
                }
            }         

            this.MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);

        }

        private class Menu
        {
            public string nombre { get; set; }
            public List<SubMenu> subMenu { get; set; }
        }

        public class SubMenu
        {
            public string nombre { get; set; }
        }

        private void submenuSelected(object sender, EventArgs e)
        {
            if(sender.ToString() == "Check-In" || sender.ToString() == "Check-Out")
            {
                ValidarReserva validaReserva = new ValidarReserva();
                validaReserva.MdiParent = this;
                validaReserva.Show();
            }
            if(sender.ToString() == "Salir")
            {
                Close();
            }
            if(sender.ToString() == "Inventario")
            {
                MantenedorInventario mantenedorInventario = new MantenedorInventario();
                mantenedorInventario.MdiParent = this;
                mantenedorInventario.Show();
            }
            if(sender.ToString() == "Departamento")
            {
                MantenedorDepartamento mantenedorDepartamento = new MantenedorDepartamento();
                mantenedorDepartamento.MdiParent = this;
                mantenedorDepartamento.Show();
            }
            if(sender.ToString() == "Usuarios")
            {
                MantencionUsuarios mantencionUsuarios = new MantencionUsuarios();
                mantencionUsuarios.MdiParent = this;
                mantencionUsuarios.Show();
            }
            if (sender.ToString() == "Informes")
            {
                InformeRentabilidad informeRentabilidad = new InformeRentabilidad();
                informeRentabilidad.MdiParent = this;
                informeRentabilidad.Show();
            }
            if (sender.ToString() == "Servicio Extra")
            {
                ServicioExtra servicioExtra = new ServicioExtra();
                servicioExtra.MdiParent = this;
                servicioExtra.Show();
            }
            if (sender.ToString() == "Gastos Departamentos")
            {
                IngresarMantencionDepartamentos mantencnionDepartamentos = new IngresarMantencionDepartamentos();
                mantencnionDepartamentos.MdiParent = this;
                mantencnionDepartamentos.Show();
            }
        }
    }
}

//private void ingresarCheckInToolStripMenuItem_Click(object sender, EventArgs e)
//{
//    ValidarReserva validaReserva = new ValidarReserva();
//    validaReserva.MdiParent = this;
//    validaReserva.Show();
//}

//        private void ingresarCheckOutToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            ValidarReserva validaReserva = new ValidarReserva();
//            validaReserva.MdiParent = this;
//            validaReserva.Show();
//        }

//        private void tsmLogout_Click(object sender, EventArgs e)
//        {
//            this.Close();
//            LoginUsuario login = new LoginUsuario();
//            login.Show();
//        }

//        private void matencionDepartamentos_Click(object sender, EventArgs e)
//        {
//            MantenedorInventario mantenedorInventario = new MantenedorInventario();
//            mantenedorInventario.MdiParent = this;
//            mantenedorInventario.Show();
//        }             

//        private void menuIngresarDepartamento_Click(object sender, EventArgs e)
//        {
//            bool prueba = true;
//            if (prueba)
//            {

//            }
//            MantenedorDepartamento mantenedorDepartamento = new MantenedorDepartamento();
//            mantenedorDepartamento.MdiParent = this;
//            mantenedorDepartamento.Show();
//        }

//        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            Close();
//        }
