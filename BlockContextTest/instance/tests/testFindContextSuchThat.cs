testFindContextSuchThat
	self assert: (aBlockContext findContextSuchThat: [:each| true]) printString = aBlockContext printString.
	self assert: (aBlockContext hasContext: aBlockContext).  