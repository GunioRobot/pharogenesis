processRemoveObject: data
	| id depth |
	id _ data nextWord.
	depth _ data nextWord.
	log ifNotNil:[
		log nextPutAll:' (id = ', id printString,' depth = ', depth printString, ')'.
		self flushLog].
	self recordRemoveObject: id depth: depth.
	^true