parse: messageString toClassAndSelector: csBlock
	"Decode strings of the form <className> [class] <selectorName>."
	| tuple cl |
	tuple _ messageString findTokens: ' '.
	cl _ Smalltalk at: tuple first asSymbol.
	(tuple size = 2 or: [tuple size > 2 and: [(tuple at: 2) ~= 'class']])
		ifTrue: [^ csBlock value: cl value: (tuple at: 2) asSymbol]
		ifFalse: [^ csBlock value: cl class value: (tuple at: 3) asSymbol]