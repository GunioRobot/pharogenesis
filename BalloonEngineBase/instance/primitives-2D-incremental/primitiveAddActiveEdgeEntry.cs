primitiveAddActiveEdgeEntry
	"Note: No need to load either bitBlt or spanBuffer"
	| edgeOop edge |
	self export: true.
	self inline: false.
	doProfileStats ifTrue:[geProfileTime _ interpreterProxy ioMicroMSecs].
	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].
	edgeOop _ interpreterProxy stackObjectValue: 0.
	engine _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateWaitingForEdge)
		ifFalse:[^interpreterProxy primitiveFail].

	edge _ self loadEdgeStateFrom: edgeOop.
	interpreterProxy failed ifTrue:[^nil].

	(self needAvailableSpace: 1) 
		ifFalse:[^interpreterProxy primitiveFail].

	(self edgeNumLinesOf: edge) > 0 ifTrue:[
		self insertEdgeIntoAET: edge.
	].

	engineStopped ifTrue:[^interpreterProxy primitiveFail].

	self statePut: GEStateAddingFromGET. "Back to adding edges from GET"
	self storeEngineStateInto: engine.
	interpreterProxy pop: 1. "Leave rcvr on stack"
	doProfileStats ifTrue:[
		self incrementStat: GWCountAddAETEntry by: 1.
		self incrementStat: GWTimeAddAETEntry by: (interpreterProxy ioMicroMSecs - geProfileTime)].
