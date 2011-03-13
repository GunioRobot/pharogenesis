renameVectorSlot: oldSlotName newSlotName: newSlotName

	| index |
	index _ info at: oldSlotName asSymbol ifAbsent: [^ self].
	info removeKey: oldSlotName asSymbol.
	info at: newSlotName put: index.
