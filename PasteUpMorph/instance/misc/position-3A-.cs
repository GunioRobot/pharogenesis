position: aPoint
	"Prevent moving a world (e.g. via HandMorph>>specialGesture:)"

	self isWorldMorph ifFalse: [super position: aPoint]
