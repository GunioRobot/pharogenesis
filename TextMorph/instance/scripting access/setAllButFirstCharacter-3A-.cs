setAllButFirstCharacter: source 
	"Set all but the first char of the receiver to the source"
	| aChar chars |
	aChar _ source asCharacter.
	(chars _ self getCharacters) isEmpty
		ifTrue: [self newContents: '·' , source asString]
		ifFalse: [chars first = aChar
				ifFalse: [""
					self
						newContents: (String
								streamContents: [:aStream | 
									aStream nextPut: chars first.
									aStream nextPutAll: source])]] 