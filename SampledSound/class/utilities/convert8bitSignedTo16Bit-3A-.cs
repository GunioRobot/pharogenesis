convert8bitSignedTo16Bit: anArray
	"Convert the given array of samples--assumed to be 8-bit signed, linear data--into 16-bit signed samples. Return an array containing the resulting samples. Typically used to read uncompressed AIFF sound data."

	| n samples s |
	n _ anArray size.
	samples _ SoundBuffer newMonoSampleCount: n.
	1 to: n do: [:i |
		s _ anArray at: i.
		s > 127 ifTrue: [s _ s - 256].
		samples at: i put: (s * 256)].
	^ samples
