getMethodBody
	| m |
	m := FillInTheBlankMorph new.
	m setQuery: 'Please enter the full body of the method you want to define' 
		initialAnswer:  self class sourceCodeTemplate
		answerExtent: 500@250
		acceptOnCR: false. 
	World addMorph: m centeredNear: World activeHand position.
	^ m getUserResponse.