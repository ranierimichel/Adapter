using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterExercise
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        int side;
        public SquareToRectangleAdapter(Square square)
        {
            side = square.Side;
        }

        public int Width => side;
        public int Height => side;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square();
            square.Side = 11;
            var rectangle = new SquareToRectangleAdapter(square);            

            Console.WriteLine(ExtensionMethods.Area(rectangle));            
        }
    }
}
