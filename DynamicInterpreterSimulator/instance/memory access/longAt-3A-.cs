longAt: byteAddress
	"Note: Adjusted for Smalltalk's 1-based array indexing."
	self assertIsWordAligned: byteAddress.
	^memory at: (byteAddress // 4) + 1