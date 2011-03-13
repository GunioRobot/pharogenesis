nextSignedBits: n
	"Return the next n bits as signed integer value"
	| value bits signBit |
	n = 0 ifTrue:[^0].
	value := self nextBits: n.
	"Use a lookup for determining whether or not the value should be sign extended"
	bits := #( 1 2 4 8 16 32 64 128 "1 ... 8"
			256 512 1024 2048 4096 8192 16384 32768 "9 ... 16"
			65536 131072 262144 524288 1048576 2097152 4194304 8388608 "17 ... 24"
			16777216 33554432 67108864 134217728 268435456 536870912 1073741824 2147483648 "25 ... 32"
			 4294967296 "33 bit -- for negation only" ).
	signBit := bits at: n.
	^(value bitAnd: signBit) = 0
		ifTrue:[value]
		ifFalse:[value - (bits at: n+1)]