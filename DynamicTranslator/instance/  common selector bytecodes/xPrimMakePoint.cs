xPrimMakePoint

	self emitOp: SpecialPrimitive.
	self emitInteger: (PrimitiveMakePoint << 16) + (11 << 8) + 1