processDefineFont: data
	| fontId firstOffset offsets nShapes |
	fontId _ data nextWord.
	firstOffset _ data nextWord.
	nShapes _ firstOffset // 2.
	offsets _ Array new: nShapes.
	offsets at: 1 put: firstOffset.
	2 to: nShapes do:[:i| offsets at: i put: data nextWord].
	self recordFontBegin: fontId with: nShapes.
	1 to: nShapes do:[:i|
		log ifNotNil:[log cr; nextPutAll:'Glyph '; print: i].
		self recordFontShapeStart: fontId with: i.
		self processFontShapeFrom: data.
		self recordFontShapeEnd: fontId with: i].
	data atEnd ifFalse:[self halt].
	self recordFontEnd: fontId.
	^true