add: aB3dColor4 at: index
	| baseIdx |
	baseIdx _ index-1*4.
	self floatAt: baseIdx+1 put: (self floatAt: baseIdx+1) + aB3dColor4 red.
	self floatAt: baseIdx+2 put: (self floatAt: baseIdx+2) + aB3dColor4 green.
	self floatAt: baseIdx+3 put: (self floatAt: baseIdx+3) + aB3dColor4 blue.
	self floatAt: baseIdx+4 put: (self floatAt: baseIdx+4) + aB3dColor4 alpha.
