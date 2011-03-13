testInfinity3
	self assert: (Float infinity negated asIEEE32BitWord printPaddedWith: $0 to: 32 base: 2) =
		'11111111100000000000000000000000'.
	self assert: (Float fromIEEE32Bit:
		(Integer readFrom: '11111111100000000000000000000000' readStream base: 2))
			= Float infinity negated