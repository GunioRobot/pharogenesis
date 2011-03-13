convertBytesTo16BitSamples: aByteArray mostSignificantByteFirst: msbFirst
	"Convert the given ByteArray (with the given byte ordering) into 16-bit sample buffer."

	| n data src b1 b2 w |
	n _ aByteArray size // 2.
	data _ SoundBuffer newMonoSampleCount: n.
	src _ 1.
	1 to: n do: [:i |
		b1 _ aByteArray at: src.
		b2 _ aByteArray at: src + 1.
		msbFirst
			ifTrue: [w _ (b1 bitShift: 8) + b2]
			ifFalse: [w _ (b2 bitShift: 8) + b1].
		w > 32767 ifTrue: [w _ w - 65536].
		data at: i put: w.
		src _ src + 2].
	^ data
