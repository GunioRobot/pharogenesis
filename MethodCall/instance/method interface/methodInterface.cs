methodInterface
	"Answer the receiver's methodInterface, conjuring one up on the spot (and remembering) if not present"

	^ methodInterface ifNil:
		[methodInterface _ self ephemeralMethodInterface]