xPrimBitOr

	"	-4	PushConstant	_	MacroConstBitOr
		-0	<SmallInteger>"
	self rewrite: -4 fromPushIntegerTo: MacroConstBitOr.

	self emitOp: SpecialPrimitive.
	self emitInteger: (PrimitiveBitOr << 16) + (15 << 8) + 1