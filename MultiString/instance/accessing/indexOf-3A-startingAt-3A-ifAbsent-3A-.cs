indexOf: aCharacter  startingAt: start  ifAbsent: aBlock

	| ans |
	ans _ MultiString indexOfAscii: aCharacter asciiValue inMultiString: self  startingAt: start.
	ans = 0
		ifTrue: [^ aBlock value]
		ifFalse: [^ ans]
