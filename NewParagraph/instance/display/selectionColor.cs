selectionColor
	| color |
	Display depth = 1 ifTrue: [^ Color veryLightGray].
	Display depth = 2 ifTrue: [^ Color gray].
	color := Preferences textHighlightColor.
	self focused ifFalse: [color := color alphaMixed: 0.2 with: Color veryVeryLightGray].
	^ color