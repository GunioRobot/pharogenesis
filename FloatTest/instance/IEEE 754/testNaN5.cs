testNaN5
	self assert: (Float nan asIEEE32BitWord printPaddedWith: $0 to: 32 base: 2) =
		'01111111110000000000000000000000'.
	self assert: (Float fromIEEE32Bit:
		(Integer readFrom: '01111111110000000000000000000000' readStream base: 2)) isNaN