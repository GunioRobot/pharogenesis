isInMemory: address
	"Return true if the given address is in ST object memory"
	^address >= self startOfMemory and:[address < endOfMemory]