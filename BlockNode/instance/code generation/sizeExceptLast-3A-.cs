sizeExceptLast: encoder
	| codeSize nextToLast |
	nextToLast _ statements size - 1.
	nextToLast < 1 ifTrue: [^ 0]. "Only one statement"
	codeSize _ 0.
	1 to: nextToLast do: 
		[:i | codeSize _ codeSize + ((statements at: i) sizeForEffect: encoder)].
	^ codeSize