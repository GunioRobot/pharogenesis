unsafeByteOf: bytesOop at: ix
	"Argument bytesOop must not be aSmallInteger!"
	^ interpreterProxy integerValueOf: (interpreterProxy stObject: bytesOop at: ix)