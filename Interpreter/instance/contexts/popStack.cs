popStack

	| top |
	top _ self longAt: stackPointer.
	stackPointer _ stackPointer - 4.
	^ top