cornerStyle: aSymbol
	aSymbol == #square
		ifTrue:[self removeProperty: #cornerStyle]
		ifFalse:[self setProperty: #cornerStyle toValue: aSymbol].
	self changed