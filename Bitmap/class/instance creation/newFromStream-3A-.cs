newFromStream: s
	| len |
	s next = 16r80 ifTrue:
		["New compressed format"
		len _ self decodeIntFrom: s.
		^ Bitmap decompressFromByteArray: (s nextInto: (ByteArray new: len))].
	s skip: -1.
	len _ s nextInt32.
	len <= 0
		ifTrue: ["Old compressed format"
				^ (self new: len negated) readCompressedFrom: s]
		ifFalse: ["Old raw data format"
				^ s nextInto: (self new: len)]