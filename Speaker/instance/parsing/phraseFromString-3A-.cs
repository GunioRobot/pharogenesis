phraseFromString: aString
	^ Phrase new
		string: aString;
		words: ((aString findTokens: ' !?.,;()') collect: [ :each | self wordFromString: each])