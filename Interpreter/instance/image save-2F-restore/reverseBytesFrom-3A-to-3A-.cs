reverseBytesFrom: startAddr to: stopAddr
	"Byte-swap the given range of memory (not inclusive!)."
	| addr |
	addr _ startAddr.
	[addr < stopAddr] whileTrue:
		[self longAt: addr put: (self byteSwapped: (self longAt: addr)).
		addr _ addr + 4].