skipSeparators
	| char |
	[(char := self nextChar) == nil ifTrue:[^self].
	SeparatorChars includes: char asciiValue] whileTrue:[
		char = $# ifTrue:[self skipLine].
	].
	self skip: -1.