initializeTranslator
	self inline: true.

	translationCycle _ ConstZero.
	inlineCacheLimit _ InlineCacheLimit.

	self initializeOpcodeTable.
	1 to: OpcodeTableSize do: [:op | self initOpcode: op].

	self initializeSendTables.

	statInlineCacheHits _ 0.
	statMethodCacheHits _ 0.
	statMethodCacheMisses _ 0.

	"The following is a read-write vm parameter"
	UseInlineCacheDelay ifTrue: [inlineCacheDelay _ InlineCacheDelay].