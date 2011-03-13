compose: aTransformation 
	"Answer a WindowingTransformation that is the composition of the 
	receiver and aTransformation. The effect of applying the resulting 
	WindowingTransformation to an object is the same as that of first 
	applying aTransformation to the object and then applying the receiver to 
	its result."

	| aTransformationScale newScale newTranslation |
	aTransformationScale := aTransformation scale.
	scale == nil
		ifTrue: 
			[aTransformation noScale
				ifTrue: [newScale := nil]
				ifFalse: [newScale := aTransformationScale].
			newTranslation := translation + aTransformation translation]
		ifFalse: 
			[aTransformation noScale
				ifTrue: [newScale := scale]
				ifFalse: [newScale := scale * aTransformationScale].
			newTranslation := translation + (scale * aTransformation translation)].
	^WindowingTransformation scale: newScale translation: newTranslation