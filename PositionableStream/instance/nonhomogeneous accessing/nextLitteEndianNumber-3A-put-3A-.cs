nextLitteEndianNumber: n put: value
	"Answer the next n bytes as a positive Integer or LargePositiveInteger, where the bytes are ordered from least significant to most significant."
	| bytes |
	bytes _ ByteArray new: n.
	1 to: n do: [: i | bytes at: i put: (value digitAt: i)].
	self nextPutAll: bytes