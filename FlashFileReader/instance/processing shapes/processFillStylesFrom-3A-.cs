processFillStylesFrom: data
	| nFills matrix nColors rampIndex rampColor id color fillStyleType ramp |
	nFills _ data nextByte.
	nFills = 255 ifTrue:[nFills _ data nextWord].
	log ifNotNil:[log crtab; print: nFills; nextPutAll:' New fill styles'].
	1 to: nFills do:[:i|
		log ifNotNil:[log crtab: 2; print: i; nextPut:$:; tab].
		fillStyleType _ data nextByte.
		(fillStyleType = 0) ifTrue:["Solid fill"
			color _ data nextColor.
			self recordSolidFill: i color: color.
			log ifNotNil:[log nextPutAll:'solid color '; print: color].
		].
		(fillStyleType anyMask: 16) ifTrue:["Gradient fill"
			"Read gradient matrix"
			matrix _ data nextMatrix.
			"Read color ramp data"
			nColors _ data nextByte.
			ramp _ Array new: nColors.
			log ifNotNil:[log nextPutAll:'Gradient fill with '; print: nColors; nextPutAll:' colors'].
			1 to: nColors do:[:j|
				rampIndex _ data nextByte.
				rampColor _ data nextColor.
				ramp at: j put: (rampIndex -> rampColor)].
			self recordGradientFill: i matrix: matrix ramp: ramp linear: (fillStyleType = 16)].
		(fillStyleType anyMask: 16r40) ifTrue:["Bit fill"
			"Read bitmap id"
			id _ data nextWord.
			"Read bitmap matrix"
			matrix _ data nextMatrix.
			log ifNotNil:[log nextPutAll:'Bitmap fill id='; print: id].
			self recordBitmapFill: i matrix: matrix id: id clipped: (fillStyleType anyMask: 1)].
		self flushLog.
	].