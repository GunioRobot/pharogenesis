initialize
	"initialize the state of the receiver"
	super initialize.
	""
	
	playMode _ #stop.
	"#stop, #playOnce, or #loop"
	msecsPerFrame _ 200.
	rotationDegrees _ 0.
	scalePoint _ 1.0 @ 1.0.
	frameList _ EmptyArray.
	currentFrameIndex _ 1.
	dwellCount _ 0