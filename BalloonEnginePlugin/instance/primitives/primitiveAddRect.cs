primitiveAddRect
	| fillIndex borderWidth borderIndex endOop startOop |
	self export: true.
	self inline: false.

	"Fail if we have the wrong number of arguments"
	interpreterProxy methodArgumentCount = 5 
		ifFalse:[^interpreterProxy primitiveFail].

	borderIndex _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 0).
	borderWidth _ interpreterProxy stackIntegerValue: 1.
	fillIndex _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 2).
	endOop _ interpreterProxy stackObjectValue: 3.
	startOop _ interpreterProxy stackObjectValue: 4.
	interpreterProxy failed ifTrue:[^nil].

	(self quickLoadEngineFrom: (interpreterProxy stackObjectValue: 5) requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].

	"Make sure the fills are okay"
	((self isFillOkay: borderIndex) and:[self isFillOkay: fillIndex])
			ifFalse:[^interpreterProxy primitiveFail].

	"Transform colors"
	borderIndex _ self transformColor: borderIndex.
	fillIndex _ self transformColor: fillIndex.
	engineStopped ifTrue:[^interpreterProxy primitiveFail].

	"Check if we have anything at all to do"
	(fillIndex = 0 and:[borderIndex = 0 or:[borderWidth = 0]]) ifTrue:[
		^interpreterProxy pop: 5. "Leave rcvr on stack"
	].

	"Make sure we have some space"
	(self needAvailableSpace: (4 * GLBaseSize)) 
		ifFalse:[^interpreterProxy primitiveFail].

	"Check if we need a border"
	(borderWidth > 0 and:[borderIndex ~= 0]) 
		ifTrue:[borderWidth _ self transformWidth: borderWidth]
		ifFalse:[borderWidth _ 0].

	"Load the rectangle"
	self loadPoint: self point1Get from: startOop.
	self loadPoint: self point3Get from: endOop.
	interpreterProxy failed ifTrue:[^nil].
	self point2Get at: 0 put: (self point3Get at: 0).
	self point2Get at: 1 put: (self point1Get at: 1).
	self point4Get at: 0 put: (self point1Get at: 0).
	self point4Get at: 1 put: (self point3Get at: 1).
	"Transform the points"
	self transformPoints: 4.

	self loadRectangle: borderWidth lineFill: borderIndex leftFill: 0 rightFill: fillIndex.

	interpreterProxy failed ifFalse:[
		self needsFlushPut: 1.
		self storeEngineStateInto: engine.
		interpreterProxy pop: 5. "Leave rcvr on stack"
	].