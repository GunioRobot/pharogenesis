addPitches
	| offset |
	offset _ 0.0.
	events do: [ :each |
		each pitchPoints: (self pitchesBetween: offset and: offset + each duration).
		offset _ offset + each duration].