primitiveMergeFillFrom
	"Note: No need to load bitBlt but must load spanBuffer"
	| fillOop bitsOop value |
	self export: true.
	self inline: false.
	doProfileStats ifTrue:[geProfileTime _ interpreterProxy ioMicroMSecs].
	interpreterProxy methodArgumentCount = 2
		ifFalse:[^interpreterProxy primitiveFail].
	fillOop _ interpreterProxy stackObjectValue: 0.
	bitsOop _ interpreterProxy stackObjectValue: 1.
	engine _ interpreterProxy stackObjectValue: 2.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateWaitingForFill)
		ifFalse:[^interpreterProxy primitiveFail].
	"Load span buffer for merging the fill"
	(self loadSpanBufferFrom:
		(interpreterProxy fetchPointer: BESpanIndex ofObject: engine))
			ifFalse:[^interpreterProxy primitiveFail].
	"Check bitmap"
	(interpreterProxy fetchClassOf: bitsOop) = interpreterProxy classBitmap
		ifFalse:[^interpreterProxy primitiveFail].
	"Check fillOop"
	(interpreterProxy slotSizeOf: fillOop) < FTBalloonFillDataSize
		ifTrue:[^interpreterProxy primitiveFail].
	"Check if this was the fill we have exported"
	value _ interpreterProxy fetchInteger: FTIndexIndex ofObject: fillOop.
	(self objectIndexOf: self lastExportedFillGet) = value
		ifFalse:[^interpreterProxy primitiveFail].
	value _ interpreterProxy fetchInteger: FTMinXIndex ofObject: fillOop.
	self lastExportedLeftXGet = value
		ifFalse:[^interpreterProxy primitiveFail].
	value _ interpreterProxy fetchInteger: FTMaxXIndex ofObject: fillOop.
	self lastExportedRightXGet = value
		ifFalse:[^interpreterProxy primitiveFail].

	(interpreterProxy slotSizeOf: bitsOop) < (self lastExportedRightXGet - self lastExportedLeftXGet)
		ifTrue:[^interpreterProxy primitiveFail].

	interpreterProxy failed ifTrue:[^nil].

	self fillBitmapSpan: (interpreterProxy firstIndexableField: bitsOop)
		from: self lastExportedLeftXGet
		to: self lastExportedRightXGet.

	self statePut: GEStateScanningAET. "Back to scanning AET"
	self storeEngineStateInto: engine.
	interpreterProxy pop: 2. "Leave rcvr on stack"
	doProfileStats ifTrue:[
		self incrementStat: GWCountMergeFill by: 1.
		self incrementStat: GWTimeMergeFill by: (interpreterProxy ioMicroMSecs - geProfileTime)].
