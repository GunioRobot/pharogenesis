httpPostMultipart: url args: argsDict accept: mimeType request: requestString
	" do multipart/form-data encoding rather than x-www-urlencoded "
	" by Bolot Kerimbaev, 1998 "
	" this version is a memory hog: puts the whole file in memory "
	"bolot 12/14/2000 18:28 -- minor fixes to make it comply with RFC 1867"

	| serverName serverAddr s header length bare page list firstData aStream port argsStream specifiedServer type newUrl mimeBorder fieldValue |
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

	page := bare copyFrom: (bare indexOf: $/) to: bare size.
	page size = 0 ifTrue: [page := '/'].
	(self shouldUseProxy: serverName) ifTrue: [ 
		page := 'http://', serverName, ':', port printString, page.		"put back together"
		serverName := self httpProxyServer.
		port := self httpProxyPort].

	mimeBorder := '----squeak-georgia-tech-', Time millisecondClockValue printString, '-csl-cool-stuff-----'.
	"encode the arguments dictionary"
	argsStream := String new writeStream.
	argsDict associationsDo: [:assoc |
		assoc value do: [ :value |
		"print the boundary"
		argsStream nextPutAll: '--', mimeBorder, String crlf.
		" check if it's a non-text field "
		argsStream nextPutAll: 'Content-disposition: multipart/form-data; name="', assoc key, '"'.
		(value isKindOf: MIMEDocument)
			ifFalse: [fieldValue := value]
			ifTrue: [argsStream nextPutAll: ' filename="', value url pathForFile, '"', String crlf, 'Content-Type: ', value contentType.
				fieldValue := (value content
					ifNil: [(FileStream fileNamed: value url pathForFile) contentsOfEntireFile]
					ifNotNil: [value content]) asString].
" Transcript show: 'field=', key, '; value=', fieldValue; cr. "
		argsStream nextPutAll: String crlf, String crlf, fieldValue, String crlf.
	]].
	argsStream nextPutAll: '--', mimeBorder, '--'.

  	"make the request"	
	serverAddr := NetNameResolver addressForName: serverName timeout: 20.
	serverAddr ifNil: [
		^ 'Could not resolve the server named: ', serverName].


	s := HTTPSocket new.
	s connectTo: serverAddr port: port.
	s waitForConnectionFor: self standardTimeout.
	Transcript cr; show: serverName, ':', port asString; cr.
	s sendCommand: 'POST ', page, ' HTTP/1.1', String crlf, 
		(mimeType ifNotNil: ['ACCEPT: ', mimeType, String crlf] ifNil: ['']),
		'ACCEPT: text/html', String crlf,	"Always accept plain text"
		HTTPProxyCredentials,
		HTTPBlabEmail,	"may be empty"
		requestString,	"extra user request. Authorization"
		self userAgentString, String crlf,
		'Content-type: multipart/form-data; boundary=', mimeBorder, String crlf,
		'Content-length: ', argsStream contents size printString, String crlf,
		'Host: ', specifiedServer, String crlf.  "blank line automatically added"

	s sendCommand: argsStream contents.

	"get the header of the reply"
	list := s getResponseUpTo: String crlf, String crlf.	"list = header, CrLf, CrLf, beginningOfData"
	header := list at: 1.
	"Transcript show: page; cr; show: argsStream contents; cr; show: header; cr."
	firstData := list at: 3.

	"dig out some headers"
	s header: header.
	length := s getHeader: 'content-length'.
	length ifNotNil: [ length := length asNumber ].
	type := s getHeader: 'content-type'.
	s responseCode first = $3 ifTrue: [
		"redirected - don't re-post automatically"
		"for now, just do a GET, without discriminating between 301/302 codes"
		newUrl := s getHeader: 'location'.
		newUrl ifNotNil: [
			(newUrl beginsWith: 'http://')
				ifFalse: [
					(newUrl beginsWith: '/')
						ifTrue: [newUrl := (bare copyUpTo: $/), newUrl]
						ifFalse: [newUrl := url, newUrl. self flag: #todo
							"should do a relative URL"]
				].
			Transcript show: 'redirecting to: ', newUrl; cr.
			s destroy.
			^self httpGetDocument: newUrl
			"for some codes, may do:
			^self httpPostMultipart: newUrl args: argsDict  accept: mimeType request: requestString"] ].

	aStream := s getRestOfBuffer: firstData totalLength: length.
	s responseCode = '401' ifTrue: [^ header, aStream contents].
	s destroy.	"Always OK to destroy!"

	^ MIMEDocument contentType: type  content: aStream contents url: url