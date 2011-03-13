openFileNamed: fName withScorePlayer: playerReady andPlayFrom: frameNo
	"Note: The plan is that the score player (a SampledSound) is already spaced
	forward to this frame number so it does not need to be reset as would normally
	happen in startRunning."

	self pvtOpenFileNamed: fName.
	scorePlayer _ playerReady.
	frameNumber _ frameNo.
	frameAtLastSync _ frameNo.
	msAtLastSync _ frameAtLastSync * msPerFrame.
	self playForward.