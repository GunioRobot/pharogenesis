testPlay
	"Performance benchmark. Decompress and display all my frames. Answer the frame rate achieved in frames/second. No sound is played."

	| frameForm frameCount t |
	frameForm _ Form extent: movieExtent depth: (Display depth max: 16).
	frameCount _ self videoFrames: 0.
	self videoSetFrame: 1 stream: 0.
	t _ [
		frameCount timesRepeat: [
			self videoReadFrameInto: frameForm stream: 0.
			frameForm display].
	] timeToRun.
	^ ((1000.0 * frameCount) / t) roundTo: 0.01
