primMergeFill: fillBitmap from: fill
	"Merge the filled bitmap into the current output buffer."
	^BalloonEnginePlugin doPrimitive: 'gePrimitiveMergeFillFrom'