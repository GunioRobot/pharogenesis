peekForAll: aString
	"<Boolean> Answer whether or not the next string of characters in the receiver
	matches aString.  If a match is made, advance over that string in the receiver and
	answer true.  If no match, then leave the receiver alone and answer false."

	| start tmp |
	[self atEnd not and: [self inStream size - self inStream position < aString size]]
		whileTrue: [self receiveData].
	(self inStream size - self inStream position) >= aString size ifFalse: [^false].
	start := self inStream position + 1.
	tmp := self inStream contents 
		copyFrom: start
		to: (start + aString size - 1).
	tmp = aString ifFalse: [^false].
	self next: aString size.
	^true
