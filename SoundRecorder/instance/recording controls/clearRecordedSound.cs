clearRecordedSound
	"Clear the sound recorded thus far. Go into pause mode if currently recording."

	paused _ true.
	recordedSound _ SequentialSound new.
	self allocateBuffer.
