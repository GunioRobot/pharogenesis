addPitches
	| offset |
	offset := 0.0.
	events do: [ :each |
		each pitchPoints: (self pitchesBetween: offset and: offset + each duration).
		offset := offset + each duration].