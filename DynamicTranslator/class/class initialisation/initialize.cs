initialize		"DynamicTranslator initialize"

	super initialize.
	self initializeConfiguration.

	self initializeOpcodeTables.		"initialises OpcodeTable and TranslatorOpcodeEncodings (pool dict)"
	self initializeTranslationTable.
	self initializeSharedCodeIndices.
	self initializePrimitiveIndices.
	self initializeTranslatedMethodIndices.
	self initializeSendTypes.

	OpcodeTableSize = TranslatorOpcodeEncodings size
		ifFalse: [self error: 'table size mismatch'].