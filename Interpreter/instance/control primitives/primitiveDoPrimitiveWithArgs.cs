primitiveDoPrimitiveWithArgs
	| argumentArray arraySize index cntxSize primIdx |
	argumentArray _ self stackTop.
	arraySize _ self fetchWordLengthOf: argumentArray.
	cntxSize _ self fetchWordLengthOf: activeContext.
	self success: (self stackPointerIndex + arraySize) < cntxSize.
	self assertClassOf: argumentArray is: (self splObj: ClassArray).
	primIdx _ self stackIntegerValue: 1.
	successFlag ifFalse: [^ self primitiveFail].  "invalid args"

	"Pop primIndex and argArray, then push args in place..."
	self pop: 2.
	primitiveIndex _ primIdx.
	argumentCount _ arraySize.
	index _ 1.
	[index <= argumentCount]
		whileTrue:
		[self push: (self fetchPointer: index - 1 ofObject: argumentArray).
		index _ index + 1].

	"Run the primitive (sets successFlag)"
	self pushRemappableOop: argumentArray.	"prim might alloc/gc"
	self primitiveResponse.
	argumentArray _ self popRemappableOop.

	successFlag ifFalse:
		["If primitive failed, then restore state for failure code"
		self pop: arraySize.
		self pushInteger: primIdx.
		self push: argumentArray.
		argumentCount _ 2.
		"... caller (execNewMeth) will run failure code"]