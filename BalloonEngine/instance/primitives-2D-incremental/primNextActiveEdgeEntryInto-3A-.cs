primNextActiveEdgeEntryInto: edgeEntry
	"Store the next entry of the AET at the current y-value in edgeEntry.
	Return false if there is no entry, true otherwise."
	<primitive: 'gePrimitiveNextActiveEdgeEntry'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveNextActiveEdgeEntry'].
	^self primitiveFailed