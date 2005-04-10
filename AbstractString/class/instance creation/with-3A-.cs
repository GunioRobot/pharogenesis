with: aCharacter
	| newCollection |
self flag: #ByteString.
	aCharacter asInteger < 256
		ifTrue:[newCollection _ String new: 1]
		ifFalse:[newCollection _ MultiString new: 1].
	newCollection at: 1 put: aCharacter.
	^newCollection