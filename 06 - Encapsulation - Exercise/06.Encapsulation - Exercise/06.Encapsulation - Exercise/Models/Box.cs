
using System;

namespace Encapsulation.Models
{
    public class Box
    {
		private const string ArgumentExceptionError = "{0} cannot be zero or negative.";

		private double lenght;
		private double width;
		private double height;

        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;
            Height = height;
         } 
		public double Lenght
		{
			get { return lenght; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionError, nameof(Lenght)));

                }
                lenght = value;
            }
        }
		public double Width
		{
			get { return width; }
			private set
			{
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionError, nameof(Width)));

                }
                width = value;
			}
		}

        public double Height
		{
			get { return height; }
			private set 
			{
				if (value <= 0)
				{
					throw new ArgumentException(string.Format(ArgumentExceptionError, nameof(Height)));

                }
				height = value; 
			}
		}




        public double SurfaceArea()
        {
            return 2*((Lenght * Width) + (Lenght * Height) + (Width * Height));
        }

        public double LateralSurfaceArea()
        {  
            return 2 * Lenght * Height + 2 * Width * Height;
        }

        public double Volume()
        {
            return Width * Height * Lenght;
        }
    }
}
