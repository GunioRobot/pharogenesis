initialize
	"ObjectMemory initialize"

	self initializeSpecialObjectIndices.
	self initializeObjectHeaderConstants.

	LargeContextSize _ 156.
	SmallContextSize _ 76.
	NilContext _ 1.  "the oop for the integer 0; used to mark the end of context lists"

	MinimumForwardTableBytes _ 16000.  "bytes reserved for forwarding table (8 bytes/entry)"
	RemapBufferSize _ 25.
	RootTableSize _ 1000.  "number of root table entries (4 bytes/entry)"

	"tracer actions"
	StartField _ 1.
	StartObj _ 2.
	Upward _ 3.
	Done _ 4.