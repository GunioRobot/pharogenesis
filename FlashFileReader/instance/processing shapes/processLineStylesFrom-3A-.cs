processLineStylesFrom: data
	| nStyles styles lineWidth lineColor |
	nStyles := data nextByte.
	nStyles = 255 ifTrue:[nStyles := data nextWord].
	log ifNotNil:[log crtab; print: nStyles; nextPutAll:' New line styles'].
	styles := Array new: nStyles.
	1 to: nStyles do:[:i|
		lineWidth := data nextWord.
		lineColor := data nextColor.
		self recordLineStyle: i width: lineWidth color: lineColor.
		log ifNotNil:[log crtab: 2; print: i; nextPut:$:; tab; 
						print: lineWidth; tab; print: lineColor]].
	self flushLog.
	^styles