opSendSpecialSelector

	| descriptor |
	(self initOp: SendSpecialSelector) ifFalse: [
	self beginOp: SendSpecialSelector.
		descriptor _ self fetchInteger.
		self sendSpecialSelector: (descriptor >> 8) nArgs: (descriptor bitAnd: 255).

	self endOp: SendSpecialSelector
	].