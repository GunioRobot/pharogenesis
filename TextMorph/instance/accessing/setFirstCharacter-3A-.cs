setFirstCharacter: source
	"Set the first character of the receiver as indicated"

	| aChar chars |
	aChar _ source asCharacter.
	(chars _ self getCharacters) size > 0 
		ifFalse:
			[self newContents: (String with: aChar)]
		ifTrue:
			[(chars first = aChar) ifFalse:
				[self newContents: (String streamContents:
					[:aStream |
						aStream nextPut: aChar.
						aStream nextPutAll: (chars copyFrom: 2 to: chars size)])]]