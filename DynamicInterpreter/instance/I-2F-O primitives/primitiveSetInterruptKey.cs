primitiveSetInterruptKey
	"Set the user interrupt keycode. The keycode is an integer whose encoding is described in the comment for primitiveKbdNext."

	| keycode |
	keycode _ self popInteger.
	successFlag
		ifTrue: [ interruptKeycode _ keycode ]
		ifFalse: [ self unPop: 1 ].