sendSpecialSelector: selectorIndex nArgs: numArgs
	self inline: true.
	messageSelector _ self specialSelector: selectorIndex.
	argumentCount _ numArgs.
	self normalSend.
