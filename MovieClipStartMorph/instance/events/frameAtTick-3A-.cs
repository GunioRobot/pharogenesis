frameAtTick: time
	"Return the frame number corresponding to the given tick time"

	^ frameNumber +
		((time - self startTime) asFloat
			/ (self endTime - self startTime)
			* (endMorph frameNumber - frameNumber)) asInteger