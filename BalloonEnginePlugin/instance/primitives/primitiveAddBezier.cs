primitiveAddBezier
	| leftFill rightFill viaOop endOop startOop nSegments |
	self export: true.
	self inline: false.

	"Fail if we have the wrong number of arguments"
	interpreterProxy methodArgumentCount = 5 
		ifFalse:[^interpreterProxy primitiveFail].

	rightFill _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 0).
	leftFill _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 1).
	viaOop _ interpreterProxy stackObjectValue: 2.
	endOop _ interpreterProxy stackObjectValue: 3.
	startOop _ interpreterProxy stackObjectValue: 4.
	interpreterProxy failed ifTrue:[^nil].

	(self quickLoadEngineFrom: (interpreterProxy stackObjectValue: 5) requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].

	"Make sure the fills are okay"
	((self isFillOkay: leftFill) and:[self isFillOkay: rightFill])
			ifFalse:[^interpreterProxy primitiveFail].

	"Do a quick check if the fillIndices are equal - if so, just ignore it"
	leftFill = rightFill & false ifTrue:[
		^interpreterProxy pop: 6. "Leave rcvr on stack"
	].


	self loadPoint: self point1Get from: startOop.
	self loadPoint: self point2Get from: viaOop.
	self loadPoint: self point3Get from: endOop.
	interpreterProxy failed ifTrue:[^0].

	self transformPoints: 3.

	nSegments _ self loadAndSubdivideBezierFrom: self point1Get 
						via: self point2Get 
						to: self point3Get 
						isWide: false.
	self needAvailableSpace: nSegments * GBBaseSize.
	engineStopped ifFalse:[
		leftFill _ self transformColor: leftFill.
		rightFill _ self transformColor: rightFill].
	engineStopped ifFalse:[
		self loadWideBezier: 0 lineFill: 0 leftFill: leftFill rightFill: rightFill n: nSegments.
	].
	engineStopped ifTrue:[
		"Make sure the stack is okay"
		self wbStackClear.
		^interpreterProxy primitiveFail].

	interpreterProxy failed ifFalse:[
		self storeEngineStateInto: engine.
		interpreterProxy pop: 5. "Leave rcvr on stack"
	].