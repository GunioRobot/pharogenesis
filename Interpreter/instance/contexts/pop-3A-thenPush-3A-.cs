pop: nItems thenPush: oop

	| sp |
	self longAt: (sp _ stackPointer - ((nItems - 1) * 4)) put: oop.
	stackPointer _ sp.
