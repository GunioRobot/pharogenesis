fetchPointer: fieldIndex ofObject: oop

	^ self longAt: (self cCoerce: oop to: 'char *') + BaseHeaderSize + (fieldIndex << 2)