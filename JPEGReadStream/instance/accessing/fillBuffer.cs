fillBuffer

	| byte |
	[bitsInBuffer <= 16]
		whileTrue:[
			byte _ self next.
			(byte = 16rFF and: [(self peekFor: 16r00) not])
					ifTrue:
						[self position: self position - 1.
						^0].
			bitBuffer _ (bitBuffer bitShift: 8) bitOr: byte.
			bitsInBuffer _ bitsInBuffer + 8].
	^ bitsInBuffer