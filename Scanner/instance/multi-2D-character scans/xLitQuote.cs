xLitQuote
	"Symbols and vectors: #(1 (4 5) 2 3) #ifTrue:ifFalse: #'abc'."

	| start |
	self step. "litQuote"
	self scanToken.
	tokenType = #leftParenthesis
		ifTrue: 
			[start _ mark.
			self scanToken; scanLitVec.
			tokenType == #doIt
				ifTrue: [mark _ start.
						self offEnd: 'Unmatched parenthesis']]
		ifFalse: 
			[(#(word keyword colon ) includes: tokenType) 
				ifTrue:
					[self scanLitWord]
				ifFalse:
					[(tokenType==#literal)
						ifTrue:
							[(token isMemberOf: Symbol)
								ifTrue: "##word"
									[token _ token "May want to move toward ANSI here"]]
						ifFalse:
							[tokenType==#string ifTrue: [token _ token asSymbol]]]].
	tokenType _ #literal

"	#(Pen)
	#Pen
	#'Pen'
	##Pen
	###Pen
"