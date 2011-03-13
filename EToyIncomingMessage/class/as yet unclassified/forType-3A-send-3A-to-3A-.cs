forType: aMessageType send: aSymbol to: anObject

	self messageHandlers at: aMessageType put: {aSymbol. anObject}