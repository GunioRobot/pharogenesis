primitiveAddBitmapFill

	| nrmOop dirOop originOop tileFlag fill xIndex cmOop formOop |
	self export: true.
	self inline: false.

	"Fail if we have the wrong number of arguments"
	interpreterProxy methodArgumentCount = 7 
		ifFalse:[^interpreterProxy primitiveFail].

	xIndex _ interpreterProxy stackIntegerValue: 0.
	xIndex <= 0 ifTrue:[^interpreterProxy primitiveFail].
	nrmOop _ interpreterProxy stackObjectValue: 1.
	dirOop _ interpreterProxy stackObjectValue: 2.
	originOop _ interpreterProxy stackObjectValue: 3.
	tileFlag _ interpreterProxy booleanValueOf: (interpreterProxy stackValue: 4).
	tileFlag ifTrue:[tileFlag _ 1] ifFalse:[tileFlag _ 0].
	cmOop _ interpreterProxy stackObjectValue: 5.
	formOop _ interpreterProxy stackObjectValue: 6.
	interpreterProxy failed ifTrue:[^nil].

	(self quickLoadEngineFrom: (interpreterProxy stackObjectValue: 7) requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].

	self loadPoint: self point1Get from: originOop.
	self loadPoint: self point2Get from: dirOop.
	self loadPoint: self point3Get from: nrmOop.
	interpreterProxy failed ifTrue:[^0].

	fill _ self loadBitmapFill: formOop 
				colormap: cmOop
				tile: tileFlag
				from: self point1Get 
				along: self point2Get 
				normal: self point3Get 
				xIndex: xIndex-1.
	engineStopped ifTrue:[
		"Make sure the stack is okay"
		^interpreterProxy primitiveFail].

	interpreterProxy failed ifFalse:[
		self storeEngineStateInto: engine.
		interpreterProxy pop: 8.
		interpreterProxy push: (interpreterProxy positive32BitIntegerFor: fill).
	].