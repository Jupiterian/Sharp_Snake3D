using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.OpenGl;// для работы с библиотекой OpenGL 
using Tao.FreeGlut;// для работы с библиотекой FreeGLUT 
using Tao.Platform.Windows;// для работы с элементом управления SimpleOpenGLControl 

namespace TochilinaAnna
{
    public partial class Form1 : Form
    {
        GameModeSnake snake;
        bool pause;
        bool ViewTop;
        int background;
        bool f;
        Size Coord;
        uint[] texture;

        public Form1()
        {
            InitializeComponent();
            pause = true;
            ShowWindow.InitializeContexts();
            snake = null;
            ViewTop = false;
            f = false;
            background = 9;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGlut();
        }

        private void InitGlut()
        { 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Gl.glEnable(Gl.GL_TEXTURE_2D);
             
            texture = new uint[18];

            //Fruits
            Bitmap image = new Bitmap("..\\..\\Texture\\orange.jpg");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            System.Drawing.Imaging.BitmapData bitmapdata;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glGenTextures(17, texture);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[0]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);       // Linear Filtering
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);       // Linear Filtering

            image = new Bitmap("..\\..\\Texture\\watermelon.png");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[1]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);       // Linear Filtering
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            image = new Bitmap("..\\..\\Texture\\apple.bmp");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[2]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);       // Linear Filtering
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            image = new Bitmap("..\\..\\Texture\\apple1.bmp");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[3]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);       // Linear Filtering
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            image = new Bitmap("..\\..\\Texture\\pineapple.jpg");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[4]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);       // Linear Filtering
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            image = new Bitmap("..\\..\\Texture\\melon.jpg");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[5]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);       // Linear Filtering
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            image = new Bitmap("..\\..\\Texture\\strawberry.jpg");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[6]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);       // Linear Filtering
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            //Snake
            image = new Bitmap("..\\..\\Texture\\snake.jpg");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[7]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);       // Linear Filtering
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            //Field
            image = new Bitmap("..\\..\\Texture\\field.jpg");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[8]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);       // Linear Filtering
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);


            //Background
            image = new Bitmap("..\\..\\Texture\\backgrounds\\1.jpg");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[9]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            image = new Bitmap("..\\..\\Texture\\backgrounds\\2.png");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[10]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            image = new Bitmap("..\\..\\Texture\\backgrounds\\3.jpg");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[11]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            image = new Bitmap("..\\..\\Texture\\backgrounds\\4.jpg");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[12]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            image = new Bitmap("..\\..\\Texture\\backgrounds\\5.png");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[13]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

            image = new Bitmap("..\\..\\Texture\\backgrounds\\6.png");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[14]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);


            image = new Bitmap("..\\..\\Texture\\backgrounds\\7.png");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[15]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);


            image = new Bitmap("..\\..\\Texture\\backgrounds\\8.png");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[16]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);


            image = new Bitmap("..\\..\\Texture\\backgrounds\\9.png");
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            rect = new Rectangle(0, 0, image.Width, image.Height);
            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[17]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);


            Gl.glClearColor(255, 255, 255, 1);
            SetPerspective();

            //Gl.glEnable(Gl.GL_DEPTH_TEST);
        }


        private void SetPerspective()
        {
            Size WindowMargin = new Size(40, 105);
            ShowWindow.Width = this.Width - WindowMargin.Width;
            ShowWindow.Height = this.Height - WindowMargin.Height;
            Coord = new Size(ShowWindow.Width / 2, ShowWindow.Height / 2);


            if (ViewTop == true) topToolStripMenuItem_Click(null, null);
            else perspectiveToolStripMenuItem_Click_1(null, null);
        }

        private bool InitGame()
        {
            //int mth = Imports.LLr();
            //MessageBox.Show(mth.ToString());
            //mth = IntPtr.Zero;

            UserData user = new UserData();
            if (user.ShowDialog() == DialogResult.OK)
            {
                labelUserName.Text = user.name;

                labelPause.Text = "PAUSE";
                labelPause.BackColor = Color.Coral;
                labelPause.Visible = false;

                snake = null;
                snake = new GameModeSnake(user.fieldX, user.fieldY);

                this.OnResize(null);

                labelLevel.Text = "Level: " + snake.Level();
                labelScore.Text = "Score: " + snake.score;

                timer1.Interval = 160 - ((snake.Level() - 1) * 20) + 1;
                timer1.Start();
                return true;
            }
            return false;
        }

        private void MainDraw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            if (ViewTop == false) DrawBackground();
            Gl.glColor3f(255, 255, 255);

            DrawField();
            DrawSnake();
            DrawFruits();

            Gl.glFlush();
            ShowWindow.Invalidate();
        }

        private void DrawBackground()
        {
            topToolStripMenuItem_Click(null, null);

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[background]);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-Coord.Width, -Coord.Height, 0.0f);
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(Coord.Width, -Coord.Height, 0.0f);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(Coord.Width, Coord.Height, 0.0f);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-Coord.Width, Coord.Height, 0.0f);
            Gl.glEnd();

            Gl.glDisable(Gl.GL_TEXTURE_2D);

            perspectiveToolStripMenuItem_Click_1(null, null);
        }

        private void drawSphere(float x, float y, float r, int amountSegments, int FruitsTexture)
        {
            Glu.GLUquadric quadObj;
            quadObj = Glu.gluNewQuadric();

            Gl.glPushMatrix();
            Gl.glTranslated(x, y, 0);
            Glu.gluQuadricDrawStyle(quadObj, Glu.GLU_FILL);

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[FruitsTexture]);
            Glu.gluQuadricTexture(quadObj, Gl.GL_TRUE);

            Glu.gluSphere(quadObj, r, amountSegments, amountSegments);
            Gl.glPopMatrix();

            Glu.gluDeleteQuadric(quadObj);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }

        private void DrawCube(float x, float y, float size, int mode = Gl.GL_QUADS)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(x, y, 0);

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[7]);

            Gl.glLineWidth(2);
            Gl.glPointSize(3);
            Gl.glBegin(mode);

            //// левая грань
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-size / 2, -size / 2, -size / 2);
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(-size / 2, size / 2, -size / 2);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(-size / 2, size / 2, size / 2);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-size / 2, -size / 2, size / 2);


            //// правая грань
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(size / 2, -size / 2, -size / 2);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(size / 2, -size / 2, size / 2);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(size / 2, size / 2, size / 2);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(size / 2, size / 2, -size / 2);


            //// нижняя грань
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(-size / 2, -size / 2, -size / 2);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-size / 2, -size / 2, size / 2);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(size / 2, -size / 2, size / 2);
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(size / 2, -size / 2, -size / 2);


            // верхняя грань
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-size / 2, size / 2, -size / 2);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-size / 2, size / 2, size / 2);
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(size / 2, size / 2, size / 2);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(size / 2, size / 2, -size / 2);


            //// задняя грань
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(-size / 2, -size / 2, -size / 2);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(size / 2, -size / 2, -size / 2);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(size / 2, size / 2, -size / 2);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-size / 2, size / 2, -size / 2);


            //// передняя грань
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-size / 2, -size / 2, size / 2);
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(size / 2, -size / 2, size / 2);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(size / 2, size / 2, size / 2);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-size / 2, size / 2, size / 2);

            Gl.glEnd();

            Gl.glLineWidth(1);
            Gl.glPopMatrix();

            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }

        private void DrawFruits()
        {
            //Gl.glColor3f(0.0f,1.0f,0.5f);
            for (int i = 0; i < snake.countFruits; i++)
            {
                drawSphere(-Coord.Width + (snake.FruitsX[i] * snake.scale  + (snake.scale  / 2)), -Coord.Height + (snake.FruitsY[i] * snake.scale  + (snake.scale  / 2)), snake.scale  / 2 - 3, 10, snake.TextureFruits[i]);
            }
        }

        private void DrawSnake()
        {
            for (int i = 0; i < snake.sizeSnake; i++)
            {
                Gl.glColor3f(255, 255, 255);
                //Gl.glColor4f(0.0f, 0.0f, 1.0f, 0.6f);
                DrawCube(-Coord.Width + (snake.SnakeX[i] * snake.scale + (snake.scale / 2)), -Coord.Height + (snake.SnakeY[i] * snake.scale + (snake.scale / 2)), snake.scale - 5);

                //Gl.glColor3f(255, 255, 255);
                DrawCube(-Coord.Width + (snake.SnakeX[i] * snake.scale + (snake.scale / 2)), -Coord.Height + (snake.SnakeY[i] * snake.scale + (snake.scale / 2)), snake.scale - 5, Gl.GL_LINES);

                /*Gl.glColor3f(0, 162, 232);
                drawSphere(-Coord.Width + (snake.SnakeX[i] * snake.scale + (snake.scale / 2)), -Coord.Height + (snake.SnakeY[i] * snake.scale + (snake.scale / 2)), snake.scale / 2 - 3, 3);
                */
                /*glColor3f(0, 162, 232);
                DrawCube(-Coord.Width + (snake.SnakeX[i] * snake.scale  + (snake.scale  / 2)), -Coord.Height + (snake.SnakeY[i] * snake.scale  + (snake.scale  / 2)), snake.scale  - 5, Gl.GL_POINTS);*/
            }
        }

        private void DrawField()
        {
            //Gl.glColor3ub(150, 94, 63);
            //Gl.glColor3ub(192, 192, 192);

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[8]);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-Coord.Width, -Coord.Height, 0.0f);
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-Coord.Width + snake.cols * snake.scale, -Coord.Height, 0.0f);
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(-Coord.Width + snake.cols * snake.scale, -Coord.Height + snake.rows * snake.scale, 0.0f);
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(-Coord.Width, -Coord.Height + snake.rows * snake.scale, 0.0f);
            Gl.glEnd();

            //Gl.glRectf(-Coord.Width, -Coord.Height, -Coord.Width + snake.cols * snake.scale, -Coord.Height + snake.cols * snake.scale);
            Gl.glDisable(Gl.GL_TEXTURE_2D);

            Gl.glColor3ub(94, 47, 47);
            Gl.glBegin(Gl.GL_LINES);

            for (int i = 0; i <= snake.cols; i++)
            {
                Gl.glVertex2f(-Coord.Width + i * snake.scale, -Coord.Height);
                Gl.glVertex2f(-Coord.Width + i * snake.scale, -Coord.Height + snake.rows * snake.scale);
            }

            for (int i = 0; i <= snake.rows; i++)
            {
                Gl.glVertex2f(-Coord.Width, -Coord.Height + i * snake.scale);
                Gl.glVertex2f(-Coord.Width+snake.cols*snake.scale, -Coord.Height + i * snake.scale);
            }

            Gl.glEnd();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (snake != null)
            {
                Control control = (Control)sender;

                if (control.Size.Height != (int)(control.Size.Width * snake.rows / snake.cols))
                {
                    control.Size = new Size(control.Size.Width, (int)(control.Size.Width * snake.rows / snake.cols)+ShowWindow.Location.Y);
                    snake.scale = ShowWindow.Height / snake.rows;
                }
            }
            labelPause.Width = this.Width-40;
            labelPause.Location = new Point(labelPause.Location.X, this.Height / 2);
            labelScore.Location = new Point(this.Width - labelScore.Width-25, labelScore.Location.Y);
            labelUserName.Location = new Point(this.Width - labelUserName.Width-25, labelUserName.Location.Y);

            SetPerspective();
            if(snake != null) MainDraw(); //?delete, cause timer working
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f == true || (snake == null && InitGame() == false)) return;

            pause = !pause;
            if (pause == false)
            {
                startToolStripMenuItem.Text = "Stop";
                timer1.Start();
                MainDraw();
                labelPause.Visible = false;
            }
            else
            {
                startToolStripMenuItem.Text = "Start";
                timer1.Stop();
                labelPause.Visible = true;
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (snake != null && pause == false) startToolStripMenuItem_Click(sender, e);

            Grid lg = new Grid();
            lg.Text = "Load Game";
            lg.name = labelUserName.Text;
            lg.code = 1;
            lg.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (snake != null)
            {
                if (pause == false) startToolStripMenuItem_Click(sender, e);

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\RatingPlayers.mdb";
                OleDbCommand command = new OleDbCommand();
                
                command.CommandText = "INSERT INTO [Save game] (Name, [Level], Score) VALUES('" + labelUserName.Text + "', " + snake.Level() + ", " + snake.score + ");";
                command.Connection = connection;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Game saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            else MessageBox.Show("You need to start a new game", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (snake != null && pause == false) startToolStripMenuItem_Click(sender, e);

            Grid lg = new Grid();
            lg.Text = "Rating players";
            lg.code = 0;
            lg.Show();
        }

        private void diagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (snake != null && pause == false) startToolStripMenuItem_Click(sender, e);

            DiagramForm DiagrF = new DiagramForm();
            DiagrF.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = snake.sizeSnake - 1; i > 0; --i)
            {
                snake.SnakeX[i] = snake.SnakeX[i - 1];
                snake.SnakeY[i] = snake.SnakeY[i - 1];
            }

            if (snake.snakeDirection == 0) snake.SnakeX[0] -= 1;
            if (snake.snakeDirection == 1) snake.SnakeX[0] += 1;
            if (snake.snakeDirection == 2) snake.SnakeY[0] += 1;
            if (snake.snakeDirection == 3) snake.SnakeY[0] -= 1;

            if (snake.SnakeX[0] + 1 > snake.cols) snake.snakeDirection = 0;
            if (snake.SnakeX[0] < 0) snake.snakeDirection = 1;
            if (snake.SnakeY[0] + 1> snake.rows) snake.snakeDirection = 3;
            if (snake.SnakeY[0] < 0) snake.snakeDirection = 2;

            if ((snake.SnakeX[0] == snake.cols) ||
                (snake.SnakeX[0] == 0) ||
                (snake.SnakeY[0] == snake.rows) ||
                (snake.SnakeY[0] == 0))
            {
                snake.sizeSnake = 2;
                snake.SnakeX.RemoveRange(2, snake.SnakeX.Count - 2);
                snake.SnakeY.RemoveRange(2, snake.SnakeY.Count - 2);

                if (!snake.menuLevel)
                {
                    snake.Level(snake.sizeSnake / 3 + 1);
                    labelLevel.Text = "Level: " + snake.Level();
                    timer1.Stop();
                    timer1.Interval = 160 - ((snake.Level() - 1) * 20) + 1;
                    timer1.Start();
                }
            }

            for (int i = 1; i < snake.sizeSnake - 1; i++)
                if (snake.SnakeX[0] == snake.SnakeX[i] && snake.SnakeY[0] == snake.SnakeY[i])
                {
                    snake.sizeSnake = i;
                    snake.SnakeX.RemoveRange(i, snake.SnakeX.Count - i);
                    snake.SnakeY.RemoveRange(i, snake.SnakeY.Count - i);

                    if (!snake.menuLevel)
                    {
                        snake.Level(snake.sizeSnake / 3 + 1);
                        labelLevel.Text = "Level: " + snake.Level();
                        timer1.Stop();
                        timer1.Interval = 160 - ((snake.Level() - 1) * 20) + 1;
                        timer1.Start();
                    }
                }

            for (int i = 0; i < snake.countFruits; i++)
                if ((snake.SnakeX[0] == snake.FruitsX[i]) && (snake.SnakeY[0] == snake.FruitsY[i]))
                {
                    snake.score=snake.score + snake.points;
                    labelScore.Text = "Score: " + snake.score;
                    snake.sizeSnake=snake.sizeSnake + 1;

                    snake.SnakeX.Add(snake.SnakeX[snake.sizeSnake - 2]);
                    snake.SnakeY.Add(snake.SnakeY[snake.sizeSnake - 2]);

                    Random r = new Random();
                    snake.FruitsX[i] = r.Next(snake.cols);
                    snake.FruitsY[i] = r.Next(snake.rows);
                    snake.TextureFruits[i] = r.Next(0,7);

                    if (!snake.menuLevel)
                    {
                        snake.Level(snake.sizeSnake / 3 + 1);
                        labelLevel.Text = "Level: " + snake.Level();
                        timer1.Stop();
                        timer1.Interval = 160 - ((snake.Level() - 1) * 20) + 1;
                        timer1.Start();
                    }
                }
            MainDraw();
        }

        private void UpdateLevel(int level)
        {
            snake.Level(level);
            snake.menuLevel= true;
            labelLevel.Text = "Level: " + snake.Level();
            timer1.Interval = 160 - ((snake.Level() - 1) * 20) + 1;
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewTop = true;
            Gl.glViewport(0, 0, ShowWindow.Width, ShowWindow.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-Coord.Width - 1, Coord.Width, -Coord.Height - 1, Coord.Height, 0.0001, 1000);
            Glu.gluLookAt(0, 0, 1, 0, 0, 0, 0, 1, 0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }

        private void perspectiveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewTop = false;
            Gl.glViewport(7, 0, ShowWindow.Width, ShowWindow.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(120, 1, 0.0001, 10000);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0, -100, Coord.Height - 10, 0, 0, 0, 0, 1, 0);
        }

        private void easyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateLevel(1);
        }

        private void normalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateLevel(4);
        }

        private void hardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateLevel(6);
        }

        private void expertToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateLevel(8);
        }

        private void immpossibleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateLevel(9);
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) exitToolStripMenuItem1_Click(sender, e);
            if (snake != null)
            {
                if (e.KeyValue == 'A') snake.snakeDirection = 0;
                if (e.KeyValue == 'D') snake.snakeDirection = 1;
                if (e.KeyValue == 'W') snake.snakeDirection = 2;
                if (e.KeyValue == 'S') snake.snakeDirection = 3;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (snake != null)
            {
                if (keyData == Keys.Space) startToolStripMenuItem_Click(null, null);
                if (keyData == Keys.Left) snake.snakeDirection = 0;
                if (keyData == Keys.Right) snake.snakeDirection = 1;
                if (keyData == Keys.Up) snake.snakeDirection = 2;
                if (keyData == Keys.Down) snake.snakeDirection = 3;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void labelPause_Click(object sender, EventArgs e)
        {
            startToolStripMenuItem_Click(sender, e);
        }

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (snake != null){
                pause = false;
                startToolStripMenuItem_Click(sender, e);
                snake = null;
            }
            startToolStripMenuItem_Click(sender, e);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (snake != null)
            {
                timer1.Stop();
                DialogResult res = MessageBox.Show("Save the game?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    saveToolStripMenuItem_Click(sender, e);
            }
            Application.Exit();
        }

        private void toolStripMenuIBk1_Click(object sender, EventArgs e)
        {
            background = 9;
            if(pause==true && snake != null) MainDraw();
        }

        private void toolStripMenuIBk2_Click(object sender, EventArgs e)
        {
            background = 10;
            if (pause == true && snake != null) MainDraw();
        }

        private void toolStripMenuIBk3_Click(object sender, EventArgs e)
        {
            background = 11;
            if (pause == true && snake != null) MainDraw();
        }

        private void toolStripMenuIBk4_Click(object sender, EventArgs e)
        {
            background = 12;
            if (pause == true && snake != null) MainDraw();
        }

        private void toolStripMenuIBk5_Click(object sender, EventArgs e)
        {
            background = 13;
            if (pause == true && snake != null) MainDraw();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            background = 14;
            if (pause == true && snake != null) MainDraw();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            background = 15;
            if (pause == true && snake != null) MainDraw();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            background = 16;
            if (pause == true && snake != null) MainDraw();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            background = 17;
            if (pause == true && snake != null) MainDraw();
        }
    }
}
