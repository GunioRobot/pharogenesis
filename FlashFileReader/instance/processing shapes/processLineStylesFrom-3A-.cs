processLineStylesFrom: data
	| nStyles styles lineWidth lineColor |
	nStyles _ data nextByte.
	nStyles = 255 ifTrue:[nStyles _ data nextWord].
	log ifNotNil:[log crtab; print: nStyles; nextPutAll:' New line styles'].
	styles _ Array new: nStyles.
	1 to: nStyles do:[:i|
		lineWidth _ data nextWord.
		lineColor _ data nextColor.
		self recordLineStyle: i width: lineWidth color: lineColor.
		log ifNotNil:[log crtab: 2; print: i; nextPut:$:; tab; 
						print: lineWidth; tab; print: lineColor]].
	self flushLog.
	^styles