value
	^arguments isNil
		ifTrue: [receiver perform: selector]
		ifFalse: [receiver perform: selector withArguments: arguments]