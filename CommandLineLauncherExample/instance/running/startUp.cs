startUp
	| className |
	className _ self parameterAt: 'class'.
	Browser newOnClass: (Smalltalk at: className asSymbol ifAbsent: [Object])