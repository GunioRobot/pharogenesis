primitiveDisplaySpanBuffer
	"Note: Must load bitBlt and spanBuffer"
	self export: true.
	self inline: false.
	doProfileStats ifTrue:[geProfileTime _ interpreterProxy ioMicroMSecs].
	interpreterProxy methodArgumentCount = 0
		ifFalse:[^interpreterProxy primitiveFail].
	engine _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateBlitBuffer)
		ifFalse:[^interpreterProxy primitiveFail].
	"Load span buffer and bitBlt"
	(self loadSpanBufferFrom:
		(interpreterProxy fetchPointer: BESpanIndex ofObject: engine))
			ifFalse:[^interpreterProxy primitiveFail].
	(self loadBitBltFrom: 
		(interpreterProxy fetchPointer: BEBitBltIndex ofObject: engine))
			ifFalse:[^interpreterProxy primitiveFail].
	(self currentYGet bitAnd: self aaScanMaskGet) = self aaScanMaskGet ifTrue:[
		self displaySpanBufferAt: self currentYGet.
		self postDisplayAction.
	].
	self finishedProcessing ifFalse:[
		self aetStartPut: 0.
		self currentYPut: self currentYGet + 1.
		self statePut: GEStateUpdateEdges].
	self storeEngineStateInto: engine.
	doProfileStats ifTrue:[
		self incrementStat: GWCountDisplaySpan by: 1.
		self incrementStat: GWTimeDisplaySpan by: (interpreterProxy ioMicroMSecs - geProfileTime)].
