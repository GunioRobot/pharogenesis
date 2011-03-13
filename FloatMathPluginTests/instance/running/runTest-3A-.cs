runTest: aBlock
	| bytes out float result |
	bytes := ByteArray new: 8.
	out := WriteStream on: ByteArray new.
	float := Float basicNew: 2.
	1 to: 10000 do:[:i|
		[1 to: 8 do:[:j| bytes at: j put: (random nextInt: 256)-1].
		float basicAt: 1 put: (bytes unsignedLongAt: 1 bigEndian: true).
		float basicAt: 2 put: (bytes unsignedLongAt: 5 bigEndian: true).
		float isNaN] whileTrue.
		result := aBlock value: float.
		out nextNumber: 4 put: (result basicAt: 1).
		out nextNumber: 4 put: (result basicAt: 2).
	].
	^self md5HashMessage: out contents.