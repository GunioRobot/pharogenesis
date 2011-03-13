privStoreIn: object instVar: index
	"The compiler generates this message when assigning to instance variables of objects that have been captured by a block closure.  Do not override or change this unless you also modify the compiler and recompile everything"

	object privSetInstVar: index put: self