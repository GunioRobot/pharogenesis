normalizePositive: aLargePositiveInteger 
	"Check for leading zeroes and return shortened copy if so."
	"First establish len = significant length."
	| sLen val len oldLen |
	len _ oldLen _ self digitLength: aLargePositiveInteger.
	[len ~= 0 and: [(self unsafeByteOf: aLargePositiveInteger at: len)
			= 0]]
		whileTrue: [len _ len - 1].
	len = 0 ifTrue: [^ 0 asOop: SmallInteger].
	"Now check if in SmallInteger range"
	sLen _ 4.
	"SmallInteger maxVal digitLength."
	(len <= sLen and: [(self digitOfBytes: aLargePositiveInteger at: sLen)
			<= (self cDigitOfCSI: 1073741823 at: sLen)
		"SmallInteger maxVal"])
		ifTrue: 
			["If so, return its SmallInt value"
			val _ 0.
			len
				to: 1
				by: -1
				do: [:i | val _ val * 256 + (self unsafeByteOf: aLargePositiveInteger at: i)].
			^ val asOop: SmallInteger].
	"Return self, or a shortened copy"
	len < oldLen
		ifTrue: ["^ self growto: len"
			^ self bytes: aLargePositiveInteger growTo: len]
		ifFalse: [^ aLargePositiveInteger]