parseSymbol
	| c |
	currentToken = '#' 
		ifTrue: [
			"if token is just the #, then scan whitespace and comments
			and then process the next character.
			Squeak allows space between the # and the start of the symbol 
			e.g. # (),  #  a, #  'sym' "
			self rangeType: #symbol.
			self scanWhitespace].
	c := self currentChar.
	self failWhen: [c isNil or: [c isSeparator]].
	c = $( 
		ifTrue: [
			self nextChar.
			self scanPast: #arrayStart start: currentTokenSourcePosition end: currentTokenSourcePosition + 1.
			^self parseArray].
	c = $' ifTrue: [^self parseSymbolString].
	((self isSelectorCharacter: c) or: [c = $-]) 
		ifTrue: [^self parseSymbolSelector].
	(c isLetter or: [c = $:]) ifTrue: [^self parseSymbolIdentifier].
	^self parseCharSymbol