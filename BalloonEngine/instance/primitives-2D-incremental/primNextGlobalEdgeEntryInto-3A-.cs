primNextGlobalEdgeEntryInto: edgeEntry
	"Store the next entry of the GET at the current y-value in edgeEntry.
	Return false if there is no entry, true otherwise."
	<primitive: 'gePrimitiveNextGlobalEdgeEntry'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveNextGlobalEdgeEntry'].
	^self primitiveFailed