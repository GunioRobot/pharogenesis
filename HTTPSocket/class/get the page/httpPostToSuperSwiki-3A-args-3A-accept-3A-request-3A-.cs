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
	serverAddr := NetNameResolver addressForName: serverName timeout: 20.
	serverAddr ifNil: [
		^ 'Could not resolve the server named: ', serverName].

	s := HTTPSocket new.
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

	list := s getResponseUpTo: CrLf, CrLf.	"list = header, CrLf, CrLf, beginningOfData"
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