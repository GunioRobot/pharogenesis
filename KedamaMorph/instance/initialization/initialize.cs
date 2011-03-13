initialize

	super initialize.
	dimensions _ self class defaultDimensions.  "dimensions of this StarSqueak world in patches"
	wrapX _ dimensions x asFloat.
	wrapY _ dimensions y asFloat.
	pixelsPerPatch _ 2.
	super extent: dimensions * pixelsPerPatch.
	self assuredPlayer assureUniClass.
	self clearAll.  "be sure this is done once in case setup fails to do it"
	autoChanged _ true.
	self leftEdgeMode: #wrap.
	self rightEdgeMode: #wrap.
	self topEdgeMode: #wrap.
	self bottomEdgeMode: #wrap.

	turtlesDictSemaphore _ Semaphore forMutualExclusion.
