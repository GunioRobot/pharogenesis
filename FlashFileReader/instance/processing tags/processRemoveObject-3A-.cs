processRemoveObject: data
	| id depth |
	id := data nextWord.
	depth := data nextWord.
	log ifNotNil:[
		log nextPutAll:' (id = ', id printString,' depth = ', depth printString, ')'.
		self flushLog].
	self recordRemoveObject: id depth: depth.
	^true