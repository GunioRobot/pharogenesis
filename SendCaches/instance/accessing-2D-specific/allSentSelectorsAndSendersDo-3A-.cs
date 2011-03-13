allSentSelectorsAndSendersDo: aBlock
	self selfSentSelectorsAndSendersDo: aBlock.
	self superSentSelectorsAndSendersDo: aBlock.
	self classSentSelectorsAndSendersDo: aBlock.