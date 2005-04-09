nextPut: aCharacter toStream: aStream 
	| value leadingChar aChar |
	aStream isBinary ifTrue: [^aCharacter storeBinaryOn: aStream].
	aCharacter isUnicode ifFalse: [	
		aChar _ aCharacter.
		value _ aCharacter charCode.
	] ifTrue: [
		value _ aCharacter charCode.
		(16rFF61 <= value and: [value <= 16rFF9F]) ifTrue: [
			aStream basicNextPut: (self sjisKatakanaFor: value).
			^ aStream
		].
		aChar _ JISX0208 charFromUnicode: value.
		aChar ifNil: [^ aStream].
		value _ aChar charCode.
	].
	leadingChar _ aChar leadingChar.
	leadingChar = 0 ifTrue: [
		aStream basicNextPut: (Character value: value).
		^ aStream.
	].
	leadingChar == self leadingChar ifTrue: [
		| upper lower | 
		upper _ value // 94 + 33.
		lower _ value \\ 94 + 33.
		upper \\ 2 == 1 ifTrue: [
			upper _ upper + 1 / 2 + 112.
			lower _ lower + 31
		] ifFalse: [
			upper _ upper / 2 + 112.
			lower _ lower + 125
		].
		upper >= 160 ifTrue: [upper _ upper + 64].
		lower >= 127 ifTrue: [lower _ lower + 1].
		aStream basicNextPut: (Character value: upper).
		aStream basicNextPut: (Character value: lower).
		^ aStream
	].
