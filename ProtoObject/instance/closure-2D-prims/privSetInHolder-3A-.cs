privSetInHolder: valueHolder
	"The compiler generates this message to place values in global variables.  Do not override or change this unless you also modify the compiler and recompile everything"

	valueHolder value: self.
	^ self