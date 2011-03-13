xLitQuote
	"UniqueStrings and vectors: #(1 (4 5) 2 3) #ifTrue:ifFalse:.
	 For ##x answer #x->nil.  For ###x answer nil->#x."

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
							[(token isMemberOf: Association)
								ifTrue: "###word"
									[token _ nil->token key].
							(token isMemberOf: Symbol)
								ifTrue: "##word"
									[token _ token->nil]]]].
	tokenType _ #literal

"	#(Pen)
	#Pen
	##Pen
	###Pen
"