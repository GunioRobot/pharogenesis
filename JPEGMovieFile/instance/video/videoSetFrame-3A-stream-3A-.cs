videoSetFrame: newIndex stream: ignored
	"Set the index of the current frame."

	currentFrameIndex _ (newIndex asInteger max: 1) min: (frameOffsets size - 1).
