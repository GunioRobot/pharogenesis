primAddActiveEdgeTableEntryFrom: edgeEntry
	"Add edge entry to the AET."
	<primitive: 'gePrimitiveAddActiveEdgeEntry'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveAddActiveEdgeEntry'].
	(self canProceedAfter: self primGetFailureReason) ifTrue:[
		^self primAddActiveEdgeTableEntryFrom: edgeEntry
	].
	^self primitiveFailed