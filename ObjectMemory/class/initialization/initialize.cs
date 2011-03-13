initialize
	"ObjectMemory initialize"

	"Translation flags (booleans that control code generation via conditional translation):"
	DoAssertionChecks _ false.  "generate assertion checks"

	self initializeSpecialObjectIndices.
	self initializeObjectHeaderConstants.

	SmallContextSize _ 92.  "16 indexable fields"
	LargeContextSize _ 252.  "56 indexable fileds.  Max with single header word."
	LargeContextBit _ 16r40000.  "This bit set in method headers if large context is needed."
	CtxtTempFrameStart _ 6.  "Copy of TempFrameStart in Interp"
	NilContext _ 1.  "the oop for the integer 0; used to mark the end of context lists"

	RemapBufferSize _ 25.
	RootTableSize _ 2500.  "number of root table entries (4 bytes/entry)"

	"tracer actions"
	StartField _ 1.
	StartObj _ 2.
	Upward _ 3.
	Done _ 4.