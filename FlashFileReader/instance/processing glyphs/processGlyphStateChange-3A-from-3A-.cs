processGlyphStateChange: flags from: data
	| hasFont hasColor hasXOffset hasYOffset fontId color xOffset yOffset height |
	hasFont := flags anyMask: 8.
	hasColor := flags anyMask: 4.
	hasYOffset := flags anyMask: 2.
	hasXOffset := flags anyMask: 1.
	hasFont ifTrue:[fontId := data nextWord].
	hasColor ifTrue:[color := data nextColor].
	hasXOffset ifTrue:[xOffset := data nextWord].
	hasYOffset ifTrue:[yOffset := data nextWord].
	hasFont ifTrue:[height := data nextWord].
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