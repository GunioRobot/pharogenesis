processGlyphStateChange: flags from: data
	| hasFont hasColor hasXOffset hasYOffset fontId color xOffset yOffset height |
	hasFont _ flags anyMask: 8.
	hasColor _ flags anyMask: 4.
	hasYOffset _ flags anyMask: 2.
	hasXOffset _ flags anyMask: 1.
	hasFont ifTrue:[fontId _ data nextWord].
	hasColor ifTrue:[color _ data nextColor].
	hasXOffset ifTrue:[xOffset _ data nextWord].
	hasYOffset ifTrue:[yOffset _ data nextWord].
	hasFont ifTrue:[height _ data nextWord].
	log ifNotNil:[
		log nextPutAll:'['.
		hasFont ifTrue:[log nextPutAll:' font='; print: fontId].
		hasColor ifTrue:[log nextPutAll:' color='; print: color].
		hasXOffset ifTrue:[log nextPutAll:' xOfs=';print: xOffset].
		hasYOffset ifTrue:[log nextPutAll:' yOfs=';print: yOffset].
		hasFont ifTrue:[log nextPutAll:' height='; print: height].
		log nextPutAll:' ]'.
		self flushLog.
	].
	self recordTextChange: fontId color: color xOffset: xOffset yOffset: yOffset height: height.