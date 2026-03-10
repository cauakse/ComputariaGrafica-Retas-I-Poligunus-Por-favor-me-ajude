using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoImagem
{
    internal class Funcoes
    {

        internal static void CriarImagemTodaBranca(Bitmap originalBitmap)
        {
            int width = originalBitmap.Width;
            int height = originalBitmap.Height;
            int pixelSize = 3;


            BitmapData bitmapDataSrc = originalBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                for (int y = 0; y < height; y++) {

                    for (int x = 0; x < width; x++)
                    {
                        src[0] = 255;
                        src[1] = 255;
                        src[2] = 255;

                        src+=pixelSize;
                    }
                    src+= padding;
                }

            }

            originalBitmap.UnlockBits(bitmapDataSrc);
        }

        private static unsafe void DesenharLinhaAlgoritmoEquacaoReal(Bitmap originalBitmap, Point p0, Point p1, int v, byte* src, BitmapData data)
        {
            int width = originalBitmap.Width;
            int height = originalBitmap.Height;
            int pixelSize = 3;
            int lineSize = data.Stride;

            int dx = p1.X - p0.X;
            int dy = p1.Y - p0.Y;
            double m = (double)dy / dx;

            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                for(int x = p0.X; x!= p1.X; x+= Math.Sign(dx))
                {
                    double y = p0.Y + m * (x - p0.X);
                    int yInt = (int)Math.Round(y);
                    byte* pixel = src + yInt * lineSize + x * pixelSize;
                    if (x >= 0 && x < width && yInt >= 0 && yInt < height)
                    {
                        pixel[0] = (byte)v;
                        pixel[1] = (byte)v;
                        pixel[2] = (byte)v;
                    }

                }
            }
            else
            {
                for(int y = p0.Y; y!=p1.Y; y+= Math.Sign(dy))
                {
                    double x = p0.X + (y- p0.Y) / m;
                    int xInt = (int)Math.Round(x);
                    byte* pixel = src + y * lineSize + xInt * pixelSize;
                    if (xInt >= 0 && xInt < width && y >= 0 && y < height)
                    {
                        pixel[0] = (byte)v;
                        pixel[1] = (byte)v;
                        pixel[2] = (byte)v;
                    }
                }
            }
        }

        private static unsafe void DesenharLinhaAlgoritmoDDA(Bitmap originalBitmap, Point p0, Point p1, int v, byte* src, BitmapData bitmapDataSrc)
        {

            int width = originalBitmap.Width;
            int height = originalBitmap.Height;
            int pixelSize = 3;

            int padding = bitmapDataSrc.Stride - (width * pixelSize);
            int lineSize = bitmapDataSrc.Stride;
            int X1 = p0.X, Y1 = p0.Y, X2 = p1.X, Y2 = p1.Y;
            int Length;
            int dx = X2 - X1;
            int dy = Y2 - Y1;
            double X, Y, Xinc, Yinc;

            Length = Math.Abs(X2 - X1);

            if (Math.Abs(Y2 - Y1) > Length) Length = Math.Abs(Y2 - Y1);

            Xinc = (double)(X2 - X1) / Length;
            Yinc = (double)(Y2 - Y1) / Length;

            X = X1; Y = Y1;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (dx > 0)
                {
                    while (X <= X2)
                    {
                        int xi = (int)Math.Round(X);
                        int yi = (int)Math.Round(Y);

                        if (xi >= 0 && xi < width && yi >= 0 && yi < height)
                        {
                            byte* pixel = src + yi * lineSize + xi * pixelSize;
                            pixel[0] = pixel[1] = pixel[2] = (byte)v;
                        }

                        X += Xinc;
                        Y += Yinc;
                    }
                }
                else
                {
                    while (X >= X2)
                    {
                        int xi = (int)Math.Round(X);
                        int yi = (int)Math.Round(Y);

                        if (xi >= 0 && xi < width && yi >= 0 && yi < height)
                        {
                            byte* pixel = src + yi * lineSize + xi * pixelSize;
                            pixel[0] = pixel[1] = pixel[2] = (byte)v;
                        }

                        X += Xinc;
                        Y += Yinc;
                    }
                }
            }
            else
            {
                if (dy > 0)
                {
                    while (Y <= Y2)
                    {
                        int xi = (int)Math.Round(X);
                        int yi = (int)Math.Round(Y);

                        if (xi >= 0 && xi < width && yi >= 0 && yi < height)
                        {
                            byte* pixel = src + yi * lineSize + xi * pixelSize;
                            pixel[0] = pixel[1] = pixel[2] = (byte)v;
                        }

                        X += Xinc;
                        Y += Yinc;
                    }
                }
                else
                {
                    while (Y >= Y2)
                    {
                        int xi = (int)Math.Round(X);
                        int yi = (int)Math.Round(Y);

                        if (xi >= 0 && xi < width && yi >= 0 && yi < height)
                        {
                            byte* pixel = src + yi * lineSize + xi * pixelSize;
                            pixel[0] = pixel[1] = pixel[2] = (byte)v;
                        }

                        X += Xinc;
                        Y += Yinc;
                    }
                }
            }
        }

        private static unsafe void DesenharLinhaAlgoritmoRapidas(Bitmap originalBitmap, Point p0, Point p1, int v, byte* src, BitmapData bitmapDataSrc)
        {
            int width = originalBitmap.Width;
            int height = originalBitmap.Height;
            int pixelSize = 3;
            int stride = bitmapDataSrc.Stride;

            int x1 = p0.X;
            int y1 = p0.Y;
            int x2 = p1.X;
            int y2 = p1.Y;

            // 1️⃣ Se x2 < x1 → troca pontos
            if (x2 < x1)
            {
                (x1, x2) = (x2, x1);
                (y1, y2) = (y2, y1);
            }

            int dx = x2 - x1;
            int dy = y2 - y1;

            int declive = 1;

            // 2️⃣ Se dy < 0 → inverter
            if (dy < 0)
            {
                declive = -1;
                dy = -dy;
                y1 = -y1;
                y2 = -y2;
            }

            bool trocaXY = false;

            // 3️⃣ Se |dy| > |dx| → trocar x com y
            if (dy > dx)
            {
                trocaXY = true;

                (x1, y1) = (y1, x1);
                (x2, y2) = (y2, x2);
                (dx, dy) = (dy, dx);
            }

            int d = 2 * dy - dx;
            int incE = 2 * dy;
            int incNE = 2 * (dy - dx);

            int y = y1;

            for (int x = x1; x <= x2; x++)
            {
                int drawX = trocaXY ? y : x;
                int drawY = trocaXY ? x : y;

                if (declive == -1)
                    drawY = -drawY;

                if (drawX >= 0 && drawX < width &&
                    drawY >= 0 && drawY < height)
                {
                    byte* pixel = src + drawY * stride + drawX * pixelSize;
                    pixel[0] = pixel[1] = pixel[2] = (byte)v;
                }

                if (d <= 0)
                {
                    d += incE;
                }
                else
                {
                    d += incNE;
                    y += 1;
                }
            }
        }

        internal static unsafe void CircunferenciaEquacaoReal(Bitmap bitmap, Point p0, Point p1, int v, byte* src, BitmapData bitmapDataSrc)
        {
            int cx = p0.X, cy = p0.Y;
            int raio = Math.Abs(p1.X - p0.X);

            for(int x =0; x<raio; x++)
            {
                int y = (int)Math.Round(Math.Sqrt(Math.Pow(raio, 2) - Math.Pow(x, 2)));
                pintaEspelho(bitmap, x, y, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, y, x, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, y, -x, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, x, -y, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, -x, -y, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, -y, -x, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, -y, x, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, -x, y, cx, cy, bitmapDataSrc, src, v);
            }
        }

        internal static unsafe void CircunferenciaPontoMedio(Bitmap bitmap, Point p0, Point p1, int v, byte* src, BitmapData bitmapDataSrc)
        {
            int cx = p0.X, cy = p0.Y;
            int x =0, y = Math.Abs(p1.X - p0.X);
            double d = 1 - y;
            int width = bitmap.Width, height = bitmap.Height;
            int pixelSize = 3;
            byte* pixel = src + (cy + y) * bitmapDataSrc.Stride + (cx + x) * pixelSize;

            if(cx + x >= 0 && cx + x < width && cy + y >= 0 && cy + y < height)
                pixel[0] = pixel[1] = pixel[2] = (byte)v;

            while (y>x)
            {
                if (d < 0)
                {
                    d += 2 * x + 3;

                }
                else
                {
                    d += 2 * (x - y) + 5;
                    y--;
                }

                x++;
                pintaEspelho(bitmap, x, y, cx, cy,bitmapDataSrc,src,v);
                pintaEspelho(bitmap,y,x, cx, cy,bitmapDataSrc,src,v);
                pintaEspelho(bitmap, y, -x, cx, cy,bitmapDataSrc,src,v);
                pintaEspelho(bitmap, x, -y, cx, cy,bitmapDataSrc,src,v);
                pintaEspelho(bitmap, -x, -y, cx, cy,bitmapDataSrc,src,v);
                pintaEspelho(bitmap,-y, -x, cx, cy,bitmapDataSrc,src,v);
                pintaEspelho(bitmap, -y, x, cx, cy,bitmapDataSrc,src,v);
                pintaEspelho(bitmap, -x, y, cx, cy,bitmapDataSrc,src,v);
            }

        }

        private static unsafe void pintaEspelhoElipse(
    Bitmap bitmap,
    int x,
    int y,
    BitmapData bitmapDataSrc,
    byte* src,
    int v)
        {
            int pixelSize = 3;

            if (x >= 0 && x < bitmap.Width &&
                y >= 0 && y < bitmap.Height)
            {
                byte* pixel = src + y * bitmapDataSrc.Stride + x * pixelSize;
                pixel[0] = pixel[1] = pixel[2] = (byte)v;
            }
        }

        private static unsafe void pintaEspelho(Bitmap bitmap, int x, int y, int cx, int cy,BitmapData bitmapDataSrc,byte* src, int v)
        {
            int drawX = cx + x;
            int drawY = cy + y;
            int pixelSize = 3;
            if(drawX >= 0 && drawX < bitmap.Width && drawY >= 0 && drawY < bitmap.Height)
            {
                byte* pixel = src+ drawY * bitmapDataSrc.Stride + drawX * pixelSize;
                pixel[0] = pixel[1] = pixel[2] = (byte)v;
            }
        }

        internal static unsafe void CircunferenciaTrigonometria(Bitmap bitmap, Point p0, Point p1, int v, byte* src, BitmapData bitmapDataSrc)
        {
            int cx = p0.X, cy = p0.Y;
            int pixelSize = 3;
            int raio = Math.Abs(p1.X - p0.X);
            double perimetro = 2 * Math.PI * raio;
            double angulo = 0;
            double incremento = Math.Max(1.0 / raio, 0.001);
            double angInicio = Math.PI / 4;
            double angFim = Math.PI / 2;

            for (double i = angInicio; i <= angFim; i+=incremento) {
                int x = (int)Math.Round(raio * Math.Cos(i));
                int y = (int)Math.Round(raio * Math.Sin(i));

                pintaEspelho(bitmap, x, y, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, y, x, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, y, -x, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, x, -y, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, -x, -y, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, -y, -x, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, -y, x, cx, cy, bitmapDataSrc, src, v);
                pintaEspelho(bitmap, -x, y, cx, cy, bitmapDataSrc, src, v);
            }
        }

        internal static unsafe void ElipsePontoMedio(Bitmap bitmap, Point p0, Point p1, int v, byte* src, BitmapData bitmapDataSrc)
        {
            //gerar o retangulo e pegar o raio A e raio B
            int cx = p0.X, cy = p0.Y;
            int fx = p1.X, fy = p1.Y;

            int left = Math.Min(cx, fx);
            int top = Math.Min(cy, fy);
            int width = Math.Abs(fx - cx);
            int height = Math.Abs(fy - cy);

            //pegar o raioA e o raioB
            double b = height / 2.0;
            double a = width / 2.0;
            int xc = (int)Math.Round(left + width / 2.0);
            int yc = (int)Math.Round(top + height / 2.0);

            int x = 0;
            int y = (int)b;
            double d1 = b * b - a * a * b + 0.25 * a * a;

            while (a * a * (y - 0.5) > b * b * (x + 1))
            {
                pintaEspelhoElipse(bitmap, xc + x, yc + y, bitmapDataSrc, src, v);
                pintaEspelhoElipse(bitmap, xc - x, yc + y, bitmapDataSrc, src, v);
                pintaEspelhoElipse(bitmap, xc + x, yc - y, bitmapDataSrc, src, v);
                pintaEspelhoElipse(bitmap, xc - x, yc - y, bitmapDataSrc, src, v);

                if (d1 < 0)
                {
                    d1 += b * b * (2 * x + 3);
                    x++;
                }
                else
                {
                    d1 += b * b * (2 * x + 3) + a * a * (-2 * y + 2);
                    x++;
                    y--;
                }
            }

            double d2 = b * b * (x + 0.5) * (x + 0.5) + a * a * (y - 1) * (y - 1) - a * a * b * b;

            while (y > 0)
            {
                pintaEspelhoElipse(bitmap, xc + x, yc + y, bitmapDataSrc, src, v);
                pintaEspelhoElipse(bitmap, xc - x, yc + y, bitmapDataSrc, src, v);
                pintaEspelhoElipse(bitmap, xc + x, yc - y, bitmapDataSrc, src, v);
                pintaEspelhoElipse(bitmap, xc - x, yc - y, bitmapDataSrc, src, v);

                if (d2 < 0)
                {
                    d2 += b * b * (2 * x + 2) + a * a * (-2 * y + 3);
                    x++;
                    y--;
                }
                else
                {
                    d2 += a * a * (-2 * y + 3);
                    y--;
                }
            }
        }

        internal static unsafe void DesenharPoligono(Bitmap bitmap, List<Vertice> vertices, int v)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                Point p0 = new Point(vertices[i].getX(), vertices[i].getY());
                Point p1 = new Point(vertices[(i + 1) % vertices.Count].getX(), vertices[(i + 1) % vertices.Count].getY());
                Desenhar(bitmap, p0, p1, v, AlgoritmoSelecionado.RETA_RETASRAPIDAS);
            }

            Point p01 = new Point(vertices[vertices.Count - 1].getX(), vertices[vertices.Count - 1].getY());
            Point p11 = new Point(vertices[0].getX(), vertices[0].getY());
            Desenhar(bitmap, p01, p11, v, AlgoritmoSelecionado.RETA_RETASRAPIDAS);
        }



        internal static unsafe void Desenhar(Bitmap bitmap, Point p0, Point p1, int v, AlgoritmoSelecionado algoritmo)
        {
            BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            byte* src = (byte*)data.Scan0.ToPointer();

            try
            {
                switch (algoritmo)
                {
                    case AlgoritmoSelecionado.RETA_EQUACAO_REAL:
                        DesenharLinhaAlgoritmoEquacaoReal(bitmap, p0, p1, v, src, data);
                        break;

                    case AlgoritmoSelecionado.RETA_DDA:
                        DesenharLinhaAlgoritmoDDA(bitmap, p0, p1, v, src, data);
                        break;

                    case AlgoritmoSelecionado.RETA_RETASRAPIDAS:
                        DesenharLinhaAlgoritmoRapidas(bitmap, p0, p1, v, src, data);
                        break;

                    case AlgoritmoSelecionado.CIRCUNFERENCIA_EQUACAO_REAL:
                        CircunferenciaEquacaoReal(bitmap, p0, p1, v, src, data);
                        break;

                    case AlgoritmoSelecionado.CIRCUNFERENCIA_PONTO_MEDIO:
                        CircunferenciaPontoMedio(bitmap, p0, p1, v, src, data);
                        break;
                    
                    case AlgoritmoSelecionado.CIRCUNFERENCIA_TRIGONOMETRIA:
                        CircunferenciaTrigonometria(bitmap, p0, p1, v, src, data);
                        break;

                    case AlgoritmoSelecionado.ELIPSE_PONTO_MEDIO:
                        ElipsePontoMedio(bitmap, p0, p1, v, src, data);
                        break;
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Erro ao desenhar linha: " + ex.Message);
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }
    }
}
