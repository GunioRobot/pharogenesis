printIfNil: aStream indent: level

	^self 
		printKeywords: selector key
		arguments: (Array with: arguments first)
		on: aStream indent: level