rePluginFree: aPointer
	"Free a block of fixed memory allocated with rePluginMalloc.  Instrumented version of C free() to facilitate leak analysis from Smalltalk.   OS-specific variations on malloc/free, such as with MacOS, are handled by adding a C macro to the header file redefining malloc/free -- see the class comment"

	self inline: true.
	self var: #aPointer declareC: 'void * aPointer'.
	self returnTypeC: 'void'.

	numFrees _ numFrees + 1.
	(aPointer)
		ifTrue: [self cCode: 'free(aPointer)']	