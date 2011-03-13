new
	"Primitive. Answer an instance of the receiver (which is a class) with no 
	indexable variables. Fail if the class is indexable. Essential. See Object 
	documentation whatIsAPrimitive."

	<primitive: 70>
	self isVariable ifTrue: [ ^ self new: 0 ].
	"space must be low"
	Smalltalk signalLowSpace.
	^ self new  "retry if user proceeds"
