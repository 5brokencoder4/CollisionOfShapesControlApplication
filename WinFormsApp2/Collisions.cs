using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    internal class Collisions
    {
        public static bool point_quadrilateral(Shapes.Point3d p, Shapes.Quadrilateral q)
        {
            if (p.X >= q.Corner.X && p.X <= q.Corner.X + q.Width && p.Y >= q.Corner.Y && p.Y <= q.Corner.Y + q.Height)
                return true;
            else return false;
        }
        public static bool point_circle(Shapes.Point3d p, Shapes.Circle c)
        {
            float d = (float)Math.Sqrt(Math.Pow(p.X - c.Center.X, 2) + Math.Pow(p.Y - c.Center.Y, 2));
            if (d <= c.Radius) { return true; }
            else {return false; }
        } 
        public static bool rectangle_rectangle(Shapes.Rectangle_ r1, Shapes.Rectangle_ r2)
        {
            float c1X = r1.Corner.X + r1.Width / 2;
            float c1Y = r1.Corner.Y - r1.Height / 2;
            float c2X = r2.Corner.X + r2.Width / 2;
            float c2Y = r2.Corner.Y - r2.Height / 2;
            if (Math.Abs(c1X - c2X) <= (r1.Width + r2.Width) / 2 && Math.Abs(c1Y - c2Y) <= (r1.Height + r2.Height) / 2)
                return true;
            else return false;
        }  
        public static bool rectangle_circle(Shapes.Rectangle_ r, Shapes.Circle c)
        {
            float rCenterX = r.Corner.X + r.Width / 2;
            float rCenterY = r.Corner.Y - r.Height / 2;
            if (Math.Abs(rCenterX - c.Center.X) <= r.Width / 2 + c.Radius && Math.Abs(rCenterY - c.Center.Y) <= r.Height / 2 + c.Radius)
                return true;
            else return false;
        } 
        public static bool circle_circle(Shapes.Circle c1,Shapes.Circle c2)
        {
            float d = (float)Math.Sqrt(Math.Pow(c1.Center.X - c2.Center.X, 2) + Math.Pow(c1.Center.Y- c2.Center.Y, 2));
            if (d <= c1.Radius+c2.Radius)
                return true;
            else return false;
        }
        public static bool point_sphere(Shapes.Point3d p,Shapes.Sphere s)
        {
            float d = (float)Math.Sqrt(Math.Pow(p.X - s.Center.X, 2) + Math.Pow(p.X- s.Center.Y, 2)+ Math.Pow(p.Z- s.Center.Z, 2));
            if (d <= s.Radius)
                return true;
            else return false;
        } 
        public static bool point_rectangleprism(Shapes.Point3d p,Shapes.RectanglePrism r)
        {
            if (p.X<=r.Corner.X+r.Width && p.X>=r.Corner.X&& p.Y >= r.Corner.Y - r.Height && p.Y <= r.Corner.Y && p.Z <= r.Corner.Z + r.Depth && p.Z>= r.Corner.Z)
                return true;
            else return false;
        }
        public static bool point_cylinder(Shapes.Point3d p,Shapes.Cylinder c)
        {
            float d = (float)Math.Sqrt(Math.Pow(p.X - c.Center.X, 2) + Math.Pow(p.Y - c.Center.Y, 2));

            if (d<=c.Radius && p.Z>=c.Center.Z&&p.Z<=c.Center.Z+c.Height)
                return true;
            else return false;
        }
        public static bool cylinder_cylinder(Shapes.Cylinder c1,Shapes.Cylinder c2)
        {
            float dis_cylinderleftdown = (float)Math.Sqrt(Math.Pow(c1.Center.X-c1.Radius - c2.Center.X, 2) + Math.Pow(c1.Center.Y - c2.Center.Y, 2));
            float dis_cylinderrightdownd = (float)Math.Sqrt(Math.Pow(c1.Center.X+c1.Radius - c2.Center.X, 2) + Math.Pow(c1.Center.Y - c2.Center.Y, 2));
            if ((dis_cylinderleftdown <=c2.Radius && c1.Center.Z>=c2.Center.Z&&c1.Center.Z<=c2.Center.Z+c2.Height)|| 
                (dis_cylinderrightdownd<= c2.Radius && c1.Center.Z >= c2.Center.Z && c1.Center.Z <= c2.Center.Z + c2.Height) )
                return true;
            else return false;
        } 
        public static bool sphere_sphere(Shapes.Sphere s1,Shapes.Sphere s2)
        {
            float d = (float)Math.Sqrt(Math.Pow(s1.Center.X - s2.Center.X, 2) + Math.Pow(s1.Center.Y - s2.Center.Y, 2)+ Math.Pow(s1.Center.Z - s2.Center.Z, 2));
            if (d <= s1.Radius + s2.Radius)
                return true;
            else return false;
        }    
        public static bool sphere_cylinder(Shapes.Sphere s, Shapes.Cylinder c) {
            double centerCylinder = c.Center.Z+c.Height/2;
            double d = Math.Sqrt(Math.Pow(s.Center.Z - centerCylinder, 2) + Math.Pow(s.Center.Y - c.Center.Y, 2) + Math.Pow(s.Center.X -c.Center.X, 2));
            if (d <= s.Radius + s.Radius && d <= s.Radius+ c.Height/ 2)
            {
                return true;
            }
            else { return false; }
        }
        public static bool surface_sphere(Shapes.Surface su, Shapes.Sphere s)
        {
            float suCentery =(float)  su.Corner.Y + su.Height/ 2;
            float suCenterz =(float)  su.Corner.Z - su.Depth / 2;
            float distance = (float) Math.Sqrt(Math.Pow(suCenterz - s.Center.Z, 2) + Math.Pow(suCentery - s.Center.Y, 2) + Math.Pow(su.Corner.X - s.Center.X, 2));
            if (distance <= s.Radius)
            {
                return true;
            }
            else { return false; }

        }
        public static bool surface_rectangleprism(Shapes.Surface su , Shapes.RectanglePrism r)
        {
                float suCentery = (float)su.Corner.Y+ su.Height / 2;
                float suCenterz = (float)su.Corner.Z- su.Depth/ 2;
                float rCenterx = (float)r.Corner.X + r.Width/ 2;
                float rCentery = (float)r.Corner.Y - r.Height/ 2;
                float rCenterz = (float)r.Corner.Z - r.Depth/ 2;
                float yuzeyDikdortgenPrizmaUzaklik = (float)Math.Sqrt(Math.Pow(rCenterz - suCenterz, 2) + Math.Pow(rCentery - suCentery, 2) + Math.Pow(rCenterx - su.Corner.X, 2));
                if (yuzeyDikdortgenPrizmaUzaklik <= su.Height / 2 + r.Height/ 2 && yuzeyDikdortgenPrizmaUzaklik <= su.Depth/ 2 + r.Depth/ 2 && yuzeyDikdortgenPrizmaUzaklik <= r.Width / 2)
                {
                    return true;
                }
                else { return false; }
            }      
        public static bool surface_cylinder(Shapes.Surface su, Shapes.Cylinder s)
        {
            float suCentery =(float) su.Corner.Y + su.Height/ 2;
            float suCenterz =(float) su.Corner.Z - su.Depth/ 2;
            float sCenterz = (float)s.Center.Z + s.Height / 2;
            float distance = (float)Math.Sqrt(Math.Pow(sCenterz - suCenterz, 2) + Math.Pow(s.Center.Y - suCentery, 2) + Math.Pow(s.Center.X- su.Corner.X, 2));
            if (distance <= su.Height / 2 + s.Height/ 2 && distance <= su.Depth/ 2 + s.Radius)
            {
                return true;
            }
            else { return false; }
        }
        public static bool sphere_rectangleprism(Shapes.Sphere s, Shapes.RectanglePrism r)
        {
            float rCenterx = (float)r.Corner.X + r.Width/ 2;
            float rCentery = (float)r.Corner.Y - r.Height/ 2;
            float rCenterz = (float)r.Corner.Z - r.Depth/ 2;
            float distance = (float)Math.Sqrt(Math.Pow(rCenterz - s.Center.Z, 2) + Math.Pow(rCentery - s.Center.Y, 2) + Math.Pow(rCenterx - s.Center.Z, 2));
            if (distance <= s.Radius+ r.Height/ 2 && distance<= s.Radius+ r.Width/ 2 && distance<= s.Radius+ r.Depth/ 2)
            {
                return true;
            }
            else { return false; }
        }
        public static bool rectangleprism_rectangleprism(Shapes.RectanglePrism r1, Shapes.RectanglePrism r2)
        {
            float r1Centerx = r1.Corner.X + r1.Width / 2;
            float r1Centery = r1.Corner.Y - r1.Height/ 2;
            float r1Centerz = r1.Corner.Z - r1.Depth/ 2;
            float r2Centerx = r2.Corner.X + r2.Width/ 2;
            float r2Centery = r2.Corner.Y - r2.Height/ 2;
            float r2Centerz = r2.Corner.Z - r2.Depth/ 2;
            float distance = (float)Math.Sqrt(Math.Pow(r2Centerz - r1Centerz, 2) + Math.Pow(r2Centery - r1Centery, 2) + Math.Pow(r2Centerx - r1Centerx, 2));
            if (distance <= r1.Height / 2 + r2.Height/ 2 && distance <= r1.Width/ 2 + r2.Width/ 2 && distance <= r1.Depth/ 2 + r2.Depth/ 2)
            {
                return true;
            }
            else { return false; }
        }

    }
}
