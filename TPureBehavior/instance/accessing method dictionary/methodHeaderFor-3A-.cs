methodHeaderFor: selector 
	"Answer the string corresponding to the method header for the given selector"

	| sourceString parser |
	sourceString _ self ultimateSourceCodeAt: selector ifAbsent: [self standardMethodHeaderFor: selector].
	(parser _ self parserClass new) parseSelector: sourceString.
	^ sourceString asString copyFrom: 1 to: (parser endOfLastToken min: sourceString size)

	"Behavior methodHeaderFor: #methodHeaderFor: "
