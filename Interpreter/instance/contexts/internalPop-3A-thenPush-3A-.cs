internalPop: nItems thenPush: oop

	self longAt: (localSP _ localSP - ((nItems - 1) * 4)) put: oop.
