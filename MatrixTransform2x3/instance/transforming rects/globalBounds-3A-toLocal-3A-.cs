globalBounds: srcRect toLocal: dstRect
	"Transform aRectangle from global coordinates into local coordinates"
	<primitive:'m23PrimitiveInvertRectInto'>
	^super globalBoundsToLocal: srcRect