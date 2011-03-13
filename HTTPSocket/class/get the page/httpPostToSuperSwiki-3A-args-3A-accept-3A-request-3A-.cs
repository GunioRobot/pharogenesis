httpPostToSuperSwiki: url args: argsDict accept: mimeType request: requestString

	| serverName serverAddr s header length bare page list firstData aStream port specifiedServer type mimeBorder contentsData |

	Socket initializeNetwork.

	"parse url"
	bare := (url asLowercase beginsWith: 'http://') 
		ifTrue: [url copyFrom: 8 to: url size]
		ifFalse: [url].
	serverName := bare copyUpTo: $/.
	specifiedServer := serverName.
	(serverName includes: $:) ifFalse: [ port := self defaultPort ] ifTrue: [
		port := (serverName copyFrom: (serverName indexOf: $:) + 1 to: serverName size) asNumber.
		serverName := serverName copyUpTo: $:.
	].

	page := bare copyFrom: (bare indexOf: $/ ifAbsent: [^'error']) to: bare size.
	page size = 0 ifTrue: [page := '/'].
		(self shouldUseProxy: serverName) ifTrue: [ 
		page := 'http://', serverName, ':', port printString, page.		"put back together"
		serverName := self httpProxyServer.
		port := self httpProxyPort].

	mimeBorder := '---------SuperSwiki',Time millisecondClockValue printString,'-----'.
	contentsData := String streamContents: [ :strm |
		strm nextPutAll: mimeBorder, String crlf.
		argsDict associationsDo: [:assoc |
			assoc value do: [ :value |
				strm
					nextPutAll: 'Content-disposition: form-data; name="', assoc key, '"';
					nextPutAll: String crlf;
					nextPutAll: String crlf;
					nextPutAll: value;
					nextPutAll: String crlf;
					nextPutAll: String crlf;
					nextPutAll: mimeBorder;
					nextPutAll: String crlf.
			]
		].
	].

  	"make the request"	
	serverAddr := NetNameResolver addressForName: serverName timeout: 20.
	serverAddr ifNil: [
		^ 'Could not resolve the server named: ', serverName].

	s := HTTPSocket new.
	s connectTo: serverAddr port: port.
	s waitForConnectionFor: self standardTimeout.
	s sendCommand: 'POST ', page, ' HTTP/1.1', String crlf, 
		(mimeType ifNotNil: ['ACCEPT: ', mimeType, String crlf] ifNil: ['']),
		'ACCEPT: text/html', String crlf,	"Always accept plain text"
		HTTPProxyCredentials,
		HTTPBlabEmail,	"may be empty"
		requestString,	"extra user request. Authorization"
		self userAgentString, String crlf,
		'Content-type: multipart/form-data; boundary=', mimeBorder, String crlf,
		'Content-length: ', contentsData size printString, String crlf,
		'Host: ', specifiedServer, String crlf.  "blank line automatically added"

	s sendCommand: contentsData.

	list := s getResponseUpTo: String crlf, String crlf.	"list = header, CrLf, CrLf, beginningOfData"
	header := list at: 1.
	firstData := list at: 3.

	header isEmpty ifTrue: [
		s destroy.
		^'no response'
	].
	s header: header.
	length := s getHeader: 'content-length'.
	length ifNotNil: [ length := length asNumber ].
	type := s getHeader: 'content-type'.
	aStream := s getRestOfBuffer: firstData totalLength: length.
	s responseCode = '401' ifTrue: [^ header, aStream contents].
	s destroy.	"Always OK to destroy!"

	^ MIMEDocument contentType: type  content: aStream contents url: url