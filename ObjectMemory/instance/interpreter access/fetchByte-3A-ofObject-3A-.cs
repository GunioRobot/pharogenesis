fetchByte: byteIndex ofObject: oop

	^ self byteAt: (self cCoerce: oop to: 'char *') + BaseHeaderSize + byteIndex