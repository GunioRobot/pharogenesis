primFinishedProcessing
	"Return true if there are no more entries in AET and GET and the last scan line has been displayed"
	<primitive: 'gePrimitiveFinishedProcessing'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveFinishedProcessing'].
	^self primitiveFailed