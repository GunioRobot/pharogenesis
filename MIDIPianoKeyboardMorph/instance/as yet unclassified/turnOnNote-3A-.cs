turnOnNote: midiKey

	midiPort midiCmd: 16r90 channel: channel byte: midiKey byte: velocity.
	soundPlaying _ midiKey.
