primitiveDoPrimitiveWithArgs
	| argumentArray primIdx arraySize index cntxSize stackSize |
	"Stack:	... receiver primitiveIndex argumentArray"
	self assertStackPointerIsExternal.
	argumentArray _ self stackTop.
	arraySize _ self fetchWordLengthOf: argumentArray.
	cntxSize _ (self wordLengthOfContext: activeCachedContext) - TempFrameStart.		"max stack depth"
	stackSize _ (self stackPointer - (self cachedFramePointerAt: activeCachedContext)) // 4.	"current stack depth"
	self success: (cntxSize - stackSize) > arraySize.
	self successIfClassOf: argumentArray is: (self splObj: ClassArray).
	primIdx _ self stackIntegerValue: 1.
	successFlag ifFalse: [^ self primitiveFail].  "invalid args"

	"Pop primIndex and argArray, then push args in place..."
	self pop: 2.
	newReceiver _ self stackTop.	"is this actually necessary??"
	primitiveIndex _ primIdx.
	argumentCount _ arraySize.
	index _ 0.
	[index < arraySize] whileTrue:
		[self push: (self fetchPointer: index ofObject: argumentArray).
		 index _ index + 1].

	"Run the primitive (sets successFlag)"
	self pushRemappableOop: argumentArray.	"prim might alloc"
	self primitiveResponse.	"pseudo receivers will already be flushed by the calling primResponse"
	argumentArray _ self popRemappableOop.

	successFlag ifFalse: [
		self pop: arraySize.		"prim might clobber argumentCount"
		self pushInteger: primIdx.		"prim might clobber primitiveIndex"
		self push: argumentArray.
		argumentCount _ 2.
		"... caller (execNewMeth) will run failure code"]