processPlaceObject2: data
	| id flags depth matrix cxForm ratio name move |
	flags := data nextByte.
	depth := data nextWord.

	move := (flags anyMask: 1).
	(flags anyMask: 2) ifTrue:[id := data nextWord].
	(flags anyMask: 4) ifTrue:[matrix := data nextMatrix].
	(flags anyMask: 8) ifTrue:[cxForm := data nextColorMatrix: version >= 3].
	self flag: #checkThis.
	(flags anyMask: 16) ifTrue:["self halt." ratio := data nextWord / 65536.0].
	(flags anyMask: 32) ifTrue:["self halt." name := data nextString].
	(flags anyMask: 64) ifTrue:["self halt:'Clip shape encountered'." ^true].
	log ifNotNil:[
		log nextPutAll:' (id = ', id printString,' name = ', name printString,' depth = ', depth printString, ' move: ', move printString, ')'.
		self flushLog].
	move 
		ifTrue:[self recordMoveObject: id name: name depth: depth matrix: matrix colorMatrix: cxForm ratio: ratio]
		ifFalse:[self recordPlaceObject: id name: name depth: depth matrix: matrix colorMatrix: cxForm ratio: ratio].
	^true