arraySizeForCapacity: anInteger
	"Because of the hash performance, the array size is always a power of 2 
	and at least twice as big as the capacity anInteger"

	^ anInteger <= 0 
		ifTrue: [0]
		ifFalse: [1 << (anInteger << 1 - 1) highBit].