﻿using Spire.Presentation;
using Spire.Presentation.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EmbedExcelAsOLE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
			//Create a Presentaion document
			Presentation ppt = new Presentation();
			
			//Load a image file
            Image image = Image.FromFile(@"..\..\..\..\..\..\Data\EmbedExcelAsOLE.png");
            IImageData oleImage = ppt.Images.Append(image);
            Rectangle rec = new Rectangle(80, 60, image.Width, image.Height);

            //Insert an OLE object to presentation based on the Excel data
            Spire.Presentation.IOleObject oleObject = ppt.Slides[0].Shapes.AppendOleObject("excel", File.ReadAllBytes(@"..\..\..\..\..\..\Data\EmbedExcelAsOLE.xlsx"), rec);
            oleObject.SubstituteImagePictureFillFormat.Picture.EmbedImage = oleImage;
            oleObject.ProgId = "Excel.Sheet.12";

            //Save the document
            ppt.SaveToFile("EmbedExcelAsOLE_result.pptx", Spire.Presentation.FileFormat.Pptx2010);
            System.Diagnostics.Process.Start("EmbedExcelAsOLE_result.pptx");
        }
    }
}
