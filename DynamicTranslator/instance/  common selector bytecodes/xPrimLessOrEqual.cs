xPrimLessOrEqual

	"	-12	MacroPushTempConst	_	MacroTempConstLessEq
		-8	<SmallInteger>
		-4	[ PushConst
		-0	[ <SmallInteger> ]"
	self rewrite: -12 from: MacroPushTempConst to: MacroTempConstLessEq.

	self emitOp: PrimLessOrEqual.
	self emitSkip: 1.