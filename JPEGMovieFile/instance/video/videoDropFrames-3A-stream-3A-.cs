videoDropFrames: skipCount stream: streamIndex
	"Advance the index of the current frame by the given number of frames."

	self videoSetFrame: currentFrameIndex + skipCount stream: streamIndex.
