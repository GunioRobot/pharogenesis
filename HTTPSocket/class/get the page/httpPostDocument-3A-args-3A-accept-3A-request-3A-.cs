httpPostDocument: url  args: argsDict accept: mimeType request: requestString
	"like httpGET, except it does a POST instead of a GET.  POST allows data to be uploaded"

	| s header length page list firstData aStream type newUrl httpUrl argString |
	Socket initializeNetwork.
	httpUrl _ Url absoluteFromText: url.
	page _ httpUrl fullPath.
	"add arguments"
	argString _ argsDict
		ifNotNil: [argString _ self argString: argsDict]
		ifNil: [''].
	page _ page, argString.

	s _ HTTPSocket new. 
	s _ self initHTTPSocket: httpUrl wait: (self deadlineSecs: 30) ifError: [:errorString | ^errorString].
	s sendCommand: 'POST ', page, ' HTTP/1.0', CrLf, 
		(mimeType ifNotNil: ['ACCEPT: ', mimeType, CrLf] ifNil: ['']),
		'ACCEPT: text/html', CrLf,	"Always accept plain text"
		HTTPProxyCredentials,
		HTTPBlabEmail,	"may be empty"
		requestString,	"extra user request. Authorization"
		self userAgentString, CrLf,
		'Content-type: application/x-www-form-urlencoded', CrLf,
		'Content-length: ', argString size printString, CrLf,
		'Host: ', httpUrl authority, CrLf.  "blank line automatically added"

	argString first = $? ifTrue: [ argString _ argString copyFrom: 2 to: argString size].
	"umur - IE sends argString without a $? and swiki expects so"
	s sendCommand: argString.

	"get the header of the reply"
	list _ s getResponseUpTo: CrLf, CrLf ignoring: (String with: CR).	"list = header, CrLf, CrLf, beginningOfData"
	header _ list at: 1.
	"Transcript show: page; cr; show: argsStream contents; cr; show: header; cr."
	firstData _ list at: 3.

	"dig out some headers"
	s header: header.
	length _ s getHeader: 'content-length'.
	length ifNotNil: [ length _ length asNumber ].
	type _ s getHeader: 'content-type'.
	s responseCode first = $3 ifTrue: [
		newUrl _ s getHeader: 'location'.
		newUrl ifNotNil: [
			"umur 6/25/2003 12:58 - If newUrl is relative then we need to make it absolute."
			newUrl _ (httpUrl newFromRelativeText: newUrl) asString.
			self flag: #refactor. "get, post, postmultipart are almost doing the same stuff"
			s destroy.
			"^self httpPostDocument: newUrl  args: argsDict  accept: mimeType"
			^self httpGetDocument: newUrl accept: mimeType ] ].

	aStream _ s getRestOfBuffer: firstData totalLength: length.
	s responseCode = '401' ifTrue: [^ header, aStream contents].
	s destroy.	"Always OK to destroy!"

	^ MIMEDocument contentType: type  content: aStream contents url: url