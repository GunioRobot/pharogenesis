processPlaceObject: data
	| id depth matrix colorMatrix |
	id _ data nextWord.
	depth _ data nextWord.
	matrix _ data nextMatrix.
	log ifNotNil:[
		log nextPutAll:' (id = ', id printString,' depth = ', depth printString, ')'.
		self flushLog].
	data atEnd ifFalse:[colorMatrix _ data nextColorMatrix].
	self recordPlaceObject: id name: nil depth: depth matrix: matrix colorMatrix: colorMatrix ratio: nil.
	^true