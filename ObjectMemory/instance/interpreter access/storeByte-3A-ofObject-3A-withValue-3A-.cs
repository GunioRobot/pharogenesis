storeByte: byteIndex ofObject: oop withValue: valueByte

	^ self byteAt: (self cCoerce: oop to: 'char *') + BaseHeaderSize + byteIndex
		put: valueByte