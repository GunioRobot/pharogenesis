primitiveNextFillEntry
	"Note: No need to load bitBlt but must load spanBuffer"
	| fillOop hasFill |
	self export: true.
	self inline: false.
	doProfileStats ifTrue:[geProfileTime _ interpreterProxy ioMicroMSecs].
	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].
	fillOop _ interpreterProxy stackObjectValue: 0.
	engine _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateScanningAET)
		ifFalse:[^interpreterProxy primitiveFail].
	"Load span buffer for internal handling of fills"
	(self loadSpanBufferFrom:
		(interpreterProxy fetchPointer: BESpanIndex ofObject: engine))
			ifFalse:[^interpreterProxy primitiveFail].
	(self loadFormsFrom:
		(interpreterProxy fetchPointer: BEFormsIndex ofObject: engine))
			ifFalse:[^interpreterProxy primitiveFail].

	"Check if we have to clear the span buffer before proceeding"
	(self clearSpanBufferGet = 0) ifFalse:[
		(self currentYGet bitAnd: self aaScanMaskGet) = 0
			ifTrue:[self clearSpanBuffer].
		self clearSpanBufferPut: 0].

	hasFill _ self findNextExternalFillFromAET.
	engineStopped ifTrue:[^interpreterProxy primitiveFail].
	hasFill ifTrue:[self storeFillStateInto: fillOop].
	interpreterProxy failed ifFalse:[
		hasFill
			ifTrue:[	self statePut: GEStateWaitingForFill]
			ifFalse:[	self wbStackClear.
					self spanEndAAPut: 0.
					self statePut: GEStateBlitBuffer].
		self storeEngineStateInto: engine.
		interpreterProxy pop: 2.
		interpreterProxy pushBool: hasFill not.
		doProfileStats ifTrue:[
			self incrementStat: GWCountNextFillEntry by: 1.
			self incrementStat: GWTimeNextFillEntry by: (interpreterProxy ioMicroMSecs - geProfileTime)].
	].