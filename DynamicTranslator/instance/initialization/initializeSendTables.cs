initializeSendTables
	"Note: assumes that the opcodeTable has already been initialised."

	self inline: true.

	shortSendTable at: ImmediateSendType	put: (opcodeTable at: LinkedImmediateSend).
	shortSendTable at: CompactSendType		put: (opcodeTable at: LinkedCompactSend).
	shortSendTable at: NormalSendType		put: (opcodeTable at: LinkedNormalSend).

	extendedSendTable at: ImmediateSendType		put: (opcodeTable at: ExtendedImmediateSend).
	extendedSendTable at: CompactSendType		put: (opcodeTable at: ExtendedCompactSend).
	extendedSendTable at: NormalSendType		put: (opcodeTable at: ExtendedNormalSend).

	doubleExtendedSendTable at: ImmediateSendType	put: (opcodeTable at: DoubleExtendedImmediateSend).
	doubleExtendedSendTable at: CompactSendType	put: (opcodeTable at: DoubleExtendedCompactSend).
	doubleExtendedSendTable at: NormalSendType		put: (opcodeTable at: DoubleExtendedNormalSend).

