with: aCharacter
	| newCollection |
	aCharacter asInteger < 256
		ifTrue:[newCollection _ ByteString new: 1]
		ifFalse:[newCollection _ WideString new: 1].
	newCollection at: 1 put: aCharacter.
	^newCollection