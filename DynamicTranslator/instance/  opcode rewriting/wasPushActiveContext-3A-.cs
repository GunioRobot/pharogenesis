wasPushActiveContext: offset

	^(self longAt: (opPointer + offset)) = (opcodeTable at: PushActiveContext)