copyFromByteArray: byteArray
	"This method should work with either byte orderings"
	| long |
	(self size * 4) = byteArray size ifFalse: [self halt].
	1 to: byteArray size by: 4 do:
		[:i | long _ Integer
				byte1: (byteArray at: i+3)
				byte2: (byteArray at: i+2)
				byte3: (byteArray at: i+1)
				byte4: (byteArray at: i).
		self at: i+3//4 put: long]