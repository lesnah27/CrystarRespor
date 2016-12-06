using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TareaIIIB
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void crv_Load(object sender, EventArgs e)
        {
            DsReporteEmpleadosTableAdapters.empleadosTableAdapter tap = new DsReporteEmpleadosTableAdapters.empleadosTableAdapter();
            DsReporteEmpleados ds = new DsReporteEmpleados();
            tap.Fill(ds.empleados);

            rptEmpleados rpt = new rptEmpleados();
            rpt.SetDataSource(ds);

            crv.ReportSource = rpt;

        }
    }
}
