popPos32BitInteger
	"May set successFlag, and return false if not valid"

	| top |
	top _ self popStack.
	^ self positive32BitValueOf: top