mutedForTrack: trackIndex put: aBoolean

	muted at: trackIndex put: aBoolean.
	aBoolean ifTrue: [
		activeSounds do: [:pair |
			pair last = trackIndex ifTrue: [activeSounds remove: pair ifAbsent: []]]].
