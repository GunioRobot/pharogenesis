byteSwapByteObjects
	"Byte-swap the words of all bytes objects in the image, including Strings, ByteArrays, and CompiledMethods. This returns these objects to their original byte ordering after blindly byte-swapping the entire image. For compiled methods, byte-swap only their bytecodes part."

	| oop fmt wordAddr methodHeader |
	oop _ self firstObject.
	[oop < endOfMemory] whileTrue: [
		(self isFreeObject: oop) ifFalse: [
			fmt _ self formatOf: oop.
			fmt >= 8 ifTrue: [  "oop contains bytes"
				wordAddr _ oop + BaseHeaderSize.
				fmt >= 12 ifTrue: [
					"compiled method; start after methodHeader and literals"
					methodHeader _ self longAt: oop + BaseHeaderSize.
					wordAddr _ wordAddr + 4 + (((methodHeader >> 10) bitAnd: 16rFF) * 4).
				].
				self reverseBytesFrom: wordAddr to: oop + (self sizeBitsOf: oop).
			].
 		].
		oop _ self objectAfter: oop.
	].
