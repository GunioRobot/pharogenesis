setPopUserName
	self popUserName: (FillInTheBlank
		request: 'What is your username on your POP server?'
		initialAnswer: (popUserName ifNil: [''])).
	
	^ popUserName