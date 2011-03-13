allObjectsDo: aBlock 
	"Evaluate the argument, aBlock, for each object in the system
	 excluding SmallIntegers."

	| object |
	object _ self someObject.
	[0 == object] whileFalse: [
		aBlock value: object.
		object _ object nextObject.
	].