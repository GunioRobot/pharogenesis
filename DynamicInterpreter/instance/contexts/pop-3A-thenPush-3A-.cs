pop: nItems thenPush: oop

	| sp |
	self longAt: (sp _ self stackPointer - ((nItems - 1) * 4)) put: oop.
	self setStackPointer: sp.
