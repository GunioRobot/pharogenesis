rePluginMalloc: anInteger
	"Allocate a block of fixed memory using C calls to malloc().  Instrumented to facilitate leak analysis from Smalltalk.  Set global lastAlloc to anInteger.  OS-specific variations on malloc/free, such as with MacOS, are handled by adding a C macro to the header file redefining malloc/free -- see the class comment"

	| aPointer |
	self inline: true.
	self var: #anInteger declareC: 'size_t anInteger'.
	self var: #aPointer declareC: 'void *aPointer'.
	self returnTypeC: 'void *'.
	numAllocs _ numAllocs + 1.
	(aPointer _ self cCode: 'malloc(anInteger)')
		ifTrue: [lastAlloc _ anInteger].
	^aPointer
