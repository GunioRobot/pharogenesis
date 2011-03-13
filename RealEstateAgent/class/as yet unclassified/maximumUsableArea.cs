maximumUsableArea

	| allowedArea |
	allowedArea _ Display usableArea.
	Smalltalk isMorphic ifTrue: [
		allowedArea _ allowedArea intersect: Display getCurrentMorphicWorld viewBox
	].
	^allowedArea
