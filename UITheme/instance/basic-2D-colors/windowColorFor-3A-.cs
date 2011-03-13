windowColorFor: aWindowOrModel
	"Answer the colour for the given window."

	|c|
	self settings standardColorsOnly
		ifTrue: [^self settings windowColor].
	c := (aWindowOrModel isSystemWindow)
		ifTrue: [Color colorFrom: (Preferences
					windowColorFor: aWindowOrModel class name)]
		ifFalse: [aWindowOrModel defaultBackgroundColor].
	^c = Color white
		ifTrue: [self settings windowColor]
		ifFalse: [c duller]