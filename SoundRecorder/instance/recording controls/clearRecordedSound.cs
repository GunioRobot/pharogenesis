clearRecordedSound
	"Clear the sound recorded thus far. Go into pause mode if currently recording."

	paused _ true.
	recordedBuffers _ OrderedCollection new: 1000.
	self allocateBuffer.
