globalPointToLocal: aPoint
	"Transform aPoint from global coordinates into local coordinates"
	<primitive: 'm23PrimitiveInvertPoint'>
	^(self invertPoint: aPoint) rounded