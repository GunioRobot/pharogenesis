localBounds: srcRect toGlobal: dstRect
	"Transform aRectangle from local coordinates into global coordinates"
	<primitive:'m23PrimitiveTransformRectInto'>
	^super localBoundsToGlobal: srcRect