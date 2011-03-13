at: index 
	"Primitive. Assumes receiver is indexable. Answer the value of an 
	indexable element in the receiver. Fail if the argument index is not an 
	Integer or is out of bounds. Essential. See Object documentation 
	whatIsAPrimitive."

	<primitive: 60>
	index isInteger
		ifTrue: [self errorSubscriptBounds: index].
	index isNumber
		ifTrue: [^self at: index asInteger]
		ifFalse: [self errorNonIntegerIndex]