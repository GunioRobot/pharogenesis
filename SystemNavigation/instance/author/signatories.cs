signatories
	^(self signatoriesString subStrings: {Character cr})
		collect: [ :each | each substrings first]