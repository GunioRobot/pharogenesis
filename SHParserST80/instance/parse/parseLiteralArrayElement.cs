parseLiteralArrayElement
	currentTokenFirst isLetter 
		ifTrue: [
			| type |
			type := (#('true' 'false' 'nil') includes: currentToken) 
				ifTrue: [currentToken asSymbol]
				ifFalse: [#symbol].
			^self scanPast: type].
	currentTokenFirst = $( 
		ifTrue: [
			self scanPast: #arrayStart.
			^self parseArray].
	^self parseLiteral: true