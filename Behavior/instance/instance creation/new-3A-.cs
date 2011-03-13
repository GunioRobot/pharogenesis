new: anInteger 
	"Primitive. Answer an instance of the receiver (which is a class) with the 
	number of indexable variables specified by the argument, anInteger. Fail 
	if the class is not indexable or if the argument is not a positive Integer. 
	Essential. See Object documentation whatIsAPrimitive."

	<primitive: 71>
	(anInteger isInteger and: [anInteger >= 0]) ifTrue: [
		"arg okay; space must be low"
		Smalltalk signalLowSpace.
		^ self new: anInteger  "retry if user proceeds"
	].
	self primitiveFailed