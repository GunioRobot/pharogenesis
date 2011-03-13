processShapeRecordFrom: data
	| flags pt lineInfo fillInfo0 fillInfo1 |
	data nextBitFlag ifTrue:["Boundary edge record"
		data nextBitFlag
			ifTrue:[self processLineRecordFrom: data]
			ifFalse:[self processCurveRecordFrom: data].
		^true].
	flags := data nextBits: 5.
	flags = 0 ifTrue:[^false]. "At end of shape"
	(flags anyMask: 1) ifTrue:["move to"
		pt := data nextPoint.
		self recordMoveTo: pt.
		log ifNotNil:[log crtab; nextPutAll:'MoveTo '; print: pt]].
	(flags anyMask: 2) ifTrue:["fill info 0"
		fillInfo0 := data nextBits: nFillBits.
		self recordFillStyle0: fillInfo0.
		log ifNotNil:[log crtab; nextPutAll:'FillInfo0 '; print: fillInfo0]].
	(flags anyMask: 4) ifTrue:["fill info 1"
		fillInfo1 := data nextBits: nFillBits.
		self recordFillStyle1: fillInfo1.
		log ifNotNil:[log crtab; nextPutAll:'FillInfo1 '; print: fillInfo1]].
	(flags anyMask: 8) ifTrue:["line info"
		lineInfo := data nextBits: nLineBits.
		self recordLineStyle: lineInfo.
		log ifNotNil:[log crtab; nextPutAll:'LineInfo '; print: lineInfo]].
	(flags anyMask: 16) ifTrue:["new styles"
		self recordEndSubshape.
		log ifNotNil:[log crtab; nextPutAll:'New Set of styles '].
		self processShapeStylesFrom: data.
		"And reset info"
		data initBits.
		nFillBits := data nextBits: 4.
		nLineBits := data nextBits: 4].
	^true