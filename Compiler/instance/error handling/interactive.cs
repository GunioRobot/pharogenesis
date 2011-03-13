interactive
	"this version of the method is necessary to load code from MC else the interactive mode is one. 
	This method is really bad since it links the compiler package with the Tools
	one. The solution would be to have a real SyntaxError exception belonging to the 
	compiler package and not a subclass of StringHolder - sd Nov 2005"
	"the code submitted by PlusTools is ideally the one that should be used
	interactive

	      ^requestor ~~ nil "
	
	^ (requestor == nil or: [requestor isKindOf: SyntaxError]) not