scanLitVec

	| s |
	s _ WriteStream on: (Array new: 16).
	[tokenType = #rightParenthesis or: [tokenType = #doIt]]
		whileFalse: 
			[tokenType = #leftParenthesis
				ifTrue: 
					[self scanToken; scanLitVec]
				ifFalse: 
					[tokenType = #word | (tokenType = #keyword) | (tokenType = #colon)
						ifTrue: 
							[self scanLitWord.
							token = #true ifTrue: [token _ true].
							token = #false ifTrue: [token _ false].
							token = #nil ifTrue: [token _ nil]]
						ifFalse:
							[(token == #- 
									and: [((typeTable at: hereChar charCode ifAbsent: [#xLetter])) = #xDigit])
								ifTrue: 
									[self scanToken.
									token _ token negated]]].
			s nextPut: token.
			self scanToken].
	token _ s contents