fromByteArray: aByteArray
	"Convert the given ByteArray (stored with the most significant byte first) into 16-bit sample buffer."

	| n buf src w |
	n _ aByteArray size // 2.
	buf _ SoundBuffer newMonoSampleCount: n.
	src _ 1.
	1 to: n do: [:i |
		w _ ((aByteArray at: src) bitShift: 8) + (aByteArray at: src + 1).
		w > 32767 ifTrue: [w _ w - 65536].
		buf at: i put: w.
		src _ src + 2].
	^ buf
