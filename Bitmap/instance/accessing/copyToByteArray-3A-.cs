copyToByteArray: byteArray
	"This method should work with either byte orderings"
	| long |
	(self size * 4) = byteArray size ifFalse: [self halt].
	1 to: byteArray size by: 4 do:
		[:i | long _ self at: i+3//4.
		byteArray at: i+3 put: (long digitAt: 1).
		byteArray at: i+2 put: (long digitAt: 2).
		byteArray at: i+1 put: (long digitAt: 3).
		byteArray at: i put: (long digitAt: 4)]