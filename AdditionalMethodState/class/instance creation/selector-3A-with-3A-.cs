selector: aSelector with: aPropertyOrPragma
	^(self basicNew: 1)
		selector: aSelector;
		basicAt: 1 put: aPropertyOrPragma;
		yourself