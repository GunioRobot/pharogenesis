getFullBounds
	"Return the 2D bounds of the receiver and its children or nil if not visible"
	^self getFullBoundsFor: myWonderland getDefaultCamera.