lastIncomingMessageTimeString

	lastRequests isEmpty ifTrue: [^'never'].
	^self dateAndTimeStringFrom: lastRequests first first
