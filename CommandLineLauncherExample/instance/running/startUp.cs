startUp
	| className |
	className _ self parameterAt: 'class'.
	(Smalltalk at: className asSymbol ifAbsent: [Object]) browse