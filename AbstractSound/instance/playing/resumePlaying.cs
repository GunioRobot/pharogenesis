resumePlaying
	"Pause this sound. It can be resumed from this point, or reset and resumed to start from the beginning."

	SoundPlayer pauseSound: self.  "be sure it isn't already playing"
	SoundPlayer resumePlaying: self.
