xPrimDiv

	self emitOp: SpecialPrimitive.
	self emitInteger: (PrimitiveDiv << 16) + (13 << 8) + 1