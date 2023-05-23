using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Shapes
    {
        public class Point3d
        {
            int x, y, z;
            public Point3d()
            { X = 0; Y = 0; Z = 0; }
            public Point3d(int x, int y, int z)
            { X = x; Y = y; Z = z; }
            public int X { get => x; set => x = value; }
            public int Y { get => y; set => y = value; }
            public int Z { get => z; set => z = value; }
        }
        public class Rectangle_
        {
            int height;
            int width;
            Point3d corner;
            public Rectangle_()
            {
                Height = 0;
                Width = 0;
                Corner = new Point3d();
            }
            public Rectangle_(Point3d corner, int width, int height)
            {
                Height = height;
                Width = width;
                Corner = corner;
            }

            public int Height { get => height; set => height = value; }
            public int Width { get => width; set => width = value; }
            internal Point3d Corner { get => corner; set => corner = value; }
        }
        public class Circle
        {
            int radius;
            Point3d center;
            public Circle()
            {
                Center = new Point3d();
                Radius = 0;
            }
            public Circle(Point3d c, int r)
            {
                Center = c; Radius = r;
            }

            public int Radius { get => radius; set => radius = value; }
            internal Point3d Center { get => center; set => center = value; }
        }
        public class Sphere
        {
            int radius;
            Point3d center;
            public Sphere()
            {
                Radius = 0;
                Center = new Point3d();
            }
            public Sphere(Point3d center, int radius)
            {
                Radius = radius;
                Center = center;
            }
            public int Radius { get => radius; set => radius = value; }
            internal Point3d Center { get => center; set => center = value; }
        }
        public class Cylinder
        {
            int radius;
            Point3d center;
            int height;
            public Cylinder()
            {
                Radius = 0;
                Center = new Point3d();
                Height = 0;
            }
            public Cylinder(Point3d center, int radius, int height)
            {
                Radius = radius;
                Center = center;
                Height = height;
            }
            public int Radius { get => radius; set => radius = value; }
            public int Height { get => height; set => height = value; }
            internal Point3d Center { get => center; set => center = value; }
        }
        public class RectanglePrism
        {
            int height;
            int width;
            int depth;
            Point3d corner;
            public RectanglePrism()
            {
                Height = 0;
                Width = 0;
                Depth = 0;
                Corner = new Point3d();
            }
            public RectanglePrism(Point3d corner, int width, int height, int depth)
            {
                Height = height;
                Width = width;
                Depth = depth;
                Corner = corner;
            }
            public int Height { get => height; set => height = value; }
            public int Width { get => width; set => width = value; }
            public int Depth { get => depth; set => depth = value; }
            internal Point3d Corner { get => corner; set => corner = value; }
        }
        public class Quadrilateral
        {
            int height;
            int width;
            Point3d corner;
            public Quadrilateral()
            {
                Height = 0;
                Width = 0;
                Corner = new Point3d();
            }
            public Quadrilateral(Point3d corner, int width, int height)
            {
                Height = height;
                Width = width;
                Corner = corner;
            }

            public int Height { get => height; set => height = value; }
            public int Width { get => width; set => width = value; }
            internal Point3d Corner { get => corner; set => corner = value; }
        }
        public class Surface
        {
            int height;
            int depth;
            Point3d corner;
            public Surface()
            {
                Height = 0;
                Depth = 0;
                Corner = new Point3d();
            }
            public Surface(Point3d corner, int height, int depth)
            {
                Height = height;
                Depth = depth;
                Corner = corner;
            }
            public int Height { get => height; set => height = value; }
            public int Depth { get => depth; set => depth = value; }
            internal Point3d Corner { get => corner; set => corner = value; }
        }
    }
}
