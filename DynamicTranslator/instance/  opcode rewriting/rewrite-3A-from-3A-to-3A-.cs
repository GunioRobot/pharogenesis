rewrite: offset from: oldIndex to: newIndex

	(self longAt: opPointer + offset) = (opcodeTable at: oldIndex)
		ifTrue:
			[self longAt: opPointer + offset put: (opcodeTable at: newIndex).
			 ^true]
		ifFalse:
			[^false]