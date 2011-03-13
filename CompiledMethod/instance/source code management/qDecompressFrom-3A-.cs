qDecompressFrom: input "<ReadStream on: ByteArray> ^<String>"
	"Decompress strings compressed by qCompress:.
	Most common 11 chars get values 0-10 packed in one 4-bit nibble;
	next most common 52 get values 12-15 (2 bits) * 16 plus next nibble;
	escaped chars get three nibbles"
	^ String streamContents:
		[:strm | | nextNibble nibble peek charTable char |
		charTable :=  "Character encoding table must match qCompress:"
		'ear tonsilcmbdfghjkpquvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ012345[]()'.
		peek := true.
		nextNibble := [peek
						ifTrue: [peek := false. input peek ifNil: [0] ifNotNil: [:b| b // 16]]
						ifFalse: [peek := true. input next ifNil: [0] ifNotNil: [:b| b \\ 16]]].
		[input atEnd] whileFalse:
			[(nibble := nextNibble value) = 0
				ifTrue: [input atEnd ifFalse:
						[strm nextPut: (Character value: nextNibble value * 16 + nextNibble value)]]
				ifFalse:
					[nibble <= 11
						ifTrue:
							[strm nextPut: (charTable at: nibble)]
						ifFalse:
							[strm nextPut: (charTable at: nibble-12 * 16 + nextNibble value)]]]]