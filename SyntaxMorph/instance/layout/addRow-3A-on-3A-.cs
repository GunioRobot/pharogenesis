addRow: aColorOrSymbol on: aNode

	| row |
	self addMorphBack: (row _ self class row: aColorOrSymbol on: aNode).
	^row
