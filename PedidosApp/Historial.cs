using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp
{
    public partial class Historial : Form
    {
        public Historial()
        {
            InitializeComponent();
        }

        private void Historial_Load(object sender, EventArgs e)
        {
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("Dron");
            cmbFiltro.Items.Add("Motocicleta");
            cmbFiltro.Items.Add("Camión");
            cmbFiltro.Items.Add("Bicicleta");
            cmbFiltro.SelectedIndex = 0;

            CargarHistorial();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = cmbFiltro.SelectedItem.ToString();
            CargarHistorial(filtro);
        }

        private void CargarHistorial(string tipoFiltro = "Todos")
        {
            List<Pedido> pedidos = RegistroPedidos.Instancia.Pedidos;
            List<Pedido> filtrados = new List<Pedido>();

            if (tipoFiltro == "Todos")
            {
                filtrados = pedidos;
            }
            else
            {
                foreach (Pedido p in pedidos)
                {
                    if (p.MetodoEntrega.TipoEntrega() == tipoFiltro)
                    {
                        filtrados.Add(p);
                    }
                }
            }


            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = filtrados.Select(p => new
            {
                Cliente = p.Cliente,
                Producto = p.Producto,
                Urgente = p.Urgente,
                Peso = p.Peso,
                Distancia = p.Distancia,
                TipoEntrega = p.MetodoEntrega.TipoEntrega(),
                Costo = p.ObtenerCosto()
            }).ToList();
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
