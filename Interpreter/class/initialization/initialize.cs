initialize
	"Interpreter initialize"

	super initialize.  "initialize ObjectMemory constants"
	self initializeAssociationIndex.
	self initializeBytecodeTable.
	self initializeCharacterIndex.
	self initializeClassIndices.
	self initializeContextIndices.
	self initializeDirectoryLookupResultCodes.
	self initializeMessageIndices.
	self initializeMethodIndices.
	self initializePointIndices.
	self initializePrimitiveTable.
	self initializeSchedulerIndices.
	self initializeSmallIntegers.
	self initializeStreamIndices.

	MethodCacheEntries _ 512. 
	MethodCacheMask _ MethodCacheEntries - 1.
	(MethodCacheEntries bitAnd: MethodCacheMask) = 0
		ifFalse: [ self error: 'MethodCacheEntries must be a power of two' ].
	MethodCacheSize _ MethodCacheEntries * 4.
	CacheProbeMax _ 3.

	SemaphoresToSignalSize _ 25.
