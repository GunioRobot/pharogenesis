assertInitializersCalled
	| cvar |
	cvar _ self mockClassA cVar.
	self assert: cvar = #initialized