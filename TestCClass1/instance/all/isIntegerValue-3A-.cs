isIntegerValue: intValue
	"Copied from ObjectMemory."

	^ (intValue bitXor: (intValue << 1)) >= 0