keyboardFocusChange: aBoolean
	"Set the focus to the default button."

	aBoolean ifTrue: [
		self defaultFocusMorph ifNotNilDo: [:b |
			b takeKeyboardFocus]]