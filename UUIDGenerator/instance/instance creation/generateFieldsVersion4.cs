generateFieldsVersion4

	timeLow _ self generateRandomBitsOfLength: 32.
	timeMid _ self generateRandomBitsOfLength: 16.
	timeHiAndVersion _ 16r4000 bitOr: (self generateRandomBitsOfLength: 12).
	clockSeqHiAndReserved _ 16r80 bitOr: (self generateRandomBitsOfLength: 6).
	clockSeqLow _ self generateRandomBitsOfLength: 8.
	node _ self generateRandomBitsOfLength: 48.
	