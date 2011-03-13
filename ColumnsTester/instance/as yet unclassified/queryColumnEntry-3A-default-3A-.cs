queryColumnEntry: column default: defaultString
	^FillInTheBlank
		request: 'New entry for column ', column printString, '?'
		initialAnswer: defaultString