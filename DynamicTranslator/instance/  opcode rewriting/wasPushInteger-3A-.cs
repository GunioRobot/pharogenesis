wasPushInteger: offset

	^(self wasPushConstant: offset)
		and: [self isIntegerObject: (self longAt: opPointer + offset + 4)]