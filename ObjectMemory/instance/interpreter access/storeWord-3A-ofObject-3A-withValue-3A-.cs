storeWord: fieldIndex ofObject: oop withValue: valueWord

	^ self longAt: (self cCoerce: oop to: 'char *') + BaseHeaderSize + (fieldIndex << 2) put: valueWord