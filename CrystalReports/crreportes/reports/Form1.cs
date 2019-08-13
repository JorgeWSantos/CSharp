using crreportes.DAO;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace crreportes.reports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            pontosDAO dao = new pontosDAO();
            cadastro_empresaDAO dao_cad = new cadastro_empresaDAO();
            var empresa = dao_cad.SelecionarEmpresa(101);
            var table = dao.Report_SelecionarTodosPonto();

            InitializeComponent();

            //------------------------------------------------
            //com imagem
            //CrystalReport1 cr = new CrystalReport1();
            //cr.SetDataSource(table);
            //cr.DataDefinition.FormulaFields["imgform"].Text = $@"'{Global.PegarCaminho()}\assets\logofundo.jpg'";
            //cr.DataDefinition.FormulaFields["empresa"].Text = $@"'{empresa.nome_fantasia}'";
            //cr.DataDefinition.FormulaFields["cnpj"].Text = $@"'CNPJ : {empresa.cnpj}'";
            //--------------------------------------------------

            //----------------------------------------------------
            //com parametro/formula
            //CrystalReport2 cr = new CrystalReport2();
            //cr.SetDataSource(table);
            //cr.DataDefinition.FormulaFields["empresa"].Text = $@"'{empresa.nome_fantasia}'";
            //cr.DataDefinition.FormulaFields["cidade"].Text = $@"'{empresa.cidade}'";
            //cr.DataDefinition.FormulaFields["razao_social"].Text = $@"'{empresa.razao_social}'";
            //cr.DataDefinition.FormulaFields["endereco_numero"].Text = $@"'{empresa.endereco} | {empresa.numero}'";
            //cr.DataDefinition.FormulaFields["data"].Text = $@"'{(DateTime.Now.ToLongDateString().ToUpper())}'";
            //cr.DataDefinition.FormulaFields["cnpj"].Text = $@"'CNPJ : {empresa.cnpj}'";
            //crystalReportViewer1.ReportSource = cr;
            //--------------------------------------------------

            //----------------------------------------------------------
            //imprimindo sem viewer
            //CrystalReport2 cr = new CrystalReport2();
            //cr.SetDataSource(table);
            //cr.DataDefinition.FormulaFields["empresa"].Text = $@"'{empresa.nome_fantasia}'";
            //cr.DataDefinition.FormulaFields["cidade"].Text = $@"'{empresa.cidade}'";
            //cr.DataDefinition.FormulaFields["razao_social"].Text = $@"'{empresa.razao_social}'";
            //cr.DataDefinition.FormulaFields["endereco_numero"].Text = $@"'{empresa.endereco} | {empresa.numero}'";
            //cr.DataDefinition.FormulaFields["data"].Text = $@"'{(DateTime.Now.ToLongDateString().ToUpper())}'";
            //cr.DataDefinition.FormulaFields["cnpj"].Text = $@"'CNPJ : {empresa.cnpj}'";

            //using (var printdocument = new PrintDocument())
            //{
            //    cr.PrintOptions.PrinterName = "Microsoft Print to PDF";
            //    cr.PrintToPrinter(1, false, 0, 0);
            //}
            //--------------------------------------------------

            //----------------------------------------------------------
            //imprimindo sem viewer seleionando impressora
            CrystalReport2 cr = new CrystalReport2();
            cr.SetDataSource(table);
            cr.DataDefinition.FormulaFields["empresa"].Text = $@"'{empresa.nome_fantasia}'";
            cr.DataDefinition.FormulaFields["cidade"].Text = $@"'{empresa.cidade}'";
            cr.DataDefinition.FormulaFields["razao_social"].Text = $@"'{empresa.razao_social}'";
            cr.DataDefinition.FormulaFields["endereco_numero"].Text = $@"'{empresa.endereco} | {empresa.numero}'";
            cr.DataDefinition.FormulaFields["data"].Text = $@"'{(DateTime.Now.ToLongDateString().ToUpper())}'";
            cr.DataDefinition.FormulaFields["cnpj"].Text = $@"'CNPJ : {empresa.cnpj}'";

            using (var dialogo = new PrintDialog())
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    cr.PrintOptions.PrinterName = dialogo.PrinterSettings.PrinterName;
                    crystalReportViewer1.ReportSource = cr;
                }
            //cr.PrintToPrinter(dialogo.PrinterSettings, dialogo.PrinterSettings.DefaultPageSettings, false);
            //--------------------------------------------------
        }
    }
}
