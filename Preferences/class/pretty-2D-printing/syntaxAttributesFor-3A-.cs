syntaxAttributesFor: aPartSymbol
	SyntaxColorsAndStyles ifNil: [self initializeSyntaxColorsAndStyles].
	^ (SyntaxColorsAndStyles at: aPartSymbol ifAbsent: [^ #()]) attributeList