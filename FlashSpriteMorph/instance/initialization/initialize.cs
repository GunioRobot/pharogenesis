initialize
"initialize the state of the receiver"
	super initialize.
""
	playing _ false.
	loadedFrames _ 0.
	maxFrames _ 1.
	frameNumber _ 1.
	sounds _ Dictionary new.
	actions _ Dictionary new.
	labels _ Dictionary new.
	stepTime _ 1.
	useTimeSync _ true