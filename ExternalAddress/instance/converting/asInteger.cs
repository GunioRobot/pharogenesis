asInteger
	"convert address to integer"
	^self inject: 0 into: [:total :byte | total * 256 + byte]