asByteArray
	"Answer a ByteArray containing my sample data serialized in most-significant byte first order."

	| sampleCount bytes dst s |
	sampleCount _ self monoSampleCount.
	bytes _ ByteArray new: 2 * sampleCount.
	dst _ 0.
	1 to: sampleCount do: [:src |
		s _ self at: src.
		bytes at: (dst _ dst + 1) put: ((s bitShift: -8) bitAnd: 255).
		bytes at: (dst _ dst + 1) put: (s bitAnd: 255)].
	^ bytes

	