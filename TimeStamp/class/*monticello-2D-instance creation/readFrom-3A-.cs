readFrom: stream
	| date time |
	stream skipSeparators.
	date _ Date readFrom: stream.
	stream peek = $, ifTrue: [stream next].
	stream skipSeparators.
	time _ Time readFrom: stream.
	^self 
		date: date
		time: time