mouseDown: evt
	"If the shift key is pressed, make this string the keyboard input focus."

	evt shiftPressed
		ifTrue: [evt hand newKeyboardFocus: self]
		ifFalse: [super mouseDown: evt].
