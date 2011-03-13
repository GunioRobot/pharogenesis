httpPut: contents to: url user: user passwd: passwd
	"Upload the contents of the stream to a file on the server"

	| bare serverName specifiedServer port page serverAddr authorization s list header firstData length aStream command |
	Socket initializeNetwork.
 
	"parse url"
	bare := (url asLowercase beginsWith: 'http://') 
		ifTrue: [url copyFrom: 8 to: url size]
		ifFalse: [url].
	serverName := bare copyUpTo: $/.
	specifiedServer := serverName.
	(serverName includes: $:) ifFalse: [ port := self defaultPort ] ifTrue: [
		port := (serverName copyFrom: (serverName indexOf: $:) + 1 
				to: serverName size) asNumber.
		serverName := serverName copyUpTo: $:.
	].

	page := bare copyFrom: (bare indexOf: $/) to: bare size.
	page size = 0 ifTrue: [page := '/'].
	(self shouldUseProxy: serverName) ifTrue: [ 
		page := 'http://', serverName, ':', port printString, page.		"put back together"
		serverName := self httpProxyServer.
		port := self httpProxyPort].

  	"make the request"	
	serverAddr := NetNameResolver addressForName: serverName timeout: 20.
	serverAddr ifNil: [
		^ 'Could not resolve the server named: ', serverName].

	authorization := (Base64MimeConverter mimeEncode: (user , ':' , passwd) readStream) contents.
	s := HTTPSocket new.
	s connectTo: serverAddr port: port.
	s waitForConnectionUntil: self standardDeadline.
	Transcript cr; show: url; cr.
	command := 
		'PUT ', page, ' HTTP/1.0', CrLf, 
		self userAgentString, CrLf,
		'Host: ', specifiedServer, CrLf, 
		'ACCEPT: */*', CrLf,
		HTTPProxyCredentials,
		'Authorization: Basic ' , authorization , CrLf , 
		'Content-length: ', contents size printString, CrLf , CrLf , 
		contents.
	s sendCommand: command.
	"get the header of the reply"
	list := s getResponseUpTo: CrLf, CrLf ignoring: (String with: CR).	"list = header, CrLf, CrLf, beginningOfData"
	header := list at: 1.
	"Transcript show: page; cr; show: argsStream contents; cr; show: header; cr."
	firstData := list at: 3.

	"dig out some headers"
	s header: header.
	length := s getHeader: 'content-length'.
	length ifNotNil: [ length := length asNumber ].

	aStream := s getRestOfBuffer: firstData totalLength: length.
	s destroy.	"Always OK to destroy!"

	^ header, aStream contents