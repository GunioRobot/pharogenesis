upTo: aCharacter
	| newStream char |
	newStream _ WriteStream on: (String new: 100).
	[(char _ self next) isNil or: [char == aCharacter]]
		whileFalse: [newStream nextPut: char].
	^ newStream contents
