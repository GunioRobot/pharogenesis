fillBuffer

	| byte |
	[bitsInBuffer <= 16]
		whileTrue:
			[byte _ self next.
			(byte = 16rFF and: [(stream peekFor: 16r00) not])
					ifTrue:
						[stream position: stream position - 1.
						^0].
			bitBuffer _ bitBuffer << 8 bitOr: byte.
			bitsInBuffer _ bitsInBuffer + 8].
	^ bitsInBuffer