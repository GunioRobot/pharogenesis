storePointer: fieldIndex ofObject: oop withValue: valuePointer
	"Note must check here for stores of young objects into old ones."

	(oop < youngStart) ifTrue: [
		self possibleRootStoreInto: oop value: valuePointer.
	].

	^ self longAt: (self cCoerce: oop to: 'char *') + BaseHeaderSize + (fieldIndex << 2)
		put: valuePointer