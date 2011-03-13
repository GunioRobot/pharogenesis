initialInteger
	"Answer the integer that is represented by the receiver up until its first non-digit character"
	| pos |
	(pos _ self findFirst: [:d | d isDigit not]) == 0 ifTrue: [^ self asNumber].
	
	^ (self copyFrom: 1 to: (pos = 0 ifTrue: [self size] ifFalse: [pos - 1])) asNumber