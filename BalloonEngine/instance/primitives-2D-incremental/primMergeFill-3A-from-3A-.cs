primMergeFill: fillBitmap from: fill
	"Merge the filled bitmap into the current output buffer."
	<primitive: 'gePrimitiveMergeFillFrom'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveMergeFillFrom'].
	^self primitiveFailed