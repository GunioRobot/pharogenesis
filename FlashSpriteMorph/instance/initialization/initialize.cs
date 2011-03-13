initialize
"initialize the state of the receiver"
	super initialize.
""
	playing := false.
	loadedFrames := 0.
	maxFrames := 1.
	frameNumber := 1.
	sounds := Dictionary new.
	actions := Dictionary new.
	labels := Dictionary new.
	stepTime := 1.
	useTimeSync := true