createTokenFor: string 
	| token |
	token := SmaCCToken 
				value: string
				start: start
				id: matchActions.
	outputStream reset.
	matchActions := nil.
	returnMatchBlock value: token