xPrimSubtract

	"	-4	PushConstant	_	MacroConstSub
		-0	<SmallInteger>"
	self rewrite: -4 fromPushIntegerTo: MacroConstSub.

	"	-12	PushTempTemp	_	MacroTempTempSub
		-8	<SmallInteger>
		-4	[ PushTemp
		-0	  <SmallInteger> ]"
	self rewrite: -12 from: MacroPushTempTemp to: MacroTempTempSub.

	self emitOp: PrimSubtract.
	self emitSkip: 1.