asByteArray
	"Faster way to make a byte array from me.
	copyFromByteArray: makes equal Bitmap."
	| f bytes hack |
	f _ Form extent: 4@self size depth: 8 bits: self.
	bytes _ ByteArray new: self size * 4.
	hack _ Form new hackBits: bytes.
	SmalltalkImage current isLittleEndian ifTrue:[hack swapEndianness].
	hack copyBits: f boundingBox
		from: f
		at: (0@0)
		clippingBox: hack boundingBox
		rule: Form over
		fillColor: nil
		map: nil.

	"f displayOn: hack."
	^ bytes.
