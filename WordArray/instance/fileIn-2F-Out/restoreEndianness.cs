restoreEndianness
	"This word object was just read in from a stream.  It was stored in Big Endian (Mac) format.  Reverse the byte order if the current machine is Little Endian."

	Smalltalk endianness == #little 
		ifTrue: [
			self swapBytesFrom: 1 to: self size]
