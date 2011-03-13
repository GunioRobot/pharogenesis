garbageCollect
	"Do a garbage collection, and report results to the user."

	self inform:
		(Smalltalk bytesLeft asStringWithCommas, ' bytes available').
