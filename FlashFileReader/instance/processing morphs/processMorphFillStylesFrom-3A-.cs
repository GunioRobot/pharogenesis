processMorphFillStylesFrom: data
	| nFills nColors rampIndex rampColor id fillStyleType color1 color2 matrix1 matrix2 ramp1 ramp2 |
	nFills := data nextByte.
	nFills = 255 ifTrue:[nFills := data nextWord].
	log ifNotNil:[log crtab; print: nFills; nextPutAll:' New fill styles'].
	1 to: nFills do:[:i|
		log ifNotNil:[log crtab: 2; print: i; nextPut:$:; tab].
		fillStyleType := data nextByte.
		(fillStyleType = 0) ifTrue:["Solid fill"
			color1 := data nextColor: true.
			color2 := data nextColor: true.
			self recordMorphFill: i color1: color1 color2: color2.
			log ifNotNil:[log nextPutAll:'solid color '; print: color1; nextPutAll:' -- '; print: color2].
		].
		(fillStyleType anyMask: 16) ifTrue:["Gradient fill"
			"Read gradient matrix"
			matrix1 := data nextMatrix.
			matrix2 := data nextMatrix.
			"Read color ramp data"
			nColors := data nextByte.
			ramp1 := Array new: nColors.
			ramp2 := Array new: nColors.
			log ifNotNil:[log nextPutAll:'Gradient fill with '; print: nColors; nextPutAll:' colors'].
			1 to: nColors do:[:j|
				rampIndex := data nextByte.
				rampColor := data nextColor: true.
				ramp1 at: j put: (rampIndex -> rampColor).
				rampIndex := data nextByte.
				rampColor := data nextColor: true.
				ramp2 at: j put: (rampIndex -> rampColor)].
			self recordMorphFill: i matrix1: matrix1 ramp1: ramp1 matrix2: matrix2 ramp2: ramp2 linear: (fillStyleType = 16).
			fillStyleType := 0].
		(fillStyleType anyMask: 16r40) ifTrue:["Bit fill"
			"Read bitmap id"
			id := data nextWord.
			"Read bitmap matrix"
			matrix1 := data nextMatrix.
			matrix2 := data nextMatrix.
			log ifNotNil:[log nextPutAll:'Bitmap fill id='; print: id].
			self recordMorphFill: i matrix1: matrix1 matrix2: matrix2 id: id clipped: (fillStyleType anyMask: 1).
			fillStyleType := 0].
		fillStyleType = 0 ifFalse:[self error:'Unknown fill style: ',fillStyleType printString].
		self flushLog.
	].