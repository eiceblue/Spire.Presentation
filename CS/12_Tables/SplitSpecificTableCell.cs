using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Presentation;

namespace SplitSpecificTableCell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //Create a PPT document
            Presentation presentation = new Presentation();

            //Load the file from disk.
            presentation.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Ppt_1.pptx");

            //Get the first slide.
            ISlide slide = presentation.Slides[0];

            //Get the table.
            ITable table = slide.Shapes[0] as ITable;

            //Split cell [1, 2] into 3 rows and 2 columns.
            table[1, 2].Split(3, 2);

            String result = "Result-SplitSpecificTableCell.pptx";

            //Save to file.
            presentation.SaveToFile(result, FileFormat.Pptx2013);

            //Launch the PowerPoint file.
            PptDocumentViewer(result);
        }

        private void PptDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}