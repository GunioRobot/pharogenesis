suppressFlapsString
	^ (Project current flapsSuppressed)
		ifFalse: ['hide flaps']
		ifTrue: ['show flaps']
