initializeHashTables
	hashHead _ WordArray new: 1 << HashBits.
	hashTail _ WordArray new: WindowSize.
