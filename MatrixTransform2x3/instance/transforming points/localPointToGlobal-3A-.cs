localPointToGlobal: aPoint
	"Transform aPoint from local coordinates into global coordinates"
	<primitive: 'm23PrimitiveTransformPoint'>
	^(self transformPoint: aPoint) rounded