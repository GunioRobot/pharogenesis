useGlobalFlapsString
	^ (Preferences valueOfFlag: #useGlobalFlaps)
			ifTrue: ['stop using global flaps']
			ifFalse: ['start using global flaps']