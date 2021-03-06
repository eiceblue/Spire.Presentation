﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Presentation;
using Spire.Presentation.Drawing.Transition;
using Spire.Presentation.Diagrams;
using System.IO;
using Spire.Presentation.Drawing;

namespace CustomBulletsNumber
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

            //Load PPT file from disk
            presentation.LoadFromFile(@"..\..\..\..\..\..\Data\Bulltes2.pptx");
            //Get the first slide
            ISlide slide = presentation.Slides[0];

            //Access the first placeholder in the slide and typecasting it as AutoShape
            ITextFrameProperties tf1 = ((IAutoShape)slide.Shapes[1]).TextFrame;

            //Access the first Paragraph and set bullet style
            TextParagraph para= tf1.Paragraphs[0];
            para.Depth = 0;
            para.BulletType = TextBulletType.Numbered;
            para.BulletStyle = NumberedBulletStyle.BulletArabicPeriod;
            para.BulletNumber = 2;

             //Access the second Paragraph and set bullet style
             para = tf1.Paragraphs[1];
             para.Depth = 0;
             para.BulletType = TextBulletType.Numbered;
             para.BulletStyle = NumberedBulletStyle.BulletArabicPeriod;
             para.BulletNumber = 4;

             //Access the third Paragraph and set bullet style
             para = tf1.Paragraphs[2];
             para.Depth = 0;
             para.BulletType = TextBulletType.Numbered;
             para.BulletStyle = NumberedBulletStyle.BulletArabicPeriod;
             para.BulletNumber = 6;

             //Access the fourth Paragraph and set bullet style
             para = tf1.Paragraphs[3];
             para.Depth = 0;
             para.BulletType = TextBulletType.Numbered;
             para.BulletStyle = NumberedBulletStyle.BulletArabicPeriod;
             para.BulletNumber = 7;

             string result = "CustomBulletsNumber_result.pptx";
            presentation.SaveToFile(result, FileFormat.Pptx2013);
            Viewer(result);
        }

        private void Viewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}