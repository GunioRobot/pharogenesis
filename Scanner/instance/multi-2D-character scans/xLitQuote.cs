xLitQuote
	"Symbols and vectors: #(1 (4 5) 2 3) #ifTrue:ifFalse: #'abc'."

	| start |
	start _ mark.
	self step. "litQuote"
	self scanToken.
	tokenType = #leftParenthesis
		ifTrue: 
			[self scanToken; scanLitVec.
			mark _ start+1.
			tokenType == #doIt
				ifTrue: [self offEnd: 'Unmatched parenthesis']]
		ifFalse: 
			[(#(word keyword colon ) includes: tokenType) 
				ifTrue:
					[self scanLitWord]
				ifFalse:
					[(tokenType==#literal)
						ifTrue:
							[(token isSymbol)
								ifTrue: "##word"
									[token _ token "May want to move toward ANSI here"]]
						ifFalse:
							[tokenType==#string ifTrue: [token _ token asSymbol]]]].
	mark _ start.
	tokenType _ #literal

"	#(Pen)
	#Pen
	#'Pen'
	##Pen
	###Pen
"