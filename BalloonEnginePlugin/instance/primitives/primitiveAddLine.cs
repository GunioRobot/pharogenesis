primitiveAddLine
	| leftFill rightFill endOop startOop |
	self export: true.
	self inline: false.

	"Fail if we have the wrong number of arguments"
	interpreterProxy methodArgumentCount = 4 
		ifFalse:[^interpreterProxy primitiveFail].

	rightFill _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 0).
	leftFill _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 1).
	endOop _ interpreterProxy stackObjectValue: 2.
	startOop _ interpreterProxy stackObjectValue: 3.
	interpreterProxy failed ifTrue:[^nil].

	(self quickLoadEngineFrom: (interpreterProxy stackObjectValue: 4) requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].

	"Make sure the fills are okay"
	((self isFillOkay: leftFill) and:[self isFillOkay: rightFill])
			ifFalse:[^interpreterProxy primitiveFail].

	"Load the points"
	self loadPoint: self point1Get from: startOop.
	self loadPoint: self point2Get from: endOop.
	interpreterProxy failed ifTrue:[^0].

	"Transform points"
	self transformPoints: 2.

	"Transform colors"
	leftFill _ self transformColor: leftFill.
	rightFill _ self transformColor: rightFill.
	engineStopped ifTrue:[^interpreterProxy primitiveFail].

	"Load line"
	self loadWideLine: 0 from: self point1Get to: self point2Get 
		lineFill: 0 leftFill: leftFill rightFill: rightFill.
	engineStopped ifTrue:[^interpreterProxy primitiveFail].

	interpreterProxy failed ifFalse:[
		self storeEngineStateInto: engine.
		interpreterProxy pop: 4. "Leave rcvr on stack"
	].