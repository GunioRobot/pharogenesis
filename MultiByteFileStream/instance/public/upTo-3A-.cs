upTo: delim 

	| out ch |
	out _ WriteStream on: (String new: 1000).
	self atEnd ifTrue: [^ ''].
	[(ch _ self next) isNil] whileFalse: [
		(ch = delim) ifTrue: [
			^ out contents  "terminator is not doubled; we're done!"
		].
		out nextPut: ch.
	].
	^ out contents.
