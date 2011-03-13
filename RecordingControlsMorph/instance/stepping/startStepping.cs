startStepping
	"Make the level meter active when dropped into the world. Do nothing if already recording. Note that this will cause other recorders to stop recording..."

	super startStepping.
	recorder isPaused ifTrue: [
		SoundRecorder allInstancesDo: [:r | r stopRecording].  "stop all other sound recorders"
		recorder pause].  "meter is updated while paused"
