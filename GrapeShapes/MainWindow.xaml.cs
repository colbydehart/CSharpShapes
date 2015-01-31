using CSharpShape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace GrapeShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Shape> ShapeList = new List<Shape>();
        private int RedTick = 0;
        private int BlueTick = 86;
        private int GreenTick = 172;
        public MainWindow()
        {
            InitializeComponent();
            PopulateClassList();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dipatcherTimer_Tick);
            timer.Interval = new TimeSpan(0,0,0,0,50);
            timer.Start();
        }

        private void dipatcherTimer_Tick(object sender, EventArgs e)
        {
            RedTick = RedTick > 254 ? -255 : RedTick + 1;
            GreenTick = GreenTick > 254 ? -255 : GreenTick + 1;
            BlueTick = BlueTick > 254 ? -255 : BlueTick + 1;
            ShapeCanvas.Children.Clear();
            double tix = DateTime.Now.Ticks;
            foreach (Square shape in ShapeList)
            {
                shape.FillColor = new SolidColorBrush(Color.FromRgb(
                    (byte)(Math.Abs(RedTick)),
                    (byte)(Math.Abs(BlueTick)),
                    (byte)(Math.Abs(GreenTick))
                ));
                shape.X = shape.X + shape.Velocity[0];
                shape.Y = shape.Y + shape.Velocity[1];
                if ((shape.X + shape.Width) > (decimal)ShapeCanvas.Width || shape.X <= 0)
                    shape.Velocity[0] = -shape.Velocity[0];
                if ((shape.Y + shape.Height) > (decimal)ShapeCanvas.Height || shape.Y <= 0)
                    shape.Velocity[1] = -shape.Velocity[1];
                shape.DrawOnto( ShapeCanvas, shape.X, shape.Y);
            }
        }

        public static int ArgumentCountFor(string className)
        {
            Type classType = GetShapeTypeOf(className);
            ConstructorInfo classConstructor = classType.GetConstructors().First();
            return classConstructor.GetParameters().Length;
        }

        private static Type GetShapeTypeOf(string className)
        {
            return Assembly.GetAssembly(typeof(Shape)).GetTypes().Where(shapeType => shapeType.Name == className).First();
        }

        public static Shape InstantiateWithArguments(string className, object[] args)
        {
            Type classType = GetShapeTypeOf(className);
            ConstructorInfo classConstructor = classType.GetConstructors().First();
            return (Shape)classConstructor.Invoke(args);
        }

        private void PopulateClassList()
        {
            var classList = new List<string>();
            var shapeType = typeof(Shape);
            foreach (Type type in Assembly.GetAssembly(shapeType).GetTypes())
            {
                if (type.IsSubclassOf(shapeType) && !type.IsAbstract)
                {
                    classList.Add(type.Name);
                }
            }
            ShapeType.ItemsSource = classList;
        }

        private void ShapeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string className = (String)ShapeType.SelectedValue;
            int NumberOfArgs = ArgumentCountFor(className);
            Argument2.IsEnabled = NumberOfArgs > 1;
            Argument3.IsEnabled = NumberOfArgs > 2;
            Argument1.Text = Argument2.Text = Argument3.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Retrieve correct # of args
            string ClassName = ShapeType.SelectedValue.ToString();
            int argCount = ArgumentCountFor(ClassName);
            object[] potentialArgs = new object[] { 
                Int32.Parse(Argument1.Text),
                Int32.Parse(Argument2.Text), 
                Int32.Parse(Argument3.Text) 
            };
            //Create shape
            Shape shape = 
                InstantiateWithArguments(ClassName, potentialArgs.Take(argCount).ToArray());
            //Draw shape
            shape.DrawOnto(ShapeCanvas, 50, 50);
            ShapeList.Add(shape);  
        }

    }
}
