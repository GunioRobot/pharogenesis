endianness

	EndianCache ifNil: [EndianCache _ self calcEndianness].
	^ EndianCache.
