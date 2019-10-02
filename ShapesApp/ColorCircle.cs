namespace ShapesApp.Library
{
    public class ColorCircle : ColorCircle
    {
        public string Color { get; set; }
        public override double GetPerimeter()
        {
            System.Console.WriteLine("Calculating perimeter...");
            return base.GetPerimeter(); //uses base class implementation
        }
    } 
}