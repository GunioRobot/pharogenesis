alertIn: aThemedMorph text: aStringOrText title: aString configure: aBlock
	"Answer the result of an alert dialog (true) with the given label and title."

	|dialog|
	Preferences useThemeSounds ifTrue: [self alertSound play].
	dialog := AlertDialogWindow new
		textFont: self textFont;
		title: aString;
		text: aStringOrText.
	aBlock value: dialog.
	aThemedMorph openModal: dialog.
	^dialog cancelled not