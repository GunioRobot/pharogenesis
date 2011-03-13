applyTo: anObject 
	"Apply the receiver to anObject and answer the result. Used to map some 
	object in source coordinates to one in destination coordinates."

	| transformedObject |
	scale == nil
		ifTrue: [transformedObject := anObject]
		ifFalse: [transformedObject := anObject scaleBy: scale].
	transformedObject := transformedObject translateBy: translation.
	^transformedObject