primitiveNextGlobalEdgeEntry
	"Note: No need to load either bitBlt or spanBuffer"
	| edgeOop hasEdge edge |
	self export: true.
	self inline: false.
	doProfileStats ifTrue:[geProfileTime _ interpreterProxy ioMicroMSecs].
	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].
	edgeOop _ interpreterProxy stackObjectValue: 0.
	engine _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateAddingFromGET)
		ifFalse:[^interpreterProxy primitiveFail].

	hasEdge _ self findNextExternalEntryFromGET.
	hasEdge ifTrue:[
		edge _ getBuffer at: self getStartGet.
		self storeEdgeStateFrom: edge into: edgeOop.
		self getStartPut: self getStartGet + 1].

	interpreterProxy failed ifTrue:[^nil].

	hasEdge
		ifTrue:[	self statePut: GEStateWaitingForEdge] "Wait for adding edges"
		ifFalse:[ "Start scanning the AET"
				self statePut: GEStateScanningAET.
				self clearSpanBufferPut: 1. "Clear span buffer at next entry"
				self aetStartPut: 0.
				self wbStackClear].
	self storeEngineStateInto: engine.

	interpreterProxy pop: 2.
	interpreterProxy pushBool: hasEdge not.
	doProfileStats ifTrue:[
		self incrementStat: GWCountNextGETEntry by: 1.
		self incrementStat: GWTimeNextGETEntry by: (interpreterProxy ioMicroMSecs - geProfileTime)].
