selectionColor
	Display depth = 1 ifTrue: [^ Color veryLightGray].
	Display depth = 2 ifTrue: [^ Color gray].
	^ Preferences textHighlightColor