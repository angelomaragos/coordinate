//Angelo Maragos
// This program demonstrates overloading and implict & explicit conversions by adding/subtracing various Polar and Rectangular coordinates
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace UML.Assignment6
{
    class pnt  //pnt class contains rect and polar strucs as well as overload and conversion operators
    {




        public struct PolarPoint  // struct PolarPoint  aka  PolarCoordinate
        {
            public PolarPoint(double radius, double angle)  //gather radius and angle/degree of polar coordinates
            {
                _angle = angle;
                _radius = radius;
                
            }

            


            public static implicit operator Rectangular(PolarPoint p1)      //implict operator to convert Polar to Rect
            {


              double dividor = Math.PI / 180.0;
              double radians = p1._angle * dividor;

              double resultX = (float)Math.Cos(radians) * p1._radius;
              double  resultY = (float)Math.Sin(radians) * p1._radius;



                Rectangular rect = new pnt.Rectangular(resultX, resultY);
                return rect;
            }

            







           public static PolarPoint operator +(PolarPoint p1, PolarPoint p2)  //overloading + to add polar coordinates
            {
               
               //convert polar coordinates to rectangular.  add coordinates.  convert back to polar and return.
               
               double dividor = Math.PI / 180.0;
                double radians = p1._angle * dividor;
                double radians2 = p2._angle * dividor;

                double resultX = (float)Math.Cos(radians) * p1._radius;
                double resultY = (float)Math.Sin(radians) * p1._radius;

                double resultX2 = (float)Math.Cos(radians2) * p2._radius;
                double resultY2 = (float)Math.Sin(radians2) * p2._radius;


                double nX = resultX + resultX2;
                double nY = resultY + resultY2;

          


            double nP1 =  Math.Sqrt((nX * nX) + (nY * nY));
              
              double np2 = Math.Atan(nY / nX);


               // <->  degree/radians

              np2 = np2 * 180;   /////////
              np2 = np2 / Math.PI;  //////////


           

              double nP2 = np2;

              

              PolarPoint p3 = new PolarPoint(nP1, np2);
               return p3;
            }

           public static PolarPoint operator -(PolarPoint p1, PolarPoint p2)           //overloading - opeartor to subtarct polar coordinates
           {


               //convert polar coordinates to rectangular.  subtact coordinates.  convert back to polar and return.

               double dividor = Math.PI / 180.0;
               double radians = p1._angle * dividor;
               double radians2 = p2._angle * dividor;

               double resultX = (float)Math.Cos(radians) * p1._radius;
               double resultY = (float)Math.Sin(radians) * p1._radius;

               double resultX2 = (float)Math.Cos(radians2) * p2._radius;
               double resultY2 = (float)Math.Sin(radians2) * p2._radius;


               double nX = resultX - resultX2;
               double nY = resultY - resultY2;


              double nP1 = Math.Sqrt((nX * nX) + (nY * nY));
               
               double np2 = Math.Atan(nY / nX);

               // <->  degree/radians
               np2 = np2 * 180;   /////////
               np2 = np2 / Math.PI;  //////////


   

               double nP2 = np2;
               PolarPoint p3 = new PolarPoint(nP1, nP2);

               
             
               return p3;
           }

           public string displayP()
           {
               
               
               return String.Format(" The radius is: {0:0.00}. The angle/degree is: {1:0.00}",  _radius ,  _angle);  //string representation 
           }




         
            // public to give necessary amount of access
           public double _angle;
           public double _radius;
        }

       public struct Rectangular
        {
           public Rectangular(double x, double y)  //gather x & y coordinates
            {
                _x = x;
                _y = y;
            }


            public static Rectangular operator +(Rectangular r1, Rectangular r2) // overloading + to add two rects
            {
                return new Rectangular(
                    r1._x + r2._x,
                    r1._y + r2._y);

            }

            public static Rectangular operator -(Rectangular r1, Rectangular r2)  //overloading - to subtract two rects
            {
                return new Rectangular(
                    r1._x - r2._x,
                    r1._y - r2._y);

            }


            public string display()
            {
                return String.Format("X is: {0:0.00}. Y is: {1:0.00}", _x, _y);  //string representation 
            }


          


            public static explicit operator pnt.PolarPoint(Rectangular r1)        // explicit conversion operator...with appropriate formula
            {
                double nP1 = Math.Sqrt((r1._x * r1._x) + (r1._y * r1._y));
              //  double np2 = Math.Atan(r1._y / r1._x);
                double np2 =(r1._y / r1._x);
                double nP2 = Math.Atan(np2);
                nP2 = nP2 * 180;
                nP2 = nP2 / Math.PI;

                PolarPoint p3 = new PolarPoint(nP1, nP2);
                return p3;



            }

           

            public double _x;
            public double _y;
        }




    }

    

  
 

    class Overloading_Conversion
    {
        static void Main(string[] args)
        {



           pnt.PolarPoint p4 = new pnt.PolarPoint(5.0, 53.0); 
           pnt.PolarPoint p3 = new pnt.PolarPoint(4.0, 50.0);
           pnt.PolarPoint p2 = new pnt.PolarPoint(5.0, 4.0);
           pnt.PolarPoint p1 = new pnt.PolarPoint(0, 0);


         pnt.Rectangular r4 = new pnt.Rectangular(3.0, 4.0);
         pnt.Rectangular r3 = new pnt.Rectangular(4.0, 5.0);
         pnt.Rectangular r2 = new pnt.Rectangular(5.0, 4.0);
         pnt.Rectangular r1 = new pnt.Rectangular(0, 0);



         Console.WriteLine("Polar coordinate (5.0, 4.0) + (Polar coordinate conversion) of Rectangular coordinate (3.0, 4.0) is: ");
            var x = p2 + (pnt.PolarPoint)r4;
            var xx = x.displayP();
            Console.WriteLine("{0}", xx);
            Console.WriteLine();

            Console.WriteLine("Polar coordinate (5.0, 53.0) += (Polar coordinate conversion) of Rectangular coordinate (4.0, 5.0) is: ");
            p4 += (pnt.PolarPoint)r3;
            var pp4 = p4.displayP();
            Console.WriteLine("{0}", pp4);
            Console.WriteLine();

            Console.WriteLine("Rectangular coordinate (0, 0) -= Polar coordinate (4.0, 50.0) is:");
            r1 -= p3;
            var rr1 = r1.display();
            Console.WriteLine("{0}", rr1);
            Console.WriteLine();

            Console.WriteLine("Rectangular coordinate (5.0, 4.0) - Polar coordinate (4.0, 50.0) is: ");
            var y = r2 - p3;
            var yy = y.display();
            Console.WriteLine("{0}", yy);
            Console.WriteLine();



            Console.WriteLine("Rectangular coordinate (4.0, 5.0) + Rectanular coordinate (3.0, 4.0) is: ");
           var z = r3 + r4;
           var zz = z.display();
           Console.WriteLine("{0}", zz);
           Console.WriteLine();



           Console.WriteLine("Polar coordinate (5.0, 4.0) + Polar coordinate (5.0, 4.0) is: ");
          var a = p2 + p2;
          var aa = a.displayP();
          Console.WriteLine("{0}", aa);
          Console.WriteLine();

          Console.WriteLine("Rectangular coordinate (3.0, 4.0) - Rectanular coordinate (3.0, 4.0) is: ", r4, r4);
            var b = r4 - r4;
           var bb = b.display();
           Console.WriteLine("{0}", bb);
           Console.WriteLine();

           Console.WriteLine("Porlar coordinate (4.0, 50.0) - Polar coordinate (5.0, 4.0) is: ");
            var c = p3 - p2;
            var cc = c.displayP();
            Console.WriteLine("{0}", cc);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Press enter to exit.");
        
            Console.ReadLine();

        }
    }
}
