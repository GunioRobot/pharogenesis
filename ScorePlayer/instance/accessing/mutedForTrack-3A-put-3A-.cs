mutedForTrack: trackIndex put: aBoolean

	muted at: trackIndex put: aBoolean.
	aBoolean ifFalse: [^ self].

	"silence any currently sounding notes for this track"
	activeSounds do: [:pair |
		pair last = trackIndex ifTrue: [activeSounds remove: pair ifAbsent: []]].
	midiPort ifNotNil: [
		activeMIDINotes do: [:pair |
			pair last = trackIndex ifTrue: [
				pair first endNoteOnMidiPort: midiPort.
				activeMIDINotes remove: pair ifAbsent: []]]].
