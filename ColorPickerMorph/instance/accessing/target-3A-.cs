target: anObject

	target _ anObject.
	(target respondsTo: #color)
		ifTrue: [selectedColor _ target color]
		ifFalse: [selectedColor _ Color white].
