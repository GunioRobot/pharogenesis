upTo: aCharacter
	| newStream char |
	newStream := (String new: 100) writeStream.
	[(char := self next) isNil or: [char == aCharacter]]
		whileFalse: [newStream nextPut: char].
	^ newStream contents
