shiftPressed
	"Answer whether the shift key on the keyboard is being held down."

	^ self primMouseButtons anyMask: 8
