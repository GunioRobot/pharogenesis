loadRenderingState
	"Load the entire state from the interpreter for the rendering primitives"
	| edgeOop fillOop state |
	self inline: false.
	interpreterProxy methodArgumentCount = 2
		ifFalse:[^interpreterProxy primitiveFail].
	fillOop _ interpreterProxy stackObjectValue: 0.
	edgeOop _ interpreterProxy stackObjectValue: 1.
	engine _ interpreterProxy stackObjectValue: 2.
	interpreterProxy failed ifTrue:[^false].
	(self quickLoadEngineFrom: engine)
		ifFalse:[^false].

	"Load span buffer and bitBlt"
	(self loadSpanBufferFrom:
		(interpreterProxy fetchPointer: BESpanIndex ofObject: engine))
			ifFalse:[^false].
	(self loadBitBltFrom: 
		(interpreterProxy fetchPointer: BEBitBltIndex ofObject: engine))
			ifFalse:[^false].
	(self loadFormsFrom:
		(interpreterProxy fetchPointer: BEFormsIndex ofObject: engine))
			ifFalse:[^false].
	"Check edgeOop and fillOop"
	(interpreterProxy slotSizeOf: edgeOop) < ETBalloonEdgeDataSize 
		ifTrue:[^false].
	(interpreterProxy slotSizeOf: fillOop) < FTBalloonFillDataSize 
		ifTrue:[^false].

	"Note: Rendering can only take place if we're not in one of the intermediate
	(e.g., external) states."
	state _ self stateGet.
	(state = GEStateWaitingForEdge or:[
		state = GEStateWaitingForFill or:[
			state = GEStateWaitingChange]]) ifTrue:[^false].

	^true