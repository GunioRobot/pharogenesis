storeAIFFSamples: aSoundBuffer samplingRate: rate on: aBinaryStream

	| sampleCount s |
	sampleCount _ aSoundBuffer monoSampleCount.
	aBinaryStream nextPutAll: 'FORM' asByteArray.
	aBinaryStream nextInt32Put: (2 * sampleCount) + ((7 * 4) + 18).
	aBinaryStream nextPutAll: 'AIFF' asByteArray.
	aBinaryStream nextPutAll: 'COMM' asByteArray.
	aBinaryStream nextInt32Put: 18.
	aBinaryStream nextNumber: 2 put: 1.  "channels"
	aBinaryStream nextInt32Put: sampleCount.
	aBinaryStream nextNumber: 2 put: 16.  "bits/sample"
	self storeExtendedFloat: rate on: aBinaryStream.
	aBinaryStream nextPutAll: 'SSND' asByteArray.
	aBinaryStream nextInt32Put: (2 * sampleCount) + 8.
	aBinaryStream nextInt32Put: 0.
	aBinaryStream nextInt32Put: 0.
	1 to: sampleCount do: [:i |
		s _ aSoundBuffer at: i.
		aBinaryStream nextPut: ((s bitShift: -8) bitAnd: 16rFF).
		aBinaryStream nextPut: (s bitAnd: 16rFF)].
