internalAboutToReturn: resultObj through: aContext
	self inline: true.
	self internalPush: activeContext.
	self internalPush: resultObj.
	self internalPush: aContext.
	messageSelector _ self splObj: SelectorAboutToReturn.
	argumentCount _ 2.
	^self normalSend