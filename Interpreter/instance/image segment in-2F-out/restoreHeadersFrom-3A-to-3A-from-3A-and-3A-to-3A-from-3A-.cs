restoreHeadersFrom: firstIn to: lastIn from: hdrBaseIn and: firstOut to: lastOut from: hdrBaseOut

	"Restore headers smashed by forwarding links"
	| tablePtr oop header |
	tablePtr _ firstIn.
	[tablePtr <= lastIn] whileTrue:
		[oop _ self longAt: tablePtr.
		header _ self longAt: hdrBaseIn + (tablePtr-firstIn).
		self longAt: oop put: header.
		tablePtr _ tablePtr + 4].
	tablePtr _ firstOut.
	[tablePtr <= lastOut] whileTrue:
		[oop _ self longAt: tablePtr.
		header _ self longAt: hdrBaseOut + (tablePtr-firstOut).
		self longAt: oop put: header.
		tablePtr _ tablePtr + 4].
	
	"Clear all mark bits"
	oop _ self firstObject.
	[oop < endOfMemory] whileTrue:
		[(self isFreeObject: oop) ifFalse:
			[self longAt: oop put: ((self longAt: oop) bitAnd: AllButMarkBit)].
		oop _ self objectAfter: oop].
