postMultipartFormArgs: args
	| contents request |
	request _ realm ifNotNil: [Passwords at: realm ifAbsent: ['']]
		ifNil: [''].
	request = '' ifFalse: [request _ 'Authorization: Basic ', request, PWS crlf].
		"Why doesn't Netscape send the name of the realm instead of Basic?"
	contents _ (HTTPSocket httpPostMultipart: self toText args: args
				accept: 'application/octet-stream' request: request).

	self checkAuthorization: contents retry: [^ self postMultipartFormArgs: args].

	^self normalizeContents: contents