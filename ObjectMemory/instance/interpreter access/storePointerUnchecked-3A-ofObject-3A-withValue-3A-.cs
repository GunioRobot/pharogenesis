storePointerUnchecked: fieldIndex ofObject: oop withValue: valuePointer
	"Like storePointer:ofObject:withValue:, but the caller guarantees that the object being stored into is a young object or is already marked as a root."

	^ self longAt: (self cCoerce: oop to: 'char *') + BaseHeaderSize + (fieldIndex << 2)
			put: valuePointer
