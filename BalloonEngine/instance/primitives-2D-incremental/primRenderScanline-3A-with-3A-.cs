primRenderScanline: edge with: fill
	"Start/Proceed rendering the current scan line"
	<primitive: 'gePrimitiveRenderScanline'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveRenderScanline'].
	^self primitiveFailed