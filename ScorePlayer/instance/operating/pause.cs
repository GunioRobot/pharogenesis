pause
	"Pause this sound. It can be resumed from this point, or reset and resumed to start from the beginning."

	score pauseFrom: self.
	super pause.
	activeSounds _ activeSounds species new.
	midiPort ifNotNil: [self stopMIDIPlaying].
