#Formulacrum 

*Formulacrum* is an API for dynamically composing formulas for *Microsoft Excel*, without directly manipulating strings.  It is intended for use in *Excel* add-ins or applications generating reports to be viewed in *Excel*.

###Technical details###
*The source is written in C#6, targeting .NET 4.0. 
*Assembly is CLS compliant, for use with *VB.NET, F#, etc.* clients.
*Assembly is ***not yet*** COM visible, but this is a goal for use with *VBA* clients and scripting.
*The **only** dependencies are *mscorlib.dll* and *System.dll*.  This (theoretically) allows for simple integration with any Excel automation or reporting platform *(ExcelDNA, PIA, VSTO, EPPlus, Aspose,...)*.

###Design###
**Formulacrum* models an *Excel* formula as a tree-like hierarchy of objects called *nodes*. 
*Each node represents a formula element, such as a function, operator, literal value, or reference.
*There is no "Formula" object at the top of the hierarchy, only nodes linked to nodes.
*Depending on the specific type, nodes can have zero or more child nodes.  This nesting can go on repeatedly, much like in *Excel*.  (*Excel* does have a formula length limit, and *Formulacum* does not, at least for now.)

###Benefits###
*Using an object model of formulas, rather than creating them with direct string manipulation, allows the client compiler to be used for some basic syntax checking on generated formulas.
*IDE text editor color schemes can be used to highlight the different syntactic parts of formulas, to give more readily visible structure.
*The code for generating formulas actually resembles the formulas themselves, as opposed to a low-level approach with StringBuilder and String.Format.
*Null *slots* can be left in the node hierarchy, for deferred binding of function or operator arguments.