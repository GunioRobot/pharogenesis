retrieveContentsArgs: args accept: mimeType
	| contents request |
	request _ realm ifNotNil: [Passwords at: realm ifAbsent: ['']] ifNil: [''].
	request = '' ifFalse: [request _ 'Authorization: Basic ' , request , String crlf].
		"Why doesn't Netscape send the name of the realm instead of Basic?"

	contents _ (HTTPSocket
		httpGetDocument: self withoutFragment asString
		args: args
		accept: mimeType
		request: request).

	self checkAuthorization: contents retry: [^ self retrieveContentsArgs: args].

	^ self normalizeContents: contents