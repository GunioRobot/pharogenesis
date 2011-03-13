qCompress: string
	"A very simple text compression routine designed for method temp names.
	 Most common 11 chars get values 1-11 packed in one 4-bit nibble;
	 the next most common get values 12-15 (2 bits) * 16 plus next nibble;
	 unusual ones get three nibbles, the first being the escape nibble 0.
	 CompiledMethod>>endPC determines the maximum length of encoded
	 output, which means 1 to (251 - 128) * 128 + 127, or 15871 bytes"
	string isEmpty ifTrue:
		[^self qCompress: ' '].
	^ ByteArray streamContents:
		[:strm | | ix oddNibble sz |
		oddNibble := nil.
		string do:
			[:char |
			ix := 'ear tonsilcmbdfghjkpquvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ012345[]()'
					indexOf: char ifAbsent: 0.
			(ix = 0
				ifTrue:
					[char asInteger > 255 ifTrue: [^nil]. "Could use UTF8 here; too lazy right now"
					{ 0. char asInteger // 16. char asInteger \\ 16 }]
				ifFalse:
					[ix <= 11
						ifTrue: [{ ix }]
						ifFalse: [{ ix//16+12. ix\\16 }]])
					do: [:nibble |
						oddNibble
							ifNotNil: [strm nextPut: oddNibble*16 + nibble. oddNibble := nil]
							ifNil: [oddNibble := nibble]]].
		oddNibble ifNotNil: "4 = 'ear tonsil' indexOf: Character space"
			[strm nextPut: oddNibble * 16 + 4].
		(sz := strm position) > ((251 - 128) * 128 + 127) ifTrue:
			[^nil].
		sz <= 127
			ifTrue: [strm nextPut: sz]
			ifFalse:
				[strm nextPut: sz \\ 128; nextPut: sz // 128 + 128]]