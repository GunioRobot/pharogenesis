sendLiteralSelectorBytecode
	"Can use any of the first 16 literals for the selector and pass up to 2 arguments."

	messageSelector _ self literal: (currentBytecode bitAnd: 16rF).
	argumentCount _ ((currentBytecode >> 4) bitAnd: 3) - 1.
	self normalSend.
