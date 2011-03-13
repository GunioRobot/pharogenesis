sizeExceptLast: encoder
	| codeSize nextToLast |
	nextToLast := statements size - 1.
	nextToLast < 1 ifTrue: [^ 0]. "Only one statement"
	codeSize := 0.
	1 to: nextToLast do: 
		[:i | codeSize := codeSize + ((statements at: i) sizeForEffect: encoder)].
	^ codeSize