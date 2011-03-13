processPlaceObject: data
	| id depth matrix colorMatrix |
	id := data nextWord.
	depth := data nextWord.
	matrix := data nextMatrix.
	log ifNotNil:[
		log nextPutAll:' (id = ', id printString,' depth = ', depth printString, ')'.
		self flushLog].
	data atEnd ifFalse:[colorMatrix := data nextColorMatrix].
	self recordPlaceObject: id name: nil depth: depth matrix: matrix colorMatrix: colorMatrix ratio: nil.
	^true