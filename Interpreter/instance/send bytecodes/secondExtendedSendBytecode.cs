secondExtendedSendBytecode
	"This replaces the Blue Book double-extended super-send [134],
	which is subsumed by the new double-extended do-anything [132].
	It offers a 2-byte send of 0-3 args for up to 63 literals, for which 
	the Blue Book opcode set requires a 3-byte instruction."

	| descriptor |
	descriptor _ self fetchByte.
	messageSelector _ self literal: (descriptor bitAnd: 16r3F).
	argumentCount _ descriptor >> 6.
	self normalSend.
