primitiveAddPolygon
	| points lineFill lineWidth fillIndex nPoints length isArray segSize |
	self export: true.
	self inline: false.

	"Fail if we have the wrong number of arguments"
	interpreterProxy methodArgumentCount = 5 
		ifFalse:[^interpreterProxy primitiveFail].

	lineFill _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 0).
	lineWidth _ interpreterProxy stackIntegerValue: 1.
	fillIndex _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 2).
	nPoints _ interpreterProxy stackIntegerValue: 3.
	points _ interpreterProxy stackObjectValue: 4.
	interpreterProxy failed ifTrue:[^nil].

	(self quickLoadEngineFrom: (interpreterProxy stackObjectValue: 5) requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].

	"First, do a check if the points look okay"
	length _ interpreterProxy slotSizeOf: points.
	(interpreterProxy isWords: points) ifTrue:[
		isArray _ false.
		"Either PointArray or ShortPointArray"
		(length = nPoints or:[nPoints * 2 = length])
			ifFalse:[^interpreterProxy primitiveFail].
	] ifFalse:["Must be Array of points"
		(interpreterProxy isArray: points)
			ifFalse:[^interpreterProxy primitiveFail].
		length = nPoints
			ifFalse:[^interpreterProxy primitiveFail].
		isArray _ true.
	].

	"Now check that we have some hope to have enough free space.
	Do this by assuming nPoints boundaries of maximum size,
	hoping that most of the fills will be colors and many boundaries
	will be line segments"

	(lineWidth = 0 or:[lineFill = 0])
		ifTrue:[segSize _ GLBaseSize]
		ifFalse:[segSize _ GLWideSize].
	(self needAvailableSpace: segSize * nPoints)
		ifFalse:[^interpreterProxy primitiveFail].

	"Check the fills"
	((self isFillOkay: lineFill) and:[self isFillOkay: fillIndex])
		ifFalse:[^interpreterProxy primitiveFail]. 

	"Transform colors"
	lineFill _ self transformColor: lineFill.
	fillIndex _ self transformColor: fillIndex.
	engineStopped ifTrue:[^interpreterProxy primitiveFail].

	"Check if have anything at all to do"
	((lineFill = 0 or:[lineWidth = 0]) and:[fillIndex = 0])
		ifTrue:[^interpreterProxy pop: 6].

	"Transform the lineWidth"
	lineWidth = 0 ifFalse:[lineWidth _ self transformWidth: lineWidth].

	"And load the actual polygon"
	isArray ifTrue:[
		self loadArrayPolygon: points nPoints: nPoints
			fill: fillIndex lineWidth: lineWidth lineFill: lineFill
	] ifFalse:[
		self loadPolygon: (interpreterProxy firstIndexableField: points) nPoints: nPoints 
			fill: fillIndex lineWidth: lineWidth lineFill: lineFill 
			pointsShort: (nPoints = length)].

	engineStopped ifTrue:[^interpreterProxy primitiveFail].

	interpreterProxy failed ifFalse:[
		self needsFlushPut: 1.
		self storeEngineStateInto: engine.
		interpreterProxy pop: 5. "Leave rcvr on stack"
	].