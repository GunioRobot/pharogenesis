popStack

	| top |
	top _ self longAt: self stackPointer.
	self setStackPointer: (self stackPointer - 4).
	^ top