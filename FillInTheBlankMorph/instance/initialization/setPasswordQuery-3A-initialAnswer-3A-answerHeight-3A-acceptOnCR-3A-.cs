setPasswordQuery: queryString initialAnswer: initialAnswer answerHeight: answerHeight acceptOnCR: acceptBoolean
	| pane |
	self setQuery: queryString 
		initialAnswer: initialAnswer 
		answerHeight: answerHeight 
		acceptOnCR: acceptBoolean.
	pane := self submorphNamed: 'textPane'.
	pane font: (StrikeFont passwordFontSize: 12).