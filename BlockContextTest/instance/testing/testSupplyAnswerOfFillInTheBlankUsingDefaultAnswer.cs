testSupplyAnswerOfFillInTheBlankUsingDefaultAnswer

	self should: ['red' = ([FillInTheBlank request: 'Your favorite color?' initialAnswer: 'red'] 
		valueSupplyingAnswer: #('Your favorite color?' #default))]