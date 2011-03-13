playMidiStream: aStream title: titleString
	"The stream can be either a FileStream or a RemoteFileStream."

	aStream binary.
	ScorePlayerMorph
		openOn: (self new readMIDIFrom: aStream) asScore
		title: titleString.
