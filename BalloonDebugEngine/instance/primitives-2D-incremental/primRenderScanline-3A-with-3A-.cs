primRenderScanline: edge with: fill
	"Start/Proceed rendering the current scan line"
	^BalloonEnginePlugin doPrimitive: 'gePrimitiveRenderScanline'