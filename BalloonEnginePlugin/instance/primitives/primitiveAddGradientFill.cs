primitiveAddGradientFill

	| isRadial nrmOop dirOop originOop rampOop fill |
	self export: true.
	self inline: false.

	"Fail if we have the wrong number of arguments"
	interpreterProxy methodArgumentCount = 5 
		ifFalse:[^interpreterProxy primitiveFail].

	isRadial _ interpreterProxy booleanValueOf: (interpreterProxy stackValue: 0).
	nrmOop _ interpreterProxy stackValue: 1.
	dirOop _ interpreterProxy stackValue: 2.
	originOop _ interpreterProxy stackValue: 3.
	rampOop _ interpreterProxy stackValue: 4.
	interpreterProxy failed ifTrue:[^nil].

	(self quickLoadEngineFrom: (interpreterProxy stackObjectValue: 5) requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].

	self loadPoint: self point1Get from: originOop.
	self loadPoint: self point2Get from: dirOop.
	self loadPoint: self point3Get from: nrmOop.
	interpreterProxy failed ifTrue:[^0].

	fill _ self loadGradientFill: rampOop 
				from: self point1Get 
				along: self point2Get 
				normal: self point3Get 
				isRadial: isRadial.
	engineStopped ifTrue:[
		"Make sure the stack is okay"
		^interpreterProxy primitiveFail].

	interpreterProxy failed ifFalse:[
		self storeEngineStateInto: engine.
		interpreterProxy pop: 6.
		interpreterProxy push: (interpreterProxy positive32BitIntegerFor: fill).
	].