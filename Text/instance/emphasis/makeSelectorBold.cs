makeSelectorBold
	"For formatting Smalltalk source code, set the emphasis of that portion of 
	the receiver's string that parses as a message selector to be bold."

	| parser i |
	string size = 0 ifTrue: [^ self].
	i _ 0.
	[(string at: (i _ i + 1)) isSeparator] whileTrue.
	(string at: i) = $[ ifTrue: [^ self].  "block, no selector"
	(parser _ Compiler parserClass new) parseSelector: string.
	self makeBoldFrom: 1 to: (parser endOfLastToken min: string size)