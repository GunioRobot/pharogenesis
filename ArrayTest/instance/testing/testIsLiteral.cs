testIsLiteral
	"We work with a copy of literalArray, to avoid corrupting the code."
	| l |
	l := literalArray copy.
	self assert: l isLiteral.
	l at: 1 put: self class.
	self deny: l isLiteral