﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{

    public class RigthPolygon : Polygon
    {

        public RigthPolygon(int x0, int y0, Graphics gr, Pen pen, Color Fc) : base(x0, y0, gr, pen, Fc) { }
        protected int topAmount = 3;
        protected Point[] points = new Point[3];


        public int TopAmount
        {
            get
            {
                return topAmount;
            }
            set
            {
                points = new Point[value];
                topAmount = value;
            }

        }


        public override Point StartPoint
        {
            get
            {
                return startPoint;
            }
            set
            {
                startPoint = value;

            }
        }

        public override Point PreDrawEndPoint
        {
            get
            {
                return endPoint;
            }
            set
            {
                EndPoint = value;

            }

        }

        public override Point EndPoint
        {
            get => base.EndPoint;
            set
            {
                endPoint = value;

                int r = (int)(endPoint.X - startPoint.X) / 2, x1, y1;

                var center = new PointF(StartPoint.X + r, startPoint.Y + r);

                double angle = Math.PI * 2 / TopAmount, shiftAngle = Math.PI * (endPoint.X - startPoint.X) / (endPoint.Y - startPoint.Y) / 20;

                for (int i = 0; i < TopAmount; i++)
                {
                    x1 = (int)(center.X + Math.Cos(i * angle + shiftAngle) * r);
                    y1 = (int)(center.Y + Math.Sin(i * angle + shiftAngle) * r);
                    points[i].X = x1;
                    points[i].Y = y1;

                }

                var brush = new SolidBrush(FillColor);

                DrawPanel.DrawPolygon(DrPen, points);
                DrawPanel.FillPolygon(brush, points);

                brush.Dispose();

            }
        }
    }

    public class RigthPolygonCreator : IFiguresCreator
    {
        public Figure Create(int x0, int y0, Graphics gr, Pen pen, Color Fc)
        {
            return new RigthPolygon(x0, y0, gr, pen, Fc);
        }
        public string Name
        {
            get
            {
                return " Правильный Многоугольник";
            }
        }
        public bool TopsNeeded
        {
            get
            {
                return true;
            }
        }

    }


}

