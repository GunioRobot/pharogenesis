proceedRenderingScanline
	"Proceed rendering the current scan line.
	This method may be called after some Smalltalk code has been executed inbetween."
	"This is the main rendering entry"
	| external state |
	self inline: false.
	state _ self stateGet.

	state = GEStateUnlocked ifTrue:[
		self initializeGETProcessing.
		engineStopped ifTrue:[^0].
		state _ GEStateAddingFromGET.
	]. 

	state = GEStateAddingFromGET ifTrue:[
		doProfileStats ifTrue:[geProfileTime _ interpreterProxy ioMicroMSecs].
		external _ self findNextExternalEntryFromGET.
		doProfileStats ifTrue:[
			self incrementStat: GWCountNextGETEntry by: 1.
			self incrementStat: GWTimeNextGETEntry by: (interpreterProxy ioMicroMSecs - geProfileTime)].
		engineStopped ifTrue:[^self statePut: GEStateAddingFromGET].
		external ifTrue:[
			self statePut: GEStateWaitingForEdge.
			^self stopBecauseOf: GErrorGETEntry.
		]. 
		self aetStartPut: 0.
		self wbStackClear.
		self clearSpanBufferPut: 1.
		state _ GEStateScanningAET.
	].

	state = GEStateScanningAET ifTrue:[
		doProfileStats ifTrue:[geProfileTime _ interpreterProxy ioMicroMSecs].
		(self clearSpanBufferGet ~= 0 and:[(self currentYGet bitAnd: self aaScanMaskGet) = 0])
			ifTrue:[self clearSpanBuffer].
		self clearSpanBufferPut: 0.
		external _ self findNextExternalFillFromAET.
		doProfileStats ifTrue:[
			self incrementStat: GWCountNextFillEntry by: 1.
			self incrementStat: GWTimeNextFillEntry by: (interpreterProxy ioMicroMSecs - geProfileTime)].
		engineStopped ifTrue:[^self statePut: GEStateScanningAET].
		external ifTrue:[
			self statePut: GEStateWaitingForFill.
			^self stopBecauseOf: GErrorFillEntry.
		].
		state _ GEStateBlitBuffer.
		self wbStackClear.
		self spanEndAAPut: 0.
	].

	state = GEStateBlitBuffer ifTrue:[
		doProfileStats ifTrue:[geProfileTime _ interpreterProxy ioMicroMSecs].
		(self currentYGet bitAnd: self aaScanMaskGet) = self aaScanMaskGet ifTrue:[
			self displaySpanBufferAt: self currentYGet.
			self postDisplayAction.
		].
		doProfileStats ifTrue:[
			self incrementStat: GWCountDisplaySpan by: 1.
			self incrementStat: GWTimeDisplaySpan by: (interpreterProxy ioMicroMSecs - geProfileTime)].
		engineStopped ifTrue:[^self statePut: GEStateBlitBuffer].
		self finishedProcessing ifTrue:[^0].
		state _ GEStateUpdateEdges.
		self aetStartPut: 0.
		self currentYPut: self currentYGet + 1.
	].

	state = GEStateUpdateEdges ifTrue:[
		doProfileStats ifTrue:[geProfileTime _ interpreterProxy ioMicroMSecs].
		external _ self findNextExternalUpdateFromAET.
		doProfileStats ifTrue:[
			self incrementStat: GWCountNextAETEntry by: 1.
			self incrementStat: GWTimeNextAETEntry by: (interpreterProxy ioMicroMSecs - geProfileTime)].
		engineStopped ifTrue:[^self statePut: GEStateUpdateEdges].
		external ifTrue:[
			self statePut: GEStateWaitingChange.
			^self stopBecauseOf: GErrorAETEntry.
		].
		self statePut: GEStateAddingFromGET.
	].