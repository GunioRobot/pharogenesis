gotSomething

	numStringsInNextArray ifNil: [^self tryForNumStringsInNextArray ].
	nextStringSize ifNil: [^ self tryForNextStringSize ].
	^self tryForString
