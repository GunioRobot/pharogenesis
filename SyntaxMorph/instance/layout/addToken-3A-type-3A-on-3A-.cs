addToken: aString type: aColorOrSymbol on: aNode

	^ (self addColumn: aColorOrSymbol on: aNode)
		layoutInset: 1;
		addMorphBack: (self addString: aString)
