processRemoveObject2: data
	| depth |
	depth _ data nextWord.
	log ifNotNil:[
		log nextPutAll:' (depth = ', depth printString, ')'.
		self flushLog].
	self recordRemoveObject: nil depth: depth.
	^true