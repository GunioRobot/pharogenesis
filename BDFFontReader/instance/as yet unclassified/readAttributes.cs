readAttributes
	| str a |
	"I don't handle double-quotes correctly, but it works"
	self reset.
	[self atEnd] whileFalse: [
		str _ self getLine.
		(str beginsWith: 'STARTCHAR') ifTrue: [self skip: (0 - str size - 1). ^self].
		a _ str substrings.
		properties at: a first asSymbol put: a allButFirst.
	].
	self error: 'file seems corrupted'.