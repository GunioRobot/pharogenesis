processMorphLineStylesFrom: data
	| nStyles styles lineWidth1 lineWidth2 lineColor1 lineColor2 |
	nStyles := data nextByte.
	nStyles = 255 ifTrue:[nStyles := data nextWord].
	log ifNotNil:[log crtab; print: nStyles; nextPutAll:' New line styles'].
	styles := Array new: nStyles.
	1 to: nStyles do:[:i|
		lineWidth1 := data nextWord.
		lineWidth2 := data nextWord.
		lineColor1 := data nextColor: true.
		lineColor2 := data nextColor: true.
		self recordMorphLineStyle: i width1: lineWidth1 width2: lineWidth2 color1: lineColor1 color2: lineColor2.
		log ifNotNil:[log crtab: 2; print: i; nextPut:$:; tab; 
						print: lineWidth1; tab; print: lineColor1; tab;
						print: lineWidth2; tab; print: lineColor2; tab]].
	self flushLog.
	^styles