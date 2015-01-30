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

namespace GrapeShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateClassList();
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
        }

    }
}
