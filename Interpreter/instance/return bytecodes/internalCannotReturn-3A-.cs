internalCannotReturn: resultObj
	self inline: true.
	self internalPush: activeContext.
	self internalPush: resultObj.
	messageSelector _ self splObj: SelectorCannotReturn.
	argumentCount _ 1.
	^ self normalSend