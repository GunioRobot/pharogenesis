openTapeFromFile
	"Open an eventRecorder tape for playback."
 
	(EventRecorderMorph new readTape: self fullName) rewind openInWorld