midiKeyForPitch: pitchNameOrNumber
	"Answer the midiKey closest to the given pitch. Pitch may be a numeric pitch or a pitch name string such as 'c4'."
	"AbstractSound midiKeyForPitch: 440.0"

	| p octave i midiKey |
	pitchNameOrNumber isNumber
		ifTrue: [p _ pitchNameOrNumber asFloat]
		ifFalse: [p _ AbstractSound pitchForName: pitchNameOrNumber].
	octave _ -1.
	[p >= TopOfBottomOctave] whileTrue: [
		octave _ octave + 1.
		p _ p / 2.0].

	i _ self indexOfBottomOctavePitch: p.
	(i > 1) ifTrue: [
		(p - (PitchesForBottomOctave at: i - 1)) < ((PitchesForBottomOctave at: i) - p)
			ifTrue: [i _ i - 1]].

	midiKey _ ((octave * 12) + 11 + i).
	midiKey > 127 ifTrue: [midiKey _ 127].
	^ midiKey
