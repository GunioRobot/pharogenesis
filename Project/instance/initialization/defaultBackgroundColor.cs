defaultBackgroundColor
	^ self isMorphic
		ifTrue: [self backgroundColorForMorphicProject]
		ifFalse: [self backgroundColorForMvcProject]