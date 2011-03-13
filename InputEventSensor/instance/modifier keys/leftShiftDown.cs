leftShiftDown
	"Answer whether the shift key on the keyboard is being held down. The name of this message is a throwback to the Alto, which had independent left and right shift keys."

	^self modifiers anyMask: 16r01