push: object

	| sp |
	self longAt: (sp _ self stackPointer + 4) put: object.
	self setStackPointer: sp.