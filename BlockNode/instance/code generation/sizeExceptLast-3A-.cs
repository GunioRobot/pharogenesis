sizeExceptLast: encoder
	| codeSize nextToLast |
	nextToLast _ statements size - 1.
	nextToLast < 1 ifTrue: [^ 0]. "Only one statement"
	codeSize _ 0.
	1 to: nextToLast - 1 do: 
		[:i | codeSize _ codeSize + ((statements at: i) sizeForEffect: encoder)].
	^ (returns  "Don't pop before a return"
			and: [(statements at: nextToLast) prefersValue])
		ifTrue: [codeSize + ((statements at: nextToLast) sizeForValue: encoder)]
		ifFalse: [codeSize + ((statements at: nextToLast) sizeForEffect: encoder)]