boinkPitch: p dur: d loudness: l waveTable: waveTable pan: pan
	"Play a decaying note on the given stream using the given wave table. Used for testing only."

	| decay tableSize amplitude increment cycles i |
	decay _ 0.96.
	tableSize _ waveTable size.
	amplitude _ l asInteger min: 1000.
	increment _ ((p asFloat * tableSize asFloat) / SamplingRate asFloat) asInteger.
	increment _ (increment max: 1) min: (tableSize // 2).
	cycles _ (d * SamplingRate asFloat) asInteger.

	i _ 1.
	1 to: cycles do: [ :cycle |
		(cycle \\ 100) = 0 ifTrue: [
			amplitude _ (decay * amplitude asFloat) asInteger.
		].
		i _ (((i - 1) + increment) \\ tableSize) + 1.
		self playTestSample: (amplitude * (waveTable at: i)) // 1000 pan: pan.
	].
