wasPushConstant: offset

	^(self longAt: (opPointer + offset)) = (opcodeTable at: PushConstant)