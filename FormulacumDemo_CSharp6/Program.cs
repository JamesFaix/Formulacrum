using System;
using System.Linq;
using Formulacrum.Nodes;
using static Formulacrum.A1References;
using static Formulacrum.Common;
using static Formulacrum.Logic;
using static Formulacrum.Math;

namespace Formulacrum.Demo {

    class Program {

        static void Main() {

            //CreateIntNode();

            //CreateDecimalNode();

            //CreateStringNode();

            //CreateTrivialFormula();

            //CreateSingleOperatorFormula();

            //CreateSingleFunctionFormula();

            //GroupNodes();

            //LinqToNodes();

            //CreateReference();

            OutlineRendering();

            Console.Write("Press any key to exit.");
            Console.Read();
        }

        private static void Write(string label, object obj) {
            Console.WriteLine(label);
            Console.WriteLine("    " + obj);
//            Console.WriteLine("{0}   =>   {1}", label, n);
            Console.WriteLine();
        }

        private static void CreateIntNode() {
            //You can create nodes that represent literal values using the various overloads of 
            //Formulacrum.Common.Literal

            Node n = Literal(123);
            Write("Literal(123)", n);

            //As expected, ToString will convert a node to a string.
            //For this example, the result is the literal value we assigned, "123";
            //more complicated nodes will be converted to more interesting formulas.
        }

        private static void CreateDecimalNode() {
            //This example can be used with Decimal or Double values.
            //There are Literal overloads for both types, which work exactly the same.

            var pi = System.Math.PI;

            Node n = Literal(pi);        
            Write("Literal(pi)", n);
            
            //By default, Formulacrum formats decimal types with 2 digits after the decimal place.
            //There are overloads for each type of literal nodes that take a custom format string.

            n = Literal(pi, "{0:000.000}");
            Write("Literal(pi, \"{0:000.000}\")", n);

            //Internally this will call String.Format(format, pi), 
            //so format strings must be in the format /accepted by String.Format.  
            //!!You cannot use Excel-style format strings!!
            
            n = Literal(pi, "{0}");
            Write("Literal(pi, \"{0}\")", n);
        }

        private static void CreateStringNode() {

            Node n = Literal("Hello");
            Write("Literal(\"Hello\")", n);

            //String nodes will be formatted with double quotes by default.
            //If you need some arbitrary unquoted text, you can override the format, as with decimal literal nodes.

            n = Literal("Hello", "{0}");
            Write("Literal(\"Hello\", \"{0}\")", n);
        }

        private static void CreateTrivialFormula() {
            //The Formula operator inserts a "=" before its single argument.
            //Typically this will be the outermost node, unless you are creating a formula fragment.

            var n = Formula(Literal(123));
            Write("Formula(Literal(123))", n);
        }

        private static void CreateSingleOperatorFormula() {
            //The Add operator will insert a "+" between its two arguments.
            //The other math operators work exactly the same (except negation, which only takes 1 argument).
            //Note, for flexibility, all functions and operators can take any type of node as any argument. 

            var n = Formula(
                Add(
                    Literal(1), 
                    Literal(2)));

            Write("Formula(Add(Literal(1), Literal(2)))", n);

            //If you would prefer to put binary operators between their arguments in source code,
            //as they are in Excel formulas, you can use the Infix extension method for Node.
            //This is syntactic sugar, and produces the same result.

            n = Formula(
                Literal(1).Infix(
                Add(), 
                Literal(2)));

            Write("Formula(Literal(1).Infix(Add(), Literal(2))", n);

            //Note here that an Add node was created without any arguments.  
            //We'll get back to that.
        }

        private static void CreateSingleFunctionFormula() {
            //In source code, functions work pretty much the same as operators.
            //There is no syntactic sugar for functions, like the Infix method for binary operators.

            var n = Formula(
                Count(
                    Literal("hello"), 
                    Literal("world")));

            Write("Formula(Count(Literal(\"hello\"), Literal(\"world\")))", n);
        }

        private static void GroupNodes() {
            //Functions bring their own parenthesis, 
            //but for operators you may want to supply them explicitly.
            
            //For example, these two expressions look different, but will create the same formula:

            var n = Formula(
                Add(
                    Multiply(
                        Literal(2),
                        Literal(3)),
                    Literal(4)));
            Write("Formula(Add(Multiply(Literal(2), Literal(3)), Literal(4)))", n);
            //This looks like it might result in =(2*3)+4

            n = Formula(
                Multiply(
                    Literal(2),
                    Add(Literal(3),
                        Literal(4))));
            Write("Formula(Multiply(Literal(2), Add(Literal(3), Literal(4)))", n);
            //This looks like it might result in =2*(3+4)

            //Both, however, result in =2*3+4

            //To specify grouping:
            n = Formula(
                Multiply(
                    Literal(2),
                    Group(Add(
                        Literal(3),
                        Literal(4)))));
            Write("Formula(Multiply(Literal(2), Group(Add(Literal(3), Literal(4))))", n);
        }
        
        private static void LinqToNodes() {
            //Aggregate functions like Count, Sum, and Average 
            //can take a variable number of arguments.

            var n = Formula(
                Average(
                    Enumerable.Range(1, 13)
                    .Select(i => Literal(Fibonacci(i)))
                    .ToArray()));

            Write("Formula(Average(Enumerable.Range(1, 20).Select(i => Literal(Fibbonacci(i))).ToArray()))", n);

            //Node implements IEnumerable<Node>, so you can use LINQ to crawl up and down a formula's structure.
            //You may need to cast to specific node types to use some members when iterating nested nodes.

            var args = n //n is the Formula node
                .First() //it's first element is the Average node
                .Where(fib => ((fib as IntNode).Value % 3) == 1)
                .ToArray();

            n = Formula(Average(args));

            Write("Formula(Average(Enumerable.Range(1, 20).Select(i => " + 
                "Literal(Fibbonacci(i))).Where(fib => ((fib as IntNode).Value % 3) == 1).ToArray()))", n);
        }

        private static int Fibonacci(int n) {
            int a = 0,  b = 1;
            for (var i = 0; i < n; i++) {
                var temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        private static void CreateReference() {
            //There are a lot of constructors for references
            //These examples are using the AbsoluteRefs module, which uses A1 notation,
            //the RelativeRefs module uses R1C1 notation.

            Write("Cell(1, 2)", Cell(1, 2));
            Write("Column(1)", Column(1));
            Write("Columns(1, 5)", Columns(1, 5));
            Write("Row(1)", Row(1));
            Write("Rows(1, 5)", Rows(1, 5));
            Write("Range(1, 2, 3, 4)", Range(1, 2, 3, 4));

            //There are also overloads that take IntNodes
            //References are the only type of Node that require specific node types as children.

            Write("Cell(Literal(1), Literal(2))", Cell(Literal(1), Literal(2)));

            //You can also add a worksheet and workbook reference

            var n = Row(1).SetSheet(Sheet("Sheet2")).SetBook(Book("Book1.xlsx"));

            //The Sheet and Book methods return nodes that represent worksheets and workbooks
            //However, SetSheet and SetBook have overloads that can take strings and create BookNodes and SheetNodes

            n = Range(1, 2, 3, 4).SetSheet("Sheet2").SetBook("Book1.xlsx");
            Write("Range(1, 2, 3, 4).SetSheet(\"Sheet2\").SetBook(\"Book1.xlsx\")", n);
        }

        private static void OutlineRendering() {
            //Once your formulas are sufficiently long, it may be convenient for debugging to print 
            //them in an outline format, like the source code below.

            var r = Group(
                Enumerable.Range(1, 15)
                .Select(x => Column(x * 2))
                .ToArray());

            var n = Formula(GreaterThan(Average(r), Count(r)));

            //The render method can be used to convert nodes to a string.
            //If the "outline" parameter is set to true, 
            //the string will list each node on a new line, and indent each level of nesting.
            //If false, the result is the same as ToString

            Write("Formula(GreaterThan(Average(r), Count(r)))", n);
            Write("Formula(GreaterThan(Average(r), Count(r))).Render(false)", n.Render(false));
            Write("Formula(GreaterThan(Average(r), Count(r))).Render(true)", n.Render(true));
        }
        
    }
}
