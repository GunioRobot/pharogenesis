rewrite: offset fromPushIntegerTo: newIndex

	(self wasPushInteger: offset)
		ifTrue:
			[self longAt: opPointer + offset put: (opcodeTable at: newIndex).
			 ^true]
		ifFalse:
			[^false]