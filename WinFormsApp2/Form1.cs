/****************************************************************************
** SAKARYA ÜNÝVERSÝTESÝ
** BÝLGÝSAYAR VE BÝLÝÞÝM BÝLÝMLERÝ FAKÜLTESÝ
** BÝLGÝSAYAR MÜHENDÝSLÝÐÝ BÖLÜMÜ
** Nesneye Dayalý Programlama DERSÝ
**
** ÖDEV NUMARASI    :1
** ÖÐRENCÝ ADI      :MELÝH
** ÖÐRENCÝ NUMARASI :B221210079
** DERS GRUBU       :1-A 
****************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        Graphics drawing;
        Pen penBlack = new Pen(Color.Black, 2);
        Pen penBlue = new Pen(Color.Blue, 2);
        Pen penRed = new Pen(Color.Red, 2);
        SolidBrush brushBlue = new SolidBrush(Color.Blue);
        SolidBrush brushRed = new SolidBrush(Color.Red);
        bool button_vrb = false;
        int tbtx_1; int tbtx_2; int tbty_1; int tbty_2; int tbtz_1; int tbtz_2;
        int tbth_1; int tbth_2; int tbtw_1; int tbtw_2; int tbtd_1; int tbtd_2; int tbtr_1; int tbtr_2;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            radio_pointquadrilateral.Checked = true;
        }
        private void buttonRandom_Click(object sender, EventArgs e)
        {
            button_vrb = true;
            buttonCollision_Click(sender, e);
        }
        public void buttonCollision_Click(object sender, EventArgs e)
        {
            drawing = pictureBox1.CreateGraphics();
            Point pictureOrigin = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            drawing.Clear(Color.White);
            drawing.DrawLine(penBlack, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            drawing.DrawLine(penBlack, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
            bool collision_vrb = false;
            if (button_vrb == false)
            {
                tbtx_1 = Convert.ToInt32(textBox_x1.Text); tbty_1 = Convert.ToInt32(textBox_y1.Text); tbtz_1 = Convert.ToInt32(textBox_z1.Text);
                tbtx_2 = Convert.ToInt32(textBox_x2.Text); tbty_2 = Convert.ToInt32(textBox_y2.Text); tbtz_2 = Convert.ToInt32(textBox_z2.Text);
                tbth_1 = Convert.ToInt32(textBox_h1.Text); tbth_2 = Convert.ToInt32(textBox_h2.Text);
                tbtw_1 = Convert.ToInt32(textBox_w1.Text); tbtw_2 = Convert.ToInt32(textBox_w2.Text);
                tbtd_1 = Convert.ToInt32(textBox_d1.Text); tbtd_2 = Convert.ToInt32(textBox_d2.Text);
                tbtr_1 = Convert.ToInt32(textBox_r1.Text); tbtr_2 = Convert.ToInt32(textBox_r2.Text);
            }
            else
            {
                Random rastgele = new Random();
                tbtx_1 = 150 - rastgele.Next(0, 300); tbty_1 = 150 - rastgele.Next(0, 300); tbtz_1 = 50 - rastgele.Next(0, 100);
                tbtx_2 = 150 - rastgele.Next(0, 300); tbty_2 = 150 - rastgele.Next(0, 300); tbtz_2 = 50 - rastgele.Next(0, 100);
                tbth_1 = rastgele.Next(5, 100); tbth_2 = rastgele.Next(5, 25);
                tbtw_1 = rastgele.Next(5, 100); tbtw_2 = rastgele.Next(5, 25);
                tbtd_1 = rastgele.Next(5, 100); tbtd_2 = rastgele.Next(5, 25);
                tbtr_1 = rastgele.Next(5, 25); tbtr_2 = rastgele.Next(5, 25);
            }
            if (radio_pointquadrilateral.Checked == true)
            {
                drawing.DrawRectangle(penBlue, new Rectangle(pictureOrigin.X + tbtx_2, pictureOrigin.Y - tbty_2, tbtw_2, tbth_2));
                drawing.DrawLine(penRed, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1 + 2, pictureOrigin.Y - tbty_1 + 2);
                Shapes.Point3d point = new Shapes.Point3d(tbtx_1, tbty_1, 0);
                Shapes.Quadrilateral quadrilateral = new Shapes.Quadrilateral(new Shapes.Point3d(tbtx_2, tbty_2, 0), tbtw_2, tbth_2);
                if (Collisions.point_quadrilateral(point, quadrilateral)) { collision_vrb = true; }
            }
            else if (radio_pointcircle.Checked == true)
            {
                drawing.DrawLine(penRed, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1 + 2, pictureOrigin.Y - tbty_1 + 2);
                drawing.DrawEllipse(penBlue, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbtx_2 - tbtr_2, tbtr_2 * 2, tbtr_2 * 2));
                Shapes.Point3d point = new Shapes.Point3d(tbtx_1, tbty_1, 0);
                Shapes.Circle circle = new Shapes.Circle(new Shapes.Point3d(tbtx_2, tbty_2, 0), tbtr_2);
                if (Collisions.point_circle(point, circle)) { collision_vrb = true; }
            }
            else if (radio_rectanglerectangle.Checked == true)
            {
                drawing.DrawRectangle(penBlue, new Rectangle(pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, tbtw_1, tbth_1));
                drawing.DrawRectangle(penRed, new Rectangle(pictureOrigin.X + tbtx_2, pictureOrigin.Y - tbty_2, tbtw_2, tbth_2));
                Shapes.Rectangle_ rectangle1 = new Shapes.Rectangle_(new Shapes.Point3d(tbtx_1, tbty_1, 0), tbtw_1, tbth_1);
                Shapes.Rectangle_ rectangle2 = new Shapes.Rectangle_(new Shapes.Point3d(tbtx_2, tbty_2, 0), tbtw_2, tbth_2);
                if (Collisions.rectangle_rectangle(rectangle1, rectangle2)) { collision_vrb = true; }
            }
            else if (radio_rectanglecircle.Checked == true)
            {
                drawing.DrawRectangle(penBlue, new Rectangle(pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, tbtw_1, tbth_1));
                drawing.DrawEllipse(penRed, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2, tbtr_2 * 2, tbtr_2 * 2));
                Shapes.Rectangle_ rectangle = new Shapes.Rectangle_(new Shapes.Point3d(tbtx_1, tbty_1, 0), tbtw_1, tbth_1);
                Shapes.Circle circle = new Shapes.Circle(new Shapes.Point3d(tbtx_2, tbty_2, 0), tbtr_2);
                if (Collisions.rectangle_circle(rectangle, circle)) { collision_vrb = true; }
            }
            else if (radio_circlecircle.Checked == true)
            {
                drawing.DrawEllipse(penBlue, new Rectangle(pictureOrigin.X + tbtx_1 - tbtr_1, pictureOrigin.Y - tbty_1 - tbtr_1, tbtr_1 * 2, tbtr_1 * 2));
                drawing.DrawEllipse(penRed, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2, tbtr_2 * 2, tbtr_2 * 2));
                Shapes.Circle circle1 = new Shapes.Circle(new Shapes.Point3d(tbtx_1, tbty_1, 0), tbtr_1);
                Shapes.Circle circle2 = new Shapes.Circle(new Shapes.Point3d(tbtx_2, tbty_2, 0), tbtr_2);
                if (Collisions.circle_circle(circle1, circle2)) { collision_vrb = true; }
            }
            else if (radio_pointsphere.Checked == true)
            {
                drawing.FillEllipse(brushBlue, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2, tbtr_2 * 2, tbtr_2 * 2));
                drawing.DrawLine(penRed, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1 + 2, pictureOrigin.Y - tbty_1 + 2);
                Shapes.Point3d point = new Shapes.Point3d(tbtx_1, tbty_1, 0);
                Shapes.Sphere sphere = new Shapes.Sphere(new Shapes.Point3d(tbtx_2, tbty_2, tbtz_2), tbtr_2);
                if (Collisions.point_sphere(point, sphere)) { collision_vrb = true; }
            }
            else if (radio_pointrectangleprism.Checked == true)
            {
                drawing.DrawLine(penRed, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1 + 2, pictureOrigin.Y - tbty_1 + 2);
                //Draw rectangle prism
                int r1Cornerx = pictureOrigin.X + tbtx_2;
                int r1Cornery = pictureOrigin.Y - tbty_2;
                int r2Cornerx = r1Cornerx + (int)(tbtd_2 / Math.Pow(2, 1 / 2));
                int r2Cornery = r1Cornery - (int)(tbtd_2 / Math.Pow(2, 1 / 2));
                drawing.DrawRectangle(penBlue, new Rectangle(r1Cornerx, r1Cornery, tbtw_2, tbth_2));
                drawing.DrawRectangle(penBlue, new Rectangle(r2Cornerx, r2Cornery, tbtw_2, tbth_2));
                drawing.DrawLine(penBlue, r1Cornerx, r1Cornery, r2Cornerx, r2Cornery);
                drawing.DrawLine(penBlue, r1Cornerx + tbtw_2, r1Cornery, r2Cornerx + tbtw_2, r2Cornery);
                drawing.DrawLine(penBlue, r1Cornerx, r1Cornery + tbth_2, r2Cornerx, r2Cornery + tbth_2);
                drawing.DrawLine(penBlue, r1Cornerx + tbtw_2, r1Cornery + tbth_2, r2Cornerx + tbtw_2, r2Cornery + tbth_2);
                Shapes.RectanglePrism rectangleprism = new Shapes.RectanglePrism(new Shapes.Point3d(tbtx_2, tbty_2, tbtz_2), tbtw_2, tbth_2, tbtd_2);
                Shapes.Point3d point = new Shapes.Point3d(tbtx_1, tbty_1, tbtz_1);
                if (Collisions.point_rectangleprism(point, rectangleprism)) { collision_vrb = true; }
            }
            else if (radio_pointcylinder.Checked == true)
            {
                //draw cylinder
                drawing.FillEllipse(brushBlue, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2, tbtr_2 * 2, tbtr_2 * 2));
                drawing.FillEllipse(brushBlue, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2 - tbth_2, tbtr_2 * 2, tbtr_2 * 2));
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_2 - tbtr_2 + 1, pictureOrigin.Y - tbty_2, pictureOrigin.X + tbtx_2 - tbtr_2 + 1, pictureOrigin.Y - tbty_2 - tbth_2);
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_2 + tbtr_2 - 1, pictureOrigin.Y - tbty_2, pictureOrigin.X + tbtx_2 + tbtr_2 - 1, pictureOrigin.Y - tbty_2 - tbth_2);

                drawing.DrawLine(penRed, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1 + 2, pictureOrigin.Y - tbty_1 + 2);
                Shapes.Point3d point = new Shapes.Point3d(tbtx_1, tbty_1, tbtz_1);
                Shapes.Cylinder cylinder = new Shapes.Cylinder(new Shapes.Point3d(tbtx_2, tbty_2, tbtz_2), tbtr_2, tbth_2);
                if (Collisions.point_cylinder(point, cylinder)) { collision_vrb = true; }
            }
            else if (radio_cylindercylinder.Checked == true)
            {
                //draw cylinder
                drawing.FillEllipse(brushBlue, new Rectangle(pictureOrigin.X + tbtx_1 - tbtr_1, pictureOrigin.Y - tbty_1 - tbtr_1, tbtr_1 * 2, tbtr_1 * 2));
                drawing.FillEllipse(brushBlue, new Rectangle(pictureOrigin.X + tbtx_1 - tbtr_1, pictureOrigin.Y - tbty_1 - tbtr_1 - tbth_1, tbtr_1 * 2, tbtr_1 * 2));
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1 - tbtr_1 + 1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1 - tbtr_1 + 1, pictureOrigin.Y - tbty_1 - tbth_1);
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1 + tbtr_1 - 1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1 + tbtr_1 - 1, pictureOrigin.Y - tbty_1 - tbth_1);
                //draw cylinder
                drawing.FillEllipse(brushRed, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2, tbtr_2 * 2, tbtr_2 * 2));
                drawing.FillEllipse(brushRed, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2 - tbth_2, tbtr_2 * 2, tbtr_2 * 2));
                drawing.DrawLine(penRed, pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2, pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbth_2);
                drawing.DrawLine(penRed, pictureOrigin.X + tbtx_2 + tbtr_2, pictureOrigin.Y - tbty_2, pictureOrigin.X + tbtx_2 + tbtr_2, pictureOrigin.Y - tbty_2 - tbth_2);
                Shapes.Cylinder cylinder1 = new Shapes.Cylinder(new Shapes.Point3d(tbtx_1, tbty_1, tbtz_1), tbtr_1, tbth_1);
                Shapes.Cylinder cylinder2 = new Shapes.Cylinder(new Shapes.Point3d(tbtx_2, tbty_2, tbtz_2), tbtr_2, tbth_2);
                if (Collisions.cylinder_cylinder(cylinder1, cylinder2)) { collision_vrb = true; }
            }
            else if (radio_spheresphere.Checked == true)
            {
                drawing.FillEllipse(brushBlue, new Rectangle(pictureOrigin.X + tbtx_1 - tbtr_1, pictureOrigin.Y - tbty_1 - tbtr_1, tbtr_1 * 2, tbtr_1 * 2));
                drawing.FillEllipse(brushRed, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2, tbtr_2 * 2, tbtr_2 * 2));
                Shapes.Sphere sphere1 = new Shapes.Sphere(new Shapes.Point3d(tbtx_1, tbty_1, tbtz_1), tbtr_1);
                Shapes.Sphere sphere2 = new Shapes.Sphere(new Shapes.Point3d(tbtx_2, tbty_2, tbtz_2), tbtr_2);
                if (Collisions.sphere_sphere(sphere1, sphere2)) { collision_vrb = true; }
            }
            else if (radio_spherecylinder.Checked == true)
            {
                drawing.FillEllipse(brushBlue, new Rectangle(pictureOrigin.X + tbtx_1 - tbtr_1, pictureOrigin.Y - tbty_1 - tbtr_1, tbtr_1 * 2, tbtr_1 * 2));
                //draw cylinder
                drawing.FillEllipse(brushRed, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2, tbtr_2 * 2, tbtr_2 * 2));
                drawing.FillEllipse(brushRed, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2 - tbth_2, tbtr_2 * 2, tbtr_2 * 2));
                drawing.DrawLine(penRed, pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2, pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbth_2);
                drawing.DrawLine(penRed, pictureOrigin.X + tbtx_2 + tbtr_2, pictureOrigin.Y - tbty_2, pictureOrigin.X + tbtx_2 + tbtr_2, pictureOrigin.Y - tbty_2 - tbth_2);
                Shapes.Sphere sphere = new Shapes.Sphere(new Shapes.Point3d(tbtx_1, tbty_1, tbtz_1), tbtr_1);
                Shapes.Cylinder cylinder = new Shapes.Cylinder(new Shapes.Point3d(tbtx_2, tbty_2, tbtz_2), tbtr_2, tbth_2);
                if (Collisions.sphere_cylinder(sphere, cylinder)) { collision_vrb = true; }
            }
            else if (radio_surfacesphere.Checked == true)
            {
                drawing.FillEllipse(brushRed, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2, tbtr_2 * 2, tbtr_2 * 2));
                //Draw surface
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1 + tbth_1);
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1 + tbth_1, pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 + tbth_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)));
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 + tbth_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)));
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)));
                Shapes.Surface surface = new Shapes.Surface(new Shapes.Point3d(tbtx_1, tbty_1, tbtz_1), tbth_1, tbtd_1);
                Shapes.Sphere sphere = new Shapes.Sphere(new Shapes.Point3d(tbtx_2, tbty_2, tbtz_2), tbtr_2);
                if (Collisions.surface_sphere(surface, sphere)) { collision_vrb = true; }

            }
            else if (radio_surfacerectangleprism.Checked == true)
            {
                //Draw rectangle prism
                int r1Cornerx = pictureOrigin.X + tbtx_2;
                int r1Cornery = pictureOrigin.Y - tbty_2;
                int r2Cornerx = r1Cornerx + (int)(tbtd_2 / Math.Pow(2, 1 / 2));
                int r2Cornery = r1Cornery - (int)(tbtd_2 / Math.Pow(2, 1 / 2));
                drawing.DrawRectangle(penRed, new Rectangle(r1Cornerx, r1Cornery, tbtw_2, tbth_2));
                drawing.DrawRectangle(penRed, new Rectangle(r2Cornerx, r2Cornery, tbtw_2, tbth_2));
                drawing.DrawLine(penRed, r1Cornerx, r1Cornery, r2Cornerx, r2Cornery);
                drawing.DrawLine(penRed, r1Cornerx + tbtw_2, r1Cornery, r2Cornerx + tbtw_2, r2Cornery);
                drawing.DrawLine(penRed, r1Cornerx, r1Cornery + tbth_2, r2Cornerx, r2Cornery + tbth_2);
                drawing.DrawLine(penRed, r1Cornerx + tbtw_2, r1Cornery + tbth_2, r2Cornerx + tbtw_2, r2Cornery + tbth_2);
                //Draw surface
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1 + tbth_1);
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1 + tbth_1, pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 + tbth_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)));
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 + tbth_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)));
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)));
                Shapes.Surface surface = new Shapes.Surface(new Shapes.Point3d(tbtx_1, tbty_1, tbtz_1), tbth_1, tbtd_1);
                Shapes.RectanglePrism rectangleprism = new Shapes.RectanglePrism(new Shapes.Point3d(tbtx_2, tbty_2, tbtz_2), tbtw_2, tbth_2, tbtd_2);
                if (Collisions.surface_rectangleprism(surface, rectangleprism)) { collision_vrb = true; }
            }
            else if (radio_surfacecylinder.Checked == true)
            {
                //draw cylinder
                drawing.FillEllipse(brushRed, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2, tbtr_2 * 2, tbtr_2 * 2));
                drawing.FillEllipse(brushRed, new Rectangle(pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbtr_2 - tbth_2, tbtr_2 * 2, tbtr_2 * 2));
                drawing.DrawLine(penRed, pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2, pictureOrigin.X + tbtx_2 - tbtr_2, pictureOrigin.Y - tbty_2 - tbth_2);
                drawing.DrawLine(penRed, pictureOrigin.X + tbtx_2 + tbtr_2, pictureOrigin.Y - tbty_2, pictureOrigin.X + tbtx_2 + tbtr_2, pictureOrigin.Y - tbty_2 - tbth_2);
                //Draw surface
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1 + tbth_1);
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1 + tbth_1, pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 + tbth_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)));
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 + tbth_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)));
                drawing.DrawLine(penBlue, pictureOrigin.X + tbtx_1, pictureOrigin.Y - tbty_1, pictureOrigin.X + tbtx_1 + (int)(tbtd_1 / Math.Pow(2, 1 / 2)), pictureOrigin.Y - tbty_1 - (int)(tbtd_1 / Math.Pow(2, 1 / 2)));
                Shapes.Surface surface = new Shapes.Surface(new Shapes.Point3d(tbtx_1, tbty_1, tbtz_1), tbth_1, tbtd_1);
                Shapes.Cylinder cylinder = new Shapes.Cylinder(new Shapes.Point3d(tbtx_2, tbty_2, tbtz_2), tbtr_2, tbth_2);
                if (Collisions.surface_cylinder(surface, cylinder)) { collision_vrb = true; }
            }
            else if (radio_sphererectangleprism.Checked == true)
            {
                drawing.FillEllipse(brushBlue, new Rectangle(pictureOrigin.X + tbtx_1 - tbtr_1, pictureOrigin.Y - tbty_1 - tbtr_1, tbtr_1 * 2, tbtr_1 * 2));
                //Draw rectangle prism
                int r1Cornerx = pictureOrigin.X + tbtx_2;
                int r1Cornery = pictureOrigin.Y - tbty_2;
                int r2Cornerx = r1Cornerx + (int)(tbtd_2 / Math.Pow(2, 1 / 2));
                int r2Cornery = r1Cornery - (int)(tbtd_2 / Math.Pow(2, 1 / 2));
                drawing.DrawRectangle(penRed, new Rectangle(r1Cornerx, r1Cornery, tbtw_2, tbth_2));
                drawing.DrawRectangle(penRed, new Rectangle(r2Cornerx, r2Cornery, tbtw_2, tbth_2));
                drawing.DrawLine(penRed, r1Cornerx, r1Cornery, r2Cornerx, r2Cornery);
                drawing.DrawLine(penRed, r1Cornerx + tbtw_2, r1Cornery, r2Cornerx + tbtw_2, r2Cornery);
                drawing.DrawLine(penRed, r1Cornerx, r1Cornery + tbth_2, r2Cornerx, r2Cornery + tbth_2);
                drawing.DrawLine(penRed, r1Cornerx + tbtw_2, r1Cornery + tbth_2, r2Cornerx + tbtw_2, r2Cornery + tbth_2);
                Shapes.Sphere sphere = new Shapes.Sphere(new Shapes.Point3d(tbtx_1, tbty_1, tbtz_1), tbtr_1);
                Shapes.RectanglePrism rectangleprism = new Shapes.RectanglePrism(new Shapes.Point3d(tbtx_2, tbty_2, tbtz_2), tbtw_2, tbth_2, tbtd_2);
                if (Collisions.sphere_rectangleprism(sphere, rectangleprism)) { collision_vrb = true; }
            }
            else if (radio_rectangleprismrectangleprism.Checked == true)
            {
                //Draw rectangle prism
                int r1_1Cornerx = pictureOrigin.X + tbtx_1;
                int r1_1Cornery = pictureOrigin.Y - tbty_1;
                int r1_2Cornerx = r1_1Cornerx + (int)(tbtd_1 / Math.Pow(2, 1 / 2));
                int r1_2Cornery = r1_1Cornery - (int)(tbtd_1 / Math.Pow(2, 1 / 2));
                drawing.DrawRectangle(penBlue, new Rectangle(r1_1Cornerx, r1_1Cornery, tbtw_1, tbth_1));
                drawing.DrawRectangle(penBlue, new Rectangle(r1_2Cornerx, r1_2Cornery, tbtw_1, tbth_1));
                drawing.DrawLine(penBlue, r1_1Cornerx, r1_1Cornery, r1_2Cornerx, r1_2Cornery);
                drawing.DrawLine(penBlue, r1_1Cornerx + tbtw_1, r1_1Cornery, r1_2Cornerx + tbtw_1, r1_2Cornery);
                drawing.DrawLine(penBlue, r1_1Cornerx, r1_1Cornery + tbth_1, r1_2Cornerx, r1_2Cornery + tbth_1);
                drawing.DrawLine(penBlue, r1_1Cornerx + tbtw_1, r1_1Cornery + tbth_1, r1_2Cornerx + tbtw_1, r1_2Cornery + tbth_1);
                //Draw rectangle prism
                int r2_1Cornerx = pictureOrigin.X + tbtx_2;
                int r2_1Cornery = pictureOrigin.Y - tbty_2;
                int r2_2Cornerx = r2_1Cornerx + (int)(tbtd_2 / Math.Pow(2, 1 / 2));
                int r2_2Cornery = r2_1Cornery - (int)(tbtd_2 / Math.Pow(2, 1 / 2));
                drawing.DrawRectangle(penRed, new Rectangle(r2_1Cornerx, r2_1Cornery, tbtw_2, tbth_2));
                drawing.DrawRectangle(penRed, new Rectangle(r2_2Cornerx, r2_2Cornery, tbtw_2, tbth_2));
                drawing.DrawLine(penRed, r2_1Cornerx, r2_1Cornery, r2_2Cornerx, r2_2Cornery);
                drawing.DrawLine(penRed, r2_1Cornerx + tbtw_2, r2_1Cornery, r2_2Cornerx + tbtw_2, r2_2Cornery);
                drawing.DrawLine(penRed, r2_1Cornerx, r2_1Cornery + tbth_2, r2_2Cornerx, r2_2Cornery + tbth_2);
                drawing.DrawLine(penRed, r2_1Cornerx + tbtw_2, r2_1Cornery + tbth_2, r2_2Cornerx + tbtw_2, r2_2Cornery + tbth_2);
                Shapes.RectanglePrism rectangleprism1 = new Shapes.RectanglePrism(new Shapes.Point3d(tbtx_1, tbty_1, tbtz_1), tbtw_1, tbth_1, tbtd_1);
                Shapes.RectanglePrism rectangleprism2 = new Shapes.RectanglePrism(new Shapes.Point3d(tbtx_2, tbty_2, tbtz_2), tbtw_2, tbth_2, tbtd_2);
                if (Collisions.rectangleprism_rectangleprism(rectangleprism1, rectangleprism2)) { collision_vrb = true; }
            }

            if (collision_vrb) { label_collisionControl.Text = "Çarpýþma Var"; label_collisionControl.ForeColor = Color.Green; }
            else { label_collisionControl.Text = "Çarpýþma Yok"; label_collisionControl.ForeColor = Color.Red; }
            button_vrb = false;
        }
        private void textBox_x1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
                e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
                e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
                e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
                e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Down || e.KeyCode == Keys.OemMinus) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_x1.Text = "";
            }
        }
        private void textBox_y1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
                       e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
                       e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
                       e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
                       e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
                       e.KeyCode == Keys.Left || e.KeyCode == Keys.Down || e.KeyCode == Keys.OemMinus) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_y1.Text = "";
            }
        }
        private void textBox_z1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
                  e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
                  e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
                  e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
                  e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
                  e.KeyCode == Keys.Left || e.KeyCode == Keys.Down || e.KeyCode == Keys.OemMinus) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_z1.Text = "";
            }
        }
        private void textBox_x2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
                  e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
                  e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
                  e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
                  e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
                  e.KeyCode == Keys.Left || e.KeyCode == Keys.Down || e.KeyCode == Keys.OemMinus) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_x2.Text = "";
            }
        }
        private void textBox_y2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
                  e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
                  e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
                  e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
                  e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
                  e.KeyCode == Keys.Left || e.KeyCode == Keys.Down || e.KeyCode == Keys.OemMinus) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_y2.Text = "";
            }
        }
        private void textBox_z2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
                  e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
                  e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
                  e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
                  e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
                  e.KeyCode == Keys.Left || e.KeyCode == Keys.Down || e.KeyCode == Keys.OemMinus) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_z2.Text = "";
            }
        }
        private void textBox_w1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
               e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
               e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
               e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
               e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
               e.KeyCode == Keys.Left || e.KeyCode == Keys.Down) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_w1.Text = "";
            }
        }
        private void textBox_w2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
          e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
          e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
          e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
          e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
          e.KeyCode == Keys.Left || e.KeyCode == Keys.Down) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_w2.Text = "";
            }
        }
        private void textBox_h1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
          e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
          e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
          e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
          e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
          e.KeyCode == Keys.Left || e.KeyCode == Keys.Down) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_h1.Text = "";
            }
        }
        private void textBox_h2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
          e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
          e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
          e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
          e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
          e.KeyCode == Keys.Left || e.KeyCode == Keys.Down) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_h2.Text = "";
            }
        }
        private void textBox_d1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
          e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
          e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
          e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
          e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
          e.KeyCode == Keys.Left || e.KeyCode == Keys.Down) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_d1.Text = "";
            }
        }
        private void textBox_d2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
          e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
          e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
          e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
          e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
          e.KeyCode == Keys.Left || e.KeyCode == Keys.Down) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_d2.Text = "";
            }
        }
        private void textBox_r1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
          e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
          e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
          e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
          e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
          e.KeyCode == Keys.Left || e.KeyCode == Keys.Down) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_r1.Text = "";
            }
        }
        private void textBox_r2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
          e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
          e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
          e.KeyCode == Keys.D9 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back ||
          e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right ||
          e.KeyCode == Keys.Left || e.KeyCode == Keys.Down) { }
            else
            {
                MessageBox.Show("Please Enter a value greater than 0 !", "Entered Value Error");
                textBox_r2.Text = "";
            }
        }
    }

}
