primRenderImage: edge with: fill
	"Start/Proceed rendering the current scan line"
	<primitive: 'gePrimitiveRenderImage'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveRenderImage'].
	^self primitiveFailed