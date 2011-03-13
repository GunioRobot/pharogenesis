basicNew
	"Primitive. Answer an instance of the receiver (which is a class) with no 
	indexable variables. Fail if the class is indexable. Essential. See Object 
	documentation whatIsAPrimitive."

	<primitive: 70>
	self isVariable ifTrue: [ ^ self basicNew: 0 ].
	"space must be low"
	Smalltalk signalLowSpace.
	^ self basicNew  "retry if user proceeds"
