primitiveChangedActiveEdgeEntry
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
	(self quickLoadEngineFrom: engine requiredState: GEStateWaitingChange)
		ifFalse:[^interpreterProxy primitiveFail].

	edge _ self loadEdgeStateFrom: edgeOop.
	interpreterProxy failed ifTrue:[^nil].

	(self edgeNumLinesOf: edge) = 0 
		ifTrue:[	self removeFirstAETEntry]
		ifFalse:[	self resortFirstAETEntry.
				self aetStartPut: self aetStartGet + 1].

	self statePut: GEStateUpdateEdges. "Back to updating edges"
	self storeEngineStateInto: engine.
	interpreterProxy pop: 1. "Leave rcvr on stack"
	doProfileStats ifTrue:[
		self incrementStat: GWCountChangeAETEntry by: 1.
		self incrementStat: GWTimeChangeAETEntry by: (interpreterProxy ioMicroMSecs - geProfileTime)].
