videoFrames: ignored
	"Answer the number of video frames in this movie."

	^ (frameOffsets size - 1) max: 0
