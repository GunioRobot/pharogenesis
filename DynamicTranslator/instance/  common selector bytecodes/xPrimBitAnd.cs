xPrimBitAnd

	"	-4	PushConstant	_	MacroConstBitAnd
		-0	<SmallInteger>"
	self rewrite: -4 fromPushIntegerTo: MacroConstBitAnd.

	self emitOp: SpecialPrimitive.
	self emitInteger: (PrimitiveBitAnd << 16) + (14 << 8) + 1