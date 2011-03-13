xLitQuote
	"Symbols and vectors: #(1 (4 5) 2 3) #ifTrue:ifFalse: #'abc'."
	| start |
	start := mark.
	self step.
	"litQuote"
	self scanToken.
	tokenType = #leftParenthesis
		ifTrue: [self scanToken; scanLitVec.
			mark := start + 1.
			tokenType == #doIt
				ifTrue: [self offEnd: 'Unmatched parenthesis']]
		ifFalse: [tokenType = #leftBracket
				ifTrue: [self scanToken; scanLitByte.
					mark := start + 1.
					tokenType == #doIt
						ifTrue: [self offEnd: 'Unmatched bracket']]
				ifFalse: [(#(#word #keyword #colon ) includes: tokenType)
						ifTrue: [self scanLitWord]
						ifFalse: [tokenType == #literal
								ifTrue: [token isSymbol
										ifTrue: ["##word"
											token := token
											"May want to move toward ANSI
											here "]]
								ifFalse: [tokenType == #string
										ifTrue: [token := token asSymbol]]]]].
	mark := start.
	tokenType := #literal
	"#(Pen)
	#Pen
	#'Pen'
	##Pen
	###Pe
	"