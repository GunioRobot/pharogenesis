isPureTranslation
	"Return true if the receiver specifies no rotation or scaling."
	<primitive: 'm23PrimitiveIsPureTranslation'>
	^self a11 = 1.0 and:[self a12 = 0.0 and:[self a22 = 0.0 and:[self a21 = 1.0]]]