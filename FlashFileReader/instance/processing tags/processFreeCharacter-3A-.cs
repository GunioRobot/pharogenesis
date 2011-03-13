processFreeCharacter: data
	| id |
	id := data nextWord.
	data atEnd ifFalse:[self halt].
	self recordFreeCharacter: id.
	^true