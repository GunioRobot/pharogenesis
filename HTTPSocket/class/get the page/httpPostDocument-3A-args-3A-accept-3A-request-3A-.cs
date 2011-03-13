httpPostDocument: url  args: argsDict accept: mimeType request: requestString
	"like httpGET, except it does a POST instead of a GET.  POST allows data to be uploaded"

	| s header length page list firstData aStream argsStream first type newUrl httpUrl |
	Socket initializeNetwork.

	httpUrl _ Url absoluteFromText: url.
	page _ httpUrl toText.
	"add arguments"
	argsDict ifNotNil: [page _ page, (self argString: argsDict) ].

	"encode the arguments dictionary"
	argsStream _ WriteStream on: String new.
	first _ true.
	argsDict associationsDo: [ :assoc |
		assoc value do: [ :value |
			first ifTrue: [ first _ false ] ifFalse: [ argsStream nextPut: $& ].
			argsStream nextPutAll: assoc key encodeForHTTP.
			argsStream nextPut: $=.
			argsStream nextPutAll: value encodeForHTTP.
	] ].

	s _ HTTPSocket new. 
	s _ self initHTTPSocket: httpUrl wait: (self deadlineSecs: 30) ifError: [:errorString | ^errorString].
	Transcript cr; show: url; cr.
	s sendCommand: 'POST ', page, ' HTTP/1.0', CrLf, 
		(mimeType ifNotNil: ['ACCEPT: ', mimeType, CrLf] ifNil: ['']),
		'ACCEPT: text/html', CrLf,	"Always accept plain text"
		HTTPBlabEmail,	"may be empty"
		requestString,	"extra user request. Authorization"
		'User-Agent: Squeak 1.31', CrLf,
		'Content-type: application/x-www-form-urlencoded', CrLf,
		'Content-length: ', argsStream contents size printString, CrLf,
		'Host: ', httpUrl authority, CrLf.  "blank line automatically added"

	s sendCommand: argsStream contents.

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
			Transcript show: 'Response: ' , s responseCode.
			Transcript show: ' redirecting to: ', newUrl; cr.
			s destroy.
			"^self httpPostDocument: newUrl  args: argsDict  accept: mimeType"
			^self httpGetDocument: newUrl accept: mimeType ] ].

	aStream _ s getRestOfBuffer: firstData totalLength: length.
	s responseCode = '401' ifTrue: [^ header, aStream contents].
	s destroy.	"Always OK to destroy!"

	^ MIMEDocument contentType: type  content: aStream contents url: url