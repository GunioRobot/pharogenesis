privGetInstVar: index
	"The compiler generates this message when accessing to instance variables of objects other than the receiver.  Do not override or change this unless you also modify the compiler and recompile everything"

	<primitive: 73>
	^ self basicAt: index - self class instSize