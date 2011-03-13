initialize
	"Interpreter initialize"

	super initialize.  "initialize ObjectMemory constants"
	self initializeAssociationIndex.
	self initializeBytecodeTable.
	self initializeCaches.
	self initializeCharacterIndex.
	self initializeClassIndices.
	self initializeCompilerHooks.
	self initializeContextIndices.
	self initializeDirectoryLookupResultCodes.
	self initializeMessageIndices.
	self initializeMethodIndices.
	self initializePointIndices.
	self initializePrimitiveTable.
	self initializeSchedulerIndices.
	self initializeSmallIntegers.
	self initializeStreamIndices.

	SemaphoresToSignalSize _ 500.
	PrimitiveExternalCallIndex _ 117. "Primitive index for #primitiveExternalCall"
	GenerateBrowserPlugin _ false.
	MillisecondClockMask _ 16r1FFFFFFF.
	"Note: The external primitive table should actually be dynamically sized but for the sake of inferior platforms (e.g., Mac :-) who cannot allocate memory in any reasonable way, we keep it static (and cross our fingers...)"
	MaxExternalPrimitiveTableSize _ 4096. "entries"
