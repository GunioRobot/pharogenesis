push: object

	| sp |
	self longAt: (sp _ stackPointer + 4) put: object.
	stackPointer _ sp.