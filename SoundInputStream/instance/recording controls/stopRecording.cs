stopRecording
	"Turn off the sound input process and close the driver."

	super stopRecording.
	recordedBuffers _ nil.
	mutex _ nil.
