httpPostToSuperSwiki: url args: argsDict accept: mimeType request: requestString

	| serverName serverAddr s header length bare page list firstData aStream port specifiedServer type mimeBorder contentsData |

	Socket initializeNetwork.

	"parse url"
	bare _ (url asLowercase beginsWith: 'http://') 
		ifTrue: [url copyFrom: 8 to: url size]
		ifFalse: [url].
	serverName _ bare copyUpTo: $/.
	specifiedServer _ serverName.
	(serverName includes: $:) ifFalse: [ port _ self defaultPort ] ifTrue: [
		port _ (serverName copyFrom: (serverName indexOf: $:) + 1 to: serverName size) asNumber.
		serverName _ serverName copyUpTo: $:.
	].

	page _ bare copyFrom: (bare indexOf: $/ ifAbsent: [^'error']) to: bare size.
	page size = 0 ifTrue: [page _ '/'].
		(self shouldUseProxy: serverName) ifTrue: [ 
		page _ 'http://', serverName, ':', port printString, page.		"put back together"
		serverName _ HTTPProxyServer.
		port _ HTTPProxyPort].

	mimeBorder _ '---------SuperSwiki',Time millisecondClockValue printString,'-----'.
	contentsData _ String streamContents: [ :strm |
		strm nextPutAll: mimeBorder, CrLf.
		argsDict associationsDo: [:assoc |
			assoc value do: [ :value |
				strm
					nextPutAll: 'Content-disposition: form-data; name="', assoc key, '"';
					nextPutAll: CrLf;
					nextPutAll: CrLf;
					nextPutAll: value;
					nextPutAll: CrLf;
					nextPutAll: CrLf;
					nextPutAll: mimeBorder;
					nextPutAll: CrLf.
			]
		].
	].

  	"make the request"	
	serverAddr _ NetNameResolver addressForName: serverName timeout: 20.
	serverAddr ifNil: [
		^ 'Could not resolve the server named: ', serverName].

	s _ HTTPSocket new.
	s connectTo: serverAddr port: port.
	s waitForConnectionUntil: self standardDeadline.
	s sendCommand: 'POST ', page, ' HTTP/1.1', CrLf, 
		(mimeType ifNotNil: ['ACCEPT: ', mimeType, CrLf] ifNil: ['']),
		'ACCEPT: text/html', CrLf,	"Always accept plain text"
		HTTPProxyCredentials,
		HTTPBlabEmail,	"may be empty"
		requestString,	"extra user request. Authorization"
		self userAgentString, CrLf,
		'Content-type: multipart/form-data; boundary=', mimeBorder, CrLf,
		'Content-length: ', contentsData size printString, CrLf,
		'Host: ', specifiedServer, CrLf.  "blank line automatically added"

	s sendCommand: contentsData.

	list _ s getResponseUpTo: CrLf, CrLf.	"list = header, CrLf, CrLf, beginningOfData"
	header _ list at: 1.
	firstData _ list at: 3.

	header isEmpty ifTrue: [
		s destroy.
		^'no response'
	].
	s header: header.
	length _ s getHeader: 'content-length'.
	length ifNotNil: [ length _ length asNumber ].
	type _ s getHeader: 'content-type'.
	aStream _ s getRestOfBuffer: firstData totalLength: length.
	s responseCode = '401' ifTrue: [^ header, aStream contents].
	s destroy.	"Always OK to destroy!"

	^ MIMEDocument contentType: type  content: aStream contents url: url