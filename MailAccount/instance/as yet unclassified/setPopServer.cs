setPopServer
	self popServer: (FillInTheBlank
		request: 'What is your POP server''s hostname?'
		initialAnswer: (popServer ifNil: [''])).
	^ popServer