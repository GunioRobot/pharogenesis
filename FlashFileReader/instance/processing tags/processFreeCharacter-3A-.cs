processFreeCharacter: data
	| id |
	id _ data nextWord.
	data atEnd ifFalse:[self halt].
	self recordFreeCharacter: id.
	^true