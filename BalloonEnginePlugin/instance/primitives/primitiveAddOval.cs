primitiveAddOval
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
	fillIndex _ self transformColor: fillIndex.
	borderIndex _ self transformColor: borderIndex.
	engineStopped ifTrue:[^interpreterProxy primitiveFail].

	"Check if we have anything at all to do"
	(fillIndex = 0 and:[borderIndex = 0 or:[borderWidth <= 0]]) ifTrue:[
		^interpreterProxy pop: 5. "Leave rcvr on stack"
	].

	"Make sure we have some space"
	(self needAvailableSpace: (16 * GBBaseSize)) 
		ifFalse:[^interpreterProxy primitiveFail].

	"Check if we need a border"
	(borderWidth > 0 and:[borderIndex ~= 0]) 
		ifTrue:[borderWidth _ self transformWidth: borderWidth]
		ifFalse:[borderWidth _ 0].


	"Load the rectangle points"
	self loadPoint: self point1Get from: startOop.
	self loadPoint: self point2Get from: endOop.
	interpreterProxy failed ifTrue:[^0].

	self loadOval: borderWidth lineFill: borderIndex 
		leftFill: 0 rightFill: fillIndex.

	engineStopped ifTrue:[
		self wbStackClear.
		^interpreterProxy primitiveFail.
	].
	interpreterProxy failed ifFalse:[
		self needsFlushPut: 1.
		self storeEngineStateInto: engine.
		interpreterProxy pop: 5. "Leave rcvr on stack"
	].