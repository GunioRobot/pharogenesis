initialize
	"DynamicInterpreterState initialize"

	super initialize.

	self initializeAssociationIndex.
	self initializeCharacterIndex.
	self initializeClassIndices.
	self initializeContextIndices.
	self initializeDirectoryLookupResultCodes.
	self initializeMessageIndices.
	self initializeMethodCacheIndices.
	self initializeMethodIndices.
	self initializePointIndices.
	self initializePrimitiveTable.
	self initializeSchedulerIndices.
	self initializeSmallIntegers.
	self initializeStreamIndices.

	SemaphoresToSignalSize _ 25.