addColumn: aColorOrSymbol on: aNode
	| col |
	self addMorphBack: (col _ self class column: aColorOrSymbol on: aNode).
	^ col
