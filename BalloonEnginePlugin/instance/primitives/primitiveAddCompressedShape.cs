primitiveAddCompressedShape
	| fillIndexList lineFills lineWidths rightFills leftFills nSegments points pointsShort |
	self export: true.
	self inline: false.

	"Fail if we have the wrong number of arguments"
	interpreterProxy methodArgumentCount = 7 
		ifFalse:[^interpreterProxy primitiveFail].

	fillIndexList _ interpreterProxy stackObjectValue: 0.
	lineFills _ interpreterProxy stackObjectValue: 1.
	lineWidths _ interpreterProxy stackObjectValue: 2.
	rightFills _ interpreterProxy stackObjectValue: 3.
	leftFills _ interpreterProxy stackObjectValue: 4.
	nSegments _ interpreterProxy stackIntegerValue: 5.
	points _ interpreterProxy stackObjectValue: 6.
	interpreterProxy failed ifTrue:[^nil].

	(self quickLoadEngineFrom: (interpreterProxy stackObjectValue: 7) requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].

	"First, do a check if the compressed shape is okay"
	(self checkCompressedShape: points 
			segments: nSegments 
			leftFills: leftFills 
			rightFills: rightFills 
			lineWidths: lineWidths 
			lineFills: lineFills 
			fillIndexList: fillIndexList) ifFalse:[^interpreterProxy primitiveFail].

	"Now check that we have some hope to have enough free space.
	Do this by assuming nSegments boundaries of maximum size,
	hoping that most of the fills will be colors and many boundaries
	will be line segments"

	(self needAvailableSpace: (GBBaseSize max: GLBaseSize) * nSegments)
		ifFalse:[^interpreterProxy primitiveFail].

	"Check if the points are short"
	pointsShort _ (interpreterProxy slotSizeOf: points) = (nSegments * 3).

	"Then actually load the compressed shape"
	self loadCompressedShape: (interpreterProxy firstIndexableField: points)
			segments: nSegments 
			leftFills: (interpreterProxy firstIndexableField: leftFills)
			rightFills: (interpreterProxy firstIndexableField: rightFills)
			lineWidths: (interpreterProxy firstIndexableField: lineWidths)
			lineFills: (interpreterProxy firstIndexableField: lineFills)
			fillIndexList: (interpreterProxy firstIndexableField: fillIndexList)
			pointShort: pointsShort.

	engineStopped ifTrue:[^interpreterProxy primitiveFail].

	interpreterProxy failed ifFalse:[
		self needsFlushPut: 1.
		self storeEngineStateInto: engine.
		interpreterProxy pop: 7. "Leave rcvr on stack"
	].