clauseFromString: aString
	^ Clause new
		string: aString;
		phrases: ((aString findTokens: '!?.,;()') collect: [ :each | self phraseFromString: each])