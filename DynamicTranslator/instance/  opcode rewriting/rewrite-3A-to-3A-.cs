rewrite: offset to: opIndex

	self longAt: (opPointer + offset) put: (opcodeTable at: opIndex)