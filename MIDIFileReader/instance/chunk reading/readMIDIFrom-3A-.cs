readMIDIFrom: aBinaryStream
	"Read one or more MIDI tracks from the given binary stream."

	stream _ aBinaryStream.
	tracks _ OrderedCollection new.
	trackInfo _ OrderedCollection new.
	self readHeaderChunk.
	trackCount timesRepeat: [self readTrackChunk].
	stream atEnd ifFalse: [self report: 'data beyond final track'].
