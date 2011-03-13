parse: messageString toClassAndSelector: csBlock
	"Decode strings of the form <className> [class] <selectorName>."
	| tuple cl |
	tuple _ messageString findTokens: ' '.
	cl _ Smalltalk at: tuple first asSymbol.
	tuple size = 2
		ifTrue: [^ csBlock value: cl value: tuple last asSymbol]
		ifFalse: [^ csBlock value: cl class value: tuple last asSymbol]