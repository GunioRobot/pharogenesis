taskbarButtonColorFor: aButton
	"Answer the colour for the given taskbar button."

	^self settings standardColorsOnly
		ifTrue: [self settings buttonColor]
		ifFalse: [(aButton model valueOfProperty: #paneColor) ifNil: [aButton model defaultColor]]