xxPushConstant
	"Called from all pushConstant bytecodes before they emit a PushConstant opcode."

	"	-4	pushTempVar		_	macroPushTempConst
		-0	<SmallInteger>"

	self rewrite: -4 from: PushTemporaryVariable to: MacroPushTempConst.