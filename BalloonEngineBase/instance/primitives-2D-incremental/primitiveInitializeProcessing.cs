primitiveInitializeProcessing
	"Note: No need to load bitBlt but must load spanBuffer"
	self export: true.
	self inline: false.
	doProfileStats ifTrue:[geProfileTime _ interpreterProxy ioMicroMSecs].
	interpreterProxy methodArgumentCount = 0
		ifFalse:[^interpreterProxy primitiveFail].
	engine _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateUnlocked) 
		ifFalse:[^interpreterProxy primitiveFail].
	"Load span buffer for clear operation"
	(self loadSpanBufferFrom:
		(interpreterProxy fetchPointer: BESpanIndex ofObject: engine))
			ifFalse:[^interpreterProxy primitiveFail].
	self initializeGETProcessing.
	engineStopped ifTrue:[^interpreterProxy primitiveFail].
	self statePut: GEStateAddingFromGET. "Initialized"
	interpreterProxy failed ifFalse:[self storeEngineStateInto: engine].
	doProfileStats ifTrue:[
		self incrementStat: GWCountInitializing by: 1.
		self incrementStat: GWTimeInitializing by: (interpreterProxy ioMicroMSecs - geProfileTime)].
