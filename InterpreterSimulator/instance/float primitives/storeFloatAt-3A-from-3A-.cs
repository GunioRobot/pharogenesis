storeFloatAt: floatBitsAddress from: aFloat

	self longAt: floatBitsAddress put: (aFloat at: 1).
	self longAt: floatBitsAddress+4 put: (aFloat at: 2).
