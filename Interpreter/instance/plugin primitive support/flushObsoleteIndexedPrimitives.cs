flushObsoleteIndexedPrimitives
	"Flush the pointers in the obsolete indexed primitive table"
	1 to: MaxPrimitiveIndex
		do: [:i | (obsoleteIndexedPrimitiveTable at: i) at: 2 put: nil]