ffiFail: reason
	self inline: true.
	self ffiSetLastError: reason.
	^interpreterProxy primitiveFail