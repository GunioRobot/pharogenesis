defaultSamples: anArray repeated: n

	| data |
	data _ WriteStream on: (SoundBuffer newMonoSampleCount: anArray size * n).
	n timesRepeat: [
		anArray do: [:sample | data nextPut: sample truncated]].
	DefaultSampleTable _ data contents.
