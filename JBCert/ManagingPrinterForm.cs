using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JBCert
{
    public partial class ManagingPrinterForm : Form
    {
        public ManagingPrinterForm()
        {
            InitializeComponent();
        }

        private void ConnectPrinterButton_Click(object sender, EventArgs e)
        {

        }

        private void ManagingPrinterForm_Load(object sender, EventArgs e)
        {
            if (PrinterSettings.InstalledPrinters.Count <= 0)
            {
                MessageBox.Show("Printer not found!");
                return;
            }
            List<string> printers = new List<string>();
            //Get all available printers and add them to the combo box  
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                PrinterComboBox.Items.Add(printer.ToString());
            }
        }

        private void CreateDocumentButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Create a PrintDocument object  
                PrintDocument pd = new PrintDocument();

                //Set PrinterName as the selected printer in the printers list  
                pd.PrinterSettings.PrinterName = PrinterComboBox.SelectedItem.ToString();

                //Add PrintPage event handler  
                pd.PrintPage += Pd_PrintPage;

                //Print the document  
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "");
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int x = int.Parse(XTextBox.Text);
            int y = int.Parse(YTextBox.Text);
            //Get the Graphics object  
            Graphics g = e.Graphics;

            //Create a font Arial with size 16  
            Font font = new Font("Arial", 14);

            //Create a solid brush with black color  
            SolidBrush brush = new SolidBrush(Color.Black);

            //Draw "Hello Printer!";  
            //g.RotateTransform(180);

            // 320, 460
            //g.DrawString("Nghiêm Đức Hạnh",
            //font, brush,
            //new Rectangle(x, x, 200, 100));
            DrawRotatedTextAt(e.Graphics, -90, "Nghiêm Đức Hạnh",x,y, font, brush);
        }

        private void DrawRotatedTextAt(Graphics gr, float angle,
    string txt, int x, int y, Font the_font, Brush the_brush)
        {
            // Save the graphics state.
            GraphicsState state = gr.Save();
            gr.ResetTransform();

            // Rotate.
            gr.RotateTransform(angle);

            // Translate to desired position. Be sure to append
            // the rotation so it occurs after the rotation.
            gr.TranslateTransform(x, y, MatrixOrder.Append);

            // Draw the text at the origin.
            gr.DrawString(txt, the_font, the_brush, 0, 0);

            // Restore the graphics state.
            gr.Restore(state);
        }
    }
}
