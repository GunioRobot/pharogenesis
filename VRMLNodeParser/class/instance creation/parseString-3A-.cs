parseString: aString
	^self parse: (ReadStream on: aString)