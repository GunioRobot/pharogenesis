primitiveGetTabletParameters: cursorIndex
	"Get information on the pen tablet attached to this machine. Fail if there is no tablet. If successful, the result is an array of integers; see the Smalltalk call on this primitive for its interpretation."

	| resultSize result resultPtr |
	self var: #resultPtr declareC: 'int * resultPtr'.
	self primitive: 'primitiveGetTabletParameters'
		parameters: #(SmallInteger).
	resultSize _ self tabletResultSize.
	result _ interpreterProxy instantiateClass: interpreterProxy classBitmap indexableSize: resultSize.
	resultPtr _ result asIntPtr.
	interpreterProxy success: (self cCode: 'tabletGetParameters(cursorIndex, resultPtr)').
	^result