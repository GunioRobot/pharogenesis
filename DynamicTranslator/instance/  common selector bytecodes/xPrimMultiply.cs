xPrimMultiply

	"	-4	PushConstant	_	MacroConstMul
		-0	<SmallInteger>"
	self rewrite: -4 fromPushIntegerTo: MacroConstMul.

	"	-12	PushTempTemp	_	MacroTempTempMul
		-8	<SmallInteger>
		-4	[PushTemp]
		-0	[<SmallInteger>]"
	self rewrite: -12 from: MacroPushTempTemp to: MacroTempTempMul.

	self emitOp: PrimMultiply.
	self emitSkip: 1.