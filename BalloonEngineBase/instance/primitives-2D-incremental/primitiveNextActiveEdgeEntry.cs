primitiveNextActiveEdgeEntry
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
	(self quickLoadEngineFrom: engine requiredState: GEStateUpdateEdges or: GEStateCompleted)
		ifFalse:[^interpreterProxy primitiveFail].

	hasEdge _ false.
	self stateGet = GEStateCompleted ifFalse:[
		hasEdge _ self findNextExternalUpdateFromAET.
		hasEdge ifTrue:[
			edge _ aetBuffer at: self aetStartGet.
			self storeEdgeStateFrom: edge into: edgeOop.
			"Do not advance to the next aet entry yet"
			"self aetStartPut: self aetStartGet + 1."
			self statePut: GEStateWaitingChange. "Wait for changed edge"
		] ifFalse:[self statePut: GEStateAddingFromGET]. "Start over"
	].
	interpreterProxy failed ifTrue:[^nil].

	self storeEngineStateInto: engine.

	interpreterProxy pop: 2.
	interpreterProxy pushBool: hasEdge not.
	doProfileStats ifTrue:[
		self incrementStat: GWCountNextAETEntry by: 1.
		self incrementStat: GWTimeNextAETEntry by: (interpreterProxy ioMicroMSecs - geProfileTime)].
