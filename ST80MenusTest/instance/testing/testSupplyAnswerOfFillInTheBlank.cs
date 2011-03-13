testSupplyAnswerOfFillInTheBlank

	self should: ['blue' = ([UIManager default request: 'Should not see this message or this test failed?'] 
		valueSupplyingAnswer: #('Should not see this message or this test failed?' 'blue'))]