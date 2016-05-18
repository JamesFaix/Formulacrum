namespace Formulacrum {

    /// <summary>
    /// Factory for function nodes.
    /// </summary>
    public static class FunctionNodeFactory {

        #region Text

        public static FunctionNode Char() => new FunctionNode("CHAR", 1, 1);
        public static FunctionNode Char(Node number) => Char().SetValues(number);


        public static FunctionNode Clean() => new FunctionNode("CLEAN", 1, 1);
        public static FunctionNode Clean(Node text) => Clean().SetValues(text);


        public static FunctionNode Code() => new FunctionNode("CODE", 1, 1);
        public static FunctionNode Code(Node text) => Code().SetValues(text);

        public static FunctionNode Concatenate(params Node[] args) => AggregateImpl("CONCATENATE", args);

        public static FunctionNode Find() => new FunctionNode("FIND", 2, 3);
        public static FunctionNode Find(Node findText, Node withinText, Node start = null) => 
            Find().SetValues(findText, withinText, start) as FunctionNode;

        public static FunctionNode Fixed() => new FunctionNode("FIXED", 1, 3);
        public static FunctionNode Fixed(Node number, Node decimals = null, Node noCommas = null) => 
            Fixed().SetValues(number, decimals, noCommas) as FunctionNode;

        public static FunctionNode Left() => new FunctionNode("LEFT", 1, 2);
        public static FunctionNode Left(Node text, Node length = null) => Left().SetValues(text, length);

        public static FunctionNode Len() => new FunctionNode("LEN", 1, 1);
        public static FunctionNode Len(Node text) => Len().SetValues(text);

        public static FunctionNode Lower() => new FunctionNode("LOWER", 1, 1);
        public static FunctionNode Lower(Node text) => Lower().SetValues(text);

        public static FunctionNode Mid() => new FunctionNode("MID", 2, 3);
        public static FunctionNode Mid(Node text, Node start, Node length = null) => Mid().SetValues(text, start, length) as FunctionNode;

        public static FunctionNode Proper() => new FunctionNode("PROPER", 1, 1);
        public static FunctionNode Proper(Node text) => Proper().SetValues(text);

        public static FunctionNode Replace() => new FunctionNode("REPLACE", 4, 4);
        public static FunctionNode Replace(Node oldText, Node start, Node length, Node newText) => Replace().SetValues(oldText, start, length, newText) as FunctionNode;

        public static FunctionNode Rept() => new FunctionNode("REPT", 2, 2);
        public static FunctionNode Rept(Node text, Node times) => Rept().SetValues(text, times) as FunctionNode;

        public static FunctionNode Right() => new FunctionNode("RIGHT", 1, 2);
        public static FunctionNode Right(Node text, Node length = null) => Right().SetValues(text, length) as FunctionNode;

        public static FunctionNode Search() => new FunctionNode("SEARCH", 2, 3);
        public static FunctionNode Search(Node findText, Node withinText, Node start) => Search().SetValues(findText, withinText, start) as FunctionNode;

        public static FunctionNode Substitute() => new FunctionNode("SUBSTITUTE", 3, 4);
        public static FunctionNode Substitute(Node text, Node oldText, Node newText, Node instance = null) => Substitute().SetValues(text, oldText, newText, instance) as FunctionNode;

        public static FunctionNode Text() => new FunctionNode("TEXT", 2, 2);
        public static FunctionNode Text(Node value, Node format) => Text().SetValues(value, format) as FunctionNode;

        public static FunctionNode Trim() => new FunctionNode("TRIM", 1, 1);
        public static FunctionNode Trim(Node text) => Trim().SetValues(text);
        
        public static FunctionNode Upper() => new FunctionNode("UPPER", 1, 1);
        public static FunctionNode Upper(Node text) => Upper().SetValues(text);

        public static FunctionNode Value() => new FunctionNode("VALUE", 1, 1);
        public static FunctionNode Value(Node text) => Value().SetValues(text);

        #endregion

        #region Statistical

        public static FunctionNode Average(params Node[] args) => AggregateImpl("AVERAGE", args);

        public static FunctionNode Count(params Node[] args) => AggregateImpl("COUNT", args);

        public static FunctionNode CountA(params Node[] args) => AggregateImpl("COUNTA", args);

        public static FunctionNode Sum(params Node[] args) => AggregateImpl("SUM", args);

        public static FunctionNode Max(params Node[] args) => AggregateImpl("MAX", args);

        public static FunctionNode Min(params Node[] args) => AggregateImpl("MIN", args);


        #endregion

        #region Logic
        public static FunctionNode And(params Node[] args) => AggregateImpl("AND", args);

        public static FunctionNode If() => new FunctionNode("IF", 2, 3);
        public static FunctionNode If(Node test, Node trueValue, Node falseValue = null) => If().SetValues(test, trueValue, falseValue) as FunctionNode;

        public static FunctionNode IfError() => new FunctionNode("IFERROR", 2, 2);
        public static FunctionNode IfError(Node value, Node errorValue) => IfError().SetValues(value, errorValue) as FunctionNode;

        public static FunctionNode Not(Node expr = null) {
            var f = new FunctionNode("NOT", 1, 1);
            if (expr != null) f.SetValues(expr);
            return f;
        }

        public static FunctionNode Or(params Node[] args) => AggregateImpl("OR", args);

        public static FunctionNode Xor(params Node[] args) => AggregateImpl("XOR", args);

        #endregion

        #region Information

        public static FunctionNode IsBlank(Node expr = null) {
            var f = new FunctionNode("ISBLANK", 1, 1);
            if (expr != null) f.SetValues(expr);
            return f;
        }

        public static FunctionNode IsError(Node expr = null) {
            var f = new FunctionNode("ISERROR", 1, 1);
            if (expr != null) f.SetValues(expr);
            return f;
        }

        #endregion

        #region Math

        public static FunctionNode Abs(Node value = null) {
            var f = new FunctionNode("ABS", 1, 1);
            if (value != null) f.SetValues(value);
            return f;
        }

        public static FunctionNode Ceiling() => new FunctionNode("CEILING", 2, 2);
        public static FunctionNode Ceiling(Node number, Node significance) => Ceiling().SetValues(number, significance) as FunctionNode;

        //Exp
        //Floor
        //Int
        //Mod
        //Product
        //Quotient
        //Rand
        //RandBetween
        //Round
        //RoundDown
        //RoundUp
        //Sign
        //SumIf
        //SumIfs
        //Trunc

        //CountIf
        //CountIfs
        //AverageIf
        //AverageIfs

        #endregion

        private static FunctionNode AggregateImpl(string name, params Node[] args) {
            var f = new FunctionNode(name, 1, 30);
            if (args.Length > 0) f.SetValues(args);
            return f;
        }

    }
}

