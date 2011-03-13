parse: messageString toClassAndSelector: csBlock
	"Decode strings of the form    <selectorName> (<className> [class])  "
	| tuple cl |
	tuple _ messageString asString findTokens: ' '.
	cl _ tuple at: 2.
	cl _ cl copyWithoutAll: '()'.  "Strip parens"
	cl _ tuple size = 2
		ifTrue: [Smalltalk at: cl asSymbol]
		ifFalse: [(Smalltalk at: cl asSymbol) class].
	self selectedClass: cl.
	self setSelector: tuple first.
	^ csBlock value: cl value: tuple first asSymbol