fromString: aString

	^self fromCollection: 
		((aString findTokens: '.') collect: [:ea | ea asNumber ])
	