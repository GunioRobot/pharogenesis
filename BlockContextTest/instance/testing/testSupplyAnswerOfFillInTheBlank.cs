testSupplyAnswerOfFillInTheBlank

	self should: ['blue' = ([FillInTheBlank request: 'Your favorite color?'] 
		valueSupplyingAnswer: #('Your favorite color?' 'blue'))]