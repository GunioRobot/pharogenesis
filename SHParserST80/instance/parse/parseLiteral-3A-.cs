parseLiteral: inArray 
	currentTokenFirst = $$ 
		ifTrue: [
			| pos |
			self failWhen: [self currentChar isNil].
			self rangeType: #'$'.
			pos := currentTokenSourcePosition + 1.
			self nextChar.
			^self scanPast: #character start: pos end: pos].
	currentTokenFirst isDigit 
		ifTrue: [
			"do not parse the number, can be time consuming"
			^self scanPast: #number].
	currentToken = '-' 
		ifTrue: [
			| c |
			c := self currentChar.
			(inArray and: [c isNil or: [c isDigit not]]) 
				ifTrue: [
					"single - can be a symbol in an Array"
					^self scanPast: #symbol].
			self scanPast: #-.
			self failWhen: [currentToken isNil].
			"token isNil ifTrue: [self error: 'Unexpected End Of Input']."
			"do not parse the number, can be time consuming"
			^self scanPast: #number].
	currentTokenFirst = $' ifTrue: [^self parseString].
	currentTokenFirst = $# ifTrue: [^self parseSymbol].
	(inArray and: [currentToken notNil]) ifTrue: [^self scanPast: #symbol].
	self failWhen: [currentTokenFirst = $.].
	self error	": 'argument missing'"