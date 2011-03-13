setAllButFirstCharacter: source
	"Set all but the first char of the receiver to the source"

	| aChar chars |
	aChar _ source asCharacter.
	(chars _ self getCharacters) size > 0 
		ifFalse:
			[self newContents: ('¥', source asString)]
		ifTrue:
			[(chars first = aChar) ifFalse:
				[self newContents: (String streamContents:
					[:aStream |
						aStream nextPut: chars first.
						aStream nextPutAll: source])]]