initialize
	"initialize the state of the receiver"
	super initialize.
	""
	
	playMode := #stop.
	"#stop, #playOnce, or #loop"
	msecsPerFrame := 200.
	rotationDegrees := 0.
	scalePoint := 1.0 @ 1.0.
	frameList := EmptyArray.
	currentFrameIndex := 1.
	dwellCount := 0