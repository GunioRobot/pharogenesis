messageText
	^ super messageText
		ifNil: [messageText _ self syntaxError contents]