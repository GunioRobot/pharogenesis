sizeForValue: encoder
	"elem1, ..., elemN, collectionClass, N, fromBraceStack:"

	nElementsNode _ encoder encodeLiteral: elements size.
	collClassNode isNil ifTrue:
		[collClassNode _ encoder encodeVariable: #Array].
	fromBraceStackNode _ encoder encodeSelector: #fromBraceStack:.
	^elements inject:
		(nElementsNode sizeForValue: encoder) +
		(collClassNode sizeForValue: encoder) +
		(fromBraceStackNode size: encoder args: 1 super: false)
	 into:
		[:subTotal :element |
		 subTotal + (element sizeForValue: encoder)]