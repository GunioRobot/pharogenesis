primChangeActiveEdgeTableEntryFrom: edgeEntry
	"Change the entry in the active edge table from edgeEntry"
	<primitive: 'gePrimitiveChangedActiveEdgeEntry'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveChangedActiveEdgeEntry'].
	^self primitiveFailed