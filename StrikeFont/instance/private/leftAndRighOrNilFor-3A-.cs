leftAndRighOrNilFor: char

	| code leftX |
	code _ char charCode.
	((code between: self minAscii and: self maxAscii) not) ifTrue: [
		code _ $? charCode.
	].
	leftX _ xTable at: code + 1.
	leftX < 0 ifTrue: [
		code _ $? charCode.
		leftX _ xTable at: code + 1.
	].
	^ Array with: leftX with: (xTable at: code + 2).
