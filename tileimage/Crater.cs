﻿using FreeImageAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileimage
{
    class Crater
    {
        public PointXY origin;
        public double radius;

        public Crater(double x, double y, double radius)
        {

            origin = new PointXY(x, y);
            this.radius = radius;
        }

        public double RidgeHeight
        {
            get
            {
                return radius / 4;
            }
        }

        public double PenetrationDepth
        {
            get
            {
                return radius / 3;
            }
        }
       

        public double Lerp(double a, double b, double alpha)
        {
            alpha = alpha.Clamp(0, 1);
            return a * (1 - alpha) + b * alpha;
        }

        public double EaseIn(double v)
        {
            double k = Math.Pow(v, 3);
            return k;
        }

        public bool IsRidge(PointXY p)
        {
            double d = DistanceFromCenter(p);
            return d < radius && d.NearlyEqual(radius, 5);
        }

        public bool IsInside(PointXY p)
        {
            return DistanceFromCenter(p) < radius;
        }

        public double DistanceFromCenter(PointXY p)  // compute the distance of point p to the current point
        {
            return dist(origin, p);
        }

        public double dist(PointXY a, PointXY b)  // compute the distance of point p to the current point
        {
            double distance;

            distance = Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
            return distance;
        }
    }

    public class PointXY
    {
        public double x { get; set; }
        public double y { get; set; }

        public PointXY(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

    }
}