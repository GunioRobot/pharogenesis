fetchFloatAt: floatBitsAddress into: aFloat

	aFloat at: 1 put: (self longAt: floatBitsAddress).
	aFloat at: 2 put: (self longAt: floatBitsAddress+4).
