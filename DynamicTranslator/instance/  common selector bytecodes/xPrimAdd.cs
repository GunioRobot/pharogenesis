xPrimAdd

	"	-4	PushConstant	_	MacroConstAdd
		-0	<SmallInteger>"
	self rewrite: -4 fromPushIntegerTo: MacroConstAdd.

	"	-12	PushTempTemp	_	MacroTempTempAdd
		-8	<SmallInteger>
		-4	[PushTemp]
		-0	[<SmallInteger>]"
	(self rewrite: -12 from: MacroPushTempTemp to: MacroTempTempAdd) ifFalse:

	"	-12	PushTempTemp	_	MacroTempTempAdd
		-8	<SmallInteger>
		-4	[PushTemp]
		-0	[<SmallInteger>]"
	[self rewrite: -12 from: MacroPushTempConst to: MacroTempConstAdd].

	self emitOp: PrimAdd.
	self emitSkip: 1.