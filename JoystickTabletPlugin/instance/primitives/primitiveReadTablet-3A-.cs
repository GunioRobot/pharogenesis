primitiveReadTablet: cursorIndex
	"Get the current state of the cursor of the pen tablet specified by my argument. Fail if there is no tablet. If successful, the result is an array of integers; see the Smalltalk call on this primitive for its interpretation."

	| resultSize result resultPtr|
	self var: #resultPtr declareC: 'int * resultPtr'.
	self primitive: 'primitiveReadTablet'
		parameters: #(SmallInteger).
	resultSize _ self tabletResultSize.
	result _ interpreterProxy instantiateClass: interpreterProxy classBitmap indexableSize: resultSize.
	resultPtr _ result asIntPtr.
	interpreterProxy success: (self cCode: 'tabletRead(cursorIndex, resultPtr)').
	^result